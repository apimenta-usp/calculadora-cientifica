using InterfaceUsuario.Personalizacao;
using System;
using System.Collections.Generic;
using System.Drawing;
using static InterfaceUsuario.Properties.Resources;
using System.Linq;
using System.Windows.Forms;
//using Utilities;
using System.Globalization;
using InterfaceUsuario.Operacoes;
//using InterfaceUsuario.Ajuda;
using System.Reflection;

namespace InterfaceUsuario {
    public partial class FrmCalculadoraCientifica : Form {
        public static bool Virgula { get; private set; }
        private bool Claro { get; set; }
        //private List<double> Estatistica { get; set; }
        //private FrmManual Manual { get; set; }
        public static double Numero1 { get; set; }
        public static double Numero2 { get; set; }
        public static double Memoria { get; set; }
        public static string Operacao { get; set; }
        public static bool PressionouIgual { get; set; }
        public static bool PressionouPotenciacao { get; set; }
        public static bool PressionouExponencial { get; set; }
        public static bool PressionouMemoria { get; set; }
        public const double Pi = 3.14159265359;
        //globalKeyboardHook gkh = new globalKeyboardHook();

        public FrmCalculadoraCientifica() {
            InitializeComponent();
        }

        private void FrmCalculadoraCientifica_Load(object sender, EventArgs e) {
            Claro = true;
            Virgula = false;
            //Claro = Properties.Settings.Default.TemaClaro;
            //Virgula = Properties.Settings.Default.SeparadorVirgula;
            //Estatistica.Clear();
            mnsFixar2Funcao.Checked = false;
            mnsClaro.Checked = true;
            mnsPonto.Checked = true;
            chk2Funcao.Checked = false;
            Calcular.LimparCampos(lblVisor);
            Memoria = 0;
            PressionouMemoria = false;
            TemaPrincipal(Claro, Virgula);
            //gkh.HookedKeys.Add(Keys.Enter);
            //gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
        }

        #region Eventos Click
        private void mnsCopiarVisor_Click(object sender, EventArgs e) {

        }

        private void mnsSair_Click(object sender, EventArgs e) {

        }

        private void mnsPonto_Click(object sender, EventArgs e) {

        }

        private void mnsVirgula_Click(object sender, EventArgs e) {

        }

        private void mnsClaro_Click(object sender, EventArgs e) {

        }

        private void mnsEscuro_Click(object sender, EventArgs e) {

        }

        private void mnsManual_Click(object sender, EventArgs e) {

        }

        private void mnsSobre_Click(object sender, EventArgs e) {

        }

        private void btn0_Click(object sender, EventArgs e) {
            byte tamanho;
            if (lblVisor.Text.Trim().Contains(",") || lblVisor.Text.Trim().Contains("."))
                tamanho = 11;
            else
                tamanho = 10;
            if (PressionouIgual || PressionouMemoria) {
                //lblVisor.Clear();
                lblVisor.Text = string.Empty;
                PressionouIgual = false;
                PressionouMemoria = false;
            }
            if (lblVisor.Text.Trim().Equals("0") || lblVisor.Text.Trim().Equals("-0"))
                lblVisor.Text = "0";
            else if (lblVisor.Text.Trim().Length < tamanho)
                lblVisor.Text += "0";
        }

        private void btn1_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("1", lblVisor);
        }

