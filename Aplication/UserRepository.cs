using Aplication.Application.InfrastructureInterfaces;

using Aplication.TVR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly string _connectionString;
        public ProjectRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task<Project> AddProjectAsync(Project project)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO [Users] VALUES (@User_name)";
                await connection.OpenAsync();

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@User_name", SqlDbType.VarChar, 100).Value = project.Name;
                    cmd.CommandType = CommandType.Text;
                    var result = cmd.ExecuteNonQuery();
                    if (result == 0)
                    {
                        throw new Exception("Проект не добавлен в базу данных");
                    }
                }
                await connection.CloseAsync();
            }
            return project;
        }

        public Task DeleteProjectAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProjectAsync(PurchaseItem purchaseItem)
        {
            throw new NotImplementedException();
        }

        public Task<Project[]> GetAllProjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> UpdateProjectAsync(Project project)
        {
            throw new NotImplementedException();
        }

    }
}
