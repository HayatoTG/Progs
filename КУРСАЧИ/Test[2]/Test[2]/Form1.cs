using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MongoDB.Driver;
using MongoDB.Bson;


namespace Test_2_
{
    public partial class Form1 : Form
    {
        int key;
        bool l = false;
        bool l2 = false;
        bool l3 = false;
        bool l4 = false;
        bool l5 = false;
        public Form1()
        {
            
            InitializeComponent();
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            First();
        }
        public void First()
        {
            label1 = new Label();
            label1.Text = "Вход";
            label1.Location = new Point(185,9);
            label1.Size = new Size(70, 26);
            label1.Font = new Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            label1.BackColor = /*Color.Transparent */SystemColors.ActiveCaption;
            this.Controls.Add(label1);
            panel1 = new Panel();
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Size = new Size(444, 48);
            this.Controls.Add(this.panel1);       
            tx1 = new TextBox();
            tx1.MaxLength = 25;
            tx1.Size = new Size(192, 20);
            tx1.Location = new Point(138, 118);
            tx1.Text = "Введите номер телефона или почту";
            tx1.ForeColor = Color.Gray;
            tx1.TabStop = false;
            tx1.Enter += Login_Enter;
            tx1.Leave += Login_Leave;
            this.Controls.Add(tx1);
            tx2 = new TextBox();
            tx2.TabStop = false;
            tx2.MaxLength = 25;
            tx2.Size = new Size(160, 20);
            tx2.Location = new Point(141, 171);
            tx2.Text = "Введите пароль";
            tx2.UseSystemPasswordChar = false;
            tx2.ForeColor = Color.Gray;
            tx2.Enter += Password_Enter;
            tx2.Leave += Password_Leave;
            this.Controls.Add(tx2);
            ch1 = new CheckBox();
            ch1.Location = new Point(141, 197);
            ch1.Size = new Size(114, 17);
            ch1.Text = "Показать пароль";
            ch1.Click += Chpass;
            this.Controls.Add(ch1);
            label2 = new Label();
            label2.Size = new Size(179, 15);
            label2.Location = new Point(135, 261);
            label2.Text = "* Еще не зарегистрированы ?";
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic);
            label2.Cursor =  Cursors.Hand;
            label2.Click += reg;  
            this.Controls.Add(label2);
            bt3 = new Button();
            bt3.Text = "Войти";
            bt3.Font = new Font("Microsoft Sans Serif", 16F);
            bt3.Size = new Size(102, 46);
            bt3.Location = new Point(173, 309);
            bt3.Cursor = Cursors.Hand;
            bt3.Click += en;
            this.Controls.Add(bt3);
        }
        
      


