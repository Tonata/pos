namespace SkyBarAp
{
    partial class Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Management));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ResBarten = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CanBarten = new System.Windows.Forms.Button();
            this.LoginBarten = new System.Windows.Forms.Button();
            this.textPassBat = new System.Windows.Forms.TextBox();
            this.textUserBat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ResAdmin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CanAdmin = new System.Windows.Forms.Button();
            this.LogAdmin = new System.Windows.Forms.Button();
            this.textPassAdmin = new System.Windows.Forms.TextBox();
            this.textUserA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.orderBtn = new System.Windows.Forms.Button();
            this.managementbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 428);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.orderBtn);
            this.groupBox1.Controls.Add(this.managementbtn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(385, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 305);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mangement Area";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.ResBarten);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.CanBarten);
            this.groupBox2.Controls.Add(this.LoginBarten);
            this.groupBox2.Controls.Add(this.textPassBat);
            this.groupBox2.Controls.Add(this.textUserBat);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(57, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 238);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sign In";
            this.groupBox2.Visible = false;
            // 
            // ResBarten
            // 
            this.ResBarten.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResBarten.Location = new System.Drawing.Point(105, 184);
            this.ResBarten.Name = "ResBarten";
            this.ResBarten.Size = new System.Drawing.Size(89, 45);
            this.ResBarten.TabIndex = 6;
            this.ResBarten.Text = "Reset";
            this.ResBarten.UseVisualStyleBackColor = true;
            this.ResBarten.Click += new System.EventHandler(this.ResBarten_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Login Bartender";
            // 
            // CanBarten
            // 
            this.CanBarten.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CanBarten.Location = new System.Drawing.Point(202, 184);
            this.CanBarten.Name = "CanBarten";
            this.CanBarten.Size = new System.Drawing.Size(89, 45);
            this.CanBarten.TabIndex = 4;
            this.CanBarten.Text = "Cancel";
            this.CanBarten.UseVisualStyleBackColor = true;
            this.CanBarten.Click += new System.EventHandler(this.CanBarten_Click);
            // 
            // LoginBarten
            // 
            this.LoginBarten.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBarten.Location = new System.Drawing.Point(7, 184);
            this.LoginBarten.Name = "LoginBarten";
            this.LoginBarten.Size = new System.Drawing.Size(89, 45);
            this.LoginBarten.TabIndex = 3;
            this.LoginBarten.Text = "Login";
            this.LoginBarten.UseVisualStyleBackColor = true;
            this.LoginBarten.Click += new System.EventHandler(this.LoginBarten_Click);
            // 
            // textPassBat
            // 
            this.textPassBat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassBat.Location = new System.Drawing.Point(115, 137);
            this.textPassBat.MaxLength = 12;
            this.textPassBat.Name = "textPassBat";
            this.textPassBat.Size = new System.Drawing.Size(155, 26);
            this.textPassBat.TabIndex = 3;
            this.textPassBat.UseSystemPasswordChar = true;
            // 
            // textUserBat
            // 
            this.textUserBat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUserBat.Location = new System.Drawing.Point(116, 80);
            this.textUserBat.MaxLength = 12;
            this.textUserBat.Name = "textUserBat";
            this.textUserBat.Size = new System.Drawing.Size(155, 26);
            this.textUserBat.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.ResAdmin);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.CanAdmin);
            this.groupBox3.Controls.Add(this.LogAdmin);
            this.groupBox3.Controls.Add(this.textPassAdmin);
            this.groupBox3.Controls.Add(this.textUserA);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(57, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(301, 238);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sign In";
            this.groupBox3.Visible = false;
            // 
            // ResAdmin
            // 
            this.ResAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResAdmin.Location = new System.Drawing.Point(105, 184);
            this.ResAdmin.Name = "ResAdmin";
            this.ResAdmin.Size = new System.Drawing.Size(89, 45);
            this.ResAdmin.TabIndex = 6;
            this.ResAdmin.Text = "Reset";
            this.ResAdmin.UseVisualStyleBackColor = true;
            this.ResAdmin.Click += new System.EventHandler(this.ResAdmin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Login Aministrator";
            // 
            // CanAdmin
            // 
            this.CanAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CanAdmin.Location = new System.Drawing.Point(202, 184);
            this.CanAdmin.Name = "CanAdmin";
            this.CanAdmin.Size = new System.Drawing.Size(89, 45);
            this.CanAdmin.TabIndex = 4;
            this.CanAdmin.Text = "Cancel";
            this.CanAdmin.UseVisualStyleBackColor = true;
            this.CanAdmin.Click += new System.EventHandler(this.CanAdmin_Click);
            // 
            // LogAdmin
            // 
            this.LogAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogAdmin.Location = new System.Drawing.Point(7, 184);
            this.LogAdmin.Name = "LogAdmin";
            this.LogAdmin.Size = new System.Drawing.Size(89, 45);
            this.LogAdmin.TabIndex = 3;
            this.LogAdmin.Text = "Login";
            this.LogAdmin.UseVisualStyleBackColor = true;
            this.LogAdmin.Click += new System.EventHandler(this.LogAdmin_Click);
            // 
            // textPassAdmin
            // 
            this.textPassAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassAdmin.Location = new System.Drawing.Point(115, 139);
            this.textPassAdmin.MaxLength = 12;
            this.textPassAdmin.Name = "textPassAdmin";
            this.textPassAdmin.Size = new System.Drawing.Size(155, 26);
            this.textPassAdmin.TabIndex = 3;
            this.textPassAdmin.UseSystemPasswordChar = true;
            // 
            // textUserA
            // 
            this.textUserA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUserA.Location = new System.Drawing.Point(116, 82);
            this.textUserA.MaxLength = 12;
            this.textUserA.Name = "textUserA";
            this.textUserA.Size = new System.Drawing.Size(155, 26);
            this.textUserA.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Password  :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "UserName :";
            // 
            // orderBtn
            // 
            this.orderBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("orderBtn.BackgroundImage")));
            this.orderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderBtn.Location = new System.Drawing.Point(57, 61);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(254, 88);
            this.orderBtn.TabIndex = 1;
            this.orderBtn.Text = "Place Order";
            this.orderBtn.UseVisualStyleBackColor = true;
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // managementbtn
            // 
            this.managementbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("managementbtn.BackgroundImage")));
            this.managementbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managementbtn.Location = new System.Drawing.Point(62, 188);
            this.managementbtn.Name = "managementbtn";
            this.managementbtn.Size = new System.Drawing.Size(254, 88);
            this.managementbtn.TabIndex = 0;
            this.managementbtn.Text = "Management";
            this.managementbtn.UseVisualStyleBackColor = true;
            this.managementbtn.Click += new System.EventHandler(this.managementbtn_Click);
            // 
            // Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1099, 465);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Management";
            this.Text = "Management";
            this.Load += new System.EventHandler(this.Management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button orderBtn;
        private System.Windows.Forms.Button managementbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button CanBarten;
        private System.Windows.Forms.Button LoginBarten;
        private System.Windows.Forms.TextBox textPassBat;
        private System.Windows.Forms.TextBox textUserBat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ResBarten;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ResAdmin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CanAdmin;
        private System.Windows.Forms.Button LogAdmin;
        private System.Windows.Forms.TextBox textPassAdmin;
        private System.Windows.Forms.TextBox textUserA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}