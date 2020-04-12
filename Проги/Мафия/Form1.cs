using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;


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
                if (radioButton1.Checked == false &&  radioButton4.Checked == false && radioButton5.Checked == false && radioButton6.Checked == false && radioButton7.Checked == false && radioButton8.Checked == false)
                {
                    MessageBox.Show("Выберите роль");
                }
                else
                {
                    if (radioButton1.Checked == true)
                    {
                        if (listBox3.Items.Count < 3)
                        {
                            listBox3.Items.Add(listBox1.SelectedItem);
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        }
                        else MessageBox.Show("Максимальное кол-во игроков");
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
            TeamData();
            comboBox1.SelectedValueChanged += PresetLoad;
        }
        public class Team
        {
            [BsonId]
            public string teamname;
            public string[] mafia = new string[3];
            public string boss;
            public string police;
            public string doc;
            public string sh;
            public string[] mirn = new string[9];

        }
        private void Button3_Click(object sender, EventArgs e)
        {
            
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
        public void TeamData()
        {
            comboBox1.Items.Clear();
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase("Mafia");
            var collection = database.GetCollection<BsonDocument>("Teams");
            var filter = new BsonDocument();
            var tm = collection.Find(filter).ToList();
            foreach (var doc in tm)
            {
                comboBox1.Items.Add($"{doc.GetValue("_id")}");
            }
        }
        private void PresetLoad(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase("Mafia");
            var collection = database.GetCollection<BsonDocument>("Teams");
            var filter = new BsonDocument {

               {"_id",$"{comboBox1.SelectedItem}"},

            };
            var tm = collection.Find(filter).ToList();
            BsonValue mafia = null;
            BsonValue citizens = null;
            foreach (var doc in tm)
            {

                mafia = doc.GetValue("mafia");
                citizens = doc.GetValue("mirn");
                if (doc.GetValue("boss") != BsonNull.Value)
                    labelmafia4.Text = $"{doc.GetValue("boss")}";
                if (doc.GetValue("police") != BsonNull.Value)
                    labelpolice.Text = $"{doc.GetValue("police")}";
                if (doc.GetValue("doc") != BsonNull.Value)
                    labeldoc.Text = $"{doc.GetValue("doc")}";
                if (doc.GetValue("sh") != BsonNull.Value)
                    labelsh.Text = $"{doc.GetValue("sh")}";
            }
            for (int i = 0; i < 3; i++)
            {
                if (mafia[i] != BsonNull.Value)
                {
                    listBox3.Items.Add($"{mafia[i]}");
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (citizens[i] != BsonNull.Value)
                {
                    listBox2.Items.Add($"{citizens[i]}");
                }
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase("Mafia");
            var collection = database.GetCollection<BsonDocument>("Teams");
            Team tm = new Team();

            tm.teamname = textBox2.Text;
            for (int i = 0; i < listBox3.Items.Count; i++)
            {
                tm.mafia[i] = $"{listBox3.Items[i]}";
            }
            tm.boss = labelmafia4.Text;
            tm.police = labelpolice.Text;
            tm.doc = labeldoc.Text;
            tm.sh = labelsh.Text;        
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                tm.mirn[i] = $"{listBox2.Items[i]}"; ;
            }
            collection.InsertOne(tm.ToBsonDocument()); ;
            TeamData();
        }
    }
}
