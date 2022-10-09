using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caesarr
{
    public partial class Form1 : Form
    {
        private Caesar coder;
        private Decrypter decr;
        public Form1()
        {
            InitializeComponent();
            decr = new Decrypter();
            coder = new Caesar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Введите кодируемый или закодированный текст! Здесь и сейчас! (＃￣ω￣)";
            textBox2.Text = "╭༼ ººل͟ºº ༽╮";
            decr.Learn(File.ReadAllText("learn.txt"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = coder.Code(((int)numericUpDown1.Value), textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = coder.Code(-((int)numericUpDown1.Value), textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decr.Learn(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var res = decr.DecryptKey(textBox1.Text, coder);
            numericUpDown1.Value = res;
            button1.PerformClick();
        }
    }
}
