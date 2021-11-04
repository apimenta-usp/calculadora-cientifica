using InterfaceUsuario.Personalizacao;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace InterfaceUsuario.Operacoes {
    public class Calcular {
        public static void Operacao(string operacao, Label lblVisor, double numero1, double numero2) {
            double resultado;
            switch (operacao) {
                case "+":
                    resultado = (numero1 + numero2);
                    lblVisor.Text = Visor.Exibir(resultado);
                    break;
                case "-":
                    resultado = (numero1 - numero2);
                    lblVisor.Text = Visor.Exibir(resultado);
                    break;
                case "*":
                    resultado = (numero1 * numero2);
                    lblVisor.Text = Visor.Exibir(resultado);
                    break;
                case "/":
                    if (numero2 == 0) {
                        MessageBox.Show("Divisão por zero!", "Erro!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblVisor.Text = string.Empty;
                        break;
                    }
                    resultado = (numero1 / numero2);
                    lblVisor.Text = Visor.Exibir(resultado);
                    break;
                //case "~":
                //    Radiciacao(numero1, numero2, lblVisor);
                //    break;
                //case "^":
                //    Potencia(numero1, numero2, lblVisor);
                //    break;
                //case "&":
                //    Exponencial(numero1, numero2, lblVisor);
                //    break;
            }
        }

        public static double NumeroAleatorio() {
            Random random = new Random();
            int aleatorio = random.Next(1, 1000);
            double numero = aleatorio / 1000.0;
            return numero;
        }

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
