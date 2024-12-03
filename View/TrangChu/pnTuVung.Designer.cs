namespace FlashCard.View.TrangChu
{
    partial class pnTuVung
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
            TuVung = new Label();
            SuspendLayout();
            // 
            // TuVung
            // 
            TuVung.AutoSize = true;
            TuVung.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TuVung.Location = new Point(347, 58);
            TuVung.Name = "TuVung";
            TuVung.Size = new Size(113, 32);
            TuVung.TabIndex = 0;
            TuVung.Text = "Từ Vựng";
            // 
            // pnTuVung
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TuVung);
            Name = "pnTuVung";
            Size = new Size(840, 155);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TuVung;
    }
}
