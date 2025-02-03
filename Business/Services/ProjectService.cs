using Business.Dtos;
using Data.Entities;
using Data.Repositories;

namespace Business.Services;

public class ProjectService(ProjectRepository projectRepository, StatusRepository statusRepository, EmployeeRepository employeeRepository, ServiceRepository serviceRepository)
{
    private readonly ProjectRepository _projectRepository = projectRepository;
    private readonly StatusRepository _statusRepository = statusRepository;
    private readonly EmployeeRepository _employeeRepository = employeeRepository;
    private readonly ServiceRepository _serviceRepository = serviceRepository;
}
