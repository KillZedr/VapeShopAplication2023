using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;
using VSA.ServicesInterfaces.DTOs;

namespace VSA.ServicesInterfaces
{
    public interface IManufacturerService
    {
        Task<Manufacturer[]> GetAllManufacturerAsync();
        Task<Manufacturer> GetManufacturerAsync(int idManufacturer);
        Task<Manufacturer> AddManufacturerAsync(CreateManufacturerDto manufacturerDto);
        Task<Manufacturer> UpdateManufacturerAsync(int idManufacturer, EditManufacturerDto manufacturerDto);
        Task DeleteManufacturerAsync(int manufacturerId);

    }
}
