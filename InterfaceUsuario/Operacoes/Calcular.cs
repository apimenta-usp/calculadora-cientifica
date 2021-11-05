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
                case "~":
                    Radiciacao(numero1, numero2, lblVisor);
                    break;
                case "^":
                    Potencia(numero1, numero2, lblVisor);
                    break;
                case "&":
                    Exponencial(numero1, numero2, lblVisor);
                    break;
            }
        }

        public static double NumeroAleatorio() {
            Random random = new Random();
            int aleatorio = random.Next(1, 1000);
            double numero = aleatorio / 1000.0;
            return numero;
        }

        private static void Radiciacao(double valorRadicando, double valorIndice, Label lblVisor) {
            if (valorIndice <= 0) {
                MessageBox.Show("Raiz inexistente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparCampos(lblVisor);
                return;
            }
            valorIndice = 1 / valorIndice;
            Potencia(valorRadicando, valorIndice, lblVisor);
        }

        private static void Potencia(double valorBase, double valorExpoente, Label lblVisor) {
            double resultado = 0.0;
            int valorExpoenteInteiro = (int)Math.Floor(valorExpoente);
            if (valorBase == 0 && valorExpoente < 0) {
                MessageBox.Show("Raiz inexistente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparCampos(lblVisor);
                return;
            }
            if (valorBase < 0 && valorExpoenteInteiro != valorExpoente) {
                valorBase = Math.Abs(valorBase);
                var valoresFracao = ConverterEmFracao(valorExpoente);
                ulong numeradorFracao = valoresFracao.Item1;
                ulong denominadorFracao = valoresFracao.Item2;

                if (denominadorFracao % 2 == 0) {
                    MessageBox.Show("Raiz inexistente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimparCampos(lblVisor);
                    return;
                }
                if (denominadorFracao % 2 != 0 && numeradorFracao % 2 == 0) {
                    resultado = Math.Pow(valorBase, valorExpoente);
                } else if (denominadorFracao % 2 != 0 && numeradorFracao % 2 != 0) {
                    resultado = Math.Pow(valorBase, valorExpoente) * (-1);
                }
                lblVisor.Text = Visor.Exibir(resultado);
            } else {
                resultado = Math.Pow(valorBase, valorExpoente);
                if (resultado.ToString().Trim().Contains('∞')
                    || double.IsNaN(resultado) || double.IsInfinity(resultado)
                    || double.IsPositiveInfinity(resultado) || double.IsNegativeInfinity(resultado)) {
                    MessageBox.Show("Cálculo não implementado ou \nraiz inexistente!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimparCampos(lblVisor);
                    return;
                }
                lblVisor.Text = Visor.Exibir(resultado);
            }
            FrmCalculadoraCientifica.PressionouIgual = true;
        }

        private static Tuple<ulong, ulong> ConverterEmFracao(double valorExpoente) {
            valorExpoente = Math.Abs(valorExpoente);
            double superior = 0.0;
            double inferior = 1.0;
            double quociente = superior / inferior;

            while (quociente != valorExpoente) {
                if (quociente < valorExpoente) {
                    superior++;
                } else if (quociente > valorExpoente) {
                    inferior++;
                }
                quociente = superior / inferior;
            }

            ulong numerador = (ulong)Math.Round(superior);
            ulong denominador = (ulong)Math.Round(inferior);

            return new Tuple<ulong, ulong>(numerador, denominador);
        }

        private static void Exponencial(double valorMultiplicando, double valorExpoente, Label lblVisor) {
            int valorExpoenteInteiro = (int)Math.Floor(valorExpoente);
            if (valorExpoenteInteiro != valorExpoente) {
                MessageBox.Show("Use apenas expoentes inteiros!", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimparCampos(lblVisor);
                return;
            }
            if (valorExpoente < -300.0) {
                lblVisor.Text = "0E+0";
                return;
            }
            double resultado = valorMultiplicando * Math.Pow(10, valorExpoenteInteiro);
            if (double.IsInfinity(resultado)) {
                MessageBox.Show("Número muito grande!", "Aviso!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblVisor.Text = string.Empty;
            } else {
                string visor = resultado.ToString("0.####E+0", CultureInfo.InvariantCulture);
                if (FrmCalculadoraCientifica.Virgula) {
                    visor = visor.Replace('.', ',');
                }
                lblVisor.Text = visor;
            }
        }
        
        public static string DecimalCientifico(string visor) {
            if (visor.Contains('e')) {
                visor = visor.Replace('e', 'E');
            }

            if (visor.Contains('E')) {
                string[] particao = visor.Split('E');
                double valorMultiplicando = Visor.Capturar(particao[0]);
                int valorExpoente = Convert.ToInt32(particao[1]);
                double numero = valorMultiplicando * Math.Pow(10, valorExpoente);
                if (numero > 9_999_999_999 || numero < 0.000_000_001) {
                    return visor;
                } else
                    return Visor.Exibir(numero);
            } else {
                double numero = Visor.Capturar(visor);
                visor = numero.ToString("0.####E+0", CultureInfo.InvariantCulture);
                if (FrmCalculadoraCientifica.Virgula) {
                    visor = visor.Replace('.', ',');
                }
                return visor;
            }
        }

        public static string Fatorial(string visor) {
            double dNumero = Visor.Capturar(visor);
            int iNumero = (int)Math.Floor(dNumero);
            if (iNumero != dNumero || dNumero < 0) {
                MessageBox.Show("Fatorial somente para números naturais!", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            } else {
                if (dNumero == 0 || dNumero == 1) {
                    return "1";
                } else {
                    while (iNumero > 1) {
                        double antecessor = iNumero - 1;
                        dNumero *= antecessor;
                        iNumero--;
                    }
                    if (double.IsInfinity(dNumero)) {
                        MessageBox.Show("Número muito grande!", "Aviso!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return string.Empty;
                    } else
                        return Visor.Exibir(dNumero);
                }
            }
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
