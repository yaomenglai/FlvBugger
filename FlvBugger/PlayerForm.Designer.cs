namespace Tsanie.FlvBugger {
    partial class PlayerForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSpeed1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSpeed2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSpeed3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSpeed4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSpeed5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSpeed6 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl = new System.Windows.Forms.Panel();
            this.trackPos = new System.Windows.Forms.TrackBar();
            this.labelPos = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackPos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPlayer
            // 
            this.panelPlayer.ContextMenuStrip = this.contextMenuStrip1;
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayer.Location = new System.Drawing.Point(0, 0);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(400, 300);
            this.panelPlayer.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.toolSpeed1,
            this.toolSpeed2,
            this.toolSpeed3,
            this.toolSpeed4,
            this.toolSpeed5,
            this.toolSpeed6});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 164);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "播放倍速";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolSpeed1
            // 
            this.toolSpeed1.Name = "toolSpeed1";
            this.toolSpeed1.Size = new System.Drawing.Size(152, 22);
            this.toolSpeed1.Text = "0.5x";
            this.toolSpeed1.Click += new System.EventHandler(this.toolSpeed1_Click);
            // 
            // toolSpeed2
            // 
            this.toolSpeed2.Name = "toolSpeed2";
            this.toolSpeed2.Size = new System.Drawing.Size(152, 22);
            this.toolSpeed2.Text = "0.75x";
            this.toolSpeed2.Click += new System.EventHandler(this.toolSpeed1_Click);
            // 
            // toolSpeed3
            // 
            this.toolSpeed3.Checked = true;
            this.toolSpeed3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolSpeed3.Name = "toolSpeed3";
            this.toolSpeed3.Size = new System.Drawing.Size(152, 22);
            this.toolSpeed3.Text = "1x";
            this.toolSpeed3.Click += new System.EventHandler(this.toolSpeed1_Click);
            // 
            // toolSpeed4
            // 
            this.toolSpeed4.Name = "toolSpeed4";
            this.toolSpeed4.Size = new System.Drawing.Size(152, 22);
            this.toolSpeed4.Text = "1.5x";
            this.toolSpeed4.Click += new System.EventHandler(this.toolSpeed1_Click);
            // 
            // toolSpeed5
            // 
            this.toolSpeed5.Name = "toolSpeed5";
            this.toolSpeed5.Size = new System.Drawing.Size(152, 22);
            this.toolSpeed5.Text = "2x";
            this.toolSpeed5.Click += new System.EventHandler(this.toolSpeed1_Click);
            // 
            // toolSpeed6
            // 
            this.toolSpeed6.Name = "toolSpeed6";
            this.toolSpeed6.Size = new System.Drawing.Size(152, 22);
            this.toolSpeed6.Text = "3x";
            this.toolSpeed6.Click += new System.EventHandler(this.toolSpeed1_Click);
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.trackPos);
            this.panelControl.Controls.Add(this.labelPos);
            this.panelControl.Controls.Add(this.buttonPause);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(0, 300);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(400, 21);
            this.panelControl.TabIndex = 1;
            // 
            // trackPos
            // 
            this.trackPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackPos.AutoSize = false;
            this.trackPos.Location = new System.Drawing.Point(49, 0);
            this.trackPos.Margin = new System.Windows.Forms.Padding(0);
            this.trackPos.Name = "trackPos";
            this.trackPos.Size = new System.Drawing.Size(243, 21);
            this.trackPos.TabIndex = 3;
            this.trackPos.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackPos_MouseDown);
            this.trackPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackPos_MouseUp);
            // 
            // labelPos
            // 
            this.labelPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPos.ForeColor = System.Drawing.Color.White;
            this.labelPos.Location = new System.Drawing.Point(292, 3);
            this.labelPos.Margin = new System.Windows.Forms.Padding(0);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(108, 15);
            this.labelPos.TabIndex = 2;
            this.labelPos.Text = "0:00/0:00 (0.0)";
            this.labelPos.Click += new System.EventHandler(this.labelPos_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(0, 0);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(49, 21);
            this.buttonPause.TabIndex = 0;
            this.buttonPause.Text = "▶/‖";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 321);
            this.Controls.Add(this.panelPlayer);
            this.Controls.Add(this.panelControl);
            this.Name = "PlayerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "播放器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayerForm_FormClosed);
            this.Shown += new System.EventHandler(this.PlayerForm_Shown);
            this.Resize += new System.EventHandler(this.PlayerForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackPos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Label labelPos;
        private System.Windows.Forms.TrackBar trackPos;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolSpeed1;
        private System.Windows.Forms.ToolStripMenuItem toolSpeed2;
        private System.Windows.Forms.ToolStripMenuItem toolSpeed3;
        private System.Windows.Forms.ToolStripMenuItem toolSpeed4;
        private System.Windows.Forms.ToolStripMenuItem toolSpeed5;
        private System.Windows.Forms.ToolStripMenuItem toolSpeed6;
    }
}