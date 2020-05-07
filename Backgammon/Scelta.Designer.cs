namespace Backgammon
{
    partial class Scelta
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnMuovi = new System.Windows.Forms.Button();
            this.btnTogli = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quale azione vuoi fare?";
            // 
            // btnMuovi
            // 
            this.btnMuovi.BackColor = System.Drawing.Color.Black;
            this.btnMuovi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMuovi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMuovi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMuovi.Font = new System.Drawing.Font("Stencil", 14F);
            this.btnMuovi.ForeColor = System.Drawing.Color.White;
            this.btnMuovi.Location = new System.Drawing.Point(65, 81);
            this.btnMuovi.Name = "btnMuovi";
            this.btnMuovi.Size = new System.Drawing.Size(106, 65);
            this.btnMuovi.TabIndex = 169;
            this.btnMuovi.Text = "Muovi";
            this.btnMuovi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMuovi.UseMnemonic = false;
            this.btnMuovi.UseVisualStyleBackColor = false;
            this.btnMuovi.Click += new System.EventHandler(this.btnMuovi_Click);
            // 
            // btnTogli
            // 
            this.btnTogli.BackColor = System.Drawing.Color.Black;
            this.btnTogli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTogli.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTogli.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTogli.Font = new System.Drawing.Font("Stencil", 14F);
            this.btnTogli.ForeColor = System.Drawing.Color.White;
            this.btnTogli.Location = new System.Drawing.Point(290, 81);
            this.btnTogli.Name = "btnTogli";
            this.btnTogli.Size = new System.Drawing.Size(106, 65);
            this.btnTogli.TabIndex = 170;
            this.btnTogli.Text = "Togli";
            this.btnTogli.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTogli.UseMnemonic = false;
            this.btnTogli.UseVisualStyleBackColor = false;
            this.btnTogli.Click += new System.EventHandler(this.btnTogli_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 20);
            this.label2.TabIndex = 171;
            this.label2.Text = "Premi 2 volte per confermare";
            // 
            // Scelta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 168);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTogli);
            this.Controls.Add(this.btnMuovi);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scelta";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scelta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMuovi;
        private System.Windows.Forms.Button btnTogli;
        private System.Windows.Forms.Label label2;
    }
}