using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgendaADONET.Classes;
using AgendaADONET.DAO;

namespace AgendaADONET
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            CarregarDataGridView();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = (int)dgvAgenda.CurrentRow.Cells[0].Value;
            ContatoDAO contato = new ContatoDAO();
            contato.Excluir(id);
            CarregarDataGridView();
        }
        private void CarregarDataGridView()
        {
            //posso obter dados do banco de dados tanto de DataSet como de DataTable     
            ContatoDAO contatoDao = new ContatoDAO();
            DataTable dataTable = contatoDao.GetContatos(); // neste momento a consulta é disparada para o banco de dados
            dgvAgenda.DataSource = dataTable;  // propriedade de onde ele vai extrair as informações a serem exibidas por ele*/
            dgvAgenda.Refresh();
            CarregarStatusStrip();
        }

        private void CarregarStatusStrip()
        {
            ContatoDAO contatoDAO = new ContatoDAO();
            int quantidadeContatos = contatoDAO.ContarUsuarios();
            stsInfoUsuario.Items[0].Text = quantidadeContatos.ToString() + " usuário(s)";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmAlterarContato form = new frmAlterarContato();
            form.ShowDialog();
            CarregarDataGridView();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato // contato a partir da linha que está selecionada. 
            {
                Id = (int)dgvAgenda.CurrentRow.Cells[0].Value,
                Nome = dgvAgenda.CurrentRow.Cells[1].Value.ToString(),
                Email = dgvAgenda.CurrentRow.Cells[2].Value.ToString(),
                Telefone = dgvAgenda.CurrentRow.Cells[3].Value.ToString()
            };
            frmAlterarContato form = new frmAlterarContato(contato);
            form.ShowDialog();
            CarregarDataGridView();

        }

        private void dgvAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
