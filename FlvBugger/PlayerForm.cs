using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DirectShowLib;
using System.Runtime.InteropServices;
using System.Threading;

namespace Tsanie.FlvBugger {
    internal enum PlayState {
        Stopped,
        Paused,
        Running,
        Init
    };

    public partial class PlayerForm : Form {
        #region - DirectShow -
        private const int WMGraphNotify = 0x0400 + 13;
        private const int VolumeFull = 0;
        private const int VolumeSilence = -10000;

        private IGraphBuilder graphBuilder = null;
        private IMediaControl mediaControl = null;
        private IMediaEventEx mediaEventEx = null;
        private IVideoWindow videoWindow = null;
        private IBasicAudio basicAudio = null;
        private IBasicVideo basicVideo = null;
        private IMediaSeeking mediaSeeking = null;
        private IMediaPosition mediaPosition = null;
        private IVideoFrameStep frameStep = null;
        #endregion

        private int currentVolume = VolumeFull;
        private PlayState currentState = PlayState.Stopped;
        private double currentPlaybackRate = 1.0;

        private double duration = 0;
        private double current = 0;
        private bool isDragging = false;

        private static PlayerForm _player = null;
        private FlvMain _flv = null;

        private PlayerForm() {
            InitializeComponent();
            this.trackPos.MouseWheel += new MouseEventHandler(trackPos_MouseWheel);
            panelControl.Enabled = false;
        }
        public static void ShowPlayer(FlvMain owner) {
            if (_player == null) {
                _player = new PlayerForm();
                _player._flv = owner;
                _player.Show(owner);
            }
            _player.Focus();
        }

        private void PlayerForm_FormClosed(object sender, FormClosedEventArgs e) {
            CloseClip();
            _player = null;
        }
        private void PlayerForm_Resize(object sender, EventArgs e) {
            ResizeVideoWindow(panelPlayer.Width, panelPlayer.Height);
        }
        private void PlayerForm_Shown(object sender, EventArgs e) {
            new Thread(() => {
                OpenClip();
                mediaPosition.get_Duration(out duration);
                current = 0.0;
                this.BeginInvoke(new MethodInvoker(() => {
                    this.trackPos.Maximum = (int)(duration * 10);
                    timer_Tick(null, null);
                    panelControl.Enabled = true;
                }));
            }).Start();
        }

        #region - 播放器 -
        /* 播放 */
        private void OpenClip() {
            //try {
            this.currentState = PlayState.Stopped;
            this.currentVolume = VolumeFull;
            PlayMovieInWindow(_flv._filename);
            //} catch {
            //    CloseClip();
            //}
        }
        private void CloseClip() {
            StopClip();
            this.currentState = PlayState.Stopped;
            CloseInterfaces();
        }

