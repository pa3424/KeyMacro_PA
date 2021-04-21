using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyMacro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled)
            {
                textBox1.Enabled = false;
                string currentTick = Regex.Replace(Convert.ToString(textBox1.Text), @"\s+", String.Empty);
                double second = TimeSpan.Parse("00:" + currentTick).TotalSeconds;
                TimeSpan time = TimeSpan.FromMilliseconds(second);
                button1.Text = "Loading...";
                await Task.Delay(5000);

                button1.Text = "STOP Macro";

                foreach (var number in Enumerable.Range(0, 10000).Select(i => i.ToString("0000")))
                {
                    await Task.Delay(time);
                    SendKeys.Send(number);
                    SendKeys.Send("{ENTER}");
                }
                SendKeys.Flush();
            }
            else
            {
                button1.Text = "Start Macro";
                textBox1.Enabled = true;
                await Task.Yield();
            }
        }
    }
}
