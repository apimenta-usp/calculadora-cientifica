using InterfaceUsuario.Personalizacao;
using System.Windows.Forms;

namespace InterfaceUsuario.Operacoes {
    public class AdicionarCaracter {
        public static void Numerico(string caracter, Label lblVisor) {
            byte tamanho;
            if (lblVisor.Text.Trim().Contains(",") || lblVisor.Text.Trim().Contains("."))
                tamanho = 11;
            else
                tamanho = 10;
            if (FrmCalculadoraCientifica.PressionouIgual || FrmCalculadoraCientifica.PressionouMemoria
                || !(double.TryParse(lblVisor.Text.Trim(), out double numero))) {
                lblVisor.Text = string.Empty;
                FrmCalculadoraCientifica.PressionouIgual = false;
                FrmCalculadoraCientifica.PressionouMemoria = false;
            }
            if (lblVisor.Text.Trim().Equals("0") || lblVisor.Text.Trim().Equals("-0"))
                lblVisor.Text = caracter;
            else if (lblVisor.Text.Trim().Length < tamanho)
                lblVisor.Text += caracter;
        }

        public static void Operacao(string caracter, Label lblVisor) {
            if (!double.TryParse(lblVisor.Text.Trim(), out double numero)) {
                lblVisor.Text = string.Empty;
            }
            if (!lblVisor.Text.Trim().Equals(string.Empty)) {
                FrmCalculadoraCientifica.Numero1 = Visor.Capturar(lblVisor.Text.Trim());
                FrmCalculadoraCientifica.Operacao = caracter;
                lblVisor.Text = string.Empty;
            }
        }
    }
}
