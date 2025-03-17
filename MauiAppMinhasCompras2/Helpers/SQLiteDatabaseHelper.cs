using MauiAppMinhasCompras2.Models;
using SQLite;

namespace MauiAppMinhasCompras2.Helpers
{
    //classe
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection; //Async

        //construtor da classe
        public SQLiteDatabaseHelper(string path) 
{ 
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Produto>().Wait();
        }
        //CREATE
        public Task<int> Insert(Produto p) 
        {
            return _connection.InsertAsync(p);
        }

        //UPDATE
        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=?, WHERE Id=?";
            return _connection.QueryAsync<Produto>(sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }

        //DELETE
        public Task<int> Delete(int id) 
        {
            return _connection.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        //READ
        public Task<List<Produto>> GetAll() 
        {
            return _connection.Table<Produto>().ToListAsync();
        }

        //READ
        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * FROM Produto WHERE Descricao LIKE '%" + q + "%' ";
            return _connection.QueryAsync<Produto>(sql);
        }

    }
}
