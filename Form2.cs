using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace File_Manager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //variables
            string userName = textBox1.Text;
            string password = textBox2.Text;

            //checks if password is over 8 
            if (password.Length > 8)
            {
                //over 8
                MessageBox.Show("Error. Password cant be over 8 characters", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //saves password and username
                File.WriteAllText("userName.txt", userName);
                File.WriteAllText("password.txt", password);

                //back to log in
                this.Hide();
                var form1 = new form1();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            
           


            


        }

        
    }
}
