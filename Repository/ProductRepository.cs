using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coredapperapi.DataHelper;
using coredapperapi.IRepository;
using coredapperapi.Model;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace coredapperapi.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository(IConfiguration configuration) : base(configuration)
        {}


        public async Task<int> CreateAsync(Product entity)
        {
            try
            {
                var query = "Insert into Products(Name, Price, Quantity) Values (@Name, @Price, @Quantity)";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, System.Data.DbType.String);
                parameters.Add("Price", entity.Price, System.Data.DbType.Decimal);
                parameters.Add("Quantity", entity.Quantity, System.Data.DbType.Int32);


                using(var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(Product entity)
        {
            try
            {
                var query = "DELETE FROM  Products Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, System.Data.DbType.Int32);


                using(var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var query = "Select * from Products";
                using(var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Product>(query)).ToList();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                var query = "Select * from Products where Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, System.Data.DbType.Int32);


                using(var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Product>(query, parameters));
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            try
            {
                var query = "Update Products Set Name = @Name, Price = @Price, Quantity = @Qunatity WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, System.Data.DbType.String);
                parameters.Add("Price", entity.Price, System.Data.DbType.Decimal);
                parameters.Add("Quantity", entity.Quantity, System.Data.DbType.Int32);
                parameters.Add("Id", entity.Id, System.Data.DbType.Int32);


                using(var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}