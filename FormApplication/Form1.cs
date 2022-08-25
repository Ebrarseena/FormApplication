﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormApp
{
    public partial class LOGİN : Form
    {
        public LOGİN()
        {
            InitializeComponent();
            Date.Text = DateTime.Now.ToLongDateString();
            textBox2.PasswordChar = '*';
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Form2 form = new Form2();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ebrar" && textBox2.Text == "1234")
            {
                Form2 form = new Form2();
                form.ShowDialog();
            }

            else if (textBox1.Text == "muhammet" && textBox2.Text == "1357")
            {
                Form2 form = new Form2();
                form.ShowDialog();
            }
                                              
            else if (textBox1.Text == "güven" && textBox2.Text == "0987")
            {
                Form2 form = new Form2();
                form.ShowDialog();
            }

            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please fill in all blank fields!");
            }

            else
            {
                MessageBox.Show("The user name or password entered is incorrect \n\t\tPlease try again.");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                e.Handled = true;
                button1.PerformClick();
                textBox1.Clear();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';  
            }

            else
            {
                textBox2.PasswordChar = '*';
            }
        }
      
    }
}
