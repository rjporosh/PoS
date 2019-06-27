using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ES_Project
{
    public partial class frmSale : Form
    {
        //variable decleration
        int number = 1;
        int rowsInCustomerCart;
        int purchase_Price_SingleProduct;
        int Variable_Single_Product_Purchase_Price_toDeterminSalePriceIsMorePurPrice;
        SqlConnection objc;
        SqlCommand objcmd;
        SqlDataAdapter objda;
        DataSet objds;
        string c = ConfigurationManager.ConnectionStrings["c"].ConnectionString;
        int n;
        int GridRow = 0;
        string TransactionType;
        int invoiceID;

        int total_price;
        int total_products;
        int profitSingleProduct;
        string saleID;
        string pendingID;
        // int Variable_Net_Product_Sale_Price_toCalculateProfit;
        // int Variable_single_product_purchase_price_toCalculateProfit;
        //variable declaration

        public frmSale()
        {
            InitializeComponent();
        }

        private void frmSale_Load(object sender, EventArgs e)
        {

            //generateInvoiceID();
            
            //tb_Show_Total_Products.Text = "0";
            //tb_Show_Total_Amount.Text = "0";

            //total_price = 0;
            //total_products = 0;
            ////delete previous data from bill
            //try
            //{
            //    objc = new SqlConnection(c);
            //    objc.Open();
            //    objcmd = new SqlCommand("delete from Bill", objc);
            //    objcmd.ExecuteNonQuery();
            //    objc.Close();
            //}
            //catch
            //{
            //    MessageBox.Show("Error");
            //    return;
            //}
            ////delete previous data from bill

        }

        private void generateInvoiceID()
        {
            //try
            //{
            //    objc = new SqlConnection(c);
            //    objcmd = new SqlCommand("select * from Invoice", objc);
            //    objda = new SqlDataAdapter(objcmd.CommandText, objc);
            //    objds = new DataSet();
            //    objda.Fill(objds, "Invoice");
            //    invoiceID = objds.Tables[0].Rows.Count + 1;
            //    labelID.Text = (invoiceID).ToString();
            //}
            //catch
            //{
            //    MessageBox.Show("Database Connection Error! Try again or contact Developer.", "Invoice ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (custCartGrid.Rows.Count == 0 && !cb_return.Checked)
            {
                MessageBox.Show("Cart is Empty, Fill the cart first", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO MAKE THIS TRANSACTION? YES to Confirm. NO to Discard", "Confirmation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DateTime dt = DateTime.Now;
                string date = dt.ToLongDateString();

                if (custCartGrid.Rows.Count > 0 || cb_return.Checked == true)
                {
                    if (custCartGrid.Rows.Count > 0)
                    {                   
                        SaleCartInsertion(dt); 
                    }
                    if (cb_return.Checked)
                    {
                        processReturn(dt);
                    }
                    insertIntoInvoice(dt);          //UPDATE INVOICE TABLE TO GENERATE NEW INVOICE ID
                    custCartGrid.Rows.Clear();      //CLEAR ITEMS IN CUSTOMER SALE CART  
                    custCartGrid.Refresh();         //REFRESH CUSTOMER SALE CART GRID
                    //Bill_Rpt b = new Bill_Rpt();    // SHOW BILL REPORT
                    //b.ShowDialog();                 // SHOW BILL REPORT
                    Bill_Rpt b = new Bill_Rpt();
                    b.ShowDialog();
                    gbox_CustomerInfo.Enabled = true; // ENABLE CUSTOMER INFO FOR NEW CUSTOMER
                    tb_FP_Price_Single_Product.Clear();
                    tb_FP_P_ID.Focus();
                   clearBillTable();                   //DELETE TEMPORARY BILL DATA AFTER SUCCESSFUL REPORT GENERATION
                    generateInvoiceID();


                    btnX.Enabled = true;
                    btnFetch.Enabled = true;
                    textBox1.Clear();
                    returnGridView.Enabled = true;
                    btnProcess.Enabled = true;
                    tb_Return_amt.Text = "0";
                    tb_Return_product.Text = "0";
                    tb_Show_Total_Amount.Text = "0";
                    tb_Show_Total_Products.Text = "0";
                    tbProductsTotal.Text = "0";
                    tbSaleTotal.Text = "0";
                    tbInitialPayment.Text = "0";
                    tbAmountToPay.Text = "0";
                    tb_SPayment_Purchase_Total.Text = "0";
                    tb_SPayment_PurchasedProducts.Text = "0";
                    tb_SPayment_ReturendProducts.Text = "0";
                    tb_SPayment_Return_Total.Text = "0";
                    returnGridView.DataSource = null;
                    number = 1;
                    cb_return.Checked=false;
                    gbox_Return.Enabled = true;
                    custCartGrid.Enabled = true;

                    cb_isPending.Enabled = true;
                    cb_isPending.Checked = false;
                    //cb_Pending.Enabled = true;
                   // cb_Pending.Checked = false;
                    custCartGrid.Enabled = true;
                    tb_AddToCart.Enabled = true;
                    gbox_Return.Enabled = true;
                    custCartGrid.Rows.Clear();
                    gbox_Payment.Enabled = false;
                    cb_isPending.Checked = false;
                }      
            }
        }

        private void clearBillTable()
        {
            try
            {
                objc = new SqlConnection(c);
                objc.Open();
                objcmd = new SqlCommand("delete from Bill", objc);
                objcmd.ExecuteNonQuery();
                objc.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void SaleCartInsertion(DateTime dt)
        {
            int rows = custCartGrid.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                //variables for storing data in bill
                string p_id = (custCartGrid.Rows[i].Cells[0].Value.ToString()); //find product Variable_FP_P_ID in grid
                //string quantity_requested = custCartGrid.Rows[i].Cells[4].Value.ToString(); // find requested product in grid

                //variables for storing data from bill to sales
                string product_name = custCartGrid.Rows[i].Cells[1].Value.ToString();
                string piece_price = custCartGrid.Rows[i].Cells[3].Value.ToString();
                //string net_price = custCartGrid.Rows[i].Cells[5].Value.ToString();
                string TransactionType = custCartGrid.Rows[i].Cells[12].Value.ToString();
                string margin = custCartGrid.Rows[i].Cells[11].Value.ToString();
                string saleperson = custCartGrid.Rows[i].Cells[9].Value.ToString();

                //varibles for storing data in customers table
                string customer_name = custCartGrid.Rows[i].Cells[6].Value.ToString();
                string customer_cell = custCartGrid.Rows[i].Cells[7].Value.ToString();
                string purchase_price = custCartGrid.Rows[i].Cells[15].Value.ToString();
                string Mode = custCartGrid.Rows[i].Cells[14].Value.ToString();
                string query;
                objc = new SqlConnection(c);
                
                query = "insert into Customers(CustomerName, CustomerCell, ProductName,ProductPrice, SalePerson, Date)values('" + customer_name + "', '" + customer_cell + "', '" + product_name + "','" + piece_price + "', '" + Class1.LoggedInUsername + "','" + dt.ToString() + "')";
                query += "update Add_New_Item set Quantity=Quantity-" + 1 + "where SrNo='" + p_id + "'";
                if(cb_isPending.Checked)
                {
                    query += "insert into Pending(ProductID,ProductName,PiecePrice,TransactionType,Margin, SalePerson, CustomerName, CustomerCell, Date, InvoiceNo, PurchasePrice, SaleID, PendingID, TotalPayment, InitialPayment, AmountToPay) values ('" + p_id + "','" + product_name + "'," + piece_price + ",'" + TransactionType + "','" + margin + "','" + Class1.LoggedInUsername + "', '" + customer_name + "', '" + customer_cell + "', '" + dt.ToString() + "', '" + labelID.Text + "', '" + purchase_price + "', '" + custCartGrid.Rows[i].Cells[16].Value.ToString() + "', '" + custCartGrid.Rows[i].Cells[17].Value.ToString() + "', '"+tb_Show_Total_Amount.Text.Trim()+"', '"+tbInitialPayment.Text.Trim()+"', '"+tbAmountToPay.Text.Trim()+"')";
                }
                if(!cb_isPending.Checked)
                {
                    query += "insert into Sales(ProductID,ProductName,PiecePrice,TransactionType,Margin, SalePerson, CustomerName, CustomerCell, Date, InvoiceNo, PurchasePrice, SaleID) values ('" + p_id + "','" + product_name + "'," + piece_price + ",'" + TransactionType + "','" + margin + "','" + Class1.LoggedInUsername + "', '" + customer_name + "', '" + customer_cell + "', '" + dt.ToString() + "', '" + labelID.Text + "', '" + purchase_price + "', '" + custCartGrid.Rows[i].Cells[16].Value.ToString() + "')";
                }
                query += "insert into Bill(SrNo,Product_Name,Piece_Price, SalePerson, CustomerName, CustomerCell, Margin,TransactionType, BillID, Mode, SID, ReturnedProducts, ReturnedProductsAmount, TotalPayment, InitialPayment, Balance, SaleTotalAmt, SaleTotalProducts) values ('" + p_id + "','" + product_name + "','" + piece_price + "','" + Class1.LoggedInUsername + "', '" + customer_name + "', '" + customer_cell + "', '" + margin + "', '" + TransactionType + "', '" + labelID.Text + "', '" + Mode + "', '" + saleID + "', '"+tb_Return_product.Text+"', '"+tb_Return_amt.Text+"', '"+tb_Show_Total_Amount.Text.Trim()+"', '"+tbInitialPayment.Text.Trim()+"', '"+tbAmountToPay.Text+"', '"+tbSaleTotal.Text+"', '"+tbProductsTotal.Text+"')";

                objcmd = new SqlCommand(query, objc);
                objc.Open();
                objcmd.ExecuteNonQuery();
                objc.Close();
            }
        }

        private void insertIntoInvoice(DateTime dt)
        {
            objc = new SqlConnection(c);
            string q = "insert into Invoice(InvoiceID, CustomerName, SoldBy,InvoiceDate, SaleTotal, ReturnTotal, SaleProducts, ReturnProducts)values('" + invoiceID + "', '" + tbCustomerName.Text.Trim() + "', '" + Class1.LoggedInUsername + "','" + dt.ToString() + "', '"+tb_Show_Total_Amount.Text.Trim()+"', '"+tb_Return_amt.Text.Trim()+"', '"+tb_Show_Total_Products.Text.Trim()+"', '"+tb_Return_product.Text.Trim()+"')";
            objcmd = new SqlCommand(q, objc);
            objc.Open();
            objcmd.ExecuteNonQuery();
            objc.Close();
        }

        private void processReturn(DateTime dt)
        {
            insertReturnDataIntoGrid();

            int return_rows = returnGridView.Rows.Count;
            for (int l = 0; l < return_rows; l++)
            {
                objc = new SqlConnection(c);
                objcmd = new SqlCommand("select * from Add_New_Item where SrNo = '" + returnGridView.Rows[l].Cells[5].Value.ToString() + "' ", objc);
                objda = new SqlDataAdapter(objcmd.CommandText, objc);
                objds = new DataSet();
                objda.Fill(objds, "tbl");
                string return_query = "";
                if (objds.Tables[0].Rows.Count > 0)
                {
                    return_query = "update Add_New_Item SET Quantity = Quantity + 1 where SrNo= '" + returnGridView.Rows[l].Cells[5].Value.ToString() + "'"; //if product is not null in stock
                }
                else
                {
                    string qty = "1";
                    //MessageBox.Show("Not Exist");
                    return_query = "insert into Add_New_Item(SrNo,Product_Name,Quantity,Purchase_Price,Username,date) values ('" + returnGridView.Rows[l].Cells[5].Value.ToString() + "', '" + returnGridView.Rows[l].Cells[0].Value.ToString() + "', '" + qty + "', '" + returnGridView.Rows[l].Cells[6].Value.ToString() + "','" + Class1.LoggedInUsername + "','" + dt.ToString() + "')"; //if product is null in stock
                   // MessageBox.Show("Inseted Newly");
                }

                return_query += "delete from sales where InvoiceNo = '" + returnGridView.Rows[l].Cells[3].Value.ToString() + "' AND SaleID = '" + returnGridView.Rows[l].Cells[7].Value.ToString() + "'";
                
                objcmd = new SqlCommand(return_query, objc);
                objc.Open();
                objcmd.ExecuteNonQuery();
                objc.Close();

            }
        }



        private void CalculateTotalPriceAndProducts()
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {




            //fetch product ends here
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*roles
            1. FETCH REQUIRED ITEM FROM DATABASE IN TEXTBOXES
             * 2. CONFIRMATION
             * 3. ADD PRODUCT NAME, CUSTOMER NANE, CUSTOMER CELL, PRODUCT QUANTITY, PRODUCT PRICE IN GRID
             * 4. ALLOW USER TO ADJUST QUANTITY AND PRICE
            */

            //fetch product from database
            //ROLE 1 STARTS HERE
            if (tb_FP_P_ID.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter PRODUCT ID", "PRODUCT ID REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_FP_P_ID.Clear();
                tb_FP_P_ID.Focus();
                return;
            }

            if (tb_FP_Price_Single_Product.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter SALE PRICE", "PRICE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_FP_Price_Single_Product.Clear();
                tb_FP_Price_Single_Product.Focus();
                return;
            }
            if (tbCustomerName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Customer Name or Just type WALK IN CUSTOMER!", "Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCustomerName.Focus();
                return;
            }
            fetchProductFrmDB();

            
            if (objds.Tables[0].Rows.Count > 0)
            {
                //MessageBox.Show("12");
                if (int.Parse(objds.Tables["CheckItem"].Rows[0][2].ToString()) == 0)
                {
                    MessageBox.Show("No more stock available against Product: " + objds.Tables["CheckItem"].Rows[0][1].ToString() + "", "Stock Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb_FP_P_ID.Focus();
                    return;
                }
                if (int.Parse(objds.Tables["CheckItem"].Rows[0][3].ToString()) > int.Parse(tb_FP_Price_Single_Product.Text))
                {
                    MessageBox.Show("Sale Price can not less than purchase price! Try Again", "Price Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb_FP_Price_Single_Product.Clear();
                    tb_FP_Price_Single_Product.Focus();
                    return;
                }
                else
                {
                    if (MessageBox.Show("ARE YOU SURE YOU WANT TO INSERT THIS PRODUCT INTO CUSOMER CART?", "Confirmation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        tb_FP_P_ID.Clear(); 
                        tb_FP_P_ID.Focus();
                    }
                    else
                    {                    //date
                        DateTime dt = DateTime.Now;
                        string date = dt.ToShortDateString();
                        //date
                        determineTransactionType();

                        
                        //saleID = "SID_" + invoiceID + custCartGrid.Rows[i].Cells[0].Value.ToString();
                        custCartGrid.Rows.Add();
                        GridRow = custCartGrid.Rows.Count - 1;
                        custCartGrid["CODE", GridRow].Value = objds.Tables["CheckItem"].Rows[0][0].ToString();
                        custCartGrid["NAME", GridRow].Value = objds.Tables["CheckItem"].Rows[0][1].ToString();
                        custCartGrid["DESCRIPTION", GridRow].Value = objds.Tables["CheckItem"].Rows[0][4].ToString();
                        custCartGrid["CUSTNAME", GridRow].Value = tbCustomerName.Text.Trim();
                        custCartGrid["CUSTCELL", GridRow].Value = tbCustomerCell.Text.Trim();
                        custCartGrid["PRICE", GridRow].Value = tb_FP_Price_Single_Product.Text.Trim();
                        custCartGrid["TMPDATE", GridRow].Value = date.ToString();
                        custCartGrid["TMPMARGIN", GridRow].Value = int.Parse(tb_FP_Price_Single_Product.Text.ToString()) - int.Parse(objds.Tables["CheckItem"].Rows[0][3].ToString());
                        custCartGrid["TMPTRANSACTIONTYPE", GridRow].Value = TransactionType;
                        //if(cb_isPending.Checked)
                        //{ custCartGrid["MODE", GridRow].Value = "Pending"; }
                        //else { custCartGrid["MODE", GridRow].Value = "Sale"; }
                        custCartGrid["MODE", GridRow].Value = "Sale";
                        custCartGrid["PurchasePrice", GridRow].Value = objds.Tables["CheckItem"].Rows[0][3].ToString();
                       

                        if (cb_isPending.Checked)
                        {
                            generatePendingID();
                            //gbox_Payment.Enabled = true;
                        }
                        generateSaleID();

                        //add delete button
                        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                        custCartGrid.ColumnCount = 18;
                        custCartGrid.Columns.Add(btn);
                        btn.HeaderText = "Delete Product";
                        btn.Text = "X";
                        btn.Name = "btn";
                        btn.UseColumnTextForButtonValue = true;
                        custCartGrid.ClearSelection();
                        btn.DefaultCellStyle.BackColor = Color.DarkRed;

                        custCartGrid.ClearSelection();
                        tb_FP_P_ID.Clear();
                        tb_FP_Price_Single_Product.Clear();
                        tb_FP_P_ID.Focus();
                        custCartGrid.Refresh();

                        calculteTotalAmount();

                        if(cb_isPending.Checked)
                        { calcPendAmt();
                        gbox_Payment.Enabled = true;
                        }
                        
                        

                        gbox_CustomerInfo.Enabled = false;

                        return;

                    }
                }
            }
            else
            {
                MessageBox.Show("Prodcut Not Found in Stock! Change Prodcut ID and Try Again.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            return;



        }

        private void fetchProductFrmDB()
        {
            objc = new SqlConnection(c);
            objcmd = new SqlCommand("select * from Add_New_item where SrNo ='" + tb_FP_P_ID.Text.Trim() + "'", objc);
            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            objds = new DataSet();
            objda.Fill(objds, "CheckItem");
        }

        private void generatePendingID()
        {
            pendingID = "PID_" + custCartGrid["CODE", GridRow].Value + "_" + invoiceID + "_" + number;
            custCartGrid["PENDING", GridRow].Value = pendingID;
        }

        private void generateSaleID()
        {
            saleID = "SID_" + custCartGrid["CODE", GridRow].Value + "_" + invoiceID + "_" + number;
            custCartGrid["SALE", GridRow].Value = saleID;
            number++;
        }

        private void calculteTotalAmount()
        {
            if (custCartGrid.Rows.Count > 0 || cb_return.Checked==true)
            {
                total_price = 0;
                total_products = 0;
                for (int i = 0; i < custCartGrid.Rows.Count; i++)
                {
                    int net_price = int.Parse(custCartGrid["PRICE", i].Value.ToString());
                    total_price += net_price;
                }
                tbSaleTotal.Text =  total_price.ToString();
                tbProductsTotal.Text = custCartGrid.Rows.Count.ToString();

                tb_Show_Total_Products.Text = (custCartGrid.Rows.Count - int.Parse(tb_Return_product.Text.ToString())).ToString();
                tb_Show_Total_Amount.Text = (total_price - int.Parse(tb_Return_amt.Text.ToString())).ToString();
            }
            else
            {
                tbProductsTotal.Text = "0";
                tbSaleTotal.Text = "0";

                tb_Show_Total_Products.Text = "0";
                tb_Show_Total_Amount.Text = "0";
                gbox_CustomerInfo.Enabled = true;
                gbox_Payment.Enabled = false;
                if(cb_isPending.Checked)
                { cb_isPending.Checked = false; }
            }
        }

        private void determineTransactionType()
        {
            if (radioButton1.Checked == true)
            {
                TransactionType = "Regular";
            }
            else
            {
                TransactionType = "Whole Sale";
            }
        }
        //ROLE 2 ENDS HERE

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //tb_FP_AV_QTY.Clear();
            //try
            //{
            //    objc = new SqlConnection(c);
            //    objcmd = new SqlCommand("select * from Add_New_item where SrNo LIKE'" + tb_FP_P_ID.Text.Trim() + "'", objc);
            //    objda = new SqlDataAdapter(objcmd.CommandText, objc);
            //    objds = new DataSet();
            //    objda.Fill(objds, "tbl");

            //    tb_FP_AV_QTY.Text = objds.Tables["tbl"].Rows[0][2].ToString();
            //    tb_PI_P_Name.Text = objds.Tables["tbl"].Rows[0][1].ToString();
            //    tb_PI_Desc.Text = objds.Tables["tbl"].Rows[0][4].ToString();
            //    purchase_Price_SingleProduct = int.Parse(objds.Tables["tbl"].Rows[0][3].ToString());
            //    tb_FP_REQ_QTY.Focus();
            //    tb_FP_P_ID.BackColor = Color.LightGreen;
            //    //MessageBox.Show("single product price is: " + purchase_Price_SingleProduct);

            //    //coding step 2
            //    tb_PI_P_Name.Text = objds.Tables["tbl"].Rows[0][1].ToString();
            //    //coding step 2

            //    try
            //    {
            //        tb_PI_Net_Amount.Text = (int.Parse(tb_FP_REQ_QTY.Text) * int.Parse(tb_FP_Price_Single_Product.Text)).ToString();

            //    }
            //    catch
            //    {
            //        tb_PI_Net_Amount.Text = "0";
            //    }
            //}
            //catch { tb_FP_P_ID.BackColor = Color.White; }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            tb_FP_P_ID.Clear();
            

        }
        private void tb_PricePP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmViewStock frm = new frmViewStock();
            frm.ShowDialog();
        }

        private void tbCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allows only string, white space and backspace key
            if (!char.IsLetterOrDigit(e.KeyChar) && (!char.IsWhiteSpace(e.KeyChar) && (!char.IsControl(e.KeyChar))))
            {
                e.Handled = true;

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allows only alphabets, digits and backspace key
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
           

        }

        private void tbCustomerCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbCustomerName_Click(object sender, EventArgs e)
        {
            tbCustomerName.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tb_FP_Price_Single_Product_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_FP_REQ_QTY_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void tb_FP_Price_Single_Product_MouseLeave(object sender, EventArgs e)
        {

        }

        private void btnDelCart_Click(object sender, EventArgs e)
        {


        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void tb_Percent_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_ReturnProduct_CheckedChanged(object sender, EventArgs e)
        {
            
            //frmReturn frm = new frmReturn();
            //frm.ShowDialog();
        }

        private void tb_FP_InvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void tb_FP_InvoiceNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            { MessageBox.Show("Enter Pdouct Invoice No. # first!", "Invoice # Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            else
            {
                loadDataInReturnGrid();
            }
        }

        private void loadDataInReturnGrid()
        {
            objc = new SqlConnection(c);
            objcmd = new SqlCommand("select PRODUCTNAME AS 'SOLD ITEM', PIECEPRICE AS 'SALE PRICE', DATE AS 'TRANSACTION DATE', INVOICENO AS 'INVOICE #', CUSTOMERNAME AS 'CUSTOMER NAME', ProductID as 'Item Code', PurchasePrice as 'Purchase Price', SaleID as 'SID' from Sales where InvoiceNo = '" + textBox1.Text.Trim() + "'", objc);
            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            objds = new DataSet();
            objda.Fill(objds, "tbl");
            returnGridView.DataSource = objds.Tables[0].DefaultView;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            
                    if (this.returnGridView.SelectedRows.Count > 0)
                    {
                        returnGridView.Rows.RemoveAt(returnGridView.SelectedRows[0].Index);
                    }
                
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (returnGridView.Rows.Count == 0)
            {
                MessageBox.Show("Please select products by Invoice No fisrt.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            else
            {
                    //insertReturnDataIntoGrid();

                    returnGridView.Enabled = false;
                    cb_return.Checked = true;
                    cb_return.Enabled = true;
                    btnFetch.Enabled = false;
                    btnX.Enabled = false;
                    btnProcess.Enabled = false;

                    calcRetAmt();

                    calculteTotalAmount();
                    calcPendAmt();
            }
        }

        private void calcRetAmt()
        {
            if (returnGridView.Rows.Count > 0)
            {
                int total_price = 0;
                //int total_products = 0;
                int net_price = 0;
                for (int i = 0; i < returnGridView.Rows.Count; i++)
                {
                    net_price += int.Parse(returnGridView["Sale Price", i].Value.ToString());
                }
                total_price += net_price;
                tb_Return_product.Text = returnGridView.Rows.Count.ToString();
                tb_Return_amt.Text = (net_price.ToString());
                calculteTotalAmount();
                calcPendAmt();
            }
            else
            {
                tb_Return_amt.Text = "0";
                tb_Return_product.Text = "0";
                calculteTotalAmount();
                calcPendAmt();
            }
        }

        private void insertReturnDataIntoGrid()
        {
            int rows = returnGridView.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                //variables for storing data in bill
                string product_name = returnGridView.Rows[i].Cells[0].Value.ToString();
                string salePrice = returnGridView.Rows[i].Cells[1].Value.ToString();
                string t_date = returnGridView.Rows[i].Cells[2].Value.ToString();
                string customer_name = returnGridView.Rows[i].Cells[4].Value.ToString();
                string product_id = returnGridView.Rows[i].Cells[5].Value.ToString();
                string purchase_price = returnGridView.Rows[i].Cells[6].Value.ToString();
                string mode = "Sale Return";
                string query;
                objc = new SqlConnection(c);

                query = "insert into Bill(SrNo,Product_Name,Piece_Price, SalePerson, CustomerName, CustomerCell,TransactionType, BillID, Mode, SID, ReturnedProducts, ReturnedProductsAmount, TotalPayment, InitialPayment, Balance, SaleTotalAmt, SaleTotalProducts) values ('" + product_id + "','" + product_name + "','" + salePrice + "','" + Class1.LoggedInUsername + "', '" + customer_name + "', '" + tbCustomerCell.Text.Trim() + "', '" + TransactionType + "', '" + labelID.Text + "', '" + mode + "', '" + saleID + "', '" + tb_Return_product.Text + "', '" + tb_Return_amt.Text + "', '" + tb_Show_Total_Amount.Text.Trim() + "', '" + tbInitialPayment.Text.Trim() + "', '" + tbAmountToPay.Text + "', '" + tbSaleTotal.Text + "', '" + tbProductsTotal.Text + "')";

                objcmd = new SqlCommand(query, objc);
                objc.Open();
                objcmd.ExecuteNonQuery();
                objc.Close();
            }
        }

        private void frmSale_Activated(object sender, EventArgs e)
        {

        }

        private void cb_return_CheckedChanged(object sender, EventArgs e)
        {
        
            if (cb_return.Checked == true)
            { }
            else
            {
                int rs = returnGridView.Rows.Count;
                for (int i = 0; i < rs; i++)
                {
                    //variables for deleting data from bill
                    string product_id = returnGridView.Rows[i].Cells[5].Value.ToString();
                    string query;
                    objc = new SqlConnection(c);
                    query = "delete from Bill where SrNo='" + product_id + "' AND Mode = 'Sale Return'";
                    objcmd = new SqlCommand(query, objc);
                    objc.Open();
                    objcmd.ExecuteNonQuery();
                    objc.Close();
                }


                tb_Return_product.Text = "0";
                tb_Return_amt.Text = "0";
                btnX.Enabled = true;
                btnFetch.Enabled = true;
                returnGridView.Enabled = true;
                returnGridView.DataSource = null;
                returnGridView.Refresh();
                btnProcess.Enabled = true;
                cb_return.Enabled = false;

                calculteTotalAmount();
                if (cb_isPending.Checked)
                { calcPendAmt(); }


                // }
            }
        }

        private void label_return_price_show_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_return_products_show_TextChanged(object sender, EventArgs e)
        {

        }

        private void custCartGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 18)
            {
                if (MessageBox.Show("Are you sure you want to delete Product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (this.custCartGrid.SelectedRows.Count > 0)
                    {
                        custCartGrid.Rows.RemoveAt(custCartGrid.SelectedRows[0].Index);
                        custCartGrid.ClearSelection();
                        number--;
                        calculteTotalAmount();
                        if (cb_isPending.Checked)
                        { calcPendAmt(); }
                    }
                    else
                    {
                        custCartGrid.ClearSelection();
                    }
                }
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Clicked");
        }


        private void custCartGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void returnGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (this.returnGridView.SelectedRows.Count > 0)
                {
                    returnGridView.Rows.RemoveAt(returnGridView.SelectedRows[0].Index);
                    returnGridView.ClearSelection();



                    calculteTotalAmount();
                }

            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void tbInitialPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void cb_Pending_CheckedChanged(object sender, EventArgs e)
        {
           

            
        }

        private void calcPendAmt()
        {
            tb_SPayment_Purchase_Total.Text = tbSaleTotal.Text;
            tb_SPayment_PurchasedProducts.Text = tbProductsTotal.Text;

            tb_SPayment_ReturendProducts.Text = tb_Return_product.Text;
            tb_SPayment_Return_Total.Text = tb_Return_amt.Text;
            if(cb_isPending.Checked)
            { tbAmountToPay.Text = tb_Show_Total_Amount.Text; }
            else { tbAmountToPay.Text = "0"; }
            
        }

        private void tbInitialPayment_TextChanged(object sender, EventArgs e)
        {
            if (tbInitialPayment.Text.Trim() == "")
            {
                tbInitialPayment.Text = "0";
            }
            if (int.Parse(tbInitialPayment.Text) >= int.Parse(tbAmountToPay.Text))
            {

                MessageBox.Show("Initial Payment can not be equal or greater than Total Payment. Try Again!", "Try AGAIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbInitialPayment.Clear();
                tbInitialPayment.Focus();
                tbInitialPayment.Text = "0";
            }

            tbAmountToPay.Text = tb_Show_Total_Amount.Text;
            tbAmountToPay.Text = (int.Parse(tbAmountToPay.Text) - int.Parse(tbInitialPayment.Text)).ToString();

            
        }

        private void cb_isPending_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_isPending.Checked)
            {
                if (custCartGrid.Rows.Count>0)
                {
                    
                        custCartGrid.Rows.Clear();
                        custCartGrid.Refresh();
                        calculteTotalAmount();
                        
                         calcPendAmt();
                         cb_isPending.Checked = false;
                        number = 1;
                        gbox_Payment.Enabled = true;
                    
                }
                gbox_Payment.Enabled = true;
            }
            else
            {
                if (custCartGrid.Rows.Count > 0)
                {

                    custCartGrid.Rows.Clear();
                    custCartGrid.Refresh();
                    calculteTotalAmount();
                    number = 1;
                    calcPendAmt();
                    gbox_Payment.Enabled = false;

                }
                gbox_Payment.Enabled = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbAmountToPay.Text = tb_Show_Total_Amount.Text;
            tbAmountToPay.Text = (int.Parse(tbAmountToPay.Text) - int.Parse(tbInitialPayment.Text)).ToString();
        }

        private void tbInitialPayment_Click(object sender, EventArgs e)
        {
            tbAmountToPay.Text = tb_Show_Total_Amount.Text;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frmPendingManage frm = new frmPendingManage();
            
            frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmAddNewItem frm = new frmAddNewItem();
            frm.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frmViewStock frm = new frmViewStock();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmSaleHistory frm = new frmSaleHistory();
            frm.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmExpense frm = new frmExpense();
            frm.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}

