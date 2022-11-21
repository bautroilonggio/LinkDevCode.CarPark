using AutoMapper;
using CarPark.DAL;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var employeeEntities = await _unitOfWork.EmployeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employeeEntities);
        }

        public async Task<EmployeeDto?> GetEmployeeAsync(int employeeId)
        {
            var employeeEntity = await _unitOfWork.EmployeeRepository.GetSingleAsync(employeeId);

            if (employeeEntity == null)
            {
                return null;
            }

            return _mapper.Map<EmployeeDto>(employeeEntity);
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
