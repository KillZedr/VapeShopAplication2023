using Aplication.TVR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication.Application.InfrastructureInterfaces
{
    public interface IProjectRepository
    {
        Task<Project[]> GetAllProjectsAsync();
        Task<Project> GetProjectsAsync(int id);
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);

    }
}
