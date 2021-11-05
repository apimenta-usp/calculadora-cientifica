using System.Windows.Forms;

namespace InterfaceUsuario.Ajuda {
    public partial class FrmManual : Form {
        public FrmManual() {
            InitializeComponent();
            arquivoPDF.LoadFile("ManualCalculadora.pdf");
        }

        private void FrmManual_FormClosing(object sender, FormClosingEventArgs e) {
            arquivoPDF.Dispose();
        }
    }
}
