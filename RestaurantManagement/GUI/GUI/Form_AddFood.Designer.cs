namespace GUI
{
    partial class Form_AddFood
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AddFood));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnSave = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDes = new System.Windows.Forms.Label();
            this.lbURL = new System.Windows.Forms.Label();
            this.lbIsAvailable = new System.Windows.Forms.Label();
            this.cbFoodDrink = new System.Windows.Forms.ComboBox();
            this.cbAvailable = new System.Windows.Forms.ComboBox();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbIsFood = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbURLText = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.65916F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.394426F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.83923F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbDes, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbURL, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbIsAvailable, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbFoodDrink, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbAvailable, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDes, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbIsFood, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(933, 544);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.ActiveBorderThickness = 1;
            this.btnCancel.ActiveCornerRadius = 20;
            this.btnCancel.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(129)))));
            this.btnCancel.ActiveForecolor = System.Drawing.Color.White;
            this.btnCancel.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(129)))));
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("SVN-Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnCancel.IdleBorderThickness = 1;
            this.btnCancel.IdleCornerRadius = 20;
            this.btnCancel.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(129)))));
            this.btnCancel.IdleForecolor = System.Drawing.Color.White;
            this.btnCancel.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(129)))));
            this.btnCancel.Location = new System.Drawing.Point(475, 369);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 70);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActiveBorderThickness = 1;
            this.btnSave.ActiveCornerRadius = 20;
            this.btnSave.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(129)))));
            this.btnSave.ActiveForecolor = System.Drawing.Color.White;
            this.btnSave.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(129)))));
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.ButtonText = "Save";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("SVN-Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSave.IdleBorderThickness = 1;
            this.btnSave.IdleCornerRadius = 20;
            this.btnSave.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(129)))));
            this.btnSave.IdleForecolor = System.Drawing.Color.White;
            this.btnSave.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(129)))));
            this.btnSave.Location = new System.Drawing.Point(268, 369);
            this.btnSave.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 70);
            this.btnSave.TabIndex = 6;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbName.Font = new System.Drawing.Font("SVN-Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(347, 60);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(76, 60);
            this.lbName.TabIndex = 9;
            this.lbName.Text = "Name: ";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbDes
            // 
            this.lbDes.AutoSize = true;
            this.lbDes.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbDes.Font = new System.Drawing.Font("SVN-Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDes.Location = new System.Drawing.Point(303, 120);
            this.lbDes.Name = "lbDes";
            this.lbDes.Size = new System.Drawing.Size(120, 60);
            this.lbDes.TabIndex = 10;
            this.lbDes.Text = "Description: ";
            this.lbDes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbURL
            // 
            this.lbURL.AutoSize = true;
            this.lbURL.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbURL.Font = new System.Drawing.Font("SVN-Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbURL.Location = new System.Drawing.Point(314, 180);
            this.lbURL.Name = "lbURL";
            this.lbURL.Size = new System.Drawing.Size(109, 60);
            this.lbURL.TabIndex = 11;
            this.lbURL.Text = "Image URL:";
            this.lbURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbIsAvailable
            // 
            this.lbIsAvailable.AutoSize = true;
            this.lbIsAvailable.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbIsAvailable.Font = new System.Drawing.Font("SVN-Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIsAvailable.Location = new System.Drawing.Point(206, 240);
            this.lbIsAvailable.Name = "lbIsAvailable";
            this.lbIsAvailable.Size = new System.Drawing.Size(217, 60);
            this.lbIsAvailable.TabIndex = 12;
            this.lbIsAvailable.Text = "Available / Unavailable";
            this.lbIsAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbFoodDrink
            // 
            this.cbFoodDrink.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbFoodDrink.FormattingEnabled = true;
            this.cbFoodDrink.Items.AddRange(new object[] {
            "Food",
            "Drink"});
            this.cbFoodDrink.Location = new System.Drawing.Point(470, 316);
            this.cbFoodDrink.Name = "cbFoodDrink";
            this.cbFoodDrink.Size = new System.Drawing.Size(284, 28);
            this.cbFoodDrink.TabIndex = 18;
            // 
            // cbAvailable
            // 
            this.cbAvailable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbAvailable.FormattingEnabled = true;
            this.cbAvailable.Items.AddRange(new object[] {
            "Available",
            "Unavailable"});
            this.cbAvailable.Location = new System.Drawing.Point(470, 256);
            this.cbAvailable.Name = "cbAvailable";
            this.cbAvailable.Size = new System.Drawing.Size(284, 28);
            this.cbAvailable.TabIndex = 17;
            // 
            // txtDes
            // 
            this.txtDes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDes.Location = new System.Drawing.Point(470, 123);
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(284, 54);
            this.txtDes.TabIndex = 15;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtName.Location = new System.Drawing.Point(470, 77);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(284, 26);
            this.txtName.TabIndex = 14;
            // 
            // lbIsFood
            // 
            this.lbIsFood.AutoSize = true;
            this.lbIsFood.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbIsFood.Font = new System.Drawing.Font("SVN-Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIsFood.Location = new System.Drawing.Point(306, 300);
            this.lbIsFood.Name = "lbIsFood";
            this.lbIsFood.Size = new System.Drawing.Size(117, 60);
            this.lbIsFood.TabIndex = 8;
            this.lbIsFood.Text = "Food / Drink";
            this.lbIsFood.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbURLText);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(470, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 54);
            this.panel1.TabIndex = 19;
            // 
            // lbURLText
            // 
            this.lbURLText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbURLText.AutoSize = true;
            this.lbURLText.Font = new System.Drawing.Font("SVN-Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbURLText.Location = new System.Drawing.Point(172, 13);
            this.lbURLText.Name = "lbURLText";
            this.lbURLText.Size = new System.Drawing.Size(0, 27);
            this.lbURLText.TabIndex = 17;
            this.lbURLText.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowse.Font = new System.Drawing.Font("SVN-Avo", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(20, 11);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(107, 32);
            this.btnBrowse.TabIndex = 16;
            this.btnBrowse.Text = "Browse..";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Form_AddFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 544);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form_AddFood";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Food/Drink";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnCancel;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSave;
        private System.Windows.Forms.Label lbIsFood;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDes;
        private System.Windows.Forms.Label lbURL;
        private System.Windows.Forms.Label lbIsAvailable;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cbAvailable;
        private System.Windows.Forms.ComboBox cbFoodDrink;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbURLText;
    }
}