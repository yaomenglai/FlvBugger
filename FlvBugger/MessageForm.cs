using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tsanie.FlvBugger {
    public partial class MessageForm : Form {
        private MessageForm() {
            InitializeComponent();
        }

        public static void ShowMessage(Form owner, string caption, string text) {
            MessageForm form = new MessageForm();
            form.Text = caption;
            form.textMessage.Text = text;
            form.Show(owner);
        }

        private void button_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            try {
                double d = double.Parse(textBox1.Text);
                byte[] bs = BitConverter.GetBytes(d);
                string s = "";
                for (int i = 7; i >= 0; i--) {
                    s += bs[i].ToString("X2") + " ";
                }
                textBox2.Text = s;
            } catch { }
        }
    }
}
