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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public void Form3_Load(object sender, EventArgs e)
        {
            //changes difffine
            string name = File.ReadAllText("userName.txt");
            string pass = File.ReadAllText("password.txt");
            

            //pass lenght *
            string[] pL = new string[8];

            for (int i = 0; i < pass.Length; i++)
            {
                //creates strings
                pL[i] = "*";
            }
            
            //lebels display
            label2.Text = "" + name;
            label4.Text = "Username: " + name;
            label8.Text = "Password: " + pL[0] + pL[1] + pL[2] + pL[3] + pL[4] + pL[5] + pL[6] + pL[7];
            
            

            //if notes exist write them
            if (File.Exists("notes.txt"))
            {
                string notes = File.ReadAllText("notes.txt");
                textBox1.Text = notes;
            }

            //if ran password file exist display block pass
            if (File.Exists("gPas.txt"))
            {
                //password already exist
                textBox2.Text = "Password: ********";
            }
            else
            {
                //no password yet
                textBox2.Text = "Password: ";
            }
            
            
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("you are about to log out are you sure?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //back to log in page
                this.Hide();
                var form1 = new form1();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //show password button pressed
            string pass = File.ReadAllText("password.txt");
            
            //checks if presed or not
            if (checkBox1.Checked)
            {
                //checked
                label8.Text = "Password: " + pass;
                checkBox1.Text = "Hide Password";

            }
            else
            {
                //pass lenght *   
                string[] pL = new string[8];

                for (int i = 0; i < pass.Length; i++)
                {
                    //creates strings
                    pL[i] = "*";
                }

                //not checked
                label8.Text = "Password: " + pL[0] + pL[1] + pL[2] + pL[3]+ pL[4] + pL[5] + pL[6] + pL[7];
                checkBox1.Text = "Show Password";
            }
        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            //creates save file of text box
            string notes = textBox1.Text;
            File.WriteAllText("notes.txt", notes);
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            //options
            string[] characters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "!", "@", "#", "%", "/", "?", "$", "*" };

            //random
            Random rnd = new Random();
            int random01 = rnd.Next(characters.Length);
            int random02 = rnd.Next(characters.Length);
            int random03 = rnd.Next(characters.Length);
            int random04 = rnd.Next(characters.Length);
            int random05 = rnd.Next(characters.Length);
            int random06 = rnd.Next(characters.Length);
            int random07 = rnd.Next(characters.Length);
            int random08 = rnd.Next(characters.Length);

            //change Display
            string gPassword = characters[random01] + characters[random02] + characters[random03] + characters[random04] + characters[random05] + characters[random06] + characters[random07] + characters[random08];
            label12.Text = "Password: " + gPassword;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //saves file of generated password
            string ranPassword = label12.Text;
            File.WriteAllText("gPas.txt", ranPassword);
            


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //hides password
            if (checkBox2.Checked)
            {
                textBox2.Text = "Password: ********";
            }
            else
            {
                //box unchecked
                if (File.Exists("gPas.txt"))
                {
                    string pRead = File.ReadAllText("gPas.txt");
                    textBox2.Text = pRead;
                }
                
            }
        }
    }
}