        public void en(object sender, EventArgs e)
        {
            string connection = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connection);
            var database = client.GetDatabase("Proga");
            var collection = database.GetCollection<BsonDocument>("+++");
            var filter = new BsonDocument
            {
                 {"Phone",$" {tx1.Text}"},
                {"Password",$" {tx2.Text}"}
            };
            var filter2 = new BsonDocument
            {

                 {"Snil",$" {tx1.Text}"},
                {"Password",$" {tx2.Text}"}
            };
            var account = collection.Find(filter).ToList();
            var account2 = collection.Find(filter2).ToList();
            BsonDocument acc = new BsonDocument
            {
                {"Phone",$" {tx1.Text}"},
                {"Password",$" {tx2.Text}"}
            };
            BsonDocument acc2 = new BsonDocument
            {
                {"Snil",$" {tx1.Text}"},
                {"Password",$" {tx2.Text}"}
            };
            //BsonDocument acc = new BsonDocument();
            bool key = false;
            if (tx1.Text != "" && tx2.Text != "")
            {
                foreach (var doc in account)
                {
                    key = true;
                    MessageBox.Show("Ура!");
                    var a = acc.ToString();
                    MessageBox.Show(a);
                    //this.Close();

                }
                foreach (var doc2 in account2)
                {
                    key = true;
                    MessageBox.Show("Ура!");
                    var a = acc2.ToString();
                    MessageBox.Show(a);
                    //this.Close();

                }
                if (key == false) MessageBox.Show("Нет такого пользователя.");
            }
            else
                MessageBox.Show("Введите все поля");


        }
        public void reg(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Reg();
        }
        public void Reg()
        {
            label = new Label();
            label.Location = new Point(145, 9);
            label.Size = new Size(152, 26);
            label.Text = "Регистрация";
            label.Font = new Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            label.BackColor = SystemColors.ActiveCaption;
            this.Controls.Add(label);
            panel1 = new Panel();
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Size = new Size(444, 48);
            this.Controls.Add(this.panel1);
            surname = new TextBox(); 
            surname.Location = new Point(68, 81);
            surname.Size = new Size(180, 20);
            surname.Text = "Введите фамилию";
            surname.ForeColor = Color.Gray;
            surname.MaxLength = 25;
            surname.MouseEnter += (s, e) => { help1.Text = "Введите фамилию. Используя кириллицу А-я"; };
            surname.MouseLeave += (s, e) => { help1.Text = ""; };
            surname.Enter += surname_Enter;
            surname.TextChanged += Surn;
            surname.Leave += surname_Leave;
            this.Controls.Add(this.surname);
            name = new TextBox();
            name.Location = new Point(68, 131);
            name.Size = new Size(180, 20);
            name.Text = "Введите имя";
            name.ForeColor = Color.Gray;
            name.MaxLength = 20;
            name.MouseEnter += (s, e) => { help2.Text = "Введите имя. Используя кириллицу А-я"; };
            name.MouseLeave += (s, e) => { help2.Text = ""; };
            name.Enter += name_Enter;
            name.TextChanged += Nam;
            name.Leave += name_Leave;
            this.Controls.Add(this.name);
            phone = new TextBox();
            phone.Location = new Point(68, 181);
            phone.Size = new Size(180, 20);
            phone.Text = "Введите номер телефона";
            phone.ForeColor = Color.Gray;
            phone.MaxLength = 12;
            phone.Enter += phone_Enter;
            phone.Leave += phone_Leave;
            this.Controls.Add(this.phone);
            email = new TextBox();
            email.Location = new Point(68, 231);
            email.Size = new Size(180, 20);
            email.Text = "Электронная почта";
            email.ForeColor = Color.Gray;
            email.Click += (s, e) =>
            {
                combox = new ComboBox();//нет ключа
                combox.DropDownStyle = ComboBoxStyle.DropDownList;
                combox.Location = new Point(300, 231);
                combox.Size = new Size(100, 20);
                combox.Items.AddRange(new object[] {
                    "@mail.ru",
                    "@gmail.com",
                    "@yandex.ru"});
                combox.SelectedIndex = 0;
                this.Controls.Add(this.combox);

            };
            email.Enter += email_Enter;
            email.Leave += email_Leave;
            this.Controls.Add(this.email);
            maskedtBox1 = new MaskedTextBox();
            maskedtBox1.Location = new Point(68, 281);
            maskedtBox1.Mask = "000-000-000-00";
            maskedtBox1.Size = new Size(180, 20);
            maskedtBox1.Click += Och;
            //maskedtBox1.Click += Prov;
            this.Controls.Add(this.maskedtBox1);
            tx2.Location = new Point(68, 331);
            tx2.Size = new Size(180, 20);
            tx2.Text = "Введите пароль";
            tx2.UseSystemPasswordChar = false;
            tx2.ForeColor = Color.Gray;
            tx2.TextChanged += CHek;
            tx2.Enter += Password_Enter;
            tx2.Leave += Password_Leave;
            //tx2.MouseEnter += TxEnter;
            this.Controls.Add(this.tx2);
            ch1 = new CheckBox();
            ch1.Text = "Показать пароль";
            ch1.Location = new Point(71, 357);
            ch1.Size = new Size(114, 17);
            ch1.Click += Chpass;
            this.Controls.Add(ch1);
            regist = new Button();
            regist.Text = "Зарегистрироваться";
            regist.Font = new Font("Microsoft Sans Serif", 16F);
            regist.Size = new Size(234, 35);
            regist.Location = new Point(105, 414);
            regist.Click += Prov;
            this.Controls.Add(regist);
            back = new Label();
            back.Text = "Назад";
            back.Font = new Font("Microsoft Sans Serif", 9F);
            back.Size = new Size(43, 15);
            back.Location = new Point(12, 414);
            back.Click += Form1_Load;
            this.Controls.Add(back);
            label0 = new Label();
            this.Controls.Add(label0);
            help = new Label();
            help.Location = new Point(68, 315);
            help.Size = new Size(0, 13);
            help.AutoSize = true;
            this.Controls.Add(help);
            help1 = new Label();
            help1.Location = new Point(68, 65);
            help1.Size = new Size(0, 13);
            help1.AutoSize = true;
            this.Controls.Add(help1);
            help2 = new Label();
            help2.Location = new Point(68, 115);
            help2.Size = new Size(0, 13);
            help2.AutoSize = true;
            this.Controls.Add(help2);
            help3 = new Label();
            help3.Location = new Point(68, 165);
            help3.Size = new Size(0, 13);
            help3.AutoSize = true;
            this.Controls.Add(help3);
            help4 = new Label();
            help4.Location = new Point(68, 215);
            help4.Size = new Size(0, 13);
            help4.AutoSize = true;
            this.Controls.Add(help4);
            help5 = new Label();
            help5.Location = new Point(68, 265);
            help5.Size = new Size(0, 13);
            help5.AutoSize = true;
            this.Controls.Add(help5);
        }
        public void Mobil(object sender, EventArgs e)
        {
            bool Q = Regex.IsMatch(phone.Text, @"^[+][7]{1}[9]{1}\d{9}$");
            //if ()
            //bool Q = Regex.IsMatch(phone.Text, @"^[+][7]{1}[9]{1}\d{10}$");
            if (Q == true)
            {
                l2 = true;
            }
            else l2 = false;
            //MessageBox.Show(phone.Text);
        }
        public void CHek(object sender, EventArgs e)
        {
            //Regex.IsMatch(tx2.Text, @"^(?>\d()|[a-z]()|[A-Z]()){8,}(?=\1\2\3)$");
            //tx2.Text =tx2.Text.Replace("  ", "");
            //tx2.SelectionStart = tx2.Text.Length;
            bool A = Regex.IsMatch(tx2.Text, @"(?=\d)");
            bool B = Regex.IsMatch(tx2.Text, @"(?=([-+_@.\\,/*%!;:?<>$&^~`]))");
            //bool l = Regex.IsMatch(pass, @"([\/*+@#%^""&!?,:$_~;'])");
            bool i = Regex.IsMatch(tx2.Text, @"(?=.*[A-Z])");
            bool p = Regex.IsMatch(tx2.Text, @"(?=.*[a-z])");
            bool I = Regex.IsMatch(tx2.Text, @"(?=.*[А-Я])");
            bool P = Regex.IsMatch(tx2.Text, @"(?=.*[а-я])");

            if (tx2.Text != "Введите пароль")
            {
                tx2.Text = tx2.Text.Replace(" ", "");
                tx2.SelectionStart = tx2.Text.Length;
                if ((A == true || i == true || p == true)) { help.Text = "легкий пароль"; l = false; }
                if (A == true || I == true || P == true) { help.Text = "легкий пароль"; l = false; }
                if (tx2.Text.Length > 11) if (B == true && A == true) { help.Text = "Сложность пароля:**"; l = true; }
                if (tx2.Text.Length >= 8)
                {

                    if (B == true || A == true)
                    {
                        if (i == true || p == true) { help.Text = "Сложность пароля:**"; l = true; }
                        if (I == true || P == true) { help.Text = "Сложность пароля:**"; l = true; }
                    }
                    else
                    {
                        if (i == true && p == true) { help.Text = "Сложность пароля:**"; l = true; }
                        if (I == true && P == true) { help.Text = "Сложность пароля:**"; l = true; }
                    }
                }
                if (tx2.TextLength > 5)
                {
                    if (A == true && B == true)
                    {
                        if (i == true || I == true)
                        {
                            if (p == true || P == true) { help.Text = "Сложность пароля:***"; l = true; }
                            else key = 3;
                        }
                        else
                        {
                            if (p == true || P == true) { help.Text = "Сложность пароля:***"; l = true; }
                        }

                    }
                    if (A == true || B == true)//(...?) 
                    {
                        if (i == true || I == true)
                        {
                            if (p == true || P == true)
                            { help.Text = "Сложность пароля:***"; l = true; }
                        }

                    }
                    if (A == true && B == true)//(...?) 
                    {
                        if (i == true || I == true)
                        {
                            if (p == true || P == true)
                            {
                                l = true;
                                help.Text = "Сложность пароля:****";
                            }
                        }
                    }
                    //  help.Text = "";
                    // p.BackColor = Color.Green;
                    //help.Text = "Отличный пароль (Нет)";
                    // lor = true;
                    //if (key == 1) MessageBox.Show("Сложность пароля:*");
                    //if (key == 2) MessageBox.Show("Сложность пароля:**");
                    //if (key == 3) MessageBox.Show("Сложность пароля:***");//№?
                    //if (key == 4) MessageBox.Show("Сложность пароля:****");
                }
            }
            else
            {
                help.Text = "";
                //picture.BackColor = Color.White;
                l = false;
            }

        }
        public void Snil(object sender, EventArgs e)
        {
            help3.Visible = false;
            maskedtBox1.Mask = "00000000000";
            help3.Text = maskedtBox1.Text;
            maskedtBox1.Mask = "000-000-000-00";
            if (help3.Text != "")
            {
                //MessageBox.Show(help3.Text);
                int c = int.Parse(help3.Text.Substring(9, 2));
                string cs = help3.Text.Substring(9, 2);
                int totalSum = 0;

                help3.Text = help3.Text.Remove(9, 2);
                for (int i = help3.Text.Length - 1, j = 0; i >= 0; i--, j++)
                {
                    int digit = int.Parse(help3.Text[i].ToString());
                    totalSum += digit * (j + 1);
                }
                //MessageBox.Show(totalSum + " " + cs);
                if (totalSum < 100)
                {
                    if (c == totalSum)
                    {
                        help3.Text = help3.Text + c;
                        //MessageBox.Show("Вы вошли");
                        l5 = true;
                    }
                    else/* MessageBox.Show("Вы ошиблись");//ключ*/l5 = false;
                }

                else if (totalSum == 100 || totalSum == 101)
                {
                    //MessageBox.Show("Вы вошли");
                    help3.Text = help3.Text + c;
                    l5 = true;
                }

                else if (totalSum > 101)
                {
                    decimal qw = totalSum % 101;
                    qw = Math.Round(qw, 2);
                    if (qw == 0)
                    {
                        l5 = true;
                        help3.Text = help3.Text + c;
                        //MessageBox.Show("Вы вошли");
                        //textBox1.Text = textBox1.Text + cs;
                    }
                    else if (c == qw)
                    {
                        //textBox1.Text = textBox1.Text + c;
                        //MessageBox.Show("Вы вошли");
                        l5 = true;
                        help3.Text = help3.Text + c;
                    }
                    else
                    {
                        if (qw == 100 || qw == 101)
                        {
                            l5 = true;
                            help3.Text = help3.Text + c;
                            //MessageBox.Show("Вы вошли");
                            //textBox1.Text = textBox1.Text + cs;
                        }
                        else /*MessageBox.Show("Вы ошиблись");*/l5 = false;

                    }

                }
                else
                {
                    l5 = false;
                    //MessageBox.Show("Вы ошиблись");
                }
            }
            //else MessageBox.Show("Я пуст");
        }
        public void Nam(object sender, EventArgs e)
        {
            firstCharToUpper(name);
            AllCharToUpper(name);
            //////EmptySring(textBox4, errorProvider1);
            bool A = Regex.IsMatch(name.Text, @"(?=\d)");
            bool S = Regex.IsMatch(name.Text, @"[^A-z]");
            bool B = Regex.IsMatch(name.Text, @"(?=([-+_@.\\,/*%!'?;:<>$&^~`""]))");
            if (name.Text.Length > 1)
            {
                name.Text = name.Text.Replace("  ", "");
                name.SelectionStart = name.Text.Length;
                if (A == false && S == true && B == false)
                {
                    help2.Text = "";
                    l4 = true;
                }
                else
                {
                    l4 = false;
                    help2.Text = "Имя не может содержать такие символы";
                }
            }
        }
        private void Surn(object sender, EventArgs e)
        {
            //EmptySring(textBox4, errorProvider1);
            bool A = Regex.IsMatch(surname.Text, @"(?=\d)");
            bool S = Regex.IsMatch(surname.Text, @"[^A-z]");
            bool B = Regex.IsMatch(surname.Text, @"(?=([-+_@.\\,/*%!'?;:<>$&^~`""]))");
            if (surname.Text != "")
            {
                surname.Text = surname.Text.Replace("  ", "");
                surname.SelectionStart = surname.Text.Length;
                if (A == false && S == true && B == false && name.Text.Length > 1)
                {
                    help1.Text = "";
                    firstCharToUpper(surname);
                    AllCharToUpper(surname);
                    //help1.Text = "";
                    l3 = true;
                }
                else
                {
                    l3 = false;
                    help1.Text = "Фамилия не может содержать такие символы";
                }
            }
        }
        public void  Och(object sender, EventArgs e)
        {
            maskedtBox1.Text = "";
        }
        public void Prov(object sender, EventArgs e)
        {
            
            Snil(maskedtBox1, e);
            Mobil(phone, e);
            if (surname.Text != "" && name.Text != "" && phone.Text != "" && email.Text != "" && help3.Text != "" && tx2.Text != "")
            {
                string connection = "mongodb://localhost:27017";
                MongoClient client = new MongoClient(connection);
                var database = client.GetDatabase("Proga");
                var collection = database.GetCollection<BsonDocument>("+++");
                BsonDocument acc = new BsonDocument
                    {
                        {"Name",$" {name.Text}"},
                        {"Surname",$" {surname.Text}"},
                        {"Phone",$" {phone.Text}"},
                        {"Mail",$" {email.Text}"},
                        {"Snil",$" {help3.Text}"},
                        {"Password",$" {tx2.Text}"}
                    };
                if (l3 == true && l4 == true && l2 == true && l5 == true && l == true)
                {
                    MessageBox.Show("Вы зарегистрированы в приложении <>");
                    collection.InsertOne(acc);
                }
                else MessageBox.Show("ERROR");
            }
            else MessageBox.Show("Все поля должны быть заполнены");
            //Snil(maskedtBox1,e);
            //if (l == true && l2 == true)
            //{
            //    MessageBox.Show("Запуск...");
            //}
            
        }
        public void Login_Enter(object sender, EventArgs e)
        {
            if (tx1.Text == "Введите номер телефона или почту")
            {
                tx1.Text = "";
                tx1.ForeColor = Color.Black;                
            }
        }
        public void Login_Leave(object sender, EventArgs e)
        {
            if (tx1.Text == "")
            {
                tx1.Text = "Введите номер телефона или почту";
                tx1.ForeColor = Color.Gray;
            }
        }
        public void surname_Enter(object sender, EventArgs e)
        {
            if (surname.Text == "Введите фамилию")
            {
                surname.Text = null;
                surname.ForeColor = Color.Black;

            }
        }
        public void surname_Leave(object sender, EventArgs e)
        {
            if (surname.Text == "")
            {
                surname.Text = "Введите фамилию";
                surname.ForeColor = Color.Gray;
            }
        }
        public void name_Enter(object sender, EventArgs e)
        {
            if (name.Text == "Введите имя")
            {
                name.Text = "";
                name.ForeColor = Color.Black;
            }
        }
        public void name_Leave(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                name.Text = "Введите имя";
                name.ForeColor = Color.Gray;
            }
        }
        public void email_Enter(object sender, EventArgs e)
        {
            if (email.Text == "Электронная почта")
            {
                email.Text = "";
                email.ForeColor = Color.Black;
            }
        }
        public void email_Leave(object sender, EventArgs e)
        {
            if (email.Text == "")
            {
                email.Text = "Электронная почта";
                email.ForeColor = Color.Gray;
            }
        }
        public void phone_Enter(object sender, EventArgs e)
        {
            if (phone.Text == "Введите номер телефона")
            {
                phone.Text = "";
                phone.ForeColor = Color.Black;
            }
        }
        public void phone_Leave(object sender, EventArgs e)
        {
            if (phone.Text == "")
            {
                phone.Text = "Введите номер телефона";
                phone.ForeColor = Color.Gray;
            }
        }
        public void Password_Enter(object sender, EventArgs e)
        {
            if (tx2.Text == "Введите пароль")
            {
                tx2.Text = "";
                tx2.UseSystemPasswordChar = true;
                tx2.ForeColor = Color.Black;
            }
        }
        public void Password_Leave(object sender, EventArgs e)
        {
            if (tx2.Text == "")
            {
                tx2.Text = "Введите пароль";
                tx2.UseSystemPasswordChar = false;
                tx2.ForeColor = Color.Gray;
            }
        }
        public void Chpass(object sender, EventArgs e)
        {
            if (tx2.UseSystemPasswordChar == true || tx2.Text == "Введите пароль") tx2.UseSystemPasswordChar = false;
            else tx2.UseSystemPasswordChar = true;
        }
        public void firstCharToUpper(TextBox tb)
        {
            if (tb.Text.Length == 1)
                tb.Text = tb.Text.ToUpper();
                tb.Select(tb.Text.Length, 0);
            
        }
        public void AllCharToUpper(TextBox tb)
        {
            tb.Text = Regex.Replace(tb.Text, @"\B[A-ZА-Я]", m => m.ToString().ToLower());
        }
    }
}
