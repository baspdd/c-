namespace DentalPaymentApp
{
    partial class Dental
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkClean = new System.Windows.Forms.CheckBox();
            this.lblCleanCost = new System.Windows.Forms.Label();
            this.chkWhitenning = new System.Windows.Forms.CheckBox();
            this.lblWhitenningCost = new System.Windows.Forms.Label();
            this.lblXRayCost = new System.Windows.Forms.Label();
            this.chkXRay = new System.Windows.Forms.CheckBox();
            this.lblFilling = new System.Windows.Forms.Label();
            this.NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblFillCost = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Impact", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(119, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(212, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dental Payment Form";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(59, 91);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(94, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Customer Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(212, 91);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(196, 23);
            this.txtName.TabIndex = 2;
            // 
            // chkClean
            // 
            this.chkClean.AutoSize = true;
            this.chkClean.Location = new System.Drawing.Point(59, 159);
            this.chkClean.Name = "chkClean";
            this.chkClean.Size = new System.Drawing.Size(66, 19);
            this.chkClean.TabIndex = 3;
            this.chkClean.Text = "Cạo vôi";
            this.chkClean.UseVisualStyleBackColor = true;
            // 
            // lblCleanCost
            // 
            this.lblCleanCost.AutoSize = true;
            this.lblCleanCost.Location = new System.Drawing.Point(356, 163);
            this.lblCleanCost.Name = "lblCleanCost";
            this.lblCleanCost.Size = new System.Drawing.Size(52, 15);
            this.lblCleanCost.TabIndex = 4;
            this.lblCleanCost.Text = "$100.000";
            // 
            // chkWhitenning
            // 
            this.chkWhitenning.AutoSize = true;
            this.chkWhitenning.Location = new System.Drawing.Point(59, 194);
            this.chkWhitenning.Name = "chkWhitenning";
            this.chkWhitenning.Size = new System.Drawing.Size(75, 19);
            this.chkWhitenning.TabIndex = 5;
            this.chkWhitenning.Text = "Tẩy trắng";
            this.chkWhitenning.UseVisualStyleBackColor = true;
            // 
            // lblWhitenningCost
            // 
            this.lblWhitenningCost.AutoSize = true;
            this.lblWhitenningCost.Location = new System.Drawing.Point(347, 198);
            this.lblWhitenningCost.Name = "lblWhitenningCost";
            this.lblWhitenningCost.Size = new System.Drawing.Size(61, 15);
            this.lblWhitenningCost.TabIndex = 6;
            this.lblWhitenningCost.Text = "$1.200.000";
            // 
            // lblXRayCost
            // 
            this.lblXRayCost.AutoSize = true;
            this.lblXRayCost.Location = new System.Drawing.Point(356, 231);
            this.lblXRayCost.Name = "lblXRayCost";
            this.lblXRayCost.Size = new System.Drawing.Size(52, 15);
            this.lblXRayCost.TabIndex = 8;
            this.lblXRayCost.Text = "$200.000";
            // 
            // chkXRay
            // 
            this.chkXRay.AutoSize = true;
            this.chkXRay.Location = new System.Drawing.Point(59, 227);
            this.chkXRay.Name = "chkXRay";
            this.chkXRay.Size = new System.Drawing.Size(109, 19);
            this.chkXRay.TabIndex = 7;
            this.chkXRay.Text = "Chụp hình răng";
            this.chkXRay.UseVisualStyleBackColor = true;
            // 
            // lblFilling
            // 
            this.lblFilling.AutoSize = true;
            this.lblFilling.Location = new System.Drawing.Point(59, 267);
            this.lblFilling.Name = "lblFilling";
            this.lblFilling.Size = new System.Drawing.Size(60, 15);
            this.lblFilling.TabIndex = 9;
            this.lblFilling.Text = "Trám răng";
            // 
            // NumericUpDown
            // 
            this.NumericUpDown.Location = new System.Drawing.Point(136, 267);
            this.NumericUpDown.Name = "NumericUpDown";
            this.NumericUpDown.Size = new System.Drawing.Size(75, 23);
            this.NumericUpDown.TabIndex = 10;
            // 
            // lblFillCost
            // 
            this.lblFillCost.AutoSize = true;
            this.lblFillCost.Location = new System.Drawing.Point(362, 275);
            this.lblFillCost.Name = "lblFillCost";
            this.lblFillCost.Size = new System.Drawing.Size(46, 15);
            this.lblFillCost.TabIndex = 11;
            this.lblFillCost.Text = "$80.000";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(202, 325);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(32, 15);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(295, 317);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(113, 23);
            this.txtTotal.TabIndex = 13;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(107, 364);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(274, 364);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 15;
            this.btnCalc.Text = "Tính tiền";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.GetPay);
            // 
            // Dental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 414);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblFillCost);
            this.Controls.Add(this.NumericUpDown);
            this.Controls.Add(this.lblFilling);
            this.Controls.Add(this.chkXRay);
            this.Controls.Add(this.lblXRayCost);
            this.Controls.Add(this.lblWhitenningCost);
            this.Controls.Add(this.chkWhitenning);
            this.Controls.Add(this.lblCleanCost);
            this.Controls.Add(this.chkClean);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.Name = "Dental";
            this.Text = "Dental Payment Form";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private CheckBox chkClean;
        private Label lblCleanCost;
        private CheckBox chkWhitenning;
        private Label lblWhitenningCost;
        private Label lblXRayCost;
        private CheckBox chkXRay;
        private Label lblFilling;
        private NumericUpDown NumericUpDown;
        private Label lblFillCost;
        private Label lblTotal;
        private TextBox txtTotal;
        private Button btnExit;
        private Button btnCalc;
    }
}