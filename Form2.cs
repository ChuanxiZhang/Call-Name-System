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
    public partial class Form2 : Form
    {
        static string[] array;
        private int count = 0;
        int catch1 = 0;
        public Form2()
        {
            InitializeComponent();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Hide();
            panel3.Hide();
            OpenFileDialog a = new OpenFileDialog();
            if (a.ShowDialog() == DialogResult.OK)
            {
                StreamReader m_streamReader = new StreamReader(a.FileName, System.Text.Encoding.Default);
                string[] Array = a.SafeFileName.Split(new char[] { '.' });
                string strEnd = Array[Array.Length - 1];
                if (strEnd == "txt")
                {
                    try
                    {
                        m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);               
                        this.richTextBox1.Text = "";
                        string strLine = m_streamReader.ReadLine();
                        while (strLine != null)
                        {
                            this.richTextBox1.Text += strLine + "\n";
                            strLine = m_streamReader.ReadLine();
                        }
                      
                        m_streamReader.Close();
                        MessageBox.Show("名单读取完毕！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("请选择TXT文档", "ErrorMessage"); 
                    m_streamReader.Close(); 
                }

            }
            
            
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null)
            {
                MessageBox.Show("请输入完整的信息");
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("两次输入的密码不一致，请重新输入！");
                return;
            }
            else
            {
                StreamWriter sw = new StreamWriter(@"D:\ClientInformation.txt");
                sw.WriteLine("");
                sw.WriteLine(textBox1.Text);
                sw.WriteLine(textBox2.Text);
                sw.Close();
                panel1.Hide();
                panel2.Hide();
                panel3.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"D:\Student.txt");
            for (int i = 0; i < richTextBox1.Lines.Length; i++)  
            { 
                sw.WriteLine(richTextBox1.Lines[i]); 
            }
            sw.Close();
            MessageBox.Show("学生信息已录入点名系统！");
            panel2.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel2.Hide();
            panel1.Hide();
            string a;
            int n=0;
            StreamReader read = new StreamReader(@"D:\Student.txt");
            StreamReader read2 = new StreamReader(@"D:\Student.txt");
            while (read.ReadLine() != null)
            {
                n++;
            }
            read.Close();
            array=new string[n];
            for (int i = 0;(a= read2.ReadLine()) != null; i++) {
                array[i] = a;
            }
               
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            int j = count % array.Length;//循环得到该第几个数出现
            this.label4.Text = array[j].ToString();
            count++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            catch1++;
            if (catch1 % 2 == 0)
            {
                this.timer1.Enabled = false;
                button2.Text = "开始";
            
            }
            else
            {
                this.timer1.Enabled = true;
                button2.Text = "暂停";
                this.timer1.Interval = 1;
               
            }
        }
    }
}


