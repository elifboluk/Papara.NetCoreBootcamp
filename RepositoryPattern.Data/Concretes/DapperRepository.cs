using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using RepositoryPattern.Data.Abstracts;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RepositoryPattern.Data.Concretes
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IConfiguration configuration;
        public DapperRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> DapperAdd(Product entity)
        {
            var sqlQuery = @"INSERT INTO [dbo].[Products]
           ([Name]
           ,[Category]
           ,[Barcode]
           ,[IsDeleted]
           ,[CreatedDate]
           ,[CreatedBy]
           ,[UpdatedDate]
           ,[UpdatedUser]) VALUES(@Name, @Category, @Barcode, @IsDeleted, @CreatedDate, @CreatedBy, @UpdatedDate, @UpdatedUser)";
            using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                var result = await con.ExecuteAsync(sqlQuery, entity);
                return result;
            }
        }

        public async Task<int> DapperDelete(int id)
        {
            
            var sqlQuery = "DELETE FROM Products WHERE Id = @Id";
            using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                var result = await con.ExecuteAsync(sqlQuery, new { Id = id });
                return result;
            }
        }

        public async Task<int> DapperUpdate(Product entity)
        {
            var sqlQuery = "UPDATE Products SET Name = @Name, Category = @Category, Barcode = @Barcode WHERE Id = @Id";
            using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                var result = await con.ExecuteAsync(sqlQuery,entity);
                return result;
            }
        }

        public async Task<IReadOnlyList<Product>> GetAll()
        {
            var sqlQuery = "SELECT * FROM Products";
            using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                var result = await con.QueryAsync<Product>(sqlQuery);
                return result.ToList();
            }

        }

        public async Task<Product> GetById(int id)
        {
            var sqlQuery = "SELECT * FROM Products WHERE Id = @Id";
            using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                var result = await con.QuerySingleOrDefaultAsync<Product>(sqlQuery, new { Id = id });
                return result;
            }

        }
    }
}
