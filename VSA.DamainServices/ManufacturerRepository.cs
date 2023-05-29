using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;
using VSA.DomainServicesInterfaces;

namespace VSA.DamainServices
{
    public class ManufacturerRepository : IManufacturerRepository
    {

        private readonly VapeShopContext _vapeShopContext;

        public ManufacturerRepository(VapeShopContext vapeShopContext)
        {
            _vapeShopContext = vapeShopContext;
        }
        public async Task<Manufacturer> AddManufacturerAsync(Manufacturer manufacturer)
        {
            _vapeShopContext.Manufacturers.Add(manufacturer);
            await _vapeShopContext.SaveChangesAsync();

            return manufacturer;
        }

        public async Task DeleteManufacturerAsync(Manufacturer manufacturer)
        {
            _vapeShopContext.Manufacturers.Remove(manufacturer);
            await _vapeShopContext.SaveChangesAsync();
            
        }

        public async Task<Manufacturer[]> GetAllManufacturerAsync()
        {
            return await _vapeShopContext.Manufacturers.ToArrayAsync();
        }

        public async Task<Manufacturer> GetManufacturerAsync(int idManufacturer)
        {
            return await _vapeShopContext.Manufacturers.SingleOrDefaultAsync(m => m.ManufacturerId == idManufacturer);
        }

        public async Task<Manufacturer> GetManufacturerByName(string manufacturerName)
        {
            return await _vapeShopContext.Manufacturers.SingleOrDefaultAsync(m => m.ManufacturerName == manufacturerName);
        }

        public async Task<Manufacturer> UpdateManufacturerAsync(Manufacturer manufacturer)
        {
            _vapeShopContext.Manufacturers.Update(manufacturer);
            await _vapeShopContext.SaveChangesAsync();
            return manufacturer;
        }
    }
}
