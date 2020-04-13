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
            buttonfocus = new Button();
            buttonfocus.Location = new Point(0,0);
            buttonfocus.Width = 0;
            buttonfocus.Height = 0;
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
            profileimage = new PictureBox();            
            labelnameage = new Label();
            labelnameage.Location = new Point(95, 18);
            labelnameage.Width = 200;
            labelnameage.TextAlign = ContentAlignment.MiddleCenter;

            profileimage.Location = new Point(95, 43);
            profileimage.Width = 200;
            profileimage.Height = 220;
            profileimage.SizeMode = PictureBoxSizeMode.StretchImage;
            profileimage.BorderStyle = BorderStyle.FixedSingle;
            editprofile = new Button();
            editprofile.Location = new Point(95, 274);
            editprofile.Width = 200;
            editprofile.Height = 37;
            editprofile.Text = "Редактировать профиль";
            editprofile.FlatStyle = FlatStyle.Flat;
            editprofile.Click += Edit;
           
            textinfo = new Label();
            textinfo.Location = new Point(95, 335);
            textinfo.Text = "О себе:";
            pnl = new Panel();
            pnl.Location = new Point(388, 0);
            pnl.Width = 10;
            pnl.Height = 666;
            aboutme = new Label();
            aboutme.AutoSize = true;    
            pnl.BackColor = SystemColors.ScrollBar;   
            infopanel = new FlowLayoutPanel();
            infopanel.Location = new Point(95, 360);
            infopanel.BackColor = Color.White;
            infopanel.BorderStyle = BorderStyle.FixedSingle;
            infopanel.AutoScroll = true;
            infopanel.WrapContents = true;
            infopanel.HorizontalScroll.Visible = false;
            infopanel.Width = 200;
            infopanel.Height = 115;
            //if (Properties.Settings.Default.theme == "светлая")
            //{
            //    infopanel.BackColor = Color.White;

            //}
            //if (Properties.Settings.Default.theme == "темная")
            //{
            //    infopanel.BackColor = Color.FromArgb(96, 96, 96);
            //}
            infopanel.Controls.Add(aboutme);

     

            this.Controls.Add(labelnameage);
            this.Controls.Add(profileimage);
            this.Controls.Add(editprofile);
            //this.Controls.Add(messages);
            //this.Controls.Add(notifications);
            //this.Controls.Add(findcouple);
            this.Controls.Add(pnl);
            this.Controls.Add(infopanel);
            //this.Controls.Add(options);
            this.Controls.Add(textinfo);
            SocialGUI();
        }
        public void SocialGUI()
        {
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
            findcouple.Click += CopuleFindGUI;
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
            this.Controls.Add(options);
            this.Controls.Add(findcouple);
            this.Controls.Add(notifications);
            this.Controls.Add(messages);
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
            buttonfocus.Focus();
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

            ThemeChanged();
        }
        public void form4closed(object sender, EventArgs e)
        {
            DataLoad();
        }
        private void CopuleFindGUI(object sender, EventArgs e)
        {


            //string connectionString = "mongodb://localhost:27017";
            //MongoClient client = new MongoClient(connectionString);
            //var database = client.GetDatabase("оДНОгруппники");
            //var collection = database.GetCollection<BsonDocument>("accounts");
            //string[] massname = { "null", "Sddddddds", "Jhgjdhg", "Женщинаодин", };
            //var filter = new BsonDocument("$and", new BsonArray{

            //    //new BsonDocument("name",$"{massname}"),
            //    new BsonDocument("age",new BsonDocument("$gte", Properties.Settings.Default.agemin)),
            //    new BsonDocument("age",new BsonDocument("$lte",  Properties.Settings.Default.agemax) ),
            //    new BsonDocument("gender",$"{Properties.Settings.Default.genderfind}" )
            //});



            profileimageCF = new PictureBox();
            profileimageCF.Location = new Point(545, 43);
            profileimageCF.Width = 200;
            profileimageCF.Height = 220;
            profileimageCF.SizeMode = PictureBoxSizeMode.StretchImage;
            profileimageCF.BorderStyle = BorderStyle.FixedSingle;
            labelnameageCF = new Label();
            labelnameageCF.Location = new Point(545, 18);
            labelnameageCF.Width = 200;
            labelnameageCF.TextAlign = ContentAlignment.MiddleCenter;
            textinfoCF = new Label();
            textinfoCF.Location = new Point(545, 300);
            textinfoCF.Text = "О себе:";
            aboutmeCF = new Label();
            aboutmeCF.AutoSize = true;
            infopanelCF = new FlowLayoutPanel();
            infopanelCF.Location = new Point(545, 330);
            infopanelCF.BackColor = Color.White;
            infopanelCF.BorderStyle = BorderStyle.FixedSingle;
            infopanelCF.AutoScroll = true;
            //infopanelCF.WrapContents = true;
            infopanelCF.HorizontalScroll.Visible = false;
            infopanelCF.Width = 200;
            infopanelCF.Height = 115;
            infopanelCF.Controls.Add(aboutmeCF);
            backbutton = new Button();
            backbutton.Text = "Назад";
            backbutton.Width = 75;
            backbutton.Height = 23;
            backbutton.Location = new Point(430, 10);
            backbutton.FlatStyle = FlatStyle.Flat;
            backbutton.Click += backbt;


            dislike = new PictureBox();
            dislike.Location = new Point(570,530);
            dislike.Width = 40;
            dislike.Height = 40;
            dislike.SizeMode = PictureBoxSizeMode.StretchImage;
            dislike.Image = Properties.Resources.dislike;
            //dislike.Click += Dislike;

            like = new PictureBox();
            like.Location = new Point(670, 527);
            like.Width = 45;
            like.Height = 45;
            like.SizeMode = PictureBoxSizeMode.StretchImage;
            like.Image = Properties.Resources.like;
            //like.Click += Like;
            //var account = collection.Find(filter).ToList();
            //int count = 0;
            //foreach (var doc in account)
            //{
            //    count += 1;
            //}
            //bool key = false;
            //bool mainkey = false;
            //var acc = collection.Find(filter).Limit(1).ToList();
            //do
            //{
            //    count -= 1;
            //    key = false;
            //    mainkey = false;
            //    foreach (var doc in acc)
            //    {
            //        for (int i = 0; i < massname.Length; i++)
            //        {
            //            if (massname[i] == $"{doc.GetValue("name")}")
            //            {
            //                key = true;
            //            }
            //            else {/* acc = collection.Find(filter).Skip(i).Limit(1).ToList();*/ }
            //            if (key == true)
            //            {
            //                mainkey = false;
            //                acc = collection.Find(filter).Skip(i).Limit(1).ToList();

            //            }
            //            else
            //            {
            //                mainkey = true;
            //                labelnameageCF.Text = $"{doc.GetValue("name")}, {doc.GetValue("age")}";
            //                BsonValue bs = null;
            //                byte[] photoimg = null;
            //                bs = doc.GetValue("photo");
            //                photoimg = bs.AsByteArray;
            //                MemoryStream ms = new MemoryStream(photoimg, 0, photoimg.Length);
            //                profileimageCF.Image = new Bitmap(ms);
            //            }
            //        }

            //    }
            //    if (count == 0)
            //    { mainkey = true; }    
            //}
            //while (mainkey == false);
            FindCoupleData();
            if (labelnameageCF.Text == "")
            { MessageBox.Show("Не найдено анкет с выбранными параметрами"); }
            else
            {
                this.Controls.Remove(options);
                this.Controls.Remove(messages);
                this.Controls.Remove(notifications);
                this.Controls.Remove(findcouple);


                this.Controls.Add(profileimageCF);
                this.Controls.Add(labelnameageCF);
                this.Controls.Add(infopanelCF);
                this.Controls.Add(textinfoCF);
                this.Controls.Add(backbutton);
                this.Controls.Add(like);
                this.Controls.Add(dislike);
            }

        }
        private void backbt(object sender, EventArgs e)
        {
            this.Controls.Remove(profileimageCF);
            this.Controls.Remove(labelnameageCF);
            this.Controls.Remove(infopanelCF);
            this.Controls.Remove(textinfoCF);
            this.Controls.Remove(backbutton);
            this.Controls.Remove(like);
            this.Controls.Remove(dislike);
            SocialGUI();
        }
        private void FindCoupleData()
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase("оДНОгруппники");
            var collection = database.GetCollection<BsonDocument>("accounts");
            string[] massname = { "null", "Sddddddds", "Jhgjdhg", "Женщинаодин", };
            var filter = new BsonDocument("$and", new BsonArray{

                //new BsonDocument("name",$"{massname}"),
                new BsonDocument("age",new BsonDocument("$gte", Properties.Settings.Default.agemin)),
                new BsonDocument("age",new BsonDocument("$lte",  Properties.Settings.Default.agemax) ),
                new BsonDocument("gender",$"{Properties.Settings.Default.genderfind}" )
            });
            var account = collection.Find(filter).ToList();
            int count = 0;
            foreach (var doc in account)
            {
                count += 1;
            }
            bool key = false;
            bool mainkey = false;
            var acc = collection.Find(filter).Limit(1).ToList();
            do
            {
                count -= 1;
                key = false;
                mainkey = false;
                foreach (var doc in acc)
                {
                    for (int i = 0; i < massname.Length; i++)
                    {
                        if (massname[i] == $"{doc.GetValue("name")}")
                        {
                            key = true;
                        }
                        else {/* acc = collection.Find(filter).Skip(i).Limit(1).ToList();*/ }
                        if (key == true)
                        {
                            mainkey = false;
                            acc = collection.Find(filter).Skip(i).Limit(1).ToList();

                        }
                        else
                        {
                            mainkey = true;
                            labelnameageCF.Text = $"{doc.GetValue("name")}, {doc.GetValue("age")}";
                            BsonValue bs = null;
                            byte[] photoimg = null;
                            bs = doc.GetValue("photo");
                            photoimg = bs.AsByteArray;
                            MemoryStream ms = new MemoryStream(photoimg, 0, photoimg.Length);
                            profileimageCF.Image = new Bitmap(ms);
                        }
                    }

                }
                if (count <= 0)
                { mainkey = true; }
            }
            while (mainkey == false);
        }


        private void Button5_Click(object sender, EventArgs e)
        {

        }
    }
}
