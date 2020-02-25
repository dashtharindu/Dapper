using Dapper;
using DapperSwaggerAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperSwaggerAPI.Data
{
    public class ProductRepository
    {
        private string ConnectionString;
        public ProductRepository()
        {
            ConnectionString = @"Server=.;Database=TestData;Trusted_Connection=true";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }

        public void Add(Product Product)
        {
            //todo-changed table name to "Product"
            using(IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Product (Name,Quantity,Price) VALUES (@Name,@Quantity,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Product);
            }
        }

        public List<Product> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Products";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery).ToList();
            }
        }

        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Products WHERE ProductId=@Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public string Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Products WHERE ProductId=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
                return "Sucesssfully Deleted";
            }
        }

        public string Update(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Products SET Name=@Name,Quantity=@Quantity,Price=@Price WHERE ProductId=@ProductId";
                dbConnection.Open();
                dbConnection.Query(sQuery, prod);
                //Tim said execute sould work cuz no return data like insert,delete update need execute command.
                //to get data back in return you need Query command
                return "Updated";
            }
        }
    }
}
