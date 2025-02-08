using SistemaGestao.Core;
using SistemaGestao.Models;

namespace SistemaGestao.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            Produto produto = new Produto
            {
                Nome = txtNome.Text,
                Preco = Convert.ToDecimal(txtPreco.Text),
                Quantidade = Convert.ToInt32(txtQuantidade.Text)
            };

            ProdutoBLL produtoBLL = new ProdutoBLL();
            produtoBLL.AdicionarProduto(produto);


            AtualizarGrid();


            txtNome.Clear();
            txtPreco.Clear();
            txtQuantidade.Clear();

            MessageBox.Show("Produto cadastrado com sucesso");
        }

        private void AtualizarGrid()
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();
            var proodutos = produtoBLL.ObterTodosProdutos();

            dgvProdutos.DataSource = proodutos;
        }
    }
}
