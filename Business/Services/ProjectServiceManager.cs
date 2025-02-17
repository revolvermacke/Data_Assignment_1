using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProjectServiceManager : IProjectServiceManager
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IProjectServiceRepository _projectServiceRepository;

        public ProjectServiceManager(IServiceRepository serviceRepository, IProjectServiceRepository projectServiceRepository)
        {
            _serviceRepository = serviceRepository;
            _projectServiceRepository = projectServiceRepository;
        }

        public async Task<List<ProjectServiceDto>> CreateProjectServiceAsync(List<ServiceRegistrationForm> serviceFroms)
        {
            if (serviceFroms == null || !serviceFroms.Any())
                return [];

            //var serviceIds = serviceFroms.Select(s => s.ServiceId).ToList();
            //var services = await _serviceRepository.GetByIdsAsync(serviceIds);

            //if (!services.Any())
            //  return [];

            var projectServiceEntites = ProjectServiceFactory.Create(serviceFroms);
            await _projectServiceRepository.AddRangeAsync(projectServiceEntites);
            return ProjectServiceFactory.Create(projectServiceEntites);
        }
    }
}
