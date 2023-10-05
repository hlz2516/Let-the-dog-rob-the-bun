namespace 放狗抢包子
{
    partial class Form1_NoLock
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_bunNum = new System.Windows.Forms.Label();
            this.dog1 = new 放狗抢包子.Dog();
            this.dog2 = new 放狗抢包子.Dog();
            this.dog3 = new 放狗抢包子.Dog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::放狗抢包子.Resource1.包子;
            this.pictureBox1.Location = new System.Drawing.Point(355, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(523, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // lbl_bunNum
            // 
            this.lbl_bunNum.AutoSize = true;
            this.lbl_bunNum.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_bunNum.Location = new System.Drawing.Point(548, 120);
            this.lbl_bunNum.Name = "lbl_bunNum";
            this.lbl_bunNum.Size = new System.Drawing.Size(28, 31);
            this.lbl_bunNum.TabIndex = 2;
            this.lbl_bunNum.Text = "0";
            // 
            // dog1
            // 
            this.dog1.BunNum = 0;
            this.dog1.DogImage = global::放狗抢包子.Resource1.柯基;
            this.dog1.Location = new System.Drawing.Point(89, 283);
            this.dog1.Name = "dog1";
            this.dog1.Size = new System.Drawing.Size(178, 193);
            this.dog1.TabIndex = 3;
            // 
            // dog2
            // 
            this.dog2.BunNum = 0;
            this.dog2.DogImage = global::放狗抢包子.Resource1.柯基;
            this.dog2.Location = new System.Drawing.Point(374, 283);
            this.dog2.Name = "dog2";
            this.dog2.Size = new System.Drawing.Size(178, 193);
            this.dog2.TabIndex = 4;
            // 
            // dog3
            // 
            this.dog3.BunNum = 0;
            this.dog3.DogImage = global::放狗抢包子.Resource1.柯基;
            this.dog3.Location = new System.Drawing.Point(697, 283);
            this.dog3.Name = "dog3";
            this.dog3.Size = new System.Drawing.Size(178, 193);
            this.dog3.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(373, 503);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 56);
            this.button1.TabIndex = 6;
            this.button1.Text = "开始抢包子";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 597);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dog3);
            this.Controls.Add(this.dog2);
            this.Controls.Add(this.dog1);
            this.Controls.Add(this.lbl_bunNum);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label lbl_bunNum;
        private Dog dog1;
        private Dog dog2;
        private Dog dog3;
        private Button button1;
    }
}