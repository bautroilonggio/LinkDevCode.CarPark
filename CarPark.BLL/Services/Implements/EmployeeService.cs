using AutoMapper;
using Azure;
using CarPark.DAL;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;
using System.Text.Json;

namespace CarPark.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        const int maxEmployeesPageSize = 20;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<(IEnumerable<EmployeeDto>, PaginationMetadata)> GetEmployeesAsync(
            string? employeeName, string? searchQuery, int pageNumber, int pageSize)
        {
            if(pageSize > maxEmployeesPageSize)
            {
                pageSize = maxEmployeesPageSize;
            }

            var (employeeEntities, paginationMetadata) = await _unitOfWork.EmployeeRepository
                                        .GetAllAsync(employeeName, searchQuery, pageNumber, pageSize);

            var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeeEntities);

            return (employeeDto, paginationMetadata);
        }

        public async Task<EmployeeDetailDto?> GetEmployeeAsync(int employeeId)
        {
            var employeeEntity = await _unitOfWork.EmployeeRepository.GetSingleAsync(employeeId);

            if (employeeEntity == null)
            {
                return null;
            }

            return _mapper.Map<EmployeeDetailDto>(employeeEntity);
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeForCreateDto employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);

            _unitOfWork.EmployeeRepository.Add(employeeEntity);

            await _unitOfWork.ComitAsync();

            return _mapper.Map<EmployeeDto>(employeeEntity);
        }

        public async Task<bool> UpdateEmployeeAsync(int employeeId, EmployeeForUpdateDto employee)
        {
            var employeeEntity = await _unitOfWork.EmployeeRepository.GetSingleAsync(employeeId);

            if (employeeEntity == null)
            {
                return false;
            }

            _mapper.Map(employee, employeeEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            var employeeEntity = await _unitOfWork.EmployeeRepository.GetSingleAsync(employeeId);

            if (employeeEntity == null)
            {
                return false;
            }

            _unitOfWork.EmployeeRepository.Delete(employeeEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }
    }
}
