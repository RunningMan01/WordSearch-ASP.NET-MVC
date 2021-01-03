namespace WordSearchTestHarness
{
    partial class Form1
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
            this.buttonCreateGrid = new System.Windows.Forms.Button();
            this.labelGrid = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCreateGrid
            // 
            this.buttonCreateGrid.Location = new System.Drawing.Point(12, 12);
            this.buttonCreateGrid.Name = "buttonCreateGrid";
            this.buttonCreateGrid.Size = new System.Drawing.Size(131, 23);
            this.buttonCreateGrid.TabIndex = 0;
            this.buttonCreateGrid.Text = "Create Grid";
            this.buttonCreateGrid.UseVisualStyleBackColor = true;
            this.buttonCreateGrid.Click += new System.EventHandler(this.buttonCreateGrid_Click);
            // 
            // labelGrid
            // 
            this.labelGrid.BackColor = System.Drawing.SystemColors.HighlightText;
            this.labelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelGrid.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrid.Location = new System.Drawing.Point(19, 51);
            this.labelGrid.Name = "labelGrid";
            this.labelGrid.Size = new System.Drawing.Size(757, 467);
            this.labelGrid.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 559);
            this.Controls.Add(this.labelGrid);
            this.Controls.Add(this.buttonCreateGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateGrid;
        private System.Windows.Forms.Label labelGrid;
    }
}

