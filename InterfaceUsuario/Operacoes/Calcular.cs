using InterfaceUsuario.Personalizacao;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace InterfaceUsuario.Operacoes {
    public class Calcular {
        public static void LimparCampos(Label lblVisor) {
            lblVisor.Text = string.Empty;
            FrmCalculadoraCientifica.Numero1 = 0;
            FrmCalculadoraCientifica.Numero2 = 0;
            FrmCalculadoraCientifica.Operacao = string.Empty;
            FrmCalculadoraCientifica.PressionouIgual = false;
            FrmCalculadoraCientifica.PressionouPotenciacao = false;
            FrmCalculadoraCientifica.PressionouExponencial = false;
        }
    }
}
