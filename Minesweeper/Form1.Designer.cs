namespace Minesweeper
{
    partial class MineSweeper
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.newGame_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bombsLeftLabel = new System.Windows.Forms.Label();
            this.cellsRevealedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newGame_Button
            // 
            this.newGame_Button.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newGame_Button.Location = new System.Drawing.Point(550, 300);
            this.newGame_Button.Name = "newGame_Button";
            this.newGame_Button.Size = new System.Drawing.Size(160, 40);
            this.newGame_Button.TabIndex = 0;
            this.newGame_Button.Text = "New Game";
            this.newGame_Button.UseVisualStyleBackColor = true;
            this.newGame_Button.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(547, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bombs Left:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(547, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cells Revealed:";
            // 
            // bombsLeftLabel
            // 
            this.bombsLeftLabel.AutoSize = true;
            this.bombsLeftLabel.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bombsLeftLabel.Location = new System.Drawing.Point(580, 128);
            this.bombsLeftLabel.Name = "bombsLeftLabel";
            this.bombsLeftLabel.Size = new System.Drawing.Size(26, 31);
            this.bombsLeftLabel.TabIndex = 3;
            this.bombsLeftLabel.Text = "0";
            // 
            // cellsRevealedLabel
            // 
            this.cellsRevealedLabel.AutoSize = true;
            this.cellsRevealedLabel.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cellsRevealedLabel.Location = new System.Drawing.Point(580, 221);
            this.cellsRevealedLabel.Name = "cellsRevealedLabel";
            this.cellsRevealedLabel.Size = new System.Drawing.Size(26, 31);
            this.cellsRevealedLabel.TabIndex = 4;
            this.cellsRevealedLabel.Text = "0";
            // 
            // MineSweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.cellsRevealedLabel);
            this.Controls.Add(this.bombsLeftLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newGame_Button);
            this.Name = "MineSweeper";
            this.Text = "MineSweeper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGame_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label bombsLeftLabel;
        private System.Windows.Forms.Label cellsRevealedLabel;
    }
}

