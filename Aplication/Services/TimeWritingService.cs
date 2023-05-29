using Aplication.Application.InfrastructureInterfaces;
using Aplication.Application.Interfaces;
using Aplication.TVR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication.Application.Services
{
    public class TimeWritingService : ITimeWritingService
    {
        private readonly IReportItemRepository _reportItemRepository;

        public TimeWritingService(IReportItemRepository reportItemRepository)
        {
            _reportItemRepository = reportItemRepository;
        }
        public async Task<ReportItem> AddReportItem(Project project, DateOnly workDate, float hours)
        {
            return await _reportItemRepository.AddReportItemAsync(new ReportItem
            {
                ProjectId = project.Id,
                WorkTame = workDate,
                Hours = hours
            });
        }

        public async Task<ReportItem[]> GetUserReportItems(User user)
        {
            return await _reportItemRepository.GetUserReports(user);
        }
    }
}
