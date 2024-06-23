namespace Minesweeper
{
    partial class Game
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTimeCount = new System.Windows.Forms.Label();
            this.gameTime = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pnlLayout
            // 
            this.pnlLayout.ColumnCount = 1;
            this.pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.pnlLayout.Location = new System.Drawing.Point(49, 62);
            this.pnlLayout.Margin = new System.Windows.Forms.Padding(1);
            this.pnlLayout.Name = "pnlLayout";
            this.pnlLayout.RowCount = 1;
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.pnlLayout.Size = new System.Drawing.Size(400, 400);
            this.pnlLayout.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(461, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(25, 25);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "↺";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblTimeCount
            // 
            this.lblTimeCount.AutoSize = true;
            this.lblTimeCount.Location = new System.Drawing.Point(232, 24);
            this.lblTimeCount.Name = "lblTimeCount";
            this.lblTimeCount.Size = new System.Drawing.Size(0, 13);
            this.lblTimeCount.TabIndex = 2;
            // 
            // gameTime
            // 
            this.gameTime.Enabled = true;
            this.gameTime.Interval = 1000;
            this.gameTime.Tick += new System.EventHandler(this.gameTime_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 489);
            this.Controls.Add(this.lblTimeCount);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pnlLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Game";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlLayout;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTimeCount;
        private System.Windows.Forms.Timer gameTime;
    }
}

