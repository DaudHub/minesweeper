namespace Minesweeper
{
    partial class Menu
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.cbxDifficulty = new System.Windows.Forms.ComboBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.cbxSize = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(60, 41);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(414, 73);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Minesweeper";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficulty.Location = new System.Drawing.Point(68, 172);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(163, 25);
            this.lblDifficulty.TabIndex = 1;
            this.lblDifficulty.Text = "Select difficulty:";
            // 
            // cbxDifficulty
            // 
            this.cbxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDifficulty.FormattingEnabled = true;
            this.cbxDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.cbxDifficulty.Location = new System.Drawing.Point(310, 176);
            this.cbxDifficulty.Name = "cbxDifficulty";
            this.cbxDifficulty.Size = new System.Drawing.Size(164, 21);
            this.cbxDifficulty.TabIndex = 2;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(68, 234);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(123, 25);
            this.lblSize.TabIndex = 3;
            this.lblSize.Text = "Select size:";
            // 
            // cbxSize
            // 
            this.cbxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSize.FormattingEnabled = true;
            this.cbxSize.Items.AddRange(new object[] {
            "10x10",
            "16x16",
            "20x20",
            "25x25"});
            this.cbxSize.Location = new System.Drawing.Point(310, 240);
            this.cbxSize.Name = "cbxSize";
            this.cbxSize.Size = new System.Drawing.Size(164, 21);
            this.cbxSize.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(167, 344);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(205, 51);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(503, 13);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 25);
            this.btnConfig.TabIndex = 6;
            this.btnConfig.Text = "⚙";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(540, 450);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cbxSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.cbxDifficulty);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.ComboBox cbxDifficulty;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.ComboBox cbxSize;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnConfig;
    }
}