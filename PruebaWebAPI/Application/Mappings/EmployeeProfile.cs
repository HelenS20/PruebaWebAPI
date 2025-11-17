using AutoMapper;
using PruebaWebAPI.Domain.Entities;
using PruebaWebAPI.DTOs;
using PruebaWebAPI.CQRS.Commands.CreateEmployee;
using PruebaWebAPI.CQRS.Commands.UpdateEmployee;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeCreateDto, CreateEmployeeCommand>();
        CreateMap<EmployeeUpdateDto, UpdateEmployeeCommand>();
        CreateMap<Employee, EmployeeUpdateDto>();
    }
}
