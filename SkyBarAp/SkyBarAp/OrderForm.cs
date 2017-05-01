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
    public partial class OrderForm : Form
    {
        // OracleConnection con = new OracleConnection();
        OracleDataReader reader;
         String cashiersID;
         OracleConnection conn;
         int currentOrderNumber;
        String cashier;

        int quantOf = 0;
        int paymentNum = 1;
        string bartender;
        DateTime date;
        int orderNumber;
        string drinkType;
        int d;
        double unitPrice;
        string nm;
        double subTotal;
        double tax;
        double totalAfterTax;
        int itemCount = 0;
        double orderTotal = 0;
        int quantityCount = 0;
		

        public OrderForm(OracleConnection conn,String c,String id)
         {
             InitializeComponent();
             this.conn = conn;
             cashier=c;
             cashiersID=id;
         }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        private void OrderForm_Load(object sender, EventArgs e)
        {
            OracleCommand cd = new OracleCommand("select order_number.nextval from dual", conn);
            cd.CommandType = CommandType.Text;
            orderNumber = Int32.Parse(cd.ExecuteScalar().ToString());

            date = DateTime.Now;
            ItemList.Focus();
            txtBartenderName.Text = cashier;
            label14.Text = date.ToLongDateString();
            label15.Text = date.ToShortTimeString();
            txtOrderNum.Text = orderNumber.ToString();

            try
            {
                OracleCommand cmd = new OracleCommand("select item_name from item", conn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("item_name", OracleDbType.Varchar2, ParameterDirection.Output);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ItemList.Items.Add(reader["item_name"].ToString());
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                nm = ItemList.SelectedItem.ToString();
                OracleCommand cmd1 = new OracleCommand("select item_number, picture_name, unit_price from item where item_name = '" + nm + "'", conn);
               cmd1.CommandType = CommandType.Text;
               // OracleCommand cmd1 = new OracleCommand("Select_Item", conn);
                //cmd1.CommandType = CommandType.StoredProcedure;
                //cmd2.CommandType = CommandType.StoredProcedure;
               // cmd2.Parameters.Add("p_id", OracleDbType.Int32, ParameterDirection.Input).Value = number;
               // cmd2.Parameters.Add("p_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = name;
                        
                
                cmd1.Parameters.Add("item_number", OracleDbType.Decimal, ParameterDirection.Output);
                cmd1.Parameters.Add("picture_name", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd1.Parameters.Add("unit_price", OracleDbType.Decimal, ParameterDirection.Output);
                reader = cmd1.ExecuteReader();
                reader.Read();
                int item_num = Convert.ToInt32(reader["item_number"]);
                string pic = (reader["picture_name"]).ToString();
                unitPrice = Convert.ToDouble(reader["unit_price"]);

                if (item_num >= 1 && item_num <= 60)
                {
                    drinkOptions.Visible = true;
                    drinkOptions.Items.Clear();

                    drinkOptions.Items.Add("Bottle");
                    drinkOptions.Items.Add("Shot");
                    drinkType = "vodka";
                    d = ItemList.SelectedIndex;
                    string filepath = "Images\\";
                    pictureBox1.Image = Image.FromFile(filepath + pic);


                }
                if (item_num >= 4000 && item_num <= 4700)
                {
                    drinkOptions.Visible = true;
                    drinkOptions.Items.Clear();
                    drinkOptions.Items.Add("Bottle");
                    drinkOptions.Items.Add("Glass");
                    drinkType = "wine";
                    d = ItemList.SelectedIndex;
                    string filepath = "Images\\";
                    pictureBox1.Image = Image.FromFile(filepath + pic);

                }
                if (item_num >= 100 && item_num <= 170)
                {

                    drinkOptions.Visible = true;
                    drinkOptions.Items.Clear();
                    drinkOptions.Items.Add("Bottle");
                    drinkOptions.Items.Add("Shot");
                    drinkType = "whiskey";
                    d = ItemList.SelectedIndex;
                    string filepath = "Images\\";
                    pictureBox1.Image = Image.FromFile(filepath + pic);

                }
                if (item_num >= 2000 && item_num <= 2500)
                {
                    drinkOptions.Items.Clear();
                    drinkOptions.Visible = false;
                    drinkType = "beer";
                    d = ItemList.SelectedIndex;
                    string filepath = "Images\\";
                    pictureBox1.Image = Image.FromFile(filepath + pic);
                    txtPrice.Text = unitPrice.ToString("00");
                }
                if (item_num >= 1000 && item_num <= 1700)
                {
                    drinkOptions.Items.Clear();
                    drinkOptions.Visible = false;
                    drinkType = "cider";
                    d = ItemList.SelectedIndex;
                    string filepath = "Images\\";
                    pictureBox1.Image = Image.FromFile(filepath + pic);
                    txtPrice.Text = unitPrice.ToString("00");
                }
                if (item_num >= 3000 && item_num <= 3700)
                {
                    drinkOptions.Items.Clear();
                    drinkOptions.Visible = false;
                    drinkType = "soda";
                    d = ItemList.SelectedIndex;
                    string filepath = "Images\\";
                    pictureBox1.Image = Image.FromFile(filepath + pic);
                    txtPrice.Text = unitPrice.ToString("00");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result;

			 result = MessageBox.Show("You are about to exit the application, are you sure about this ?","Exiting Application",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

			 if(result == System.Windows.Forms.DialogResult.Yes)
				{ this.Close();
			      conn.Close();
			    }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        { 
            
            string Item;
            string Qty;
            
            for (int x = 0; x < itemCount; x++)
            {
                //try
               // {
                    string list2 = listView1.Items[x].SubItems[2].ToString();
                    string list4 = listView1.Items[x].SubItems[4].ToString();

                    int lists2 = list2.Length - 18;
                    Item = list2.Substring(18, lists2 - 1);

                    int lists4 = list4.Length - 18;
                    Qty = list4.Substring(18, lists4 - 1);

                    OracleCommand cm1 = new OracleCommand("select quantity from item where item_name = '" + Item + "'", conn);
                    cm1.CommandType = CommandType.Text;
                    cm1.Parameters.Add("quantity", OracleDbType.Int32, ParameterDirection.Output);
                    reader = cm1.ExecuteReader();
                    reader.Read();
                    int dbQty = Convert.ToInt32(reader["quantity"]);

                    int newQuant = dbQty + Convert.ToInt32(Qty);

                    OracleCommand updateQty2 = new OracleCommand("update item set quantity = :1 where item_name = :2", conn);
                    updateQty2.Parameters.Add(new OracleParameter("1", OracleDbType.Int32, newQuant, ParameterDirection.Input));
                    updateQty2.Parameters.Add(new OracleParameter("2", OracleDbType.Varchar2, Item, ParameterDirection.Input));
                    int eR = updateQty2.ExecuteNonQuery();
                    MessageBox.Show("Order successfully cancelled");
               // }
               // catch (Exception ee)
               // {
                   // MessageBox.Show(ee.Message);
               // }
                

            }
           

            txtSubTotal.Text = "";
            txtTax.Text = "";
            txtTot.Text = "";
            txtPayment.Clear();
            listView1.Items.Clear();
            ItemList.Text = "";
            txtPrice.Text = "";
            pictureBox1.Image.Dispose();
            txtTotal.Text = "";

           


        }

        private void drinkOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drinkOptions.SelectedItem.ToString() == "Bottle")
            {
                txtPrice.Text = unitPrice.ToString("00");
            }

            //Per Glass
            if (drinkOptions.SelectedItem.ToString() == "Glass")
            {
                //Wine
                if (drinkType == "wine")
                {

                    txtPrice.Text = "17.00";
                }

            }

            //Per Shot
            if (drinkOptions.SelectedItem.ToString() == "Shot")
            {
                //Vodka
                if (drinkType == "vodka")
                {
                    if (nm == "Absolute Vodka")
                    {
                        txtPrice.Text = "20.00";
                    }
                    else
                        if (nm == "ZYR Vodka")
                        {
                            txtPrice.Text = "25.00";
                        }
                        else
                            txtPrice.Text = "15.00";
                }

                //Whiskey
                if (drinkType == "whiskey")
                {
                    if (nm == "Jim Beam")
                    {
                        txtPrice.Text = "26.00";
                    }
                    else
                        if (nm == "Johnnie Walker - Black Label")
                        {
                            txtPrice.Text = "30.00";
                        }
                        else
                            txtPrice.Text = "20.00";
                }

            }


            for (int i = 0; i < 3; i++)
            {
                if (drinkType == "wine" && drinkOptions.SelectedItem.ToString() == "Bottle")
                {
                    txtPrice.Text = unitPrice.ToString("00");
                }
                if (drinkType == "wine" && drinkOptions.SelectedItem.ToString() == "Glass")
                {

                    txtPrice.Text = "16.90";
                }
                if (drinkType == "w" && drinkOptions.SelectedItem.ToString() == "Bottle")
                {
                    txtPrice.Text = unitPrice.ToString("00");
                }

            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
           // try
           // {
            if (!System.Text.RegularExpressions.Regex.Match(txtQty.Text, "[0-9]").Success)
            {
                MessageBox.Show("Only Numeric Values allowed in this field. Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = Convert.ToInt32(txtQty.Text);

                string itm = ItemList.SelectedItem.ToString();
                OracleCommand cmd3 = new OracleCommand("select quantity from item where item_name = '" + itm + "'", conn);
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.Add("quantity", OracleDbType.Int32, ParameterDirection.Output);
                reader = cmd3.ExecuteReader();

                reader.Read();
                int qtyOnHand = Convert.ToInt32(reader["quantity"]);
                if (i >= qtyOnHand)
                {
                    MessageBox.Show("Not enough stock on hand. Try a lower value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQty.Text = "";
                    txtTotal.Text = "";
                }
                else
                {
                    double price = Convert.ToDouble(txtPrice.Text);
                    double total = price * i;
                    txtTotal.Text = total.ToString(".00");
                }
            }
                    
                
                

            //}
            //catch (Exception ex)
            //{
            //    txtQty.Clear();
            //    MessageBox.Show("Only Numeric Values allowed in this field. Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtQty.Text == "" || txtQty.Text == "0" || txtQty.Text == "- ")
            {
                MessageBox.Show("Field cannot be left empty. Please Enter Quantity value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                if (ItemList.SelectedIndex == -1)
                {
                    MessageBox.Show("Field cannot be left empty. Please Select an item", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int iCount = 0;
                    string it = ItemList.SelectedItem.ToString();
                    OracleCommand cmd4 = new OracleCommand("select item_number, quantity from item where item_name = '" + it + "'", conn);
                    cmd4.CommandType = CommandType.Text;
                    cmd4.Parameters.Add("item_number", OracleDbType.Decimal, ParameterDirection.Output);
                    reader = cmd4.ExecuteReader();

                    reader.Read();
                    int num = Convert.ToInt32(reader["item_number"]);
                    int qtty = Convert.ToInt32(reader["quantity"]);
                    int newQty = 0;
                    double totalPr = Convert.ToDouble(txtTotal.Text);

                    ListViewItem order = new ListViewItem(txtOrderNum.Text);
                    order.SubItems.Add(num.ToString());
                    order.SubItems.Add(ItemList.SelectedItem.ToString());
                    order.SubItems.Add(txtPrice.Text);
                    order.SubItems.Add(txtQty.Text);
                    order.SubItems.Add(txtTotal.Text);
                    orderTotal += totalPr;
                    listView1.Items.Add(order);

                    drinkOptions.Text = "";
                    ItemList.Text = "";
                    txtPrice.Text = "";
                    pictureBox1.Image.Dispose();
                    txtTotal.Text = "";
                   
                    subTotal = orderTotal;
                    tax = subTotal * 0.14;
                    totalAfterTax = subTotal + tax;
                    txtSubTotal.Text = subTotal.ToString(".00");
                    txtTax.Text = tax.ToString(".00");
                    txtTot.Text = totalAfterTax.ToString(".00");
                    iCount++;
                    itemCount = iCount;

                    newQty = qtty - Convert.ToInt32(txtQty.Text); // needs refining (bottle vs glass/shot ratio)

                    OracleCommand cm = new OracleCommand("update item set quantity = :1 where item_number = :2", conn);
                    cm.Parameters.Add(new OracleParameter("", OracleDbType.Int32, newQty, ParameterDirection.Input));
                    cm.Parameters.Add(new OracleParameter("2", OracleDbType.Int32, num, ParameterDirection.Input));
                    int rw = cm.ExecuteNonQuery();
                    /*
                     OracleCommand cm = new OracleCommand("update_Quantity", conn);
                    cm.Parameters.Add("p_qty", OracleDbType.Int32,ParameterDirection.Input).Value =newQty;
                    cm.Parameters.Add("p_number", OracleDbType.Int32, ParameterDirection.Input).Value=num;
                    int rw = cm.ExecuteNonQuery();
                     */

                }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select an item first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult rsl = MessageBox.Show("Are you sure you would like to remove this item?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rsl == DialogResult.Yes)
                {
                    string totalPrice = listView1.SelectedItems[0].SubItems[5].Text;
                    string userQty = listView1.SelectedItems[0].SubItems[4].Text;
                    string itemSel = listView1.SelectedItems[0].SubItems[2].Text;

                    listView1.Items.RemoveAt(listView1.SelectedIndices[0]);

                    orderTotal = orderTotal - Convert.ToDouble(totalPrice);
                    subTotal = orderTotal;
                    tax = subTotal * 0.14;
                    totalAfterTax = subTotal + tax;
                    txtSubTotal.Text = subTotal.ToString(".00");
                    txtTax.Text = tax.ToString(".00");
                    txtTot.Text = totalAfterTax.ToString(".00");
                    itemCount--;

                    OracleCommand cm1 = new OracleCommand("select quantity from item where item_name = '" + itemSel + "'", conn);
                    cm1.CommandType = CommandType.Text;
                    cm1.Parameters.Add("quantity", OracleDbType.Int32, ParameterDirection.Output);
                    reader = cm1.ExecuteReader();

                    reader.Read();
                    int qtty = Convert.ToInt32(reader["quantity"]);
                    int newQuantity = qtty + Convert.ToInt32(userQty);  // needs refining (bottle vs glass/shot ratio)

                    OracleCommand updateQty = new OracleCommand("update item set quantity = :1 where item_name = :2", conn);
                    updateQty.Parameters.Add(new OracleParameter("1", OracleDbType.Int32, newQuantity, ParameterDirection.Input));
                    updateQty.Parameters.Add(new OracleParameter("2", OracleDbType.Varchar2, itemSel, ParameterDirection.Input));
                    int eR = updateQty.ExecuteNonQuery();



                }

            }
        }

        private void btnAcceptOrder_Click(object sender, EventArgs e)
        {


            if (txtPayment.Text == "")
            {
                MessageBox.Show("The Order cannot be proccessed without valid payment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (Convert.ToDouble(txtPayment.Text) < Convert.ToDouble(txtTot.Text))
            {
                MessageBox.Show("The Payment cannot be less than total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPayment.Text = "";
                txtChange.Text = "";
            }
            else
            {
                try
                {
                    string ItemNum;
                    string Item;
                    string UnitPrice;
                    string Qty;
                    string Total;
                    string name = txtBartenderName.Text;

                    int ord = Convert.ToInt32(txtOrderNum.Text);
                    OracleCommand cmd6 = new OracleCommand("select worker_id from bartender where name ='" + name + "'", conn);
                    cmd6.CommandType = CommandType.Text;
                    cmd6.Parameters.Add("worker_id", OracleDbType.Varchar2, ParameterDirection.Output);
                    reader = cmd6.ExecuteReader();
                    reader.Read();
                    string workerID = (reader["worker_id"]).ToString();
                    for (int o = 0; o < itemCount; o++)
                    {
                        string qq;
                        string qtyList = listView1.Items[o].SubItems[4].ToString();

                        int qtyLists = qtyList.Length - 18;
                        qq = qtyList.Substring(18, qtyLists - 1);

                        quantityCount += Convert.ToInt32(qq);
                    }

                     OracleCommand cmd7 = new OracleCommand("insert into orderlist values(:1 ,:2 , :3 , :4 , :5) ", conn);

                     cmd7.Parameters.Add(new OracleParameter("1", OracleDbType.Int32, Convert.ToInt32(txtOrderNum.Text), ParameterDirection.Input));
                      cmd7.Parameters.Add(new OracleParameter("2", OracleDbType.Decimal, totalAfterTax, ParameterDirection.Input));
                      cmd7.Parameters.Add(new OracleParameter("3", OracleDbType.Date, date, ParameterDirection.Input));
                      cmd7.Parameters.Add(new OracleParameter("4", OracleDbType.Int32, quantityCount, ParameterDirection.Input));
                      cmd7.Parameters.Add(new OracleParameter("5", OracleDbType.Varchar2, workerID, ParameterDirection.Input));
                      
                    //OracleCommand cmd7 = new OracleCommand("ADD_orderlist", conn);
                    //cmd7.CommandType = CommandType.StoredProcedure;
                    //cmd7.Parameters.Add("p_order", OracleDbType.Int32, ParameterDirection.Input).Value = orderNumber;
                    //cmd7.Parameters.Add("p_total", OracleDbType.Decimal, ParameterDirection.Input).Value = totalAfterTax;
                    //cmd7.Parameters.Add("p_date", OracleDbType.Date, ParameterDirection.Input).Value = date;
                    //cmd7.Parameters.Add("p_qty", OracleDbType.Int32, ParameterDirection.Input).Value = quantityCount;
                    //cmd7.Parameters.Add("p_workerID", OracleDbType.Varchar2, ParameterDirection.Input).Value = workerID;

                      int rowUpdate = cmd7.ExecuteNonQuery();


                    OracleCommand cmd9 = new OracleCommand("select payment_number.nextval from dual", conn);
                    cmd9.CommandType = CommandType.Text;
                    paymentNum = Int32.Parse(cmd9.ExecuteScalar().ToString());

                    listBox1.Items.Add("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    listBox1.Items.Add("*************************************************** SKYY BAR *******************************************************");
                    listBox1.Items.Add("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    listBox1.Items.Add("ORDER NUMBER: " + ord + "		" + date + "		BARTENDER:" + name);
                    listBox1.Items.Add("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    listBox1.Items.Add("ITEM(S)#	 Description \t\t Price \t Quantity \t Total");

                    for (int x = 0; x < itemCount; x++)
                    {
                        quantOf++;
                        string list = listView1.Items[x].SubItems[1].ToString();
                        string list2 = listView1.Items[x].SubItems[2].ToString();
                        string list3 = listView1.Items[x].SubItems[3].ToString();
                        string list4 = listView1.Items[x].SubItems[4].ToString();
                        string list5 = listView1.Items[x].SubItems[5].ToString();

                        int lists = list.Length - 18;
                        ItemNum = list.Substring(18, lists - 1);

                        int lists2 = list2.Length - 18;
                        Item = list2.Substring(18, lists2 - 1);

                        int lists3 = list3.Length - 18;
                        UnitPrice = list3.Substring(18, lists3 - 1);

                        int lists4 = list4.Length - 18;
                        Qty = list4.Substring(18, lists4 - 1);

                        int lists5 = list5.Length - 18;
                        Total = list5.Substring(18, lists5 - 1);

                        OracleCommand cmd10 = new OracleCommand("select list_num.nextval from dual", conn);
                        cmd10.CommandType = CommandType.Text;
                        int list_num = Int32.Parse(cmd10.ExecuteScalar().ToString());

                        OracleCommand cmd8 = new OracleCommand("insert into orderlistitem values(:1 ,:2 , :3 , :4 , :5 , :6) ", conn);

                        cmd8.Parameters.Add(new OracleParameter("1", OracleDbType.Int32, list_num, ParameterDirection.Input));
                        cmd8.Parameters.Add(new OracleParameter("2", OracleDbType.Int32, Convert.ToInt32(txtOrderNum.Text), ParameterDirection.Input));
                        cmd8.Parameters.Add(new OracleParameter("3", OracleDbType.Int32, Convert.ToInt32(ItemNum), ParameterDirection.Input));
                        cmd8.Parameters.Add(new OracleParameter("4", OracleDbType.Int32, Convert.ToInt32(Qty), ParameterDirection.Input));
                        cmd8.Parameters.Add(new OracleParameter("5", OracleDbType.Decimal, Convert.ToDouble(UnitPrice), ParameterDirection.Input));
                        cmd8.Parameters.Add(new OracleParameter("6", OracleDbType.Decimal, Convert.ToDouble(Total), ParameterDirection.Input));
                        int rowUpdated = cmd8.ExecuteNonQuery();

                        /*
                        OracleCommand cmd2 = new OracleCommand("ADD_orderlistitem", conn);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("p_qtyof", OracleDbType.Int32, ParameterDirection.Input).Value = quantOf;
                        cmd2.Parameters.Add("p_order", OracleDbType.Int32, ParameterDirection.Input).Value = orderNumber;
                        cmd2.Parameters.Add("p_item", OracleDbType.Int32, ParameterDirection.Input).Value = Convert.ToInt32(ItemNum);
                        cmd2.Parameters.Add("p_qty", OracleDbType.Int32, ParameterDirection.Input).Value = Convert.ToInt32(Qty);
                        cmd2.Parameters.Add("p_unit", OracleDbType.Decimal, ParameterDirection.Input).Value = Convert.ToDouble(UnitPrice);
                        cmd2.Parameters.Add("p_total", OracleDbType.Decimal, ParameterDirection.Input).Value = Convert.ToDouble(Total);
                        cmd2.ExecuteNonQuery()
                         * */

                        listBox1.Items.Add(ItemNum + "\t\t" + Item + "\t\t" + UnitPrice + "\t" + Qty + "\t" + Total);


                    }


                    OracleCommand cmd12 = new OracleCommand("insert into payment values(:1 ,:2 , :3 ) ", conn);

                    cmd12.Parameters.Add(new OracleParameter("1", OracleDbType.Int32, paymentNum, ParameterDirection.Input));
                    cmd12.Parameters.Add(new OracleParameter("2", OracleDbType.Int32, ord, ParameterDirection.Input));
                    cmd12.Parameters.Add(new OracleParameter("3", OracleDbType.Decimal, Convert.ToDouble(txtPayment.Text), ParameterDirection.Input));
                    int rwp = cmd12.ExecuteNonQuery();
                    /* OracleCommand cmd12 = new OracleCommand("ADD_payment ", conn);
                      cmd12.CommandType = CommandType.StoredProcedure;
                    cmd12.Parameters.Add("p_payment", OracleDbType.Int32, ParameterDirection.Input).Value=paymentNum;
                    cmd12.Parameters.Add("p_order", OracleDbType.Int32, ord, ParameterDirection.Input).Value =p_order;
                    cmd12.Parameters.Add("p_total", OracleDbType.Decimal,  ParameterDirection.Input).Value=Convert.ToDouble(txtPayment.Text);
                    int rwp = cmd12.ExecuteNonQuery();
*/
                    listBox1.Items.Add("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    listBox1.Items.Add("Total Items		" + quantityCount);
                    listBox1.Items.Add("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    listBox1.Items.Add("SubTotal        R" + txtSubTotal.Text);
                    listBox1.Items.Add("Tax @ 14%     R" + txtTax.Text);
                    listBox1.Items.Add("Order Total     R" + txtTot.Text);
                    listBox1.Items.Add("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    listBox1.Items.Add("\n");
                    listBox1.Items.Add("Amount Paid    R" + txtPayment.Text);
                    listBox1.Items.Add("Change Due     R" + txtChange.Text);
                    listBox1.Items.Add("***********************************************Thank You and Come Again!!!************************************************");
                    listBox1.Items.Add("\n");
                    listBox1.Items.Add("\n");
                    listBox1.Items.Add("\n");

                    btnNewOrder.Enabled = true;
                }
                catch (Exception nn)
                {
                    MessageBox.Show(nn.Message);
                }
            }
                


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        { 

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            OracleCommand cd = new OracleCommand("select order_number.nextval from dual", conn);
            cd.CommandType = CommandType.Text;
            int od = Int32.Parse(cd.ExecuteScalar().ToString());

            ItemList.Text = "";
            txtOrderNum.Text = od.ToString();
            drinkOptions.Text = "";
            txtSubTotal.Text = "";
            txtQty.Text = 0 + "";
            txtTax.Text = "";
            txtChange.Clear();
            txtTot.Text = "";
           // txtPayment.Clear();
            listView1.Enabled = false;
            ItemList.Text = "";
            txtPrice.Text = "";
            pictureBox1.Image.Dispose();
            txtTotal.Text = "";
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            listView1.Enabled = true;
            //listBox1.Visible = false;
            listBox1.Items.Clear();
            listView1.Items.Clear();
            quantityCount = 0;
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            //try
            //{

            if (!System.Text.RegularExpressions.Regex.Match(txtPayment.Text, "[0-9]" ).Success)
            {
                MessageBox.Show("Only Numeric Values allowed in this field. Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                if (!System.Text.RegularExpressions.Regex.Match(txtPayment.Text, "").Success)
                {

                }
            else
            {
                double change = Convert.ToDouble(txtPayment.Text) - Convert.ToDouble(txtTot.Text);
                txtChange.Text = change.ToString(".00");
            }
             

           // }
            //catch (Exception ec)
           // {
                
           // }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           Management o = new Management();
            this.Hide();
            o.ShowDialog();
        }
    }
}
