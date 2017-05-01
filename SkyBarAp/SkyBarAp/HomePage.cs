using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;


namespace SkyBarAp
{
    public partial class HomePage : Form
    {

        public HomePage()
        {
            InitializeComponent();
        }

        
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
         
                Management m = new Management();
                this.Hide();
                m.ShowDialog();
               
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Management m = new Management();
            this.Hide();
            m.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            
        }
    }
}
