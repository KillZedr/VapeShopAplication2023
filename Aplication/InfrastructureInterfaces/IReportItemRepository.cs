using Aplication.TVR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication.Application.InfrastructureInterfaces
{
    public interface IReportItemRepository
    {
        Task<ReportItem> AddReportItemAsync(ReportItem reportItem);
        Task<ReportItem[]> GetUserReports(User user);
        
    }
}
