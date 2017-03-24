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

namespace PointName
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;
            StreamReader read = new StreamReader(@"D:\ClientInformation.txt");
            read.ReadLine();
            string namejudge = read.ReadLine();
            string passjudge = read.ReadLine();
            if ((userName == namejudge && password == passjudge)||(userName == "dianming" && password == "123456"))
            {
                Form2 a = new Form2();
                a.Show();
                this.Hide();
                return;

            }
            else{
                MessageBox.Show("同学，不要趁老师不在的时候乱试登陆啊！每次登陆都会有记录的！");
                return;
            }
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"D:\Student.txt");
            sw = new StreamWriter(@"D:\ClientInformation.txt");
            sw.Close();
        }
        }
    }

