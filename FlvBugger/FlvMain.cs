using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tsanie.FlvBugger.Utils;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace Tsanie.FlvBugger {
    public partial class FlvMain : Form {
        //public const int c_HeaderSize = 371;
        private static string _version = "FlvBugger v"
            + Assembly.GetExecutingAssembly().GetName().Version.Major + "."
            + Assembly.GetExecutingAssembly().GetName().Version.Minor;

        private bool _changed = false;
        private FlvParser _parser = null;
        internal string _filename = null;
        private string _path = null;

        public FlvMain() {
            InitializeComponent();
            toolComboFolder.Items.AddRange(new string[] {
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                "- 视频所在文件夹 -"
            });
            this.Text = _version + " - 拖入flv文件或者mp4、mkv文件";
        }
        private void EnableUI(bool enable, string msg) {
            statusStrip1_Resize(null, null);
            if (enable)
                this.Cursor = Cursors.Default;
            else
                this.Cursor = Cursors.AppStarting;
            toolLabelProgress.Visible = !enable;
            listView1.Enabled = enable;
            toolStrip1.Enabled = enable;
            toolStrip2.Enabled = enable;
            if (msg != null) {
                toolLabelMessage.Text = msg;
            }
        }

        private void FrmMain_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }
        private void FrmMain_DragDrop(object sender, DragEventArgs e) {
            listView1.Items.Clear();
            _parser = null;

            _filename = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            _path = _filename.Substring(0, _filename.LastIndexOf('.'));
            #region - 不是flv、hlv文件的话重新封装 -
            string ext = _filename.Substring(_filename.LastIndexOf('.')).ToLower();
            if (ext != ".flv" && ext != ".hlv" &&
                (MessageBox.Show(this, "不是flv格式，是否尝试封装转换？", "封装",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)) {
                EnableUI(false, "正在重新封装: "
                    + _filename.Substring(_filename.LastIndexOf('\\') + 1));
                Process p = new Process();
                string ph = Environment.CommandLine;
                ph = ph.Substring(0, ph.LastIndexOf('\\') + 1);
                if (ph[0] == '"')
                    ph = ph.Substring(1);
                File.Delete(ph + "~tmp.flv");
                p.StartInfo.FileName = "\"" + ph + "ffmpeg.exe\"";
                p.StartInfo.Arguments = "-vcodec copy -acodec copy -i \""
                    + _filename + "\" -f flv ~tmp.flv";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = !toolShow.Checked;
                p.Start();
                //p.WaitForExit();
                while (!p.HasExited) {
                    Application.DoEvents();
                }
                if (p.ExitCode != 0) {
                    _filename = null;
                    _path = null;
                    MessageBox.Show(this, "转换flv失败 #" + p.ExitCode
                        + "\n" + p.StandardError.ReadToEnd(), "ffmpeg",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EnableUI(true, "转码flv失败...");
                    return;
                }
                _filename = ph + "~tmp.flv";
            }
            #endregion

            #region - 添加帧 -
            new Thread(() => {
                int n = 1;
                //List<ListViewItem> items = new List<ListViewItem>();
                FileStream stream = new FileStream(_filename, FileMode.Open, FileAccess.Read);
                this.Invoke(new MethodInvoker(() => {
                    toolProgress.Maximum = (int)stream.Length;
                    toolProgress.Value = 0;
                    toolProgress.Visible = true;
                    EnableUI(false, "开始分析: " + _filename.Substring(_filename.LastIndexOf('\\') + 1));
                    Application.DoEvents();
                    listView1.BeginUpdate();
                }));
                _parser = new FlvParser(stream, (tag) => {
                    string[] s = new string[]{
                            n++.ToString(),
                            tag.Type.ToString(),
                            ByteUtil.GetTime(tag.TimeStamp),
                            tag.Info1,
                            tag.Info2,
                            "0x" + tag.Offset.ToString("X8"),
                            tag.DataSize.ToString()
                        };
                    FlvParser.TagType type = tag.Type;
                    ListViewItem lvi = new ListViewItem(s);
                    if (type == FlvParser.TagType.Audio) {
                        FlvParser.AudioTag atag = tag as FlvParser.AudioTag;
                    } else if (type == FlvParser.TagType.Video) {
                        lvi.BackColor = Color.FromArgb(245, 239, 209);
                        FlvParser.VideoTag vtag = tag as FlvParser.VideoTag;
                    } else if (type == FlvParser.TagType.Script) {
                        lvi.BackColor = Color.FromArgb(153, 217, 234);
                    }
                    //items.Add(lvi);
                    this.Invoke(new MethodInvoker(() => {
                        listView1.Items.Add(lvi);
                    }));
                    this.BeginInvoke(new MethodInvoker(() => {
                        toolProgress.Value = (int)tag.Offset;
                    }));
                    return true;
                });
                stream.Close();
                stream.Dispose();
                this.Invoke(new MethodInvoker(() => {
                    listView1.EndUpdate();
                    toolProgress.Visible = false;
                    if (!_parser.IsFlv) {
                        MessageBox.Show(this, "文件格式无法识别！", "格式",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        EnableUI(true, "格式无法识别...");
                    } else {
                        RefreshCaption();
                        //EnableUI(false, "分析完毕, 正在添加列...");
                        //Application.DoEvents();
                        //listView1.Items.AddRange(items.ToArray());
                        EnableUI(true, "完毕");
                    }
                    listView1.Focus();
                }));
            }).Start();
            #endregion
        }
        private void FlvMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (_changed) {
                DialogResult dr = MessageBox.Show(this, "文件有改动，是否保存？", "提示",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.Cancel) {
                    e.Cancel = true;
                } else if (dr == System.Windows.Forms.DialogResult.Yes) {
                    toolButtonSave_Click(null, null);
                }
            }
        }
        private void RefreshCaption() {
            this.Text = _version + " - " + (_parser.Length / 1000) + "KB, 时长 "
                + ByteUtil.GetTime(_parser.Duration)
                + ", 平均混合码率 " + _parser.Rate.ToString("0.0") + "Kbps";
        }

        private void listView1_DoubleClick(object sender, EventArgs e) {
            if (listView1.SelectedIndices.Count <= 0)
                return;
            int selected = listView1.SelectedIndices[0];
            FlvParser.FlvTag tag = _parser.Tags[selected];
            MessageForm.ShowMessage(this, "#" + (selected + 1) + " " + tag.Type, tag.ToString());
        }
        private void listView1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.None) {
                toolButtonRemove_Click(null, null);
            }
        }

        private void toolButtonBlack_Click(object sender, EventArgs e) {
            ExecuteBlack(double.Parse(toolTextRate.Text), -1);
        }
        private void menuTimeBlack_Click(object sender, EventArgs e) {
            ExecuteBlack(-1, double.Parse(toolTextTime.Text));
        }
        private void menuRate_Click(object sender, EventArgs e) {
            ExecuteSpeed(double.Parse(toolTextRate.Text), -1);
        }
        private void menuSpeed_Click(object sender, EventArgs e) {
            ExecuteSpeed(-1, double.Parse(toolTextSpeed.Text));
        }
        private void menuRateFore_Click(object sender, EventArgs e) {
            ExecuteTime(double.Parse(toolTextRate.Text), -1);
        }
        private void menuTimeFore_Click(object sender, EventArgs e) {
            ExecuteTime(-1, double.Parse(toolTextTime.Text));
        }
        private void menuTimeRepair_Click(object sender, EventArgs e) {
            if (_parser == null)
                return;

            uint offset_b = 0;
            int f1 = 0, f2 = 0;
            //int size = 0;
            uint timestamp = 0;
            int lastkeyframe = 0;
            // 取得傲娇帧和后黑帧
            for (int i = 1; i < _parser.Tags.Count; i++) {
                FlvParser.FlvTag tag = _parser.Tags[i];
                FlvParser.VideoTag vtag = tag as FlvParser.VideoTag;
                if (lastkeyframe == 0) {
                    if (vtag != null && vtag.FrameType == "keyframe") {
                        lastkeyframe = i;
                    }
                }
                if (tag.TimeStamp - timestamp < 0) {
                    // 黑头
                    if (f1 == 0) {
                        offset_b = tag.TimeStamp;
                        f1 = i;
                    }
                } else if (tag.TimeStamp - timestamp > 1000) {
                    // 时间戳和上一帧间隔1s以上
                    if (f1 == 0 && timestamp <= 1000) {
                        offset_b = tag.TimeStamp;
                        f1 = i;
                        if ((vtag == null || vtag.FrameType != "keyframe") && (lastkeyframe > 0)) {
                            f1 = lastkeyframe;
                        }
                    } else if (f2 == 0) {
                        f2 = i - 1;
                        break;
                    }
                }
                timestamp = tag.TimeStamp;
            }
            if (f1 == 0 && f2 == 0) {
                MessageBox.Show(this, "此视频不需要修复！", "修复",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (f2 == 0) {
                f2 = f1 - 1;
                f1 = 1;
            }
            if (f1 == 0)
                f1 = 1;

            long filesize = _parser.Length;
            double duration = (timestamp - offset_b) / 1000.0;
            toolProgress.Maximum = _parser.Tags.Count;
            toolProgress.Value = 0;
            toolProgress.Visible = true;
            EnableUI(false, "开始修复...");
            new Thread(() => {
                Stream src = new FileStream(_filename, FileMode.Open);
                string path = _path + ".time_r.flv";
                DirectoryInfo di = new DirectoryInfo(toolComboFolder.Text);
                if (di.Exists) {
                    path = di.FullName + path.Substring(path.LastIndexOf('\\'));
                }
                Stream dest = new FileStream(path, FileMode.Create);
                WriteHead(dest, filesize, duration, -1, -1, -1, 1.0, offset_b, f1, f2, false);

                //WriteDataStream(src, parser.Tags[1].Offset - 11, dest);
                for (int i = f1; i <= f2; i++) {
                    src.Seek(_parser.Tags[i].Offset - 11, SeekOrigin.Begin);
                    FlvParser.FlvTag tag = _parser.Tags[i];
                    byte[] bs = new byte[tag.DataSize < 4 ? 4 : tag.DataSize];
                    src.Read(bs, 0, 4);
                    dest.Write(bs, 0, 4);
                    // 时间戳
                    uint t = tag.TimeStamp;
                    int tmp = (int)(t - offset_b);
                    t = (tmp > 0 ? (uint)tmp : 0);
                    PutTime(bs, 0, t);
                    dest.Write(bs, 0, 4); // timestamp
                    // 继续的数据
                    src.Seek(4, SeekOrigin.Current);
                    src.Read(bs, 0, 3); // streamid
                    dest.Write(bs, 0, 3);
                    src.Read(bs, 0, tag.DataSize);
                    dest.Write(bs, 0, tag.DataSize);
                    // prev tag size
                    src.Read(bs, 0, 4);
                    dest.Write(bs, 0, 4);
                    this.BeginInvoke(new MethodInvoker(() => {
                        toolProgress.Value = i;
                    }));
                }
                src.Close();
                src.Dispose();
                dest.Flush();
                dest.Close();
                dest.Dispose();

                string offstr = (_parser.Duration / 1000.0 - duration).ToString("0.000");
                MessageBox.Show(this, "进度条傲娇修复了"
                    + offstr + "秒！", "傲娇",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Invoke(new MethodInvoker(() => {
                    toolProgress.Visible = false;
                    EnableUI(true, "傲娇处理完成: 修复 " + offstr + " 秒");
                }));
            }).Start();
        }
        private void menuSpeedRepair_Click(object sender, EventArgs e) {
            if (_parser == null)
                return;

            double x = 1 / double.Parse(toolTextSpeed.Text);
            toolProgress.Maximum = _parser.Tags.Count;
            toolProgress.Value = 0;
            toolProgress.Visible = true;
            EnableUI(false, "开始倍速修复...");
            new Thread(() => {
                ExecuteSpeedProc(x, (pos) => {
                    this.BeginInvoke(new MethodInvoker(() => {
                        toolProgress.Value = pos;
                    }));
                }, () => {
                    this.Invoke(new MethodInvoker(() => {
                        MessageBox.Show(this, "倍速修复完毕！", "倍速",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        toolProgress.Visible = false;
                        EnableUI(true, "倍速修复完成");
                    }));
                });
            }).Start();
        }

        private void ExecuteBlack(double rate, double time) {
            if (_parser == null)
                return;

            double o_rate = _parser.Rate;
            if (o_rate < rate) {
                // 不需要转换
                MessageBox.Show(this, "此视频不需要转换", "后黑",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            long filesize = _parser.Length + 16;
            double duration;
            if (time < 0) {
                // 计算傲娇时间
                duration = filesize / 125.0 / rate; // * 8 / 1000 / rate
            } else {
                duration = _parser.Duration / 1000.0 + time;
            }
            string offset = ((duration * 1000 - _parser.Duration) / 1000).ToString("0.000");
            toolProgress.Maximum = _parser.Tags.Count;
            toolProgress.Value = 0;
            toolProgress.Visible = true;
            EnableUI(false, "开始处理后黑... (" + offset + " 秒)");
            new Thread(() => {
                Stream src = new FileStream(_filename, FileMode.Open);
                string path = _path + ".black.flv";
                DirectoryInfo di = new DirectoryInfo(toolComboFolder.Text);
                if (di.Exists) {
                    path = di.FullName + path.Substring(path.LastIndexOf('\\'));
                }
                Stream dest = new FileStream(path, FileMode.Create);
                WriteHead(dest, filesize, duration, -1, -1, -1, 1.0, 0,
                    0, _parser.Tags.Count - 1, false);
                for (int i = 1; i < _parser.Tags.Count; i++) {
                    src.Seek(_parser.Tags[i].Offset - 11, SeekOrigin.Begin);
                    FlvParser.FlvTag tag = _parser.Tags[i];
                    byte[] bs = new byte[tag.DataSize + 11];
                    // 数据
                    src.Read(bs, 0, bs.Length);
                    dest.Write(bs, 0, bs.Length);
                    // prev tag size
                    src.Read(bs, 0, 4);
                    dest.Write(bs, 0, 4);

                    this.BeginInvoke(new MethodInvoker(() => {
                        toolProgress.Value = i;
                    }));
                }
                src.Close();
                src.Dispose();
                byte[] buffer = new byte[]{
                    0x09, 0, 0, 0x01, // 视频帧 1 字节
                    0, 0, 0, 0,       // 04h, timestamp & ex
                    0, 0, 0,          // stream id
                    0x17,             // InnerFrame, H.264
                    0, 0, 0, 0x0c     // 此帧长度 12 字节
                };
                uint dur = (uint)(duration * 1000);
                PutTime(buffer, 0x04, dur);
                dest.Write(buffer, 0, buffer.Length);

                dest.Flush();
                dest.Close();
                dest.Dispose();

                MessageBox.Show(this, "处理完毕，后黑了 " + offset + " 秒！",
                    "后黑", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Invoke(new MethodInvoker(() => {
                    toolProgress.Visible = false;
                    EnableUI(true, "后黑处理完成: " + offset + " 秒");
                }));
            }).Start();
        }
        private void ExecuteSpeed(double rate, double speed) {
            if (_parser == null)
                return;

            double x;
            if (speed < 0) {
                x = _parser.Rate / rate; // 倍速
            } else {
                x = speed;
            }
            toolProgress.Maximum = _parser.Tags.Count;
            toolProgress.Value = 0;
            toolProgress.Visible = true;
            EnableUI(false, "开始处理倍速... (" + x + "x 倍)");
            new Thread(() => {
                ExecuteSpeedProc(x, (pos) => {
                    this.BeginInvoke(new MethodInvoker(() => {
                        toolProgress.Value = pos;
                    }));
                }, () => {
                    this.Invoke(new MethodInvoker(() => {
                        MessageBox.Show(this, x + "x速处理完毕！", "倍速",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        toolProgress.Visible = false;
                        EnableUI(true, "倍速处理完成: " + x + "x 倍");
                    }));
                });
            }).Start();
        }
        private void ExecuteSpeedProc(double x, Action<int> i1, MethodInvoker iEnd) {
            Stream src = new FileStream(_filename, FileMode.Open);
            double duration = _parser.Duration / 1000.0 * x;
            double framerate = 23.976;
            object o;
            if (_parser.MetaTag.TryGet("framerate", out o))
                framerate = (double)o / x;

            string path = _path + ".speed.flv";
            DirectoryInfo di = new DirectoryInfo(toolComboFolder.Text);
            if (di.Exists) {
                path = di.FullName + path.Substring(path.LastIndexOf('\\'));
            }
            Stream dest = new FileStream(path, FileMode.Create);
            WriteHead(dest, _parser.Length, duration, -1, -1, framerate, x, 0,
                0, _parser.Tags.Count - 1, false);

            //WriteDataStream(src, parser.Tags[1].Offset - 11, dest);
            for (int i = 1; i < _parser.Tags.Count; i++) {
                src.Seek(_parser.Tags[i].Offset - 11, SeekOrigin.Begin);
                FlvParser.FlvTag tag = _parser.Tags[i];
                byte[] bs = new byte[tag.DataSize < 4 ? 4 : tag.DataSize];
                src.Read(bs, 0, 4);
                dest.Write(bs, 0, 4);
                // 时间戳
                uint time = tag.TimeStamp;
                time = (uint)(time * x);
                PutTime(bs, 0, time);
                dest.Write(bs, 0, 4);
                // 继续的数据
                src.Seek(4, SeekOrigin.Current);
                src.Read(bs, 0, 3);
                dest.Write(bs, 0, 3);
                src.Read(bs, 0, tag.DataSize);
                dest.Write(bs, 0, tag.DataSize);
                // prev tag size
                src.Read(bs, 0, 4);
                dest.Write(bs, 0, 4);

                if (i1 != null)
                    i1(i);
            }
            src.Close();
            src.Dispose();
            dest.Flush();
            dest.Close();
            dest.Dispose();

            if (iEnd != null)
                iEnd();
        }
        private void ExecuteTime(double rate, double time) {
            if (_parser == null)
                return;
            double o_rate = _parser.Rate;
            if (o_rate < rate) {
                // 不需要转换
                MessageBox.Show(this, "此视频不需要傲娇", "傲娇",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            long filesize = _parser.Length;
            if (rate < 0)
                filesize += 27;
            uint offset;
            double duration;
            if (time < 0) {
                // 计算傲娇时间
                duration = filesize / 125.0 / rate; // * 8 / 1000 / rate
                offset = (uint)(duration * 1000 - _parser.Duration);
                //o_rate = rate;
            } else {
                duration = _parser.Duration / 1000.0 + time;
                offset = (uint)(time * 1000);
                //o_rate = filesize / 125.0 / duration;
            }
            string offstr = (offset / 1000.0).ToString("0.000");
            toolProgress.Maximum = _parser.Tags.Count;
            toolProgress.Value = 0;
            toolProgress.Visible = true;
            EnableUI(false, "开始处理傲娇... (" + offstr + " 秒)");
            new Thread(() => {
                Stream src = new FileStream(_filename, FileMode.Open);

                string path = _path + ".time.flv";
                this.Invoke(new MethodInvoker(() => {
                    DirectoryInfo di = new DirectoryInfo(toolComboFolder.Text);
                    if (di.Exists) {
                        path = di.FullName + path.Substring(path.LastIndexOf('\\'));
                    }
                }));
                Stream dest = new FileStream(path, FileMode.Create);
                WriteHead(dest, filesize, duration, 2.0, 2.0, -1, 1.0, 0 - offset,
                    0, _parser.Tags.Count - 1, (rate < 0));
                // 傲娇的话才插入新帧
                if (rate < 0) {
                    ushort width = 512, height = 384;
                    try {
                        string[] ss = toolComboFrame.Text.Split('x');
                        if (ss.Length == 2) {
                            width = ushort.Parse(ss[0]);
                            height = ushort.Parse(ss[1]);
                        }
                    } catch { }
                    byte[] buffer = GetH263Frame(0, width, height);
                    dest.Write(buffer, 0, buffer.Length);
                }

                //WriteDataStream(src, parser.Tags[1].Offset - 11, dest);
                bool flag = true;
                for (int i = 1; i < _parser.Tags.Count; i++) {
                    src.Seek(_parser.Tags[i].Offset - 11, SeekOrigin.Begin);
                    FlvParser.FlvTag tag = _parser.Tags[i];
                    byte[] bs = new byte[tag.DataSize < 4 ? 4 : tag.DataSize];
                    src.Read(bs, 0, 4);
                    dest.Write(bs, 0, 4);
                    // 时间戳
                    uint t = tag.TimeStamp;
                    if (flag) {
                        FlvParser.VideoTag vtag = tag as FlvParser.VideoTag;
                        if (time < 0) {
                            // 无傲娇进度条
                            if ((vtag != null) && (vtag.AVCPacketType == 1)) {
                                t += offset;
                                flag = false;
                            } else {
                                t = 0;
                            }
                        } else {
                            // 傲娇
                            if (vtag != null) {
                                if (vtag.FrameType == "keyframe") {
                                    flag = false;
                                }
                                t = 0;
                            } else {
                                t += offset;
                            }
                        }
                    } else {
                        t += offset;
                    }
                    PutTime(bs, 0, t);
                    dest.Write(bs, 0, 4); // timestamp
                    // 继续的数据
                    src.Seek(4, SeekOrigin.Current);
                    src.Read(bs, 0, 3); // streamid
                    dest.Write(bs, 0, 3);
                    src.Read(bs, 0, tag.DataSize);
                    dest.Write(bs, 0, tag.DataSize);
                    // prev tag size
                    src.Read(bs, 0, 4);
                    dest.Write(bs, 0, 4);
                    this.BeginInvoke(new MethodInvoker(() => {
                        toolProgress.Value = i;
                    }));
                }
                src.Close();
                src.Dispose();
                dest.Flush();
                dest.Close();
                dest.Dispose();

                MessageBox.Show(this, "进度条傲娇了" + (offset / 1000.0).ToString("0.000") + "秒！",
                    "傲娇", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Invoke(new MethodInvoker(() => {
                    toolProgress.Visible = false;
                    EnableUI(true, "傲娇处理完成: " + offstr + " 秒");
                }));
            }).Start();
        }

        #region - Write 函数 -
        private int PutInt(byte[] dest, int pos, int val, int length) {
            if (length <= 0)
                return pos;
            for (int i = length - 1; i >= 0; i--) {
                dest[pos + i] = (byte)(val & 0xFF);
                val >>= 8;
            }
            return pos + length;
        }
        private int WriteString(byte[] dest, int pos, string str, bool type) {
            if (string.IsNullOrEmpty(str))
                return 0;
            if (type)
                dest[pos++] = 0x2;
            byte[] bs = Encoding.ASCII.GetBytes(str);
            pos = PutInt(dest, pos, bs.Length, 2);
            bs.CopyTo(dest, pos);
            pos += bs.Length;
            return pos;
        }
        private int WriteString(byte[] dest, int pos, string str) {
            return WriteString(dest, pos, str, false);
        }
        private int WriteDouble(byte[] dest, int pos, double val) {
            dest[pos++] = 0;
            byte[] bd = BitConverter.GetBytes(val);
            for (int i = 0; i < 8; i++) {
                dest[pos++] = bd[7 - i];
            }
            return pos;
        }
        private int WriteByte(byte[] dest, int pos, byte b) {
            dest[pos++] = 0x1;
            dest[pos++] = b;
            return pos;
        }

        private void WriteHead(Stream dest, long datasize, double duration, double vcodec, double acodec,
            double framerate, double x, uint offset_b, int f1, int f2, bool reserve) {
            int framecount = f2 - f1 + 1;
            if (framecount <= 0)
                throw new Exception("帧不能为空！");

            double audiosize = 0;
            double videosize = 0;
            double audiocodec = acodec;
            double videocodec = vcodec;
            double lasttimestamp = 0;
            double lastkeyframetimestamp = 0;
            double lastkeyframelocation = 0;
            List<double> filepositions = new List<double>();
            List<double> times = new List<double>();

            long first_offset = 0;
            bool res = reserve;
            for (int i = f1; i <= f2; i++) {
                if ((first_offset == 0) && !(_parser.Tags[i] is FlvParser.ScriptTag)) {
                    first_offset = _parser.Tags[i].Offset;
                }
                FlvParser.AudioTag atag = _parser.Tags[i] as FlvParser.AudioTag;
                if (atag != null) {
                    if (audiocodec < 0)
                        audiocodec = atag.CodecId;
                    audiosize += atag.DataSize + 11;
                    continue;
                }
                FlvParser.VideoTag vtag = _parser.Tags[i] as FlvParser.VideoTag;
                if (vtag != null) {
                    if (videocodec < 0)
                        videocodec = vtag.CodecId;
                    videosize += vtag.DataSize + 11;
                    lasttimestamp = Math.Round((vtag.TimeStamp - offset_b) * x) / 1000.0;
                    if (vtag.FrameType == "keyframe") {
                        if (res) {
                            lasttimestamp = vtag.TimeStamp / 1000.0;
                            res = false;
                        }
                        lastkeyframetimestamp = lasttimestamp;
                        lastkeyframelocation = vtag.Offset - first_offset;
                        filepositions.Add(lastkeyframelocation);
                        times.Add(lastkeyframetimestamp);
                    }
                    continue;
                }
            }
            FlvParser.ScriptTag meta = _parser.MetaTag;

            byte[] bhead = new byte[] {
                0x46, 0x4c, 0x56, // FLV
                0x01,             // Version 1
                0x05,             // 0000 0101, 有音频有视频
                0, 0, 0, 0x09,    // Header size, 9
                0, 0, 0, 0,       // Previous Tag Size #0
            };
            int pos = 0;
            byte[] buffer = new byte[63356];
            buffer[pos++] = 0x12; // script
            #region - 开始写 -
            for (int i = 0; i < 10; i++) {
                buffer[pos++] = 0;
            }
            pos = WriteString(buffer, pos, "onMetaData", true);
            buffer[pos++] = 0x08;
            pos = PutInt(buffer, pos, 26, 4);

            object o;
            double d;

            pos = WriteString(buffer, pos, "creator");
            pos = WriteString(buffer, pos, "tsorgy.cnblogs.com", true);

            pos = WriteString(buffer, pos, "metadatacreator");
            pos = WriteString(buffer, pos, "Metadata creator - by Tsanie", true);

            pos = WriteString(buffer, pos, "hasKeyframes");
            pos = WriteByte(buffer, pos, 1);
            pos = WriteString(buffer, pos, "hasVideo");
            pos = WriteByte(buffer, pos, 1);
            pos = WriteString(buffer, pos, "hasAudio");
            pos = WriteByte(buffer, pos, 1);
            pos = WriteString(buffer, pos, "hasMetadata");
            pos = WriteByte(buffer, pos, 1);
            pos = WriteString(buffer, pos, "canSeekToEnd");
            pos = WriteByte(buffer, pos, 0);

            pos = WriteString(buffer, pos, "duration");
            pos = WriteDouble(buffer, pos, duration);
            pos = WriteString(buffer, pos, "datasize");
            pos = WriteDouble(buffer, pos, datasize);
            pos = WriteString(buffer, pos, "videosize");
            pos = WriteDouble(buffer, pos, videosize);
            pos = WriteString(buffer, pos, "videocodecid");
            pos = WriteDouble(buffer, pos, videocodec);

            pos = WriteString(buffer, pos, "width");
            d = 512.0;
            if (meta.TryGet("width", out o))
                d = (double)o;
            pos = WriteDouble(buffer, pos, d);

            pos = WriteString(buffer, pos, "height");
            d = 384.0;
            if (meta.TryGet("height", out o))
                d = (double)o;
            pos = WriteDouble(buffer, pos, d);

            pos = WriteString(buffer, pos, "framerate");
            d = framerate > 0 ? framerate : (framecount / duration);
            pos = WriteDouble(buffer, pos, d);

            pos = WriteString(buffer, pos, "videodatarate");
            pos = WriteDouble(buffer, pos, videosize / 125.0 / duration);

            pos = WriteString(buffer, pos, "audiosize");
            pos = WriteDouble(buffer, pos, audiosize);
            pos = WriteString(buffer, pos, "audiocodecid");
            pos = WriteDouble(buffer, pos, audiocodec);
            pos = WriteString(buffer, pos, "audiosamplerate");
            d = 44100;
            if (meta.TryGet("audiosamplerate", out o))
                d = (double)o;
            pos = WriteDouble(buffer, pos, d);
            pos = WriteString(buffer, pos, "audiosamplesize");
            d = 16;
            if (meta.TryGet("audiosamplesize", out o))
                d = (double)o;
            pos = WriteDouble(buffer, pos, d);
            pos = WriteString(buffer, pos, "stereo");
            byte stereo = 1;
            if (meta.TryGet("stereo", out o))
                stereo = (byte)o;
            pos = WriteByte(buffer, pos, stereo);
            pos = WriteString(buffer, pos, "audiodatarate");
            pos = WriteDouble(buffer, pos, audiosize / 125.0 / duration);

            pos = WriteString(buffer, pos, "filesize");
            int filesize_pos = pos;
            pos += 9;

            pos = WriteString(buffer, pos, "lasttimestamp");
            pos = WriteDouble(buffer, pos, lasttimestamp);
            pos = WriteString(buffer, pos, "lastkeyframetimestamp");
            pos = WriteDouble(buffer, pos, lastkeyframetimestamp);
            pos = WriteString(buffer, pos, "lastkeyframelocation");
            pos = WriteDouble(buffer, pos, lastkeyframelocation);
            #endregion
            pos = WriteString(buffer, pos, "keyframes");
            buffer[pos++] = 3; // object
            pos = WriteString(buffer, pos, "filepositions");
            int file_positions = pos;
            pos = WriteArray(buffer, pos, filepositions);
            pos = WriteString(buffer, pos, "times");
            pos = WriteArray(buffer, pos, times);
            buffer[pos++] = 0;
            buffer[pos++] = 0;
            buffer[pos++] = 9; // 结束符

            // script tag 长度
            PutInt(buffer, 1, pos - 11, 3); // script 帧的 datasize
            pos = PutInt(buffer, pos, pos, 4);
            WriteDouble(buffer, filesize_pos, datasize + pos + bhead.Length); // filesize
            WriteArray(buffer, file_positions, filepositions, pos + bhead.Length + (reserve ? 27 : 0));

            dest.Write(bhead, 0, bhead.Length);
            dest.Write(buffer, 0, pos);
        }
        private int WriteArray(byte[] dest, int pos, List<double> ds) {
            return WriteArray(dest, pos, ds, 0.0);
        }
        private int WriteArray(byte[] dest, int pos, List<double> ds, double offset) {
            dest[pos++] = 0xa;
            pos = PutInt(dest, pos, ds.Count, 4);
            for (int i = 0; i < ds.Count; i++) {
                pos = WriteDouble(dest, pos, ds[i] + offset);
            }
            return pos;
        }

        private void PutTime(byte[] bs, int pos, uint value) {
            for (int i = 2; i >= 0; i--) {
                bs[pos + i] = (byte)(value & 0xff);
                value >>= 8;
            }
            bs[pos + 3] = (byte)(value & 0xff);
        }
        private byte[] GetH263Frame(uint timestamp, ushort width, ushort height) {
            long b = (1 << 16) | width;
            b = (b << 16) | height;
            b <<= 7;
            byte[] buffer = new byte[]{
                    0x09, 0, 0, 0x0c, // 视频帧 12 字节
                    0, 0, 0, 0,       // timestamp & ex
                    0, 0, 0,          // stream id
                    0x22, 0, 0, 0x84, 0, // InnerFrame, H.263
                    0, 0, 0, 0, 0, 0x12, 0x26, // 16~20:width x height
                    0, 0, 0, 0x17     // 此帧长度 23 字节
                };
            PutTime(buffer, 4, timestamp);
            for (int i = 0; i < 5; i++) {
                buffer[20 - i] = (byte)(b & 0xFF);
                b >>= 8;
            }
            return buffer;
        }
        #endregion

        private void FlvMain_Load(object sender, EventArgs e) {
            toolComboFolder.SelectedIndex = 0;
        }

        private void toolButtonFolder_Click(object sender, EventArgs e) {
            DirectoryInfo di = new DirectoryInfo(toolComboFolder.Text);
            if (di.Exists) {
                folderBrowserDialog1.SelectedPath = di.FullName;
            }
            if (folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                toolComboFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void toolTransparent_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            foreach (ToolStripMenuItem menu in toolTransparent.DropDownItems) {
                if (menu != item)
                    menu.Checked = false;
            }
            item.Checked = true;
            this.Opacity = double.Parse(item.Text.Substring(0, item.Text.Length - 1)) / 100;
        }
        private void toolButtonRemove_Click(object sender, EventArgs e) {
            int[] sel = new int[listView1.SelectedIndices.Count];
            listView1.SelectedIndices.CopyTo(sel, 0);
            int count = sel.Length;
            if (count <= 0)
                return;
            if (MessageBox.Show(this, "确定要删除这些帧吗？", "删除帧",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.No)
                return;
            EnableUI(false, "正在删除帧...");
            Application.DoEvents();
            new Thread(() => {
                this.Invoke(new MethodInvoker(() => {
                    listView1.BeginUpdate();
                }));
                for (int i = count - 1; i >= 0; i--) {
                    int index = sel[i];
                    _parser.Remove(index);
                    this.BeginInvoke(new MethodInvoker(() => {
                        listView1.Items.RemoveAt(index);
                    }));
                }
                this.Invoke(new MethodInvoker(() => {
                    listView1.EndUpdate();
                    _parser.RefreshDuration();
                    EnableUI(true, "删除了 " + count + " 帧");
                    RefreshCaption();
                    listView1.Focus();
                    _changed = true;
                }));
            }).Start();
        }
        private void toolButtonSave_Click(object sender, EventArgs e) {
            if (_parser == null)
                return;
            toolProgress.Maximum = _parser.Tags.Count;
            toolProgress.Value = 0;
            toolProgress.Visible = true;
            EnableUI(false, "开始保存...");
            new Thread(() => {
                string path = _path + ".flv";
                this.Invoke(new MethodInvoker(() => {
                    DirectoryInfo di = new DirectoryInfo(toolComboFolder.Text);
                    if (di.Exists) {
                        path = di.FullName + path.Substring(path.LastIndexOf('\\'));
                    }
                }));
                if (_filename == path) {
                    File.Move(_filename, _filename + ".bak");
                    _filename += ".bak";
                }
                Stream src = new FileStream(_filename, FileMode.Open);
                Stream dest = new FileStream(path, FileMode.Create);
                WriteHead(dest, _parser.Length, _parser.Duration / 1000.0, -1, -1, -1, 1.0, 0,
                    0, _parser.Tags.Count - 1, false);
                //WriteDataStream(src, _parser.Tags[1].Offset - 11, dest);
                for (int i = 1; i < _parser.Tags.Count; i++) {
                    src.Seek(_parser.Tags[i].Offset - 11, SeekOrigin.Begin);
                    FlvParser.FlvTag tag = _parser.Tags[i];
                    byte[] bs = new byte[tag.DataSize + 11];
                    src.Read(bs, 0, bs.Length);
                    dest.Write(bs, 0, bs.Length);
                    // prev tag size
                    src.Read(bs, 0, 4);
                    dest.Write(bs, 0, 4);

                    this.BeginInvoke(new MethodInvoker(() => {
                        toolProgress.Value = i;
                    }));
                }
                src.Close();
                src.Dispose();

                dest.Flush();
                dest.Close();
                dest.Dispose();

                this.Invoke(new MethodInvoker(() => {
                    MessageBox.Show(this, "保存成功！", "保存",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolProgress.Visible = false;
                    EnableUI(true, "保存完成");
                    _changed = false;
                }));
            }).Start();
        }
        private void toolButtonPlayer_Click(object sender, EventArgs e) {
            PlayerForm.ShowPlayer(this);
        }
        private void toolMenuCopyTime_Click(object sender, EventArgs e) {
            if (listView1.SelectedIndices.Count < 1)
                return;
            FlvParser.FlvTag tag = _parser.Tags[listView1.SelectedIndices[0]];
            Clipboard.SetText((tag.TimeStamp / 1000.0).ToString("0.000"));
        }

        private void statusStrip1_Resize(object sender, EventArgs e) {
            if (toolProgress.Visible)
                toolLabelMessage.Width = statusStrip1.Width - 150;
            else
                toolLabelMessage.Width = statusStrip1.Width - 50;
        }

        private void toolMenuTop_Click(object sender, EventArgs e) {
            this.TopMost = toolMenuTop.Checked;
        }
        private void toolButtonSplit_ButtonClick(object sender, EventArgs e) {
            double split = double.Parse(toolTextSplit.Text);
            int count = (int)Math.Ceiling(_parser.Duration / 1000.0 / split);
            if (count == 1) {
                MessageBox.Show(this, "该视频不需要分割！", "分割",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            toolProgress.Maximum = count;
            toolProgress.Value = 0;
            toolProgress.Visible = true;
            string path = _path + "_split";
            DirectoryInfo di = new DirectoryInfo(toolComboFolder.Text);
            if (di.Exists) {
                path = di.FullName + path.Substring(path.LastIndexOf('\\'));
            }
            for (int i = 0; i < count; i++) {
                toolProgress.Value = i;
                EnableUI(false, "正在分割视频...part" + (i + 1).ToString());
                Process p = new Process();
                string ph = Environment.CommandLine;
                ph = ph.Substring(0, ph.LastIndexOf('\\') + 1);
                if (ph[0] == '"')
                    ph = ph.Substring(1);
                p.StartInfo.FileName = "\"" + ph + "ffmpeg.exe\"";
                p.StartInfo.Arguments = "-vcodec copy -acodec copy -i \""
                    + _filename + "\" -ss " + (split * i).ToString("0.000")
                    + " -t " + split.ToString("0.000") + " \"" + path + (i + 1).ToString("00")
                    + ".flv\"";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = !toolShow.Checked;
                p.Start();
                //p.WaitForExit();
                while (!p.HasExited) {
                    Application.DoEvents();
                }
                if (p.ExitCode != 0) {
                    MessageBox.Show(this, "分割flv失败 #" + p.ExitCode
                        + "\n" + p.StandardError.ReadToEnd(), "ffmpeg",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EnableUI(true, "分割flv失败...");
                    return;
                }
            }
            toolProgress.Visible = false;
            EnableUI(true, "成功分割出 " + count + " 个视频");
        }
    }
}
