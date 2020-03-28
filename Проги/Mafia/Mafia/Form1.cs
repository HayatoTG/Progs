using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mafia
{
    public partial class Form1 : Form
    {
        bool f = true;

        public Form1()
        {
            InitializeComponent();
            //comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox1.Items.AddRange(new string[]{
            "Камиль",
            "Тимур",
            "Андрей",
            "Илназ",
            "Никита",
            "Миша",
            "Даша",
            "Саша",
            "Маша",
            "Сеня",
            "Рустам",
            "Данис",
            "Айнур",
            "Ленар",
            "Вадим",
            "Лилия"});

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //bool rt = false;

            int v = int.Parse(listBox1.SelectedIndex.ToString());
            if (v >= 0)
                {
                
                    if (r1.Checked)
                    {
                        if (String.IsNullOrEmpty(textBox1.Text))
                        {
                             textBox1.Text = listBox1.SelectedItem.ToString();
                             listBox1.Items.RemoveAt(v);
                             comboBox1.Items.RemoveAt(v);
                        }
                    }
                    if (r2.Checked)
                    {
                        if (String.IsNullOrEmpty(textBox2.Text))
                        {
                            textBox2.Text = listBox1.SelectedItem.ToString();
                            listBox1.Items.RemoveAt(v);
                            comboBox1.Items.RemoveAt(v);
                        }   

                    }
                    if (r3.Checked)
                    {
                      if (String.IsNullOrEmpty(textBox3.Text))
                      {
                        textBox3.Text = listBox1.SelectedItem.ToString();
                        listBox1.Items.RemoveAt(v);
                        comboBox1.Items.RemoveAt(v);
                      }
                    }
                    if (r4.Checked)
                    {
                      if (String.IsNullOrEmpty(textBox4.Text))
                      {
                        textBox4.Text = listBox1.SelectedItem.ToString();
                        listBox1.Items.RemoveAt(v);
                        comboBox1.Items.RemoveAt(v);
                      }
                    }
            }
            else MessageBox.Show("Ошибка");       
        }

        private void R1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {  
        }

        private void ComboBox1_Click(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count < 0)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                Random n = new Random();
                int a = n.Next(0, 16);
                int z = n.Next(0, 16);
                int q = n.Next(0, 16);
                int s = n.Next(0, 16);
                if (z != a && q != s)
                {
                    if (a != q && a != s)
                    {

                        if (z != q && z != s)
                        {
                         textBox1.Text = listBox1.Items[a].ToString();
                         textBox2.Text = listBox1.Items[z].ToString();
                         textBox3.Text = listBox1.Items[q].ToString();
                         textBox4.Text = listBox1.Items[s].ToString();
                        }
                    }
                }
              
            }
            catch{}

        }

        private void Name_TextChanged(object sender, EventArgs e)
        {   
        }

        private void Name_Validating(object sender, CancelEventArgs e)
        {
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(name.Text))
            {

                errorProvider1.SetError(name, "Пустой ник (имя) не может быть !");

            }
            else if (listBox1.Items.Count == 16)
            {
                errorProvider1.SetError(name, "В списке 16 человек!\nМаксимум :(");
            }
            else
            {
                errorProvider1.Clear();
                MessageBox.Show("_Добавлен игрок_");
                listBox1.Items.Add(name.Text);
                comboBox1.Items.Add(name.Text);
                name.Text = "";
            }
          
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int v = int.Parse(listBox1.SelectedIndex.ToString());
            if (v >= 0)
            {
                del.Text = listBox1.SelectedItem.ToString();
            }
            //del.Text = listBox1.SelectedItem.ToString();
            if (String.IsNullOrEmpty(del.Text))
            {

                errorProvider2.SetError(del, "Пустой ник (имя) не может быть !");

            }
            else
            {
                errorProvider2.Clear();
                MessageBox.Show($"_Удален игрок_ {del.Text}");
                 listBox1.Items.Remove(del.Text);
                comboBox1.Items.Remove(del.Text);
                del.Text = "";
                
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            
            int v = int.Parse(listBox1.SelectedIndex.ToString());
            if (v >= 0)
            {

                if (r1.Checked)
                {
                    if (!String.IsNullOrEmpty(textBox1.Text))
                    {
                        listBox1.Items.Add(textBox1.Text);
                        comboBox1.Items.Add(textBox1.Text);
                        textBox1.Text = "";
                        textBox1.Text = listBox1.SelectedItem.ToString();
                        listBox1.Items.RemoveAt(v);
                        comboBox1.Items.RemoveAt(v);
                    }
                }
                if (r2.Checked)
                {
                    if (!String.IsNullOrEmpty(textBox2.Text))
                    {
                        listBox1.Items.Add(textBox2.Text);
                        comboBox1.Items.Add(textBox2.Text);
                        textBox2.Text = "";
                        textBox2.Text = listBox1.SelectedItem.ToString();
                        listBox1.Items.RemoveAt(v);
                        comboBox1.Items.RemoveAt(v);
                    }       
                }
                if (r3.Checked)
                {
                    if (!String.IsNullOrEmpty(textBox3.Text))
                    {
                        listBox1.Items.Add(textBox3.Text);
                        comboBox1.Items.Add(textBox3.Text);
                        textBox3.Text = "";
                        textBox3.Text = listBox1.SelectedItem.ToString();
                        listBox1.Items.RemoveAt(v);
                        comboBox1.Items.RemoveAt(v);
                    }                 
                }
                if (r4.Checked)
                {
                    if (!String.IsNullOrEmpty(textBox4.Text))
                    {
                        listBox1.Items.Add(textBox4.Text);
                        comboBox1.Items.Add(textBox4.Text);
                        textBox4.Text = "";
                        textBox4.Text = listBox1.SelectedItem.ToString();
                        listBox1.Items.RemoveAt(v);
                        comboBox1.Items.RemoveAt(v);
                    }
                }
               
            }
            else MessageBox.Show("Ошибка");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
