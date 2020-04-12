using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace Mafia
{
    public partial class Form1 : Form
    {
        bool s = true;
        string[] st;
        //string[] com = new string[] {"Камиль",
        //    "Тимур",
        //    "Андрей",
        //    "Илназ",
        //    "Никита",
        //    "Миша",
        //    "Даша",
        //    "Саша",
        //    "Маша",
        //    "Сеня",
        //    "Рустам",
        //    "Данис",
        //    "Айнур",
        //    "Ленар",
        //    "Вадим",
        //    "Лилия" };
        [BsonKnownTypes(typeof(Team))]
        class Team
        {
            public string TM_name;
            public List<string> mafia_role;
            public string butter_role;
            public string sherif_role;
            public string doc_role;
            public List<string> civilian_role;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void Button1_Click(object sender, EventArgs e)
        //{
        //    //bool rt = false;

        //    int v = int.Parse(listBox1.SelectedIndex.ToString());
        //    if (v >= 0)
        //        {
                
        //            if (r1.Checked)
        //            {
        //                if (String.IsNullOrEmpty(textBox1.Text))
        //                {
        //                     textBox1.Text = listBox1.SelectedItem.ToString();
        //                     listBox1.Items.RemoveAt(v);
        //                     comboBox1.Items.RemoveAt(v);
        //                }
        //            }
        //            if (r2.Checked)
        //            {
        //                if (String.IsNullOrEmpty(textBox2.Text))
        //                {
        //                    textBox2.Text = listBox1.SelectedItem.ToString();
        //                    listBox1.Items.RemoveAt(v);
        //                    comboBox1.Items.RemoveAt(v);
        //                }   

        //            }
        //            if (r3.Checked)
        //            {
        //              if (String.IsNullOrEmpty(textBox3.Text))
        //              {
        //                textBox3.Text = listBox1.SelectedItem.ToString();
        //                listBox1.Items.RemoveAt(v);
        //                comboBox1.Items.RemoveAt(v);
        //              }
        //            }
        //            if (r4.Checked)
        //            {
        //              if (String.IsNullOrEmpty(textBox4.Text))
        //              {
        //                textBox4.Text = listBox1.SelectedItem.ToString();
        //                listBox1.Items.RemoveAt(v);
        //                comboBox1.Items.RemoveAt(v);
        //              }
        //            }
        //    }
        //    else MessageBox.Show("Ошибка");       
        //}



        //private void ComboBox1_Click(object sender, EventArgs e)
        //{
        //}

        //private void Button2_Click(object sender, EventArgs e)
        //{



        //    try
        //    {
        //        if (listBox1.Items.Count < 0)
        //        {
        //            textBox1.Text = "";
        //            textBox2.Text = "";
        //            textBox3.Text = "";
        //            textBox4.Text = "";
        //        }
        //        Random n = new Random();
        //        int a = n.Next(0, 16);
        //        int z = n.Next(0, 16);
        //        int q = n.Next(0, 16);
        //        int s = n.Next(0, 16);
        //        if (z != a && q != s)
        //        {
        //            if (a != q && a != s)
        //            {

        //                if (z != q && z != s)
        //                {
        //                    textBox1.Text = listBox1.Items[a].ToString();
        //                    textBox2.Text = listBox1.Items[z].ToString();
        //                    textBox3.Text = listBox1.Items[q].ToString();
        //                    textBox4.Text = listBox1.Items[s].ToString();
        //                }
        //            }
        //        }

        //    }
        //    catch { }

        //}

        private void Name_TextChanged(object sender, EventArgs e)
        {   
        }

        private void Name_Validating(object sender, CancelEventArgs e)
        {
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Rbutt();
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
                    //comboBox2.Items.Add(name.Text);
                    name.Text = "";
                panel1.Visible = true;
                button1.Visible = true;
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
                bool g = listBox1.Items.Contains(del.Text);
                if (g == true)
                {
                    MessageBox.Show($"_Удален игрок_ {del.Text}");
                    listBox1.Items.Remove(del.Text);
                    //comboBox1.Items.Remove(del.Text);
                }
                else MessageBox.Show($"_Игрока с таким ником нет_ ");
                del.Text = "";
                
            }
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Team tm = new Team();
            //tm.mafia_role = new List<string>();
            //tm.civilian_role = new List<string>();
        }
        public void Button2_Click(object sender, EventArgs e)
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase("Mafia");
            var collection = database.GetCollection<Team>("accountdata");
            Team t1 = new Team
            {
                TM_name = comand.Text,
                mafia_role = new List<string>(),
                //Languages = new List<string> { "english", "german" },
                //Company = new Company
                //{
                //    Name = "Google"
                //}
                butter_role = label8.Text ,
                sherif_role = label9.Text,
                doc_role = label10.Text,
                civilian_role = new List<string> { "english", "german" },
            };
            collection.InsertOne(t1);
            comboBox3.Items.Add(comand.Text);
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (listBox1.SelectedItem.ToString() != null)
                {
                    string d = listBox1.SelectedItem.ToString();
                    if (radioButton1.Checked == true)
                    {
                        if (comboBox1.Items.Contains(d) == false)
                        {
                            for (int i = 0; i <= 4; i++)
                            {
                                st[i] = comboBox1.Items.Add(d).ToString();
                            }
                        }
                        //int kol = comboBox1.Items.Count;
                        /*if (comboBox1.Items.Count == 4)*/
                        comboBox1.Items.RemoveAt(4);
                    }

                    if (radioButton2.Checked == true && comboBox1.Items.Contains(d) != true)
                    {
                        label8.Text = d;
                    }

                    if (radioButton3.Checked == true && label8.Text != d && comboBox1.Items.Contains(d) != true) label9.Text = d;
                    if (radioButton4.Checked == true && comboBox1.Items.Contains(d) != true && label9.Text != d) label10.Text = d;
                    if (radioButton5.Checked == true && comboBox1.Items.Contains(d) != true && label10.Text != d)
                    {
                        if (comboBox2.Items.Contains(d) == false)
                        {
                            if(label9.Text != d && label8.Text != d)
                            comboBox2.Items.Add(d);
                            //comboBox1.Items.RemoveAt(4);
                        }
                        else MessageBox.Show($"_Игрок_ {d} cуществует"); 
                    }
                    if(comboBox1.Items.Count != 0 && comboBox2.Items.Count != 0 && label8.Text != null && label9.Text != null && label10.Text != null)
                        panel2.Visible = true;
                }
                //panel2.Visible = true;
            }
            catch
            {
               
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 4; i++)
            {
                MessageBox.Show(st[i]);
            }
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
