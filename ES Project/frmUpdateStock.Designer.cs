namespace ES_Project
{
    partial class frmUpdateStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateStock));
            this.lbl_1 = new System.Windows.Forms.Label();
            this.cbox_ = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnUDel = new System.Windows.Forms.Button();
            this.tb_U_Delete_PName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_U_ProductQuantity = new System.Windows.Forms.TextBox();
            this.btnUQty = new System.Windows.Forms.Button();
            this.tb_qty_new = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUProductName = new System.Windows.Forms.Button();
            this.tb_Name_New = new System.Windows.Forms.TextBox();
            this.tb_U_ProductName = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbP_PurchasePrice = new System.Windows.Forms.TextBox();
            this.btnPurchasePrice = new System.Windows.Forms.Button();
            this.tbN_PurchasePrice = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_1
            // 
            this.lbl_1.AutoSize = true;
            this.lbl_1.Location = new System.Drawing.Point(611, 4);
            this.lbl_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(100, 17);
            this.lbl_1.TabIndex = 13;
            this.lbl_1.Text = "Select Product";
            // 
            // cbox_
            // 
            this.cbox_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbox_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbox_.FormattingEnabled = true;
            this.cbox_.Location = new System.Drawing.Point(571, 25);
            this.cbox_.Margin = new System.Windows.Forms.Padding(4);
            this.cbox_.Name = "cbox_";
            this.cbox_.Size = new System.Drawing.Size(184, 24);
            this.cbox_.Sorted = true;
            this.cbox_.TabIndex = 0;
            this.toolTip.SetToolTip(this.cbox_, "Select item to update");
            this.cbox_.SelectedIndexChanged += new System.EventHandler(this.cbox__SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.btnUDel);
            this.groupBox5.Controls.Add(this.tb_U_Delete_PName);
            this.groupBox5.Location = new System.Drawing.Point(444, 178);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(319, 144);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Delete Product";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(78, 39);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 17);
            this.label12.TabIndex = 8;
            this.label12.Text = "Product Name";
            // 
            // btnUDel
            // 
            this.btnUDel.BackColor = System.Drawing.Color.Transparent;
            this.btnUDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUDel.Image = ((System.Drawing.Image)(resources.GetObject("btnUDel.Image")));
            this.btnUDel.Location = new System.Drawing.Point(80, 98);
            this.btnUDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnUDel.Name = "btnUDel";
            this.btnUDel.Size = new System.Drawing.Size(192, 38);
            this.btnUDel.TabIndex = 1;
            this.btnUDel.Text = "DELETE";
            this.btnUDel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip.SetToolTip(this.btnUDel, "Press to Delete");
            this.btnUDel.UseVisualStyleBackColor = false;
            this.btnUDel.Click += new System.EventHandler(this.btnUDel_Click);
            // 
            // tb_U_Delete_PName
            // 
            this.tb_U_Delete_PName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tb_U_Delete_PName.Location = new System.Drawing.Point(80, 67);
            this.tb_U_Delete_PName.Margin = new System.Windows.Forms.Padding(4);
            this.tb_U_Delete_PName.Name = "tb_U_Delete_PName";
            this.tb_U_Delete_PName.ReadOnly = true;
            this.tb_U_Delete_PName.Size = new System.Drawing.Size(195, 23);
            this.tb_U_Delete_PName.TabIndex = 0;
            this.tb_U_Delete_PName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tb_U_Delete_PName, "Previous Value");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.tb_U_ProductQuantity);
            this.groupBox4.Controls.Add(this.btnUQty);
            this.groupBox4.Controls.Add(this.tb_qty_new);
            this.groupBox4.Location = new System.Drawing.Point(449, 48);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(314, 135);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Update Product Quantity";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "New:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 20);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Previous:";
            // 
            // tb_U_ProductQuantity
            // 
            this.tb_U_ProductQuantity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tb_U_ProductQuantity.Location = new System.Drawing.Point(57, 52);
            this.tb_U_ProductQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.tb_U_ProductQuantity.Name = "tb_U_ProductQuantity";
            this.tb_U_ProductQuantity.ReadOnly = true;
            this.tb_U_ProductQuantity.Size = new System.Drawing.Size(100, 23);
            this.tb_U_ProductQuantity.TabIndex = 14;
            this.tb_U_ProductQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tb_U_ProductQuantity, "Previous Value");
            // 
            // btnUQty
            // 
            this.btnUQty.BackColor = System.Drawing.Color.Transparent;
            this.btnUQty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUQty.Image = ((System.Drawing.Image)(resources.GetObject("btnUQty.Image")));
            this.btnUQty.Location = new System.Drawing.Point(60, 84);
            this.btnUQty.Margin = new System.Windows.Forms.Padding(4);
            this.btnUQty.Name = "btnUQty";
            this.btnUQty.Size = new System.Drawing.Size(221, 38);
            this.btnUQty.TabIndex = 1;
            this.btnUQty.Text = "CHANGE";
            this.btnUQty.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip.SetToolTip(this.btnUQty, "Press to update");
            this.btnUQty.UseVisualStyleBackColor = false;
            this.btnUQty.Click += new System.EventHandler(this.btnUQty_Click);
            // 
            // tb_qty_new
            // 
            this.tb_qty_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tb_qty_new.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_qty_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tb_qty_new.Location = new System.Drawing.Point(180, 52);
            this.tb_qty_new.Margin = new System.Windows.Forms.Padding(4);
            this.tb_qty_new.Name = "tb_qty_new";
            this.tb_qty_new.Size = new System.Drawing.Size(100, 23);
            this.tb_qty_new.TabIndex = 0;
            this.tb_qty_new.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tb_qty_new, "Enter new value");
            this.tb_qty_new.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_qty_new_KeyPress);
            this.tb_qty_new.MouseLeave += new System.EventHandler(this.tb_qty_new_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnUProductName);
            this.groupBox1.Controls.Add(this.tb_Name_New);
            this.groupBox1.Controls.Add(this.tb_U_ProductName);
            this.groupBox1.Location = new System.Drawing.Point(16, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(425, 136);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Product Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "New:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Previous:";
            // 
            // btnUProductName
            // 
            this.btnUProductName.BackColor = System.Drawing.Color.Transparent;
            this.btnUProductName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUProductName.Image = ((System.Drawing.Image)(resources.GetObject("btnUProductName.Image")));
            this.btnUProductName.Location = new System.Drawing.Point(19, 85);
            this.btnUProductName.Margin = new System.Windows.Forms.Padding(4);
            this.btnUProductName.Name = "btnUProductName";
            this.btnUProductName.Size = new System.Drawing.Size(401, 39);
            this.btnUProductName.TabIndex = 1;
            this.btnUProductName.Text = "CHANGE";
            this.btnUProductName.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip.SetToolTip(this.btnUProductName, "Press to update");
            this.btnUProductName.UseVisualStyleBackColor = false;
            this.btnUProductName.Click += new System.EventHandler(this.btnUProductName_Click);
            // 
            // tb_Name_New
            // 
            this.tb_Name_New.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tb_Name_New.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_Name_New.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tb_Name_New.Location = new System.Drawing.Point(223, 53);
            this.tb_Name_New.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Name_New.Name = "tb_Name_New";
            this.tb_Name_New.Size = new System.Drawing.Size(196, 23);
            this.tb_Name_New.TabIndex = 0;
            this.tb_Name_New.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tb_Name_New, "Enter new value");
            this.tb_Name_New.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Name_New_KeyPress);
            // 
            // tb_U_ProductName
            // 
            this.tb_U_ProductName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tb_U_ProductName.Location = new System.Drawing.Point(19, 53);
            this.tb_U_ProductName.Margin = new System.Windows.Forms.Padding(4);
            this.tb_U_ProductName.Name = "tb_U_ProductName";
            this.tb_U_ProductName.ReadOnly = true;
            this.tb_U_ProductName.Size = new System.Drawing.Size(195, 23);
            this.tb_U_ProductName.TabIndex = 0;
            this.tb_U_ProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tb_U_ProductName, "Previous Value");
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.tbP_PurchasePrice);
            this.groupBox6.Controls.Add(this.btnPurchasePrice);
            this.groupBox6.Controls.Add(this.tbN_PurchasePrice);
            this.groupBox6.Location = new System.Drawing.Point(16, 191);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(420, 131);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Update Purchase Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "New:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Previous:";
            // 
            // tbP_PurchasePrice
            // 
            this.tbP_PurchasePrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbP_PurchasePrice.Location = new System.Drawing.Point(12, 47);
            this.tbP_PurchasePrice.Margin = new System.Windows.Forms.Padding(4);
            this.tbP_PurchasePrice.Name = "tbP_PurchasePrice";
            this.tbP_PurchasePrice.ReadOnly = true;
            this.tbP_PurchasePrice.Size = new System.Drawing.Size(195, 23);
            this.tbP_PurchasePrice.TabIndex = 14;
            this.tbP_PurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tbP_PurchasePrice, "Previous Value");
            // 
            // btnPurchasePrice
            // 
            this.btnPurchasePrice.BackColor = System.Drawing.Color.Transparent;
            this.btnPurchasePrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurchasePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchasePrice.Image = ((System.Drawing.Image)(resources.GetObject("btnPurchasePrice.Image")));
            this.btnPurchasePrice.Location = new System.Drawing.Point(15, 79);
            this.btnPurchasePrice.Margin = new System.Windows.Forms.Padding(4);
            this.btnPurchasePrice.Name = "btnPurchasePrice";
            this.btnPurchasePrice.Size = new System.Drawing.Size(397, 38);
            this.btnPurchasePrice.TabIndex = 1;
            this.btnPurchasePrice.Text = "CHANGE";
            this.btnPurchasePrice.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip.SetToolTip(this.btnPurchasePrice, "Press to update");
            this.btnPurchasePrice.UseVisualStyleBackColor = false;
            this.btnPurchasePrice.Click += new System.EventHandler(this.btnPurchasePrice_Click);
            // 
            // tbN_PurchasePrice
            // 
            this.tbN_PurchasePrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbN_PurchasePrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbN_PurchasePrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbN_PurchasePrice.Location = new System.Drawing.Point(223, 47);
            this.tbN_PurchasePrice.Margin = new System.Windows.Forms.Padding(4);
            this.tbN_PurchasePrice.Name = "tbN_PurchasePrice";
            this.tbN_PurchasePrice.Size = new System.Drawing.Size(188, 23);
            this.tbN_PurchasePrice.TabIndex = 0;
            this.tbN_PurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tbN_PurchasePrice, "Enter new value");
            this.tbN_PurchasePrice.TextChanged += new System.EventHandler(this.tbN_PurchasePrice_TextChanged);
            this.tbN_PurchasePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbN_PurchasePrice_KeyPress);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.Location = new System.Drawing.Point(16, 330);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(747, 176);
            this.dataGridView2.TabIndex = 26;
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Update Stock";
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Select Product from list";
            // 
            // frmUpdateStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(787, 535);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.lbl_1);
            this.Controls.Add(this.cbox_);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateStock";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Stock Information";
            this.Activated += new System.EventHandler(this.frmUpdateStock_Activated);
            this.Load += new System.EventHandler(this.frmUpdateStock_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmUpdateStock_MouseClick);
            this.MouseHover += new System.EventHandler(this.frmUpdateStock_MouseHover);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.ComboBox cbox_;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnUDel;
        private System.Windows.Forms.TextBox tb_U_Delete_PName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_U_ProductQuantity;
        private System.Windows.Forms.Button btnUQty;
        private System.Windows.Forms.TextBox tb_qty_new;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUProductName;
        private System.Windows.Forms.TextBox tb_Name_New;
        private System.Windows.Forms.TextBox tb_U_ProductName;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbP_PurchasePrice;
        private System.Windows.Forms.Button btnPurchasePrice;
        private System.Windows.Forms.TextBox tbN_PurchasePrice;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}