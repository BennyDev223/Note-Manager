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
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        private void form1_Load(object sender, EventArgs e)
        {

        }
        

        private void label4_Click(object sender, EventArgs e)
        {
            //goes to Log in page
            this.Hide();
            var form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if file is real start check
            if (File.Exists("userName.txt") && File.Exists("password.txt"))
            {
                //account made already
                string user = File.ReadAllText("userName.txt");
                string pass = File.ReadAllText("password.txt");         
                

                //checks if correct
                if (textBox1.Text == user && textBox2.Text == pass)
                {
                    //correct go to files page
                    this.Hide();
                    var form3 = new Form3();
                    form3.Closed += (s, args) => this.Close();
                    form3.Show();
                }
                else
                {
                    //acount info wrong
                    MessageBox.Show("Error... Account Info Incorrect Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //no account
                MessageBox.Show("Error... Please Make an Account Before Logging in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
