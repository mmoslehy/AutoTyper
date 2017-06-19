using System;
using System.Windows.Forms;

namespace AutoTyper
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            var gkh = new globalKeyboardHook();
            gkh.HookedKeys.Add(Keys.F5);
            gkh.KeyDown += gkh_KeyDown;

            timer1.Interval = 1000;
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            button1.PerformClick();
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            button1.Text = timer1.Enabled ? "Stop" : "Start";
            button1.Text += @" (F5)";
            Text = timer1.Enabled ? "Started" : "Stopped";
            Text += @" Autotyper";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send(textBox1.Text.Substring(0,1));
        }
    }
}
