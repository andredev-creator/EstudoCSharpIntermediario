using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudoDelegates
{
    public partial class frmCalculadora : Form
    {

        private delegate int ExecutatOperacao(int numero1, int numero2);
        private ExecutatOperacao minhaOperacao;// instancia. objeto que tem a referencia apontando para o delegate que tem o metodo que precisamos


        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {

        }

        private int Calcular()
        {
            int numero1 = Convert.ToInt32(txtNumero1.Text);
            int numero2 = Convert.ToInt32(txtNumero2.Text);
            return minhaOperacao(numero1, numero2);

        }

        private int Somar(int numero1, int numero2)
        {
            return numero1 + numero2;

        }

        private int Subtrair(int numero1, int numero2)
        {
            return numero1 - numero2;
        }

        private int Multiplicar(int numero1, int numero2)
        {
            return numero1 * numero2;
        }

        private int Dividir(int numero1, int numero2)
        {
            return numero1 / numero2;
        }

        private void btnAdicao_Click(object sender, EventArgs e)
        {

            minhaOperacao = new ExecutatOperacao(Somar);

            txtResultado.Text = Calcular().ToString();
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutatOperacao(Subtrair);

            txtResultado.Text = Calcular().ToString();
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutatOperacao(Multiplicar);

            txtResultado.Text = Calcular().ToString();
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutatOperacao(Dividir);

            txtResultado.Text = Calcular().ToString();
        }

        private void Apagar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            txtResultado.Text = " ";
        }





        private void btnApagar_Click(object sender, EventArgs e)
        {
            Apagar();
        }
    }
}
