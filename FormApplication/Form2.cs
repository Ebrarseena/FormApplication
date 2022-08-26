using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormApp
{
    public partial class Form2 : Form
    {
        DataTable tablo = new DataTable();
        public Form2()
        {
            InitializeComponent();
        }
        public void Form2_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                dataGridView1.Refresh();
            }
            timer1.Start();

            tablo.Columns.Add("ID");
            tablo.Columns.Add("Username", typeof(object));
            tablo.Columns.Add("Password", typeof(object));
            tablo.Columns.Add("Gender", typeof(string));
            tablo.Columns.Add("Age", typeof(int));
            tablo.Columns.Add("Work Status", typeof(String));
           
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tablo;

            MessageBox.Show("Login Successful!\n\nWelcome");

            textBox1.ReadOnly = true;
        }
        public void button1_Click(object sender, EventArgs e)
        {
            tablo.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            dataGridView1.DataSource = tablo;
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }

            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please fill in all blank fields!");
            }

            else
            {
                MessageBox.Show("Adding Successful!");
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
    }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Please select registration");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {           //Harf dışında herhangi bir sayı veya özel karakter girilememesi için
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !Char.IsSeparator(e.KeyChar);

            //IsLetter--> Belirtilen unicode karakterinin unicode harfi olarak kategorilere ayrılmadığını gösterir
            //IsControl--> Belirtilen unicode karakterinin bir denetim karakteri olarak kategorilere ayrılmadığını gösterir
            //IsSeparator--> Belirtilen dizedeki karakterinin ayırıcı karakter olarak kategorilere ayrılmadığını gösterir
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !Char.IsSeparator(e.KeyChar);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToLongTimeString();
        }

    }
}
