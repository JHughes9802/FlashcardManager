namespace FlashcardManager
{
    partial class FlashcardHome
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
            this.btnAddCards = new System.Windows.Forms.Button();
            this.btnRemoveCards = new System.Windows.Forms.Button();
            this.btnReviewCards = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddCards
            // 
            this.btnAddCards.Location = new System.Drawing.Point(37, 29);
            this.btnAddCards.Name = "btnAddCards";
            this.btnAddCards.Size = new System.Drawing.Size(75, 36);
            this.btnAddCards.TabIndex = 0;
            this.btnAddCards.Text = "Add Cards";
            this.btnAddCards.UseVisualStyleBackColor = true;
            // 
            // btnRemoveCards
            // 
            this.btnRemoveCards.Location = new System.Drawing.Point(193, 29);
            this.btnRemoveCards.Name = "btnRemoveCards";
            this.btnRemoveCards.Size = new System.Drawing.Size(75, 36);
            this.btnRemoveCards.TabIndex = 1;
            this.btnRemoveCards.Text = "Remove Cards";
            this.btnRemoveCards.UseVisualStyleBackColor = true;
            // 
            // btnReviewCards
            // 
            this.btnReviewCards.Location = new System.Drawing.Point(37, 99);
            this.btnReviewCards.Name = "btnReviewCards";
            this.btnReviewCards.Size = new System.Drawing.Size(75, 36);
            this.btnReviewCards.TabIndex = 2;
            this.btnReviewCards.Text = "Review Cards";
            this.btnReviewCards.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(193, 99);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 36);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // FlashcardHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(308, 163);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReviewCards);
            this.Controls.Add(this.btnRemoveCards);
            this.Controls.Add(this.btnAddCards);
            this.Name = "FlashcardHome";
            this.Text = "Flashcard Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddCards;
        private System.Windows.Forms.Button btnRemoveCards;
        private System.Windows.Forms.Button btnReviewCards;
        private System.Windows.Forms.Button btnExit;
    }
}

