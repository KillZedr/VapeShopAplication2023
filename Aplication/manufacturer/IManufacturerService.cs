using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication.manufacturer
{
    public interface IManufacturerService
    {
        Task<Manufacturer[]> GetAllCategoryAsync();
        Task<Manufacturer> GetCategoryAsync(int idManufacturer);
        Task<Manufacturer> AddCategoryAsync(Manufacturer manufacturer);
        Task<Manufacturer> UpdateCategoryAsync(Manufacturer manufacturer);
        Task DeleteCategoryAsync(Manufacturer manufacturer);

    }
}