        private void PlayMovieInWindow(string filename) {
            int hr = 0;
            this.graphBuilder = (IGraphBuilder)new FilterGraph();
            hr = this.graphBuilder.RenderFile(filename, null);
            DsError.ThrowExceptionForHR(hr);
            // DirectShow 接口
            this.mediaControl = (IMediaControl)this.graphBuilder;
            this.mediaEventEx = (IMediaEventEx)this.graphBuilder;
            this.mediaSeeking = (IMediaSeeking)this.graphBuilder;
            this.mediaPosition = (IMediaPosition)this.graphBuilder;
            // 视频接口
            this.videoWindow = this.graphBuilder as IVideoWindow;
            this.basicVideo = this.graphBuilder as IBasicVideo;
            this.basicAudio = this.graphBuilder as IBasicAudio;
            this.Invoke(new MethodInvoker(() => {
                // 回调事件
                hr = this.mediaEventEx.SetNotifyWindow(this.Handle, WMGraphNotify, IntPtr.Zero);
                DsError.ThrowExceptionForHR(hr);
                // 设置视频窗口
                hr = this.videoWindow.put_Owner(panelPlayer.Handle);
                DsError.ThrowExceptionForHR(hr);
            }));
            hr = this.videoWindow.put_WindowStyle(
                WindowStyle.Child |
                WindowStyle.ClipSiblings |
                WindowStyle.ClipChildren);
            DsError.ThrowExceptionForHR(hr);
            hr = MultiVideoWindow(1, 1);
            DsError.ThrowExceptionForHR(hr);
            this.currentPlaybackRate = 1.0;
            StopClip();
        }
        private int ResizeVideoWindow(int width, int height) {
            int hr = 0;
            int lHeight = height, lWidth = width;
            if (this.basicVideo == null)
                return hr;
            this.Invoke(new MethodInvoker(() => {
                hr = this.videoWindow.SetWindowPosition(0, 0, lWidth, lHeight);
            }));
            return hr;
        }
        private int MultiVideoWindow(int multi, int divide) {
            int hr = 0;
            int lHeight, lWidth;
            if (this.basicVideo == null)
                return hr;
            hr = this.basicVideo.GetVideoSize(out lWidth, out lHeight);
            if (hr == DsResults.E_NoInterface)
                return 0;
            lWidth = lWidth * multi / divide;
            lHeight = lHeight * multi / divide;
            this.Invoke(new MethodInvoker(() => {
                this.ClientSize = new Size(lWidth, lHeight + panelControl.Height);
            }));
            return ResizeVideoWindow(lWidth, lHeight);
        }
        private void CloseInterfaces() {
            int hr = 0;
            try {
                lock (this) {
                    // 清除视频窗口
                    hr = this.videoWindow.put_Visible(OABool.False);
                    DsError.ThrowExceptionForHR(hr);
                    hr = this.videoWindow.put_Owner(IntPtr.Zero);
                    DsError.ThrowExceptionForHR(hr);
                    if (this.mediaEventEx != null) {
                        hr = this.mediaEventEx.SetNotifyWindow(IntPtr.Zero, 0, IntPtr.Zero);
                        DsError.ThrowExceptionForHR(hr);
                    }
                    // 释放DirectShow接口
                    if (this.mediaEventEx != null)
                        this.mediaEventEx = null;
                    if (this.mediaSeeking != null)
                        this.mediaSeeking = null;
                    if (this.mediaPosition != null)
                        this.mediaPosition = null;
                    if (this.mediaControl != null)
                        this.mediaControl = null;
                    if (this.basicAudio != null)
                        this.basicAudio = null;
                    if (this.basicVideo != null)
                        this.basicVideo = null;
                    if (this.videoWindow != null)
                        this.videoWindow = null;
                    if (this.frameStep != null)
                        this.frameStep = null;
                    if (this.graphBuilder != null)
                        Marshal.ReleaseComObject(this.graphBuilder);
                    this.graphBuilder = null;

                    GC.Collect();
                }
            } catch { }
        }

        private void PauseClip() {
            if (this.mediaControl == null)
                return;
            if ((this.currentState == PlayState.Paused) || (this.currentState == PlayState.Stopped)) {
                if (this.mediaControl.Run() >= 0) {
                    this.currentState = PlayState.Running;
                    this.timer.Enabled = true;
                }
            } else {
                if (this.mediaControl.Pause() >= 0) {
                    this.currentState = PlayState.Paused;
                    this.timer.Enabled = false;
                }
            }
        }
        private void StopClip() {
            if (this.mediaControl == null || this.mediaSeeking == null)
                return;
            int hr = 0;
            DsLong pos = new DsLong(0);
            if (this.currentState == PlayState.Paused ||
                this.currentState == PlayState.Running) {
                hr = this.mediaControl.Stop();
                this.currentState = PlayState.Stopped;
                hr = this.mediaSeeking.SetPositions(pos, AMSeekingSeekingFlags.AbsolutePositioning,
                    null, AMSeekingSeekingFlags.NoPositioning);
                // 显示第一帧
                hr = this.mediaControl.Pause();
                this.trackPos.Value = 0;
                this.timer.Enabled = false;
            }
        }
        private void RunClip() {
            if (this.mediaControl == null)
                return;
            if (this.currentState != PlayState.Running)
                if (this.mediaControl.Run() >= 0) {
                    this.currentState = PlayState.Running;
                    this.timer.Enabled = true;
                }
        }

