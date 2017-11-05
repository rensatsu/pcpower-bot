namespace PCPowerBot
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.botToken = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveToken = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.maxDelayBox = new System.Windows.Forms.ComboBox();
            this.userIdBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.botNameBox = new System.Windows.Forms.TextBox();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bot Token:";
            // 
            // botToken
            // 
            this.botToken.Location = new System.Drawing.Point(12, 67);
            this.botToken.Name = "botToken";
            this.botToken.Size = new System.Drawing.Size(300, 20);
            this.botToken.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name: ";
            // 
            // btnSaveToken
            // 
            this.btnSaveToken.Location = new System.Drawing.Point(318, 67);
            this.btnSaveToken.Name = "btnSaveToken";
            this.btnSaveToken.Size = new System.Drawing.Size(66, 20);
            this.btnSaveToken.TabIndex = 4;
            this.btnSaveToken.Text = "Save";
            this.btnSaveToken.UseVisualStyleBackColor = true;
            this.btnSaveToken.Click += new System.EventHandler(this.btnSaveToken_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Maximal command delay:";
            // 
            // maxDelayBox
            // 
            this.maxDelayBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maxDelayBox.FormattingEnabled = true;
            this.maxDelayBox.Items.AddRange(new object[] {
            "10",
            "30",
            "45",
            "60",
            "90",
            "120",
            "150",
            "180",
            "300",
            "600",
            "1800",
            "3600"});
            this.maxDelayBox.Location = new System.Drawing.Point(12, 145);
            this.maxDelayBox.Name = "maxDelayBox";
            this.maxDelayBox.Size = new System.Drawing.Size(300, 21);
            this.maxDelayBox.TabIndex = 6;
            this.maxDelayBox.SelectedValueChanged += new System.EventHandler(this.maxDelayBox_SelectedValueChanged);
            // 
            // userIdBox
            // 
            this.userIdBox.Location = new System.Drawing.Point(12, 106);
            this.userIdBox.Name = "userIdBox";
            this.userIdBox.Size = new System.Drawing.Size(300, 20);
            this.userIdBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Allowed User:";
            // 
            // botNameBox
            // 
            this.botNameBox.Location = new System.Drawing.Point(12, 28);
            this.botNameBox.Name = "botNameBox";
            this.botNameBox.ReadOnly = true;
            this.botNameBox.Size = new System.Drawing.Size(300, 20);
            this.botNameBox.TabIndex = 9;
            this.botNameBox.Text = "N/A";
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Location = new System.Drawing.Point(318, 106);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(66, 20);
            this.btnSaveUser.TabIndex = 10;
            this.btnSaveUser.Text = "Save";
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 181);
            this.Controls.Add(this.btnSaveUser);
            this.Controls.Add(this.botNameBox);
            this.Controls.Add(this.userIdBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maxDelayBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveToken);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botToken);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PCPower Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox botToken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox maxDelayBox;
        private System.Windows.Forms.TextBox userIdBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox botNameBox;
        private System.Windows.Forms.Button btnSaveUser;
    }
}

