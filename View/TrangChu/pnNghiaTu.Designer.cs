﻿namespace FlashCard.View.TrangChu
{
    partial class pnNghiaTu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NghiaTu = new Label();
            SuspendLayout();
            // 
            // NghiaTu
            // 
            NghiaTu.AutoSize = true;
            NghiaTu.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NghiaTu.Location = new Point(323, 55);
            NghiaTu.Name = "NghiaTu";
            NghiaTu.Size = new Size(121, 37);
            NghiaTu.TabIndex = 0;
            NghiaTu.Text = "Nghĩa từ";
            // 
            // pnNghiaTu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(NghiaTu);
            Name = "pnNghiaTu";
            Size = new Size(840, 155);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NghiaTu;
    }
}
