using Aplication.TVR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Application.Interfaces
{
    public interface IProjectService
    {
        Task<Project[]> GetAllProjectsAsync();
        Task<Project> GetProjectsAsync(int id);
        Task<Project> AddProjectAsync(string projectName);
        Task<Project> UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);

    }
}