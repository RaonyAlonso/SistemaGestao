using SistemaGestao.Data;
using SistemaGestao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestao.Core
{
    public class ProdutoBLL
    {
        private ProdutoDAL produtoDAL = new ProdutoDAL();

        public void AdicionarProduto(Produto produto)
        {
            if (produto.Preco < 0)
                throw new Exception("O preço não pode ser negativo");

            produtoDAL.Inserir(produto);
        }

        public List<Produto> ObterTodosProdutos()
        {
            ProdutoDAL produtoDAL = new ProdutoDAL();
            return produtoDAL.ObterTodos();
        }
    }
}