        private int SetVolumn(int volumn) {
            int hr = 0;
            if (this.graphBuilder == null || this.basicAudio == null)
                return hr;
            hr = this.basicAudio.put_Volume(volumn);
            this.currentVolume = volumn;
            return hr;
        }
        private int StepFrames(int nFrames) {
            int hr = 0;
            if (this.frameStep != null) {
                hr = this.frameStep.CanStep(nFrames, null);
                if (hr == 0) {
                    if (this.currentState != PlayState.Paused)
                        PauseClip();
                    hr = this.frameStep.Step(nFrames, null);
                }
            }
            return hr;
        }
        private int SetRate(double dRate) {
            int hr = 0;
            if ((this.mediaPosition != null) && (dRate > 0.0)) {
                hr = this.mediaPosition.put_Rate(dRate);
                if (hr >= 0) {
                    this.currentPlaybackRate = dRate;
                }
            }
            return hr;
        }
        private int SetCurrentPos(double pos) {
            int hr = 0;
            if ((this.mediaPosition != null) && (pos >= 0.0) && (pos <= duration)) {
                hr = this.mediaPosition.put_CurrentPosition(pos);
                if (hr >= 0) {
                    current = pos;
                    timer_Tick(null, null);
                }
            }
            return hr;
        }

        protected override void WndProc(ref Message m) {
            switch (m.Msg) {
                case WMGraphNotify: {
                        HandleGraphEvent();
                        break;
                    }
            }
            if (this.videoWindow != null)
                this.videoWindow.NotifyOwnerMessage(m.HWnd, m.Msg, m.WParam, m.LParam);
            base.WndProc(ref m);
        }
        #endregion

        private void HandleGraphEvent() {
            int hr = 0;
            EventCode evCode;
            IntPtr param1, param2;
            if (this.mediaEventEx == null)
                return;
            while (this.mediaEventEx.GetEvent(out evCode, out param1, out param2, 0) == 0) {
                hr = this.mediaEventEx.FreeEventParams(evCode, param1, param2);
                if (evCode == EventCode.Complete) {
                    StopClip();
                } else if (evCode == EventCode.Paused) {
                    timer_Tick(null, null);
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData) {
            if (keyData == Keys.Space) {
                buttonPause_Click(null, null);
                return true;
            } else if (keyData == (Keys.Alt | Keys.D2)) {
                MultiVideoWindow(1, 1);
                return true;
            } else if (keyData == (Keys.Alt | Keys.D1)) {
                MultiVideoWindow(1, 2);
                return true;
            } else if (keyData == (Keys.Alt | Keys.D3)) {
                MultiVideoWindow(2, 1);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void buttonPause_Click(object sender, EventArgs e) {
            PauseClip();
        }

        private void timer_Tick(object sender, EventArgs e) {
            mediaPosition.get_CurrentPosition(out current);
            if (!isDragging)
                this.trackPos.Value = (int)(current * 10);
            RefreshPos();
        }

        private void RefreshPos() {
            this.labelPos.Text = GetTime(current) + "/" + GetTime(duration)
                + " (" + current.ToString("0.0") + ")";
        }
        private string GetTime(double time) {
            return Math.Round(time / 60) + ":" + (time % 60).ToString("00");
        }

        private void toolSpeed1_Click(object sender, EventArgs e) {
            toolSpeed1.Checked = false;
            toolSpeed2.Checked = false;
            toolSpeed3.Checked = false;
            toolSpeed4.Checked = false;
            toolSpeed5.Checked = false;
            toolSpeed6.Checked = false;

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            item.Checked = true;
            double rate = double.Parse(item.Text.Substring(0, item.Text.Length - 1));
            SetRate(rate);
        }

        private void trackPos_MouseUp(object sender, MouseEventArgs e) {
            isDragging = false;
            if (this.trackPos.Value != (int)(current * 10))
                SetCurrentPos(this.trackPos.Value / 10.0);
        }
        private void trackPos_MouseWheel(object sender, MouseEventArgs e) {
            if (this.trackPos.Value != (int)(current * 10))
                SetCurrentPos(this.trackPos.Value / 10.0);
        }
        private void trackPos_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                isDragging = true;
        }

        private void labelPos_Click(object sender, EventArgs e) {
            string str = current.ToString("0.0");
            Clipboard.SetText(str);
            MessageBox.Show(this, "当前时间（" + str + "）已复制到剪贴板！", "复制",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
