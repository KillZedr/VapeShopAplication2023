using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;
using VSA.DomainServicesInterfaces;
using VSA.ServicesInterfaces;
using VSA.ServicesInterfaces.DTOs;

namespace VSA.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public async Task<Manufacturer> AddManufacturerAsync(CreateManufacturerDto manufacturerDto)
        {
            var newManufacturer = await _manufacturerRepository.GetManufacturerByName(manufacturerDto.Name);
            if (newManufacturer != null) 
            {
                throw new Exception($"Производитель с таким именем уже есть{manufacturerDto.Name}");
            }
            newManufacturer = new Manufacturer() { ManufacturerName = manufacturerDto.Name, Products = new List<Product>()};
            newManufacturer = await _manufacturerRepository.AddManufacturerAsync(newManufacturer);
            return newManufacturer;
        }

        public async Task DeleteManufacturerAsync(int manufacturerId)
        {
            var manufacturerDelete = await GetManufacturerAsync(manufacturerId);
            if (manufacturerDelete != null)
            {
                await _manufacturerRepository.DeleteManufacturerAsync(manufacturerDelete);
            }
        }

        public async Task<Manufacturer[]> GetAllManufacturerAsync()
        {
            return await _manufacturerRepository.GetAllManufacturerAsync();
        }

        public async Task<Manufacturer> GetManufacturerAsync(int idManufacturer)
        {
            return await _manufacturerRepository.GetManufacturerAsync(idManufacturer);
        }

        public async Task<Manufacturer> UpdateManufacturerAsync(int idManufacturer, EditManufacturerDto manufacturerDto)
        {
            var updateManufacturer = await GetManufacturerAsync(idManufacturer);
            if (updateManufacturer == null)
            {
                throw new Exception("Такого производителя не существует");
            }
            updateManufacturer.ManufacturerName = manufacturerDto.Name;
            return await _manufacturerRepository.UpdateManufacturerAsync(updateManufacturer);
            
        }
    }
}
