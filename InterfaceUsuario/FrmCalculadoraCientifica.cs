﻿using InterfaceUsuario.Personalizacao;
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

        }

        private void btn1_Click(object sender, EventArgs e) {

        }

        private void btn2_Click(object sender, EventArgs e) {

        }

        private void btn3_Click(object sender, EventArgs e) {

        }

        private void btn4_Click(object sender, EventArgs e) {

        }

        private void btn5_Click(object sender, EventArgs e) {

        }

        private void btn6_Click(object sender, EventArgs e) {

        }

        private void btn7_Click(object sender, EventArgs e) {

        }

        private void btn8_Click(object sender, EventArgs e) {

        }

        private void btn9_Click(object sender, EventArgs e) {

        }

        private void btnSeparadorDecimal_Click(object sender, EventArgs e) {

        }

        private void btnOposicao_Click(object sender, EventArgs e) {

        }

        private void btnSoma_Click(object sender, EventArgs e) {

        }

        private void btnSubtracao_Click(object sender, EventArgs e) {

        }

        private void btnMultiplicacao_Click(object sender, EventArgs e) {

        }

        private void btnDivisao_Click(object sender, EventArgs e) {

        }

        private void btnIgual_Click(object sender, EventArgs e) {

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

        }

        private void btnApagarVisor_Click(object sender, EventArgs e) {

        }
        #endregion
    }
}
