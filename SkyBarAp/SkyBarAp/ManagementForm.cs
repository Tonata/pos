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
    public partial class ManagementForm : Form
    {

        string am;

        OracleDataReader reader, dr3,dr1;
        OracleCommand cd;
        int od;
         static String action;
         String cashiersID;
         OracleConnection conn;
         int currentOrderNumber;
         String cashier;
         int index;
		

        
        public ManagementForm(OracleConnection conn, String c, String id)
         {
             InitializeComponent();
             this.conn = conn;
             cashier=c;
             cashiersID=id;
         }


        private void insertbtn_Click(object sender, EventArgs e)
        {
             groupBox2.Enabled = false;
            textNumber.Focus();
            textNumber.Enabled = false;
            textNumber.Text = od.ToString();
            textName.Text = "";
            comboBox1.Text = "--Select a Supplier--";
            textPrice.Text = "";
            textQty.Text = "";
            textpicture.Clear();
            Width = 997;
            action ="InsertItem";

            
               
           
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

            if(listView1.SelectedItems.Count > 0)
			    {
  				 System.Windows.Forms.DialogResult reslt;
				 reslt=MessageBox.Show("Are you sure you want to edit this item record","Edit",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
				  if(System.Windows.Forms.DialogResult.Yes==reslt)
				  {
                    groupBox2.Enabled = false;
                    button2.Enabled = false; // reset button
			        textNumber.Enabled =false;
                    action = "EditItem";
                    Width = 997;
				  }
               }
		       else
			    MessageBox.Show("You must select an item","No item selected",MessageBoxButtons.OK,MessageBoxIcon.Warning);	
        }

        private void ManagementForm_Load(object sender, EventArgs e)
        {
             try
           {
           

		     // conn.Open();
               Width = 651;
			 refresh();
		   }
		   catch(Exception ex1)
		   {

		   }



            // this.reportViewer1.RefreshReport();
        }

        private void refresh() {

              OracleCommand cmd5 = new OracleCommand(" select  * from ITEM ", conn);
                       
             
              dr3 = cmd5.ExecuteReader();    
			 while(dr3.Read())
			 {
				 ListViewItem L3 = new  ListViewItem (dr3["ITEM_NUMBER"].ToString());
                 L3.SubItems.Add(dr3["ITEM_NAME"].ToString());
				 L3.SubItems.Add(dr3["SUPPLIER_ID"].ToString());
                 L3.SubItems.Add(dr3["UNIT_PRICE"].ToString());
                 L3.SubItems.Add(dr3["QUANTITY"].ToString());
                 L3.SubItems.Add(dr3["PICTURE_NAME"].ToString());
                 listView1.Items.Add(L3);

          
			 }

             OracleCommand cmd1 = new OracleCommand(" select  * from Supplier ", conn);
             reader = cmd1.ExecuteReader();
			 while(reader.Read())
			 {
                 comboBox1.Items.Add(reader["Supplier_id"].ToString());
			 }

             OracleCommand cmd = new OracleCommand(" select  * from Supplier ", conn);


             dr1 = cmd.ExecuteReader();
             while (dr1.Read())
             {
                 ListViewItem L3 = new ListViewItem(dr1["SUPPLIER_ID"].ToString());
                 L3.SubItems.Add(dr1["SUPPLIER_NAME"].ToString());
                 L3.SubItems.Add(dr1["ADDRESS"].ToString());
                 L3.SubItems.Add(dr1["TELEPHONE"].ToString());
                 L3.SubItems.Add(dr1["EMAIL"].ToString());
                 listView3.Items.Add(L3);


             }
             OracleCommand cmd3 = new OracleCommand(" select   ", conn);

		 }
        
        
        private void button4_Click(object sender, EventArgs e)
        {

            if (listView2.SelectedItems.Count > 0)
            {
                System.Windows.Forms.DialogResult reslt;
                reslt = MessageBox.Show("Are you sure you want to edit this supplier record", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (System.Windows.Forms.DialogResult.Yes == reslt)
                {
                    groupBox1.Enabled = false;
                    btReset.Enabled = false;
                    txtSNumber.Enabled = false;
                    txtSname.Focus();
                 
                    Width = 997;
                    action = "updateSupplier";
                }
            }
            else
                MessageBox.Show("You must select a supplier", "No supplier selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);	
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void SaveStock_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textNumber.Text);
                String name = textName.Text;
                int combo = Convert.ToInt32(comboBox1.Text);
                Double price = Convert.ToDouble(textPrice.Text);
                int qtity = Convert.ToInt32(textQty.Text);
                string pic = textpicture.Text;



                if (textNumber.Text != "" || textName.Text != "" || comboBox1.Text != "--Select a Supplier--" || textPrice.Text != "" || textQty.Text != "" || textpicture.Text != "")
                {
                    try
                    {
                        if (action == "InsertItem")
                        {
                            OracleCommand cmd7 = new OracleCommand("add_Item", conn);
                            cmd7.CommandType = CommandType.StoredProcedure;
                            cmd7.Parameters.Add("p_item", OracleDbType.Int32, ParameterDirection.Input).Value = number;
                            cmd7.Parameters.Add("p_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = name;
                            cmd7.Parameters.Add("p_price", OracleDbType.Double, ParameterDirection.Input).Value = price;
                            cmd7.Parameters.Add("p_quantity", OracleDbType.Int32, ParameterDirection.Input).Value = qtity;
                            cmd7.Parameters.Add("p_supplier", OracleDbType.Int32, ParameterDirection.Input).Value = combo;
                            cmd7.Parameters.Add("p_picture", OracleDbType.Varchar2, ParameterDirection.Input).Value = pic;

                            cmd7.ExecuteNonQuery();

                            MessageBox.Show("New record added.");

                            groupBox2.Enabled = true;
                            textNumber.Focus();
                            textNumber.Text = "";
                            textName.Text = "";
                            comboBox1.Text = "--Select a Supplier--";

                            textPrice.Text = "";
                            textQty.Text = "";
                            textpicture.Clear();
                            Width = 651;

                            listView1.Items.Clear();
                            refresh();

                        }
                        else if (action == "EditItem")
                        {



                            OracleCommand cmd6 = new OracleCommand("update_Item", conn);
                            cmd6.CommandType = CommandType.StoredProcedure;
                            cmd6.Parameters.Add("p_item", OracleDbType.Int32, ParameterDirection.Input).Value = number;
                            cmd6.Parameters.Add("p_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = name;
                            cmd6.Parameters.Add("p_price", OracleDbType.Double, ParameterDirection.Input).Value = price;
                            cmd6.Parameters.Add("p_quantity", OracleDbType.Int32, ParameterDirection.Input).Value = qtity;
                            cmd6.Parameters.Add("p_supplier", OracleDbType.Int32, ParameterDirection.Input).Value = combo;
                            cmd6.Parameters.Add("p_picture", OracleDbType.Varchar2, ParameterDirection.Input).Value = pic;


                            cmd6.ExecuteNonQuery();


                            MessageBox.Show("New record updated.");

                            groupBox2.Enabled = true;
                            textNumber.Focus();
                            textNumber.Text = "";
                            textName.Text = "";
                            // comboBox1.Text = "--Select a Supplier--";
                            textPrice.Text = "";
                            textQty.Text = "";
                            textpicture.Clear();
                            Width = 651;

                            listView1.Items.Clear();
                            refresh();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Some Error Occur.", "Error");
                    }

                    MessageBox.Show("Record SuccessFully save");
                }
                else
                    MessageBox.Show("Field cannot be empty");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Field cannot be empty");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textNumber.Focus();
            textNumber.Text = "";
            textName.Text = "";
            comboBox1.Text = "--Select a Supplier--";
            textPrice.Text = "";
            textQty.Text = "";
            textpicture.Clear();
            

        }

        private void deleteStock_Click(object sender, EventArgs e)
        {
            
            Width = 651;
            if (listView1.SelectedItems.Count > 0)
            { 
                
                    System.Windows.Forms.DialogResult reslt;
                    reslt = MessageBox.Show("Are you sure you want to delete this item record", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (System.Windows.Forms.DialogResult.Yes == reslt)
                    {
                        int number = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                        string itemSel = listView1.SelectedItems[0].SubItems[0].Text;

                        listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                        OracleCommand cm1 = new OracleCommand("remove_item", conn);
                        cm1.CommandType = CommandType.StoredProcedure;
                        cm1.Parameters.Add("p_item1", OracleDbType.Int32, ParameterDirection.Input).Value = number;
                       
                        cm1.ExecuteNonQuery();

                    }


           }
           else
             MessageBox.Show("You must select an item", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Width = 651;
           // groupBox2.Visible =false;
            groupBox2.Enabled = true;
            textNumber.Focus();
            textNumber.Text = "";
            textName.Text = "";
            comboBox1.Text = "--Select a Supplier--";
            textPrice.Text = "";
            textQty.Text = "";
            textpicture.Clear();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Width = 653;
            txtSNumber.Clear();
            txtSname.Clear();
            txtSAddress.Clear();
            txtSemail.Clear();                
            txtStelphone.Clear();
            groupBox1.Enabled = true;
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txtSNumber.Clear();
            txtSname.Clear();
            txtSAddress.Clear();
            txtSemail.Clear();
            txtStelphone.Clear();
            groupBox1.Enabled = false;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
           

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                  index = listView1.SelectedIndices[0];
                  textNumber.Text = listView1.SelectedItems[0].SubItems[0].Text;
                  textName.Text = listView1.SelectedItems[0].SubItems[1].Text;
                  comboBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
                  
                  textPrice.Text = listView1.SelectedItems[0].SubItems[3].Text; 
                  textQty.Text = listView1.SelectedItems[0].SubItems[4].Text; 
                  textpicture.Text = listView1.SelectedItems[0].SubItems[5].Text;

            }
           
        }

        private void deleteSupplier_Click(object sender, EventArgs e)
        {
           
                
                 
                           			
        }

        private void AddSupplier_Click(object sender, EventArgs e)
        {
           


        }

        private void btnLookUp_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
            String fn = openFile.SafeFileName;
            textpicture.Text = fn.Substring(0, fn.Length - 4); 
        }

        private void combtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combtype.SelectedItem.ToString() == "BEER")
            {
                OracleCommand cd = new OracleCommand("select beer.nextval from dual", conn);
                cd.CommandType = CommandType.Text;
                int beerID = Int32.Parse(cd.ExecuteScalar().ToString());
                textNumber.Text = Convert.ToString(beerID);
            }
            if (combtype.SelectedItem.ToString() == "WINE")
            {
                OracleCommand cd = new OracleCommand("select wine.nextval from dual", conn);
                cd.CommandType = CommandType.Text;
                int wineID = Int32.Parse(cd.ExecuteScalar().ToString());
                textNumber.Text = Convert.ToString(wineID);
            }
            if (combtype.SelectedItem.ToString() == "VODKA")
            {
                OracleCommand cd = new OracleCommand("select vodka.nextval from dual", conn);
                cd.CommandType = CommandType.Text;
                int vodkaID = Int32.Parse(cd.ExecuteScalar().ToString());
                textNumber.Text = Convert.ToString(vodkaID);
            }
            if (combtype.SelectedItem.ToString() == "CIDER")
            {
                OracleCommand cd = new OracleCommand("select cider.nextval from dual", conn);
                cd.CommandType = CommandType.Text;
                int ciderID = Int32.Parse(cd.ExecuteScalar().ToString());
                textNumber.Text = Convert.ToString(ciderID);
            }
             if (combtype.SelectedItem.ToString() == "WHISKEY")
            {
                OracleCommand cd = new OracleCommand("select whiskey.nextval from dual", conn);
                cd.CommandType = CommandType.Text;
                int whiskeyID = Int32.Parse(cd.ExecuteScalar().ToString());
                textNumber.Text = Convert.ToString(whiskeyID);
            }
        }

        

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            crystalReportViewer1.Visible = true;
            crystalReportViewer2.Visible = false;
            crystalReportViewer3.Visible = false;
 
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            crystalReportViewer3.Visible = true;
            crystalReportViewer2.Visible = false;
            crystalReportViewer1.Visible = false;
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            crystalReportViewer2.Visible = true;
            crystalReportViewer1.Visible = false;
            crystalReportViewer3.Visible = false;
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                index = listView3.SelectedIndices[0];
                txtSNumber1.Text = listView3.SelectedItems[0].SubItems[0].Text;
                txtSname1.Text = listView3.SelectedItems[0].SubItems[1].Text;
                txtStelphone1.Text = listView3.SelectedItems[0].SubItems[2].Text;
                txtSAddress1.Text = listView3.SelectedItems[0].SubItems[3].Text;
                am = listView3.SelectedItems[0].SubItems[4].Text;
                txtSemail1.Text = am.Substring(0, am.Length - 10);
                
            }
        }
        

        private void button5_Click_1(object sender, EventArgs e)
        {

            groupBox1.Enabled = false;
            groupBox4.Enabled = true;

            OracleCommand cd = new OracleCommand("select supplier_num.nextval from dual", conn);
            cd.CommandType = CommandType.Text;
            int beerID = Int32.Parse(cd.ExecuteScalar().ToString());
            txtSNumber1.Text = Convert.ToString(beerID);

            btReset.Enabled = true;
            //txtSNumber.Focus();
            txtSNumber1.Enabled = false;
            txtSname1.Focus();
            txtSname1.Text = "";
            txtSAddress1.Text = "";
            txtStelphone1.Text = "";
            txtSAddress.Clear();
            Width = 997;
            action = "AddSupplier";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Width = 651;
            if (listView3.SelectedItems.Count > 0)
            {

                System.Windows.Forms.DialogResult reslt;
                reslt = MessageBox.Show("Are you sure you want to delete this supplier record", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (System.Windows.Forms.DialogResult.Yes == reslt)
                {
                    int number = Convert.ToInt32(listView3.SelectedItems[0].SubItems[0].Text);
                    string itemSel = listView3.SelectedItems[0].SubItems[0].Text;
                    listView3.Items.RemoveAt(listView3.SelectedIndices[0]);
                    OracleCommand cm1 = new OracleCommand("remove_supplier", conn);
                    cm1.CommandType = CommandType.StoredProcedure;
                    cm1.Parameters.Add("p_supplier", OracleDbType.Int32, ParameterDirection.Input).Value = number;
                    cm1.ExecuteNonQuery();

                    /*listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                    OracleCommand cm1 = new OracleCommand("remove_item_supplier", conn);
                    cm1.CommandType = CommandType.StoredProcedure;
                    cm1.Parameters.Add("p_supplier", OracleDbType.Int32, ParameterDirection.Input).Value = number;

                    cm1.ExecuteNonQuery();*/
                   
                }

            }
            else
                MessageBox.Show("You must select a supplier", "No supplier selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            

        }

        private void btSaveS_Click(object sender, EventArgs e)
        {

            Width = 629;
            try
            {

                int number = Convert.ToInt32(txtSNumber1.Text);
                String name = txtSname1.Text;
                String address = txtSAddress1.Text;
                string email = txtSemail1.Text + comboBox3.SelectedItem.ToString();
                string tel = txtStelphone1.Text;



                if (txtSNumber1.Text != "" || txtSname1.Text != "" || txtSAddress1.Text != "" || txtSemail1.Text != "" || txtStelphone1.Text != "")
                {
                    try
                    {
                        if (action == "AddSupplier")
                        {
                            OracleCommand cmd2 = new OracleCommand("ADD_SUPPLIER", conn);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Add("p_id", OracleDbType.Int32, ParameterDirection.Input).Value = number;
                            cmd2.Parameters.Add("p_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = name;
                            cmd2.Parameters.Add("p_tel", OracleDbType.Varchar2, ParameterDirection.Input).Value = tel;
                            cmd2.Parameters.Add("p_address", OracleDbType.Varchar2, ParameterDirection.Input).Value = address;
                            cmd2.Parameters.Add("p_email", OracleDbType.Varchar2, ParameterDirection.Input).Value = email;


                            cmd2.ExecuteNonQuery();

                            MessageBox.Show("New record added.");


                            Width = 651;
                           
                            groupBox4.Enabled = false;
                            groupBox1.Enabled = true;
                            listView3.Items.Clear();
                            refresh();
                           
                        }
                        else if (action == "updateSupplier")
                        {



                            OracleCommand cmd6 = new OracleCommand("update_supplier", conn);
                            cmd6.CommandType = CommandType.StoredProcedure;
                            cmd6.Parameters.Add("p_id", OracleDbType.Int32, ParameterDirection.Input).Value = number;
                            cmd6.Parameters.Add("p_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = name;
                            cmd6.Parameters.Add("p_tel", OracleDbType.Varchar2, ParameterDirection.Input).Value = tel;
                            cmd6.Parameters.Add("p_address", OracleDbType.Varchar2, ParameterDirection.Input).Value = address;
                            cmd6.Parameters.Add("p_email", OracleDbType.Varchar2, ParameterDirection.Input).Value = email;



                            cmd6.ExecuteNonQuery();


                            MessageBox.Show("New record updated.");

                           
                            txtSNumber1.Enabled = false;
                            txtSNumber1.Text = "";
                            txtSname1.Text = "";
                            txtSAddress1.Text = "";
                            txtSemail1.Text = "";
                            txtStelphone1.Text = "";
                            Width = 651;

                            groupBox4.Enabled = false;
                            groupBox1.Enabled = true;

                            listView3.Items.Clear();
                            refresh();


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Some Error Occur.", "Error");
                    }

                    MessageBox.Show("Record SuccessFully save");
                }
                else
                    MessageBox.Show("Field cannot be empty");
            }
            catch (Exception ex)
            {

            }

        }

        private void updateSuplier_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                System.Windows.Forms.DialogResult reslt;
                reslt = MessageBox.Show("Are you sure you want to edit this supplier record", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (System.Windows.Forms.DialogResult.Yes == reslt)
                {

                    groupBox1.Enabled = false;
                   // groupBox4.Enabled = true;
                    breset.Enabled = false;
                    txtSNumber1.Enabled = false;
                    txtSname1.Focus();
                    

                    Width = 997;
                    action = "updateSupplier";
                }
            }
            else
                MessageBox.Show("You must select a supplier", "No supplier selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);	
      
        }

        private void breset_Click(object sender, EventArgs e)
        {
            txtSNumber1.Clear();
            txtSname1.Clear();
            txtSAddress1.Clear();
            txtSemail1.Clear();
            txtStelphone1.Clear();
            groupBox1.Enabled = false;
        }

        private void btCanc_Click(object sender, EventArgs e)
        {
            txtSNumber1.Clear();
            txtSname1.Clear();
            txtSAddress1.Clear();
            txtSemail1.Clear();
            txtStelphone1.Clear();
            Width = 653;
            groupBox4.Enabled = false;
            groupBox1.Enabled = true;
        }

        private void textPrice_TextChanged(object sender, EventArgs e)
        {
             try{ 
                
                  Convert.ToDouble(textPrice.Text);
                   
                

            }
            catch (Exception ex)
            {
                textPrice.Clear();
                MessageBox.Show("Only Numeric Values allowed in this field. Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
