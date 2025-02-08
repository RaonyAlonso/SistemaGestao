using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using SistemaGestao.Models;
using Dapper;

namespace SistemaGestao.Data
{
    public class ProdutoDAL
    {

        private string connectionString = "Data Source=meubanco.db;Version=3;";

        public ProdutoDAL() 
        {
            CriarTabelaSeNaoExistir();
        }
        public void Inserir(Produto produto)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                string query = "INSERT INTO Produtos (Nome, Preco, Quantidade) VALUES (@Nome, @Preco, @Quantidade)";
                connection.Execute(query, produto);
            }
        }

        public List<Produto> ObterTodos()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                string query = "SELECT * FROM Produtos";
                return connection.Query<Produto>(query).ToList();
            }
        }


        private void CriarTabelaSeNaoExistir()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                CREATE TABLE IF NOT EXISTS Produtos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Preco REAL NOT NULL,
                    Quantidade INTEGER NOT NULL
                );
                ";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
