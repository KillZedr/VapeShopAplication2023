using Aplication.Application.InfrastructureInterfaces;
using Aplication.Application.Interfaces;
using Aplication.TVR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Project> AddProjectAsync(string projectName)
        {
            /* var projects = await GetAllProjectsAsync();
             if (!projects.Any(p => p.Name == projectName)) 
             {
                 throw new Exception($"проект с таким именем {projectName} уже есть");
             }*/
            var newProject = await _projectRepository.AddProjectAsync(new Project() { Name = projectName });
            return newProject;
        }

        public async Task DeleteProjectAsync(Project project)
        {
            var projectDelete = await GetProjectsAsync(project.Id);
            if (projectDelete != null)
            {
                await _projectRepository.DeleteProjectAsync(projectDelete);
            }
        }

        public Task<Project[]> GetAllProjectsAsync()
        {
            return _projectRepository.GetAllProjectsAsync();
        }

        public Task<Project> GetProjectsAsync(int id)
        {
            return _projectRepository.GetProjectsAsync(id);
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            var targetProject = await GetProjectsAsync(project.Id);
            if (targetProject == null)
            {
                throw new Exception($"проекта с таким Id{project.Id} не существует");
            }
            var projects = await GetAllProjectsAsync();
            var projectWhithName = projects.SingleOrDefault(p => p.Name == project.Name);
            if (projectWhithName != null && projectWhithName.Id != targetProject.Id)
            {
                throw new Exception($"проект с таким именем {project.Name} уже есть");
            }
            targetProject.Name = project.Name;
            var updateProgect = await _projectRepository.UpdateProjectAsync(targetProject);
            return updateProgect;

        }
    }
}
