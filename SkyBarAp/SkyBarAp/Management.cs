using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Oracle.DataAccess;
//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;
namespace SkyBarAp
{
    public partial class Management : Form
    {
         OracleConnection con;
         OracleDataReader reader,reader1;
       
        //OracleDataReader reader;
        public Management( )
        {
            
            InitializeComponent();
        }

        int count;
        // user and password bartender
		String userName;
		String passWord;
        int attemp = 3;
        //user and password admin
        String userName1;
        String passWord1;
		
        int attemp1 = 3;
        string p,p1;
        string a,a1;
       
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
             
           HomePage h = new HomePage();
            this.Hide();
            h.ShowDialog();
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            textUserBat.Focus();
           // orderBtn.Enabled = false;
            managementbtn.Enabled = false;
        }

        private void managementbtn_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox2.Visible = false;
            textUserA.Focus();
           // managementbtn.Enabled = false;
            orderBtn.Enabled = false;
        }

        private void LoginBarten_Click(object sender, EventArgs e)
        {
           

            userName = this.textUserBat.Text;
            passWord = this.textPassBat.Text;


            OracleCommand cmd1 = new OracleCommand("select name,worker_id from bartender ", con);
            cmd1.CommandType = CommandType.Text;

            cmd1.Parameters.Add("name", OracleDbType.Varchar2, ParameterDirection.Output);
            cmd1.Parameters.Add( "worker_id", OracleDbType.Varchar2, ParameterDirection.Output);
            reader = cmd1.ExecuteReader();

            while(reader.Read())
            {

                p = reader["worker_id"].ToString();
               a = reader["name"].ToString();
               count++;
            }



          /*  if (userName != a || passWord != p )
            {
                attemp--;


                if (attemp == 2 || attemp == 1)
                {*/
            if (userName != a || passWord != p)
            {
                System.Windows.Forms.DialogResult response; response = MessageBox.Show("Credential Mismatch. Would you like to re-enter user and password ?", "ERROR....", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == System.Windows.Forms.DialogResult.Yes)
                {
                    textUserBat.Clear();
                    textUserBat.Focus();
                    textPassBat.Clear();
                    count++;
                }
                else
                    Application.Exit();
            }
          
                
              // }
                  
               
             // }
           // else
                if ((userName == a || passWord == p ))
                {
                    //ManagementForm m =new Orderform(con,userName,passWord);
                    OrderForm o = new OrderForm(con,userName,passWord);
                     this.Hide();
                    o.ShowDialog();
                    
                   
                }
           

        }

        private void LogAdmin_Click(object sender, EventArgs e)
        {

            userName1 = this.textUserA.Text;
            passWord1 = this.textPassAdmin.Text;

            OracleCommand cmd2 = new OracleCommand("select name,password from manager ", con);
            cmd2.CommandType = CommandType.Text;

            cmd2.Parameters.Add("name", OracleDbType.Varchar2, ParameterDirection.Output);
            cmd2.Parameters.Add("password", OracleDbType.Varchar2, ParameterDirection.Output);
            reader1 = cmd2.ExecuteReader();

            while (reader1.Read())
            {

                p = reader1["password"].ToString();
                a = reader1["name"].ToString();
                count++;
            }

          /*  if (userName1 != a || passWord1 != p)
            {
                attemp1--;


                if (attemp1 == 2 || attemp1 == 1)
                {*/
             if (userName1 != a || passWord1 != p)
             {  System.Windows.Forms.DialogResult response;
             response = MessageBox.Show("Credential Mismatch. Would you like to re-enter user and password ? ", "ERROR....",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (response == System.Windows.Forms.DialogResult.Yes)
                    {
                        textUserA.Clear();
                        textUserA.Focus();
                        textPassAdmin.Clear();
                        
                    }
                 else
                    Application.Exit();
                }
              //  else// if (attemp1 == 0)
              //      Application.Exit();
                  //}

            
                if ((userName1 == a || passWord1 == p) )
               {

                ManagementForm o = new ManagementForm(con, userName1, passWord1);
                this.Hide();
                o.ShowDialog();
            }
                     
        }

        private void ResBarten_Click(object sender, EventArgs e)
        {
            textUserBat.Clear();
            textPassBat.Clear();
            textUserBat.Focus();
        }

        private void ResAdmin_Click(object sender, EventArgs e)
        {
            textUserA.Clear();
            textPassAdmin.Clear();
            textUserA.Focus();
        }

        private void CanBarten_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            managementbtn.Enabled = true;
            orderBtn.Enabled = true;

        }

        private void CanAdmin_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            managementbtn.Enabled = true;
            orderBtn.Enabled = true;

        }

        private void Management_Load(object sender, EventArgs e)
        {
            con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=system;Password=papa;");
            con.Open();
           
        }
    }
}
