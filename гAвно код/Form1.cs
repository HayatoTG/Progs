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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string writePath = @"C:\Users\Ильшат\Desktop\121.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private async void  Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {

                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync("Login:" + textBox1.Text);
                    await sw.WriteLineAsync("Password:" + textBox2.Text);
                    await sw.WriteLineAsync("E-mail:" + textBox3.Text);
                    await sw.WriteLineAsync("Name:" + textBox4.Text);
                    await sw.WriteLineAsync("Thelephone number:" + textBox5.Text);
                }

            }
            else MessageBox.Show("Поля не должны быть пустыми");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }
       
    }
}
