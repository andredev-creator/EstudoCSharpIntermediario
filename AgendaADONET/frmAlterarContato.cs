using AgendaADONET.Classes;
using AgendaADONET.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaADONET
{
    public partial class frmAlterarContato : Form
    {
        private Contato contato;

        public frmAlterarContato(Contato contato = null)
        {
            this.contato = contato;
            InitializeComponent();
        }
        public frmAlterarContato()
        {
            InitializeComponent(); // método que desenha a tela
        }

        private void frmAlterarContato_Load(object sender, EventArgs e)
        {

            if (this.contato != null)
            {
                txtNome.Text = this.contato.Nome;
                txtEmail.Text = this.contato.Email;
                txtTelefone.Text = this.contato.Telefone;
            }
            else
            {
                txtNome.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtTelefone.Text = string.Empty;
            }

            txtNome.Focus();// jogar cursor para o campo Nome.

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//fechar a tela
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContatoDAO contatoDAO = new ContatoDAO();
            if (this.contato == null)
            {
                Contato contato = new Contato
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Telefone = txtTelefone.Text
                };
                try
                {
                    contatoDAO.Inserir(contato);
                    MessageBox.Show("Dados salvos!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Falha ao inserir contatos" + ex.Message);
                }
                
            }
            else
            {
                this.contato.Nome = txtNome.Text;
                this.contato.Email = txtEmail.Text;
                this.contato.Telefone = txtTelefone.Text;

                contatoDAO.Atualizar(this.contato);
                MessageBox.Show("Dados atualizados");

            }

            this.Close();
        }

        private void frmAlterarContato_Shown(object sender, EventArgs e)
        {

        }
    }
}
