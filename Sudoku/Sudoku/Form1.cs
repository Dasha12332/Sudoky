using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private RichTextBox[] rtb = new RichTextBox[81];

        private void buttonStart_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            Array.Clear(rtb, 0, rtb.Length);
            if (textBox1.Text != "" && Convert.ToInt32(textBox1.Text)<81 
                && Convert.ToInt32(textBox1.Text) > 0 && int.TryParse(textBox1.Text, out int n))
            {
                string url = "http://127.0.0.1/kursach/start1.php";
                WebClient client = new WebClient();
                NameValueCollection values = new NameValueCollection();
                values.Add("level", textBox1.Text);
                byte[] result = client.UploadValues(url, "POST", values);
                string ResultAuthTicket = Encoding.UTF8.GetString(result);
                string[] poleArr = ResultAuthTicket.Split(' ');
                for (int i = 0; i < 81; i++)
                {
                    rtb[i] = new RichTextBox();
                    rtb[i].SelectionAlignment = HorizontalAlignment.Center;
                    rtb[i].Font = new Font("Microsoft Sans Serif", 15.8F);
                    rtb[i].Text = poleArr[i];
                    tableLayoutPanel1.Controls.Add(rtb[i]);
                }
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            string url = "http://127.0.0.1/kursach/check.php";
            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            for(int i=0; i<81; i++)
            {
                values.Add("ps[" + i + "]", rtb[i].Text);
            }
            byte[] result = client.UploadValues(url, "POST", values);
            string check = Encoding.UTF8.GetString(result);
            MessageBox.Show(check);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 4.0f),  i * 504 / 4, 0, i*504 / 4, 504);
            }
            for (int i = 0; i < 5; i++)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 4.0f), 0, i * 543 / 4, 543, i * 543 / 4);
            }
        }
    }
}
