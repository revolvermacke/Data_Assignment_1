using System.Diagnostics;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Data.Entities;
using Data.Repositories;

namespace Business.Services;

public class ServiceService(IServiceRepository serviceRepository, IUnitRepository unitTypeRepository) : IServiceService
{
    private readonly IServiceRepository _serviceRepository = serviceRepository;
    private readonly IUnitRepository _unitTypeRepository = unitTypeRepository;

    public async Task<IResponseResult> CreateServiceAsync(ServiceDto form)
    {
        if (form == null)
            return ResponseResult.BadRequest("Invalid form");

        try
        {
            await _serviceRepository.BeginTransactionAsync();


            var serviceEntity = ServiceFactory.CreateEntity(form);
            await _serviceRepository.AddAsync(serviceEntity);
            bool saveResult = await _serviceRepository.SaveAsync();
            if (saveResult == false)
                throw new Exception("Error saving service");

            await _serviceRepository.CommitTransactionAsync();
            return ResponseResult.Ok();
        }
        catch (Exception ex)
        {
            await _serviceRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex.Message);
            return ResponseResult.Error($"Error creating service :: {ex.Message}");
        }
    }

    public async Task<IResponseResult> GetAllServicesAsync()
    {
        try
        {
            var entites = await _serviceRepository.GetAllAsync();
            var services = entites.Select(ServiceFactory.Create).ToList();
            return ResponseResult<IEnumerable<ServiceModel>>.Ok(services);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Error("Error retrieving services");
        }
    }

    public async Task<IResponseResult> GetServiceByIdAsync(int id)
    {
        try
        {
            var entity = await _serviceRepository.GetAsync(x => x.Id == id);
            if (entity == null)
                return ResponseResult.NotFound("Service not found");

            var service = ServiceFactory.Create(entity);
            return ResponseResult<ServiceModel>.Ok(service);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Error("Error retrieving service by id");
        }
    }

    public async Task<IResponseResult> UpdateServiceAsync(int id, ServiceRegistrationForm updateForm)
    {
        if (updateForm == null)
            return ResponseResult.BadRequest("Invalid form");

        try
        {
            var entityToUpdate = await _serviceRepository.GetAsync(x => x.Id == id);
            if (entityToUpdate == null)
                return ResponseResult.NotFound("Service not found");

            //var unitId = entityToUpdate.UnitId;
            //if (entityToUpdate.Unit.Unit != updateForm.Unit)
            //{
            //    var unit = await _unitTypeRepository.GetAsync(x => x.Unit == updateForm.Unit);
            //    if (unit == null)
            //        throw new Exception("unit not found");
            //    unitId = unit.Id;
            //}

           
            await _serviceRepository.BeginTransactionAsync();
           // entityToUpdate = ServiceFactory.CreateEntity(updateForm);
            await _serviceRepository.UpdateAsync(x => x.Id == id, entityToUpdate);
            bool saveResult = await _serviceRepository.SaveAsync();
            if (saveResult == false)
                throw new Exception("Error saving");

            await _serviceRepository.CommitTransactionAsync();
            return ResponseResult.Ok();
        }
        catch (Exception ex)
        {
            await _serviceRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex.Message);
            return ResponseResult.Error($"Error updating service :: {ex.Message}");
        }
    }

    public async Task<IResponseResult> DeleteServiceAsync(int id)
    {
        try
        {
            var entity = await _serviceRepository.GetAsync(x => x.Id == id);
            if (entity == null)
                return ResponseResult.NotFound("Service not found");

            await _serviceRepository.BeginTransactionAsync();
            await _serviceRepository.DeleteAsync(x => x.Id == id);
            bool saveResult = await _serviceRepository.SaveAsync();
            if (saveResult == false)
                throw new Exception("Error saving");

            await _serviceRepository.CommitTransactionAsync();
            return ResponseResult.Ok();
        }
        catch (Exception ex)
        {
            await _serviceRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex.Message);
            return ResponseResult.Error($"Error deleting service :: {ex.Message}");
        }
    }
}