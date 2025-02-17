using Business.Dtos;

namespace Business.Interfaces
{
    public interface IProjectServiceManager
    {
        Task<List<ProjectServiceDto>> CreateProjectServiceAsync(List<ServiceRegistrationForm> serviceFroms);
    }
}