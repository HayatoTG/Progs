using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randomizer
{
    public partial class Form1 : Form
    {     
        public Form1()
        {
            InitializeComponent();
            
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string ss = textBox1.Text;
            if (ss == "")
                MessageBox.Show("Поле не может быть пустым");
            else
            {
                if (listBox1.Items.Count >= 16)
                {
                    MessageBox.Show("Достигнуто максимальное кол-во игркоков");
                }
                else
                {
                    if (listBox1.Items.Contains(ss))
                    {
                        MessageBox.Show("Игрок с таким именем уже существует");
                    }
                    else
                    {
                        listBox1.Items.Add(ss);
                        textBox1.Clear();
                    }
                }
               
            }
            
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите игрока");
            }
            else
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false && radioButton6.Checked == false && radioButton7.Checked == false && radioButton8.Checked == false)
                {
                    MessageBox.Show("Выберите роль");
                }
                else
                {
                    if (radioButton1.Checked == true)
                    {
                        if (labelmafia1.Text == "")
                        {
                            labelmafia1.Text = listBox1.SelectedItem.ToString();
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        }
                        else MessageBox.Show("Игрок уже назначен");
                    }
                    if (radioButton2.Checked == true)
                    {
                        if (labelmafia2.Text == "")
                        {
                            labelmafia2.Text = listBox1.SelectedItem.ToString();
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        }
                        else MessageBox.Show("Игрок уже назначен");
                    }
                    if (radioButton3.Checked == true)
                    {
                        if (labelmafia3.Text == "")
                        {
                            labelmafia3.Text = listBox1.SelectedItem.ToString();
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        }
                        else MessageBox.Show("Игрок уже назначен");
                    }
                    if (radioButton4.Checked == true)
                    {
                        if (labelmafia4.Text == "")
                        {
                            labelmafia4.Text = listBox1.SelectedItem.ToString();
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        }
                        else MessageBox.Show("Игрок уже назначен");
                    }
                    if (radioButton5.Checked == true)
                    {
                        if (labelpolice.Text == "")
                        {
                            labelpolice.Text = listBox1.SelectedItem.ToString();
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        }
                        else MessageBox.Show("Игрок уже назначен");
                    }
                    if (radioButton6.Checked == true)
                    {
                        if (labeldoc.Text == "")
                        {
                            labeldoc.Text = listBox1.SelectedItem.ToString();
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        }
                        else MessageBox.Show("Игрок уже назначен");
                    }
                    if (radioButton7.Checked == true)
                    {
                        if (labelsh.Text == "")
                        {
                            labelsh.Text = listBox1.SelectedItem.ToString();
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        }
                        else MessageBox.Show("Игрок уже назначен");
                    }
                    if (radioButton8.Checked == true)
                    {
                        if (listBox2.Items.Count < 9)
                        {
                            listBox2.Items.Add(listBox1.SelectedItem.ToString());
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        }
                        else MessageBox.Show("Максимальное кол-во мирных жителей");
                    }
                }
            }
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (labelmafia1.Text != "")
                listBox1.Items.Add(labelmafia1.Text);
            labelmafia1.Text = "";
            if (labelmafia2.Text != "")
                listBox1.Items.Add(labelmafia2.Text);
            labelmafia2.Text = "";
            if (labelmafia3.Text != "")
                listBox1.Items.Add(labelmafia3.Text);
            labelmafia3.Text = "";
            if (labelmafia4.Text != "")
                listBox1.Items.Add(labelmafia4.Text);
            labelmafia4.Text = "";
            if (labelpolice.Text != "")
                listBox1.Items.Add(labelpolice.Text);
            labelpolice.Text = "";
            if (labeldoc.Text != "")
                listBox1.Items.Add(labeldoc.Text);
            labeldoc.Text = "";
            if (labelsh.Text != "")
                listBox1.Items.Add(labelsh.Text);
            labelsh.Text = "";
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                listBox1.Items.Add(listBox2.Items[i].ToString());
            }
            listBox2.Items.Clear();
        }

        
    }
}
