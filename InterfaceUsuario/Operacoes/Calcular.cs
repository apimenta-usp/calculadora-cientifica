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

        public static string DesvioAmostral(List<double> dados) {
            double resultado;
            double somatoriaDesvio;
            if (dados.Count == 0) {
                MessageBox.Show("Não há dados inseridos!", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            } else if (dados.Count == 1) {
                MessageBox.Show("Dados insuficientes para o cálculo!", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            } else {
                somatoriaDesvio = SomatoriaDesvioQuadrado(dados);
                resultado = Math.Sqrt(somatoriaDesvio / (dados.Count - 1));
                return Visor.Exibir(resultado);
            }
        }

        public static string DesvioPopulacional(List<double> dados) {
            double resultado;
            double somatoriaDesvio;
            if (dados.Count == 0) {
                MessageBox.Show("Não há dados inseridos!", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            } else {
                somatoriaDesvio = SomatoriaDesvioQuadrado(dados);
                resultado = Math.Sqrt(somatoriaDesvio / dados.Count);
                return Visor.Exibir(resultado);
            }
        }

        private static double SomatoriaDesvioQuadrado(List<double> dados) {
            double somatoriaDesvio = 0;
            double somaValores = 0;
            foreach (double valor in dados) {
                somaValores += valor;
            }
            double mediaAritmetica = somaValores / dados.Count;
            foreach (double valor in dados) {
                somatoriaDesvio += (valor - mediaAritmetica) * (valor - mediaAritmetica);
            }
            return somatoriaDesvio;
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
                if (numero >= 1 && numero < 10) {
                    visor = numero.ToString(CultureInfo.InvariantCulture);
                } else 
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

        public static string AnguloDireto(string angulo, string visor, RadioButton optGrau, RadioButton optGrado) {
            double seno = SenoDoAngulo(visor, optGrau, optGrado);
            double cosseno = CossenoDoAngulo(visor, optGrau, optGrado);
            double numero = Visor.Capturar(visor);
            if (optGrau.Checked) {
                if (numero == 90.0) {
                    cosseno = 0.0;
                }
            }
            if (optGrado.Checked) {
                if (numero == 300.0) {
                    cosseno = 0.0;
                }
            }
            if (numero == Visor.Capturar(((FrmCalculadoraCientifica.Pi * 3) / 2).ToString())) {
                cosseno = 0.0;
            }
            if (angulo == "seno") {
                return Visor.Exibir(seno);
            } else if (angulo == "cosseno") {
                return Visor.Exibir(cosseno);
            } else {
                if (cosseno == 0.0) {
                    MessageBox.Show("Valor infinito de tangente!", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return string.Empty;
                } else {
                    double tangente = TangenteDoAngulo(visor, optGrau, optGrado);
                    return Visor.Exibir(tangente);
                }
            }
        }

        public static string AnguloInverso(string angulo, string visor, RadioButton optGrau, RadioButton optGrado) {
            double? senoInverso = AnguloDoSeno(visor, optGrau, optGrado);
            double? cossenoInverso = AnguloDoCosseno(visor, optGrau, optGrado);
            double tangenteInversa = AnguloDaTangente(visor, optGrau, optGrado);
            if (angulo == "seno") {
                if (senoInverso == null) {
                    MessageBox.Show("Seno inexistente!", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return string.Empty;
                } else
                    return Visor.Exibir((double)senoInverso);
            } else if (angulo == "cosseno") {
                if (cossenoInverso == null) {
                    MessageBox.Show("Cosseno inexistente!", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return string.Empty;
                } else
                    return Visor.Exibir((double)cossenoInverso);
            } else {
                return Visor.Exibir(tangenteInversa);
            }
        }

        private static double SenoDoAngulo(string visor, RadioButton optGrau, RadioButton optGrado) {
            double numero = Visor.Capturar(visor);
            if (optGrau.Checked) {
                numero = (numero * FrmCalculadoraCientifica.Pi) / 180.0;
            }
            if (optGrado.Checked) {
                numero = (numero * FrmCalculadoraCientifica.Pi) / 200.0;
            }
            if (numero > (FrmCalculadoraCientifica.Pi * 2)) {
                numero %= (FrmCalculadoraCientifica.Pi * 2);
            }
            double seno;

            switch (numero) {
                case 0:
                case FrmCalculadoraCientifica.Pi:
                case (FrmCalculadoraCientifica.Pi * 2):
                    seno = 0.0;
                    break;
                case (FrmCalculadoraCientifica.Pi / 6):
                case ((FrmCalculadoraCientifica.Pi * 5) / 6):
                    seno = 0.5;
                    break;
                case ((FrmCalculadoraCientifica.Pi * 7) / 6):
                case ((FrmCalculadoraCientifica.Pi * 11) / 6):
                    seno = -0.5;
                    break;
                case (FrmCalculadoraCientifica.Pi / 4):
                case ((FrmCalculadoraCientifica.Pi * 3) / 4):
                    seno = (Math.Sqrt(2) / 2);
                    break;
                case ((FrmCalculadoraCientifica.Pi * 5) / 4):
                case ((FrmCalculadoraCientifica.Pi * 7) / 4):
                    seno = -(Math.Sqrt(2) / 2);
                    break;
                case (FrmCalculadoraCientifica.Pi / 3):
                case ((FrmCalculadoraCientifica.Pi * 2) / 3):
                    seno = (Math.Sqrt(3) / 2);
                    break;
                case ((FrmCalculadoraCientifica.Pi * 4) / 3):
                case ((FrmCalculadoraCientifica.Pi * 5) / 3):
                    seno = -(Math.Sqrt(3) / 2);
                    break;
                case (FrmCalculadoraCientifica.Pi / 2):
                    seno = 1.0;
                    break;
                case ((FrmCalculadoraCientifica.Pi * 3) / 2):
                    seno = -1.0;
                    break;
                default:
                    seno = Math.Sin(numero);
                    break;
            }

            return seno;
        }

        private static double CossenoDoAngulo(string visor, RadioButton optGrau, RadioButton optGrado) {
            double numero = Visor.Capturar(visor);
            if (optGrau.Checked) {
                numero = (numero * FrmCalculadoraCientifica.Pi) / 180.0;
            }
            if (optGrado.Checked) {
                numero = (numero * FrmCalculadoraCientifica.Pi) / 200.0;
            }
            if (numero > (FrmCalculadoraCientifica.Pi * 2)) {
                numero %= (FrmCalculadoraCientifica.Pi * 2);
            }
            double cosseno;

            switch (numero) {
                case 0:
                case (FrmCalculadoraCientifica.Pi * 2):
                    cosseno = 1.0;
                    break;
                case (FrmCalculadoraCientifica.Pi / 6):
                case ((FrmCalculadoraCientifica.Pi * 11) / 6):
                    cosseno = (Math.Sqrt(3) / 2);
                    break;
                case ((FrmCalculadoraCientifica.Pi * 5) / 6):
                case ((FrmCalculadoraCientifica.Pi * 7) / 6):
                    cosseno = -(Math.Sqrt(3) / 2);
                    break;
                case (FrmCalculadoraCientifica.Pi / 4):
                case ((FrmCalculadoraCientifica.Pi * 7) / 4):
                    cosseno = (Math.Sqrt(2) / 2);
                    break;
                case ((FrmCalculadoraCientifica.Pi * 3) / 4):
                case ((FrmCalculadoraCientifica.Pi * 5) / 4):
                    cosseno = -(Math.Sqrt(2) / 2);
                    break;
                case (FrmCalculadoraCientifica.Pi / 3):
                case ((FrmCalculadoraCientifica.Pi * 5) / 3):
                    cosseno = 0.5;
                    break;
                case ((FrmCalculadoraCientifica.Pi * 2) / 3):
                case ((FrmCalculadoraCientifica.Pi * 4) / 3):
                    cosseno = -0.5;
                    break;
                case (FrmCalculadoraCientifica.Pi / 2):
                case ((FrmCalculadoraCientifica.Pi * 3) / 2):
                    cosseno = 0.0;
                    break;
                case FrmCalculadoraCientifica.Pi:
                    cosseno = -1.0;
                    break;
                default:
                    cosseno = Math.Cos(numero);
                    break;
            }

            return cosseno;
        }

        private static double TangenteDoAngulo(string visor, RadioButton optGrau, RadioButton optGrado) {
            double numero = Visor.Capturar(visor);
            if (optGrau.Checked) {
                numero = (numero * FrmCalculadoraCientifica.Pi) / 180.0;
            }
            if (optGrado.Checked) {
                numero = (numero * FrmCalculadoraCientifica.Pi) / 200.0;
            }
            if (numero > (FrmCalculadoraCientifica.Pi * 2)) {
                numero %= (FrmCalculadoraCientifica.Pi * 2);
            }
            double tangente;

            switch (numero) {
                case 0:
                case FrmCalculadoraCientifica.Pi:
                case (FrmCalculadoraCientifica.Pi * 2):
                    tangente = 0.0;
                    break;
                case (FrmCalculadoraCientifica.Pi / 6):
                case ((FrmCalculadoraCientifica.Pi * 7) / 6):
                    tangente = (Math.Sqrt(3) / 3);
                    break;
                case ((FrmCalculadoraCientifica.Pi * 5) / 6):
                case ((FrmCalculadoraCientifica.Pi * 11) / 6):
                    tangente = -(Math.Sqrt(3) / 3);
                    break;
                case (FrmCalculadoraCientifica.Pi / 4):
                case ((FrmCalculadoraCientifica.Pi * 5) / 4):
                    tangente = 1.0;
                    break;
                case ((FrmCalculadoraCientifica.Pi * 3) / 4):
                case ((FrmCalculadoraCientifica.Pi * 7) / 4):
                    tangente = -1.0;
                    break;
                case (FrmCalculadoraCientifica.Pi / 3):
                case ((FrmCalculadoraCientifica.Pi * 4) / 3):
                    tangente = Math.Sqrt(3);
                    break;
                case ((FrmCalculadoraCientifica.Pi * 2) / 3):
                case ((FrmCalculadoraCientifica.Pi * 5) / 3):
                    tangente = -Math.Sqrt(3);
                    break;
                default:
                    tangente = Math.Tan(numero);
                    break;
            }

            return tangente;
        }

        private static double? AnguloDoSeno(string visor, RadioButton optGrau, RadioButton optGrado) {
            double numero = Visor.Capturar(visor);
            double? senoInverso;
            if (numero < -1 || numero > 1) {
                senoInverso = null;
            } else
                senoInverso = Math.Asin(numero);

            if (optGrau.Checked) {
                senoInverso = (senoInverso * 180.0) / FrmCalculadoraCientifica.Pi;
                if (numero == 0) {
                    senoInverso = 0.0;
                } else if (numero == 0.5) {
                    senoInverso = 30.0;
                } else if (44.99999999 < senoInverso && senoInverso < 45.000000001) {
                    senoInverso = 45.0;
                } else if (59.99999999 < senoInverso && senoInverso < 60.000000001) {
                    senoInverso = 60.0;
                } else if (numero == 1.0) {
                    senoInverso = 90.0;
                }
            }
            if (optGrado.Checked) {
                senoInverso = (senoInverso * 200.0) / FrmCalculadoraCientifica.Pi;
                if (numero == 0) {
                    senoInverso = 0.0;
                } else if (numero == 0.5) {
                    senoInverso = (100.0 / 3.0);
                } else if (49.99999999 < senoInverso && senoInverso < 50.000000001) {
                    senoInverso = 50.0;
                } else if (numero == (Visor.Capturar((Math.Sqrt(3) / 2).ToString()))) {
                    senoInverso = (200.0 / 3.0);
                } else if (numero == 1.0) {
                    senoInverso = 100.0;
                }
            }

            return senoInverso;
        }

        private static double? AnguloDoCosseno(string visor, RadioButton optGrau, RadioButton optGrado) {
            double numero = Visor.Capturar(visor);
            double? cossenoInverso;
            if (numero < -1 || numero > 1) {
                cossenoInverso = null;
            } else
                cossenoInverso = Math.Acos(numero);

            if (optGrau.Checked) {
                cossenoInverso = (cossenoInverso * 180.0) / FrmCalculadoraCientifica.Pi;
                if (numero == 1.0) {
                    cossenoInverso = 0.0;
                } else if (29.99999999 < cossenoInverso && cossenoInverso < 30.000000001) {
                    cossenoInverso = 30.0;
                } else if (44.99999999 < cossenoInverso && cossenoInverso < 45.000000001) {
                    cossenoInverso = 45.0;
                } else if (numero == 0.5) {
                    cossenoInverso = 60.0;
                } else if (numero == 0) {
                    cossenoInverso = 90.0;
                }
            }
            if (optGrado.Checked) {
                cossenoInverso = (cossenoInverso * 200.0) / FrmCalculadoraCientifica.Pi;
                if (numero == 1.0) {
                    cossenoInverso = 0.0;
                } else if (numero == (Math.Sqrt(3) / 2)) {
                    cossenoInverso = (100.0 / 3.0);
                } else if (49.99999999 < cossenoInverso && cossenoInverso < 50.000000001) {
                    cossenoInverso = 50.0;
                } else if (numero == 0.5) {
                    cossenoInverso = (200.0 / 3.0);
                } else if (numero == 0) {
                    cossenoInverso = 100.0;
                }
            }

            return cossenoInverso;
        }

        private static double AnguloDaTangente(string visor, RadioButton optGrau, RadioButton optGrado) {
            double numero = Visor.Capturar(visor);
            double tangenteInversa = Math.Atan(numero);

            if (optGrau.Checked) {
                tangenteInversa = (tangenteInversa * 180.0) / FrmCalculadoraCientifica.Pi;
                if (numero == 0) {
                    tangenteInversa = 0.0;
                } else if (29.99999999 < tangenteInversa && tangenteInversa < 30.000000001) {
                    tangenteInversa = 30.0;
                } else if (numero == 1.0) {
                    tangenteInversa = 45.0;
                } else if (59.99999999 < tangenteInversa && tangenteInversa < 60.000000001) {
                    tangenteInversa = 60.0;
                }
            }
            if (optGrado.Checked) {
                tangenteInversa = (tangenteInversa * 200.0) / FrmCalculadoraCientifica.Pi;
                if (numero == 0) {
                    tangenteInversa = 0.0;
                } else if (numero == (Math.Sqrt(3) / 3)) {
                    tangenteInversa = (100.0 / 3.0);
                } else if (numero == 1.0) {
                    tangenteInversa = 50.0;
                } else if (numero == Math.Sqrt(3)) {
                    tangenteInversa = (200.0 / 3.0);
                }
            }

            return tangenteInversa;
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