        private void btn2_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("2", lblVisor);
        }

        private void btn3_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("3", lblVisor);
        }

        private void btn4_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("4", lblVisor);
        }

        private void btn5_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("5", lblVisor);
        }

        private void btn6_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("6", lblVisor);
        }

        private void btn7_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("7", lblVisor);
        }

        private void btn8_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("8", lblVisor);
        }

        private void btn9_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("9", lblVisor);
        }

        private void btnSeparadorDecimal_Click(object sender, EventArgs e) {
            if (PressionouIgual || PressionouMemoria) {
                lblVisor.Text = string.Empty;
                PressionouIgual = false;
                PressionouMemoria = false;
            }
            if (lblVisor.Text.Trim().Equals(string.Empty) || lblVisor.Text.Trim() == "-") {
                if (!Virgula)
                    lblVisor.Text = "0.";
                else
                    lblVisor.Text = "0,";
                return;
            }
            if (lblVisor.Text.Contains(".") || lblVisor.Text.Contains(","))
                return;
            if (lblVisor.Text.Trim().Length > 9)
                return;
            if (!Virgula)
                lblVisor.Text += ".";
            else
                lblVisor.Text += ",";
        }

        private void btnOposicao_Click(object sender, EventArgs e) {
            if (!lblVisor.Text.Trim().Equals(string.Empty)) {
                double visor = (Visor.Capturar(lblVisor.Text.Trim())) * (-1);
                lblVisor.Text = Visor.Exibir(visor);
            }
        }

        private void btnSoma_Click(object sender, EventArgs e) {
            AdicionarCaracter.Operacao("+", lblVisor);
        }

        private void btnSubtracao_Click(object sender, EventArgs e) {
            AdicionarCaracter.Operacao("-", lblVisor);
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e) {
            AdicionarCaracter.Operacao("*", lblVisor);
        }

        private void btnDivisao_Click(object sender, EventArgs e) {
            AdicionarCaracter.Operacao("/", lblVisor);
        }

        private void btnIgual_Click(object sender, EventArgs e) {
            if (!lblVisor.Text.Trim().Equals(string.Empty)
                && double.TryParse(lblVisor.Text.Trim(), out double numero)) {
                Numero2 = Visor.Capturar(lblVisor.Text.Trim());
                Calcular.Operacao(Operacao, lblVisor, Numero1, Numero2);
                PressionouIgual = true;
            }
        }

        private void btnMemoriaAdicionar_Click(object sender, EventArgs e) {

        }

        private void btnMemoriaRecuperar_Click(object sender, EventArgs e) {

        }

        private void btnMemoriaSubstituir_Click(object sender, EventArgs e) {

        }

        private void btnInserirDados_Click(object sender, EventArgs e) {

        }

        private void btnDesvioAmostral_Click(object sender, EventArgs e) {

        }

        private void btnMediaAritmetica_Click(object sender, EventArgs e) {

        }

        private void btnNumeroDados_Click(object sender, EventArgs e) {

        }

        private void btnLogaritmoNeperiano_Click(object sender, EventArgs e) {

        }

        private void btnLogaritmoDecimal_Click(object sender, EventArgs e) {

        }

        private void btnInversao_Click(object sender, EventArgs e) {

        }

        private void btnRaizQuadrada_Click(object sender, EventArgs e) {

        }

        private void btnPotenciacao_Click(object sender, EventArgs e) {

        }

        private void btnExponencial_Click(object sender, EventArgs e) {

        }

        private void btnDecimalCientifico_Click(object sender, EventArgs e) {

        }

        private void btnSeno_Click(object sender, EventArgs e) {

        }

        private void btnCosseno_Click(object sender, EventArgs e) {

        }

        private void btnTangente_Click(object sender, EventArgs e) {

        }

        private void btnRemover_Click(object sender, EventArgs e) {
            if (!double.TryParse(lblVisor.Text.Trim(), out double numero)) {
                lblVisor.Text = string.Empty;
            }
            if (!lblVisor.Text.Trim().Equals(string.Empty)) {
                if (!chk2Funcao.Checked) {
                    if (PressionouIgual) {
                        Calcular.LimparCampos(lblVisor);
                        return;
                    }
                    if ((lblVisor.Text.Trim().Length == 2 && lblVisor.Text.Trim().Contains("-")) ||
                        (lblVisor.Text.Trim() == "-0." || lblVisor.Text.Trim() == "-0,")) {
                        lblVisor.Text = string.Empty;
                        return;
                    }
                    byte tamanho = (byte)lblVisor.Text.Trim().Length;
                    lblVisor.Text = lblVisor.Text.Trim().Remove((tamanho - 1));
                } else {

                }
            }
        }

        private void btnApagarVisor_Click(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Operacao.Equals(string.Empty) || PressionouIgual)
                    Calcular.LimparCampos(lblVisor);
                else
                    lblVisor.Text = string.Empty;
            } else {
                Calcular.LimparCampos(lblVisor);
                if (!mnsFixar2Funcao.Checked)
                    chk2Funcao.Checked = false;
            }
        }
        #endregion

        #region Eventos CheckedChanged
        private void chk2Funcao_CheckedChanged(object sender, EventArgs e) {
            bool assinalado = chk2Funcao.Checked;
            TemaBotoesMemoria(Claro, assinalado);
            TemaBotoesEstatistica(Claro, assinalado);
            TemaBotoesFuncoes(Claro, assinalado);
            TemaBotaoLimpeza(Claro, assinalado);
            if (!assinalado)
                mnsFixar2Funcao.Checked = false;
        }

        private void mnsFixar2Funcao_CheckedChanged(object sender, EventArgs e) {
            chk2Funcao.Checked = mnsFixar2Funcao.Checked;
        }
        #endregion

        #region Outros Métodos
        //private void gkh_KeyDown(object sender, KeyEventArgs e) {
        //    e.Handled = true;
        //}

        private void TemaPrincipal(bool claro, bool virgula) {
            // Formulário
            if (claro)
                BackColor = Color.Moccasin;
            else
                BackColor = Color.FromArgb(24, 23, 23);
            // Menu Principal
            TemaMenu(claro);
            // Demais componentes
            TemaComponentesNoButton(claro);
            // Botões
            TemaBotoes(claro, virgula, chk2Funcao.Checked);
        }

        private void TemaMenu(bool claro) {
            if (claro) {
                // BackColor
                mnsMenuPrincipal.BackColor = Color.White;
                mnsArquivo.BackColor = Color.White;
                mnsCopiarVisor.BackColor = Color.White;
                mnsSair.BackColor = Color.White;
                mnsPersonalizar.BackColor = Color.White;
                mnsFixar2Funcao.BackColor = Color.White;
                mnsSeparadorDecimal.BackColor = Color.White;
                mnsPonto.BackColor = Color.White;
                mnsVirgula.BackColor = Color.White;
                mnsTema.BackColor = Color.White;
                mnsClaro.BackColor = Color.White;
                mnsEscuro.BackColor = Color.White;
                mnsAjuda.BackColor = Color.White;
                mnsManual.BackColor = Color.White;
                mnsSobre.BackColor = Color.White;
                // ForeColor
                mnsMenuPrincipal.ForeColor = Color.Black;
                mnsArquivo.ForeColor = Color.Black;
                mnsCopiarVisor.ForeColor = Color.Black;
                mnsSair.ForeColor = Color.Black;
                mnsPersonalizar.ForeColor = Color.Black;
                mnsFixar2Funcao.ForeColor = Color.Black;
                mnsSeparadorDecimal.ForeColor = Color.Black;
                mnsPonto.ForeColor = Color.Black;
                mnsVirgula.ForeColor = Color.Black;
                mnsTema.ForeColor = Color.Black;
                mnsClaro.ForeColor = Color.Black;
                mnsEscuro.ForeColor = Color.Black;
                mnsAjuda.ForeColor = Color.Black;
                mnsManual.ForeColor = Color.Black;
                mnsSobre.ForeColor = Color.Black;
            } else {
                // BackColor
                mnsMenuPrincipal.BackColor = Color.Black;
                mnsArquivo.BackColor = Color.Black;
                mnsCopiarVisor.BackColor = Color.Black;
                mnsSair.BackColor = Color.Black;
                mnsPersonalizar.BackColor = Color.Black;
                mnsFixar2Funcao.BackColor = Color.Black;
                mnsSeparadorDecimal.BackColor = Color.Black;
                mnsPonto.BackColor = Color.Black;
                mnsVirgula.BackColor = Color.Black;
                mnsTema.BackColor = Color.Black;
                mnsClaro.BackColor = Color.Black;
                mnsEscuro.BackColor = Color.Black;
                mnsAjuda.BackColor = Color.Black;
                mnsManual.BackColor = Color.Black;
                mnsSobre.BackColor = Color.Black;
                // ForeColor
                mnsMenuPrincipal.ForeColor = Color.White;
                mnsArquivo.ForeColor = Color.White;
                mnsCopiarVisor.ForeColor = Color.White;
                mnsSair.ForeColor = Color.White;
                mnsPersonalizar.ForeColor = Color.White;
                mnsFixar2Funcao.ForeColor = Color.White;
                mnsSeparadorDecimal.ForeColor = Color.White;
                mnsPonto.ForeColor = Color.White;
                mnsVirgula.ForeColor = Color.White;
                mnsTema.ForeColor = Color.White;
                mnsClaro.ForeColor = Color.White;
                mnsEscuro.ForeColor = Color.White;
                mnsAjuda.ForeColor = Color.White;
                mnsManual.ForeColor = Color.White;
                mnsSobre.ForeColor = Color.White;
            }
            mnsClaro.Checked = claro;
            mnsEscuro.Checked = !claro;
        }

        private void TemaComponentesNoButton(bool claro) {
            if (claro) {
                // Visor
                lblVisor.BackColor = Color.White;
                lblVisor.ForeColor = Color.Black;
                // 2ª Função
                chk2Funcao.BackColor = Color.Transparent;
                chk2Funcao.ForeColor = Color.Black;
                // Ângulos
                lblAngulo.BackColor = Color.Transparent;
                lblAngulo.ForeColor = Color.Black;
                optGrau.BackColor = Color.Transparent;
                optGrau.ForeColor = Color.Black;
                optRadiano.BackColor = Color.Transparent;
                optRadiano.ForeColor = Color.Black;
                optGrado.BackColor = Color.Transparent;
                optGrado.ForeColor = Color.Black;
                // Estatística
                lblEstatistica.BackColor = Color.Transparent;
                lblEstatistica.ForeColor = Color.Black;
            } else {
                // Visor
                lblVisor.BackColor = Color.Black;
                lblVisor.ForeColor = Color.White;
                // 2ª Função
                chk2Funcao.BackColor = Color.Transparent;
                chk2Funcao.ForeColor = Color.White;
                // Ângulos
                lblAngulo.BackColor = Color.Transparent;
                lblAngulo.ForeColor = Color.White;
                optGrau.BackColor = Color.Transparent;
                optGrau.ForeColor = Color.White;
                optRadiano.BackColor = Color.Transparent;
                optRadiano.ForeColor = Color.White;
                optGrado.BackColor = Color.Transparent;
                optGrado.ForeColor = Color.White;
                // Estatística
                lblEstatistica.BackColor = Color.Transparent;
                lblEstatistica.ForeColor = Color.White;
            }
        }

        private void TemaBotoes(bool claro, bool virgula, bool funcao2) {
            TemaBotoesPrincipais(claro, virgula);
            TemaBotoesMemoria(claro, funcao2);
            TemaBotoesEstatistica(claro, funcao2);
            TemaBotoesFuncoes(claro, funcao2);
            TemaBotaoLimpeza(claro, funcao2);
        }

        private void TemaBotoesPrincipais(bool claro, bool virgula) {
            if (claro) {
                if (virgula)
                    ControleDeImagens.UmaImagem(btnSeparadorDecimal, VirgulaTemaClaroNormal);
                else
                    ControleDeImagens.UmaImagem(btnSeparadorDecimal, PontoTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn0, ZeroTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn1, UmTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn2, DoisTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn3, TresTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn4, QuatroTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn5, CincoTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn6, SeisTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn7, SeteTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn8, OitoTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn9, NoveTemaClaroNormal);
                ControleDeImagens.UmaImagem(btnOposicao, OposicaoTemaClaroNormal);
                ControleDeImagens.UmaImagem(btnSoma, SomaTemaClaroNormal);
                ControleDeImagens.UmaImagem(btnSubtracao, SubtracaoTemaClaroNormal);
                ControleDeImagens.UmaImagem(btnMultiplicacao, MultiplicacaoTemaClaroNormal);
                ControleDeImagens.UmaImagem(btnDivisao, DivisaoTemaClaroNormal);
                ControleDeImagens.UmaImagem(btnIgual, IgualTemaClaroNormal);
            } else {
                if (virgula)
                    ControleDeImagens.UmaImagem(btnSeparadorDecimal, VirgulaTemaEscuroNormal);
                else
                    ControleDeImagens.UmaImagem(btnSeparadorDecimal, PontoTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn0, ZeroTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn1, UmTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn2, DoisTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn3, TresTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn4, QuatroTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn5, CincoTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn6, SeisTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn7, SeteTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn8, OitoTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn9, NoveTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btnOposicao, OposicaoTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btnSoma, SomaTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btnSubtracao, SubtracaoTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btnMultiplicacao, MultiplicacaoTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btnDivisao, DivisaoTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btnIgual, IgualTemaEscuroNormal);
            }
        }

        private void TemaBotoesMemoria(bool claro, bool funcao2) {
            if (claro) {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnMemoriaAdicionar, MemoriaAdicionarTemaClaroNormal,
                                                    pcbMemoriaSubtrair, MemoriaSubtrairTemaClaro);
                    ControleDeImagens.DuasImagens(btnMemoriaRecuperar, MemoriaRecuperarTemaClaroNormal,
                                                    pcbMemoriaLimpar, MemoriaLimparTemaClaro);
                    ControleDeImagens.DuasImagens(btnMemoriaSubstituir, MemoriaSubstituirTemaClaroNormal,
                                                    pcbRandom, RandomTemaClaro);
                } else {
                    ControleDeImagens.DuasImagens(btnMemoriaAdicionar, MemoriaSubtrairTemaClaroNormal,
                                                    pcbMemoriaSubtrair, MemoriaAdicionarTemaClaro);
                    ControleDeImagens.DuasImagens(btnMemoriaRecuperar, MemoriaLimparTemaClaroNormal,
                                                    pcbMemoriaLimpar, MemoriaRecuperarTemaClaro);
                    ControleDeImagens.DuasImagens(btnMemoriaSubstituir, RandomTemaClaroNormal,
                                                    pcbRandom, MemoriaSubstituirTemaClaro);
                }
            } else {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnMemoriaAdicionar, MemoriaAdicionarTemaEscuroNormal,
                                                    pcbMemoriaSubtrair, MemoriaSubtrairTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMemoriaRecuperar, MemoriaRecuperarTemaEscuroNormal,
                                                    pcbMemoriaLimpar, MemoriaLimparTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMemoriaSubstituir, MemoriaSubstituirTemaEscuroNormal,
                                                    pcbRandom, RandomTemaEscuro);
                } else {
                    ControleDeImagens.DuasImagens(btnMemoriaAdicionar, MemoriaSubtrairTemaEscuroNormal,
                                                    pcbMemoriaSubtrair, MemoriaAdicionarTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMemoriaRecuperar, MemoriaLimparTemaEscuroNormal,
                                                    pcbMemoriaLimpar, MemoriaRecuperarTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMemoriaSubstituir, RandomTemaEscuroNormal,
                                                    pcbRandom, MemoriaSubstituirTemaEscuro);
                }
            }
        }

        private void TemaBotoesEstatistica(bool claro, bool funcao2) {
            if (claro) {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnInserirDados, InserirDadosTemaClaroNormal,
                                                    pcbExcluirDados, ExcluirDadosTemaClaro);
                    ControleDeImagens.DuasImagens(btnDesvioAmostral, DesvioAmostralTemaClaroNormal,
                                                    pcbDesvioPopulacional, DesvioPopulacionalTemaClaro);
                    ControleDeImagens.DuasImagens(btnMediaAritmetica, MediaAritmeticaTemaClaroNormal,
                                                    pcbSomaQuadradosValores, SomaQuadradosValoresTemaClaro);
                    ControleDeImagens.DuasImagens(btnNumeroDados, NumeroDadosTemaClaroNormal,
                                                    pcbSomaValores, SomaValoresTemaClaro);
                } else {
                    ControleDeImagens.DuasImagens(btnInserirDados, ExcluirDadosTemaClaroNormal,
                                                    pcbExcluirDados, InserirDadosTemaClaro);
                    ControleDeImagens.DuasImagens(btnDesvioAmostral, DesvioPopulacionalTemaClaroNormal,
                                                    pcbDesvioPopulacional, DesvioAmostralTemaClaro);
                    ControleDeImagens.DuasImagens(btnMediaAritmetica, SomaQuadradosValoresTemaClaroNormal,
                                                    pcbSomaQuadradosValores, MediaAritmeticaTemaClaro);
                    ControleDeImagens.DuasImagens(btnNumeroDados, SomaValoresTemaClaroNormal,
                                                    pcbSomaValores, NumeroDadosTemaClaro);
                }
            } else {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnInserirDados, InserirDadosTemaEscuroNormal,
                                                    pcbExcluirDados, ExcluirDadosTemaEscuro);
                    ControleDeImagens.DuasImagens(btnDesvioAmostral, DesvioAmostralTemaEscuroNormal,
                                                    pcbDesvioPopulacional, DesvioPopulacionalTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMediaAritmetica, MediaAritmeticaTemaEscuroNormal,
                                                    pcbSomaQuadradosValores, SomaQuadradosValoresTemaEscuro);
                    ControleDeImagens.DuasImagens(btnNumeroDados, NumeroDadosTemaEscuroNormal,
                                                    pcbSomaValores, SomaValoresTemaEscuro);
                } else {
                    ControleDeImagens.DuasImagens(btnInserirDados, ExcluirDadosTemaEscuroNormal,
                                                    pcbExcluirDados, InserirDadosTemaEscuro);
                    ControleDeImagens.DuasImagens(btnDesvioAmostral, DesvioPopulacionalTemaEscuroNormal,
                                                    pcbDesvioPopulacional, DesvioAmostralTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMediaAritmetica, SomaQuadradosValoresTemaEscuroNormal,
                                                    pcbSomaQuadradosValores, MediaAritmeticaTemaEscuro);
                    ControleDeImagens.DuasImagens(btnNumeroDados, SomaValoresTemaEscuroNormal,
                                                    pcbSomaValores, NumeroDadosTemaEscuro);
                }
            }
        }

        private void TemaBotoesFuncoes(bool claro, bool funcao2) {
            if (claro) {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnLogaritmoNeperiano, LogaritmoNeperianoTemaClaroNormal,
                                                    pcbPotenciaNeperiana, PotenciaNeperianaTemaClaro);
                    ControleDeImagens.DuasImagens(btnLogaritmoDecimal, LogaritmoDecimalTemaClaroNormal,
                                                    pcbPotenciaDecimal, PotenciaDecimalTemaClaro);
                    ControleDeImagens.DuasImagens(btnInversao, InversaoTemaClaroNormal,
                                                    pcbRaizCubica, RaizCubicaTemaClaro);
                    ControleDeImagens.DuasImagens(btnRaizQuadrada, RaizQuadradaTemaClaroNormal,
                                                    pcbXQuadrado, XQuadradoTemaClaro);
                    ControleDeImagens.DuasImagens(btnPotenciacao, PotenciacaoTemaClaroNormal,
                                                    pcbRadiciacao, RadiciacaoTemaClaro);
                    ControleDeImagens.DuasImagens(btnExponencial, ExponencialTemaClaroNormal,
                                                    pcbPi, PiTemaClaro);
                    ControleDeImagens.DuasImagens(btnDecimalCientifico, DecimalCientificoTemaClaroNormal,
                                                    pcbFatorial, FatorialTemaClaro);
                    ControleDeImagens.DuasImagens(btnSeno, SenoTemaClaroNormal,
                                                    pcbSenoInverso, SenoInversoTemaClaro);
                    ControleDeImagens.DuasImagens(btnCosseno, CossenoTemaClaroNormal,
                                                    pcbCossenoInverso, CossenoInversoTemaClaro);
                    ControleDeImagens.DuasImagens(btnTangente, TangenteTemaClaroNormal,
                                                    pcbTangenteInversa, TangenteInversaTemaClaro);
                    ControleDeImagens.DuasImagens(btnRemover, RemoverTemaClaroNormal,
                                                    pcbPorcentagem, PorcentagemTemaClaro);
                } else {
                    ControleDeImagens.DuasImagens(btnLogaritmoNeperiano, PotenciaNeperianaTemaClaroNormal,
                                                    pcbPotenciaNeperiana, LogaritmoNeperianoTemaClaro);
                    ControleDeImagens.DuasImagens(btnLogaritmoDecimal, PotenciaDecimalTemaClaroNormal,
                                                    pcbPotenciaDecimal, LogaritmoDecimalTemaClaro);
                    ControleDeImagens.DuasImagens(btnInversao, RaizCubicaTemaClaroNormal,
                                                    pcbRaizCubica, InversaoTemaClaro);
                    ControleDeImagens.DuasImagens(btnRaizQuadrada, XQuadradoTemaClaroNormal,
                                                    pcbXQuadrado, RaizQuadradaTemaClaro);
                    ControleDeImagens.DuasImagens(btnPotenciacao, RadiciacaoTemaClaroNormal,
                                                    pcbRadiciacao, PotenciacaoTemaClaro);
                    ControleDeImagens.DuasImagens(btnExponencial, PiTemaClaroNormal,
                                                    pcbPi, ExponencialTemaClaro);
                    ControleDeImagens.DuasImagens(btnDecimalCientifico, FatorialTemaClaroNormal,
                                                    pcbFatorial, DecimalCientificoTemaClaro);
                    ControleDeImagens.DuasImagens(btnSeno, SenoInversoTemaClaroNormal,
                                                    pcbSenoInverso, SenoTemaClaro);
                    ControleDeImagens.DuasImagens(btnCosseno, CossenoInversoTemaClaroNormal,
                                                    pcbCossenoInverso, CossenoTemaClaro);
                    ControleDeImagens.DuasImagens(btnTangente, TangenteInversaTemaClaroNormal,
                                                    pcbTangenteInversa, TangenteTemaClaro);
                    ControleDeImagens.DuasImagens(btnRemover, PorcentagemTemaClaroNormal,
                                                    pcbPorcentagem, RemoverTemaClaro);
                }
            } else {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnLogaritmoNeperiano, LogaritmoNeperianoTemaEscuroNormal,
                                                    pcbPotenciaNeperiana, PotenciaNeperianaTemaEscuro);
                    ControleDeImagens.DuasImagens(btnLogaritmoDecimal, LogaritmoDecimalTemaEscuroNormal,
                                                    pcbPotenciaDecimal, PotenciaDecimalTemaEscuro);
                    ControleDeImagens.DuasImagens(btnInversao, InversaoTemaEscuroNormal,
                                                    pcbRaizCubica, RaizCubicaTemaEscuro);
                    ControleDeImagens.DuasImagens(btnRaizQuadrada, RaizQuadradaTemaEscuroNormal,
                                                    pcbXQuadrado, XQuadradoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnPotenciacao, PotenciacaoTemaEscuroNormal,
                                                    pcbRadiciacao, RadiciacaoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnExponencial, ExponencialTemaEscuroNormal,
                                                    pcbPi, PiTemaEscuro);
                    ControleDeImagens.DuasImagens(btnDecimalCientifico, DecimalCientificoTemaEscuroNormal,
                                                    pcbFatorial, FatorialTemaEscuro);
                    ControleDeImagens.DuasImagens(btnSeno, SenoTemaEscuroNormal,
                                                    pcbSenoInverso, SenoInversoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnCosseno, CossenoTemaEscuroNormal,
                                                    pcbCossenoInverso, CossenoInversoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnTangente, TangenteTemaEscuroNormal,
                                                    pcbTangenteInversa, TangenteInversaTemaEscuro);
                    ControleDeImagens.DuasImagens(btnRemover, RemoverTemaEscuroNormal,
                                                    pcbPorcentagem, PorcentagemTemaEscuro);
                } else {
                    ControleDeImagens.DuasImagens(btnLogaritmoNeperiano, PotenciaNeperianaTemaEscuroNormal,
                                                    pcbPotenciaNeperiana, LogaritmoNeperianoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnLogaritmoDecimal, PotenciaDecimalTemaEscuroNormal,
                                                    pcbPotenciaDecimal, LogaritmoDecimalTemaEscuro);
                    ControleDeImagens.DuasImagens(btnInversao, RaizCubicaTemaEscuroNormal,
                                                    pcbRaizCubica, InversaoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnRaizQuadrada, XQuadradoTemaEscuroNormal,
                                                    pcbXQuadrado, RaizQuadradaTemaEscuro);
                    ControleDeImagens.DuasImagens(btnPotenciacao, RadiciacaoTemaEscuroNormal,
                                                    pcbRadiciacao, PotenciacaoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnExponencial, PiTemaEscuroNormal,
                                                    pcbPi, ExponencialTemaEscuro);
                    ControleDeImagens.DuasImagens(btnDecimalCientifico, FatorialTemaEscuroNormal,
                                                    pcbFatorial, DecimalCientificoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnSeno, SenoInversoTemaEscuroNormal,
                                                    pcbSenoInverso, SenoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnCosseno, CossenoInversoTemaEscuroNormal,
                                                    pcbCossenoInverso, CossenoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnTangente, TangenteInversaTemaEscuroNormal,
                                                    pcbTangenteInversa, TangenteTemaEscuro);
                    ControleDeImagens.DuasImagens(btnRemover, PorcentagemTemaEscuroNormal,
                                                    pcbPorcentagem, RemoverTemaEscuro);
                }
            }
        }

        private void TemaBotaoLimpeza(bool claro, bool funcao2) {
            if (claro) {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnApagarVisor, ApagarVisorTemaClaroNormal,
                                                    pcbLimparTudo, LimparTudoTemaClaro);
                } else {
                    ControleDeImagens.DuasImagens(btnApagarVisor, LimparTudoTemaClaroNormal,
                                                    pcbLimparTudo, ApagarVisorTemaClaro);
                }
            } else {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnApagarVisor, ApagarVisorTemaEscuroNormal,
                                                    pcbLimparTudo, LimparTudoTemaEscuro);
                } else {
                    ControleDeImagens.DuasImagens(btnApagarVisor, LimparTudoTemaEscuroNormal,
                                                    pcbLimparTudo, ApagarVisorTemaEscuro);
                }
            }
        }
        #endregion
    }
}
