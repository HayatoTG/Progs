﻿using System;
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
using System.IO;

namespace СРИНДЕР
{
    public partial class Form2 : Form
    {
        public Form2()
        {
           
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public void Form2_Load(object sender, EventArgs e)
        {
            //this.BackgroundImage = Properties.Resources.sds;
            mainprofileGUIload();
            ThemeChanged();
            DataLoad();     
        }
      
        public void mainprofileGUIload()
        {
            this.Controls.Clear();
            //if (Properties.Settings.Default.theme == "светлая")
            //{
            //    this.BackColor = Color.FromArgb(230, 230, 230);
            //    this.ForeColor = Color.Black;
            //}
            //if (Properties.Settings.Default.theme == "темная")
            //{
            //    this.BackColor = Color.FromArgb(64, 64, 64);
            //    this.ForeColor = Color.White;

            //}
            profilename = new Label();
            profileimage = new PictureBox();            
            labelnameage = new Label();
            labelnameage.Location = new Point(70, 18);
           
            profileimage.Location = new Point(5, 43);
            profileimage.Width = 200;
            profileimage.Height = 220;
            profileimage.SizeMode = PictureBoxSizeMode.StretchImage;
 
            profileimage.BorderStyle = BorderStyle.FixedSingle;
            editprofile = new Button();
            editprofile.Location = new Point(5, 274);
            editprofile.Width = 200;
            editprofile.Height = 37;
            editprofile.Text = "Редактировать профиль";
            editprofile.FlatStyle = FlatStyle.Flat;
            editprofile.Click += Edit;
            messages = new Button();
            messages.Location = new Point(525, 88);
            messages.Width = 243;
            messages.Height = 58;
            messages.Text = "СООБЩЕНИЯ";
            messages.FlatStyle = FlatStyle.Flat;
            //messages.Click += ;
            notifications = new Button();
            notifications.Location = new Point(525, 201);
            notifications.Width = 243;
            notifications.Height = 58;
            notifications.Text = "УВЕДОМЛЕНИЯ";
            notifications.FlatStyle = FlatStyle.Flat;
            //notifications.Click += ;
            findcouple = new Button();
            findcouple.Location = new Point(525, 316);
            findcouple.Width = 243;
            findcouple.Height = 58;
            findcouple.Text = "ПОИСК ПАРЫ";
            findcouple.FlatStyle = FlatStyle.Flat;
            //findcouple.Click += ;
            pnl = new Panel();
            pnl.Location = new Point(388, 0);
            pnl.Width = 10;
            pnl.Height = 666;
            aboutme = new Label();
            aboutme.AutoSize = true;    
            pnl.BackColor = SystemColors.ScrollBar;   
            infopanel = new FlowLayoutPanel();
            infopanel.Location = new Point(8, 452);
            infopanel.BackColor = Color.White;
            infopanel.BorderStyle = BorderStyle.FixedSingle;
            infopanel.AutoScroll = true;
            infopanel.WrapContents = true;
            infopanel.HorizontalScroll.Visible = false;
            infopanel.Width = 170;
            infopanel.Height = 116;
            //if (Properties.Settings.Default.theme == "светлая")
            //{
            //    infopanel.BackColor = Color.White;

            //}
            //if (Properties.Settings.Default.theme == "темная")
            //{
            //    infopanel.BackColor = Color.FromArgb(96, 96, 96);
            //}
            infopanel.Controls.Add(aboutme);

            options = new Button();
            options.Location = new Point(830, 15);
            options.Width = 40;
            options.Height = 40;
            options.BackgroundImage = Properties.Resources.options;
            options.FlatStyle = FlatStyle.Flat;
            options.FlatAppearance.BorderSize = 0;
            options.FlatAppearance.MouseDownBackColor = Color.Transparent;
            options.FlatAppearance.MouseOverBackColor = Color.Transparent;
            options.Click += Options;

            this.Controls.Add(labelnameage);
            this.Controls.Add(profileimage);
            this.Controls.Add(editprofile);
            this.Controls.Add(messages);
            this.Controls.Add(notifications);
            this.Controls.Add(findcouple);
            this.Controls.Add(pnl);
            this.Controls.Add(infopanel);
            this.Controls.Add(options);

        }

        public void DataLoad()
        {
           
                string connectionString = "mongodb://localhost:27017";
                MongoClient client = new MongoClient(connectionString);
                var database = client.GetDatabase("оДНОгруппники");
                var collection = database.GetCollection<BsonDocument>("accounts");
                var filter = new BsonDocument
                {
                  {"_id",$"{Properties.Settings.Default.Ulogin}"},
                  {"password", $"{Properties.Settings.Default.Upassword}"}
                };
                var acc = collection.Find(filter).ToList();
                BsonValue bs = null;
                byte[] photoimg = null;
                foreach (var doc in acc)
                {
                    labelnameage.Text = $"{doc.GetValue("name")}, {doc.GetValue("age")}";
                    bs = doc.GetValue("photo");
                    aboutme.Text = $"{doc.GetValue("info")}";
                }
                photoimg = bs.AsByteArray;
                MemoryStream ms = new MemoryStream(photoimg, 0, photoimg.Length);
                profileimage.Image = new Bitmap(ms);
            
        }
        public void ThemeChanged()
        {
            if (Properties.Settings.Default.theme == "светлая")
            {
                this.BackColor = Color.FromArgb(230, 230, 230);
                this.ForeColor = Color.Black;
                infopanel.BackColor = Color.White;
            }
            if (Properties.Settings.Default.theme == "темная")
            {
                this.BackColor = Color.FromArgb(64, 64, 64);
                this.ForeColor = Color.White;
                infopanel.BackColor = Color.FromArgb(96, 96, 96);
            }
        }
        private void Options(object sender, EventArgs e)
        {
            form3 = new Form3();
            form3.FormClosing += form3closed;
            form3.ShowDialog();   
          
        }
        private void Edit(object sender, EventArgs e)
        {
            form4 = new Form4();
            form4.FormClosing += form4closed;
            form4.ShowDialog();
        }
        public void form3closed(object sender, EventArgs e)
        {
            //mainprofileGUIload();
            //DataLoad();
            ThemeChanged();
        }
        public void form4closed(object sender, EventArgs e)
        {
            DataLoad();
        } 
        private void Button5_Click(object sender, EventArgs e)
        {

        }
    }
}
