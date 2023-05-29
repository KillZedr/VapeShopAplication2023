using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication.manufacturer
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer[]> GetAllManufacturerAsync();
        Task<Manufacturer> GetManufacturerAsync(int idManufacturer);
        Task<Manufacturer> AddManufacturerAsync(Manufacturer manufacturer);
        Task<Manufacturer> UpdateManufacturerAsync(Manufacturer manufacturer);
        Task DeleteManufacturerAsync(Manufacturer manufacturer);
        
    }
}
