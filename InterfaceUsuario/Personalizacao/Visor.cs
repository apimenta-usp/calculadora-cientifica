using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace InterfaceUsuario.Personalizacao {
    public class Visor {
        public static string Exibir(double resultado) {
            TextBox txt = new TextBox();
            txt.Text = resultado.ToString(CultureInfo.InvariantCulture);
            string visor = txt.Text;
            if (visor.Contains('e')) {
                visor = visor.Replace('e', 'E');
            }
            if (visor.Contains('E')) {
                visor = resultado.ToString("0.####E+0", CultureInfo.InvariantCulture);
            }
            if (FrmCalculadoraCientifica.Virgula) {
                visor = visor.Replace('.', ',');
            }
            return visor;
        }

        public static double Capturar(string visor) {
            if (FrmCalculadoraCientifica.Virgula) {
                visor = visor.Replace(',', '.');
            }
            return Convert.ToDouble(visor, CultureInfo.InvariantCulture);
        }
    }
}
