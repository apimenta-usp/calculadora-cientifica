
namespace InterfaceUsuario.Ajuda {
    partial class FrmManual {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManual));
            this.arquivoPDF = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.arquivoPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // arquivoPDF
            // 
            this.arquivoPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arquivoPDF.Enabled = true;
            this.arquivoPDF.Location = new System.Drawing.Point(0, 0);
            this.arquivoPDF.Name = "arquivoPDF";
            this.arquivoPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("arquivoPDF.OcxState")));
            this.arquivoPDF.Size = new System.Drawing.Size(780, 457);
            this.arquivoPDF.TabIndex = 0;
            // 
            // FrmManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 457);
            this.Controls.Add(this.arquivoPDF);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmManual";
            this.Text = "Manual Calculadora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmManual_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.arquivoPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF arquivoPDF;
    }
}