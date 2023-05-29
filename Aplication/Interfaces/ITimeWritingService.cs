using Aplication.TVR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication.Application.Interfaces
{
    public interface ITimeWritingService
    {
        Task<ReportItem> AddReportItem(Project project, DateOnly workDate, float hours);
        Task<ReportItem[]> GetUserReportItems(User user);
    }
}
