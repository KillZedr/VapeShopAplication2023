using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication.TVR
{
    public class ReportItem
    {
        public int Id { get; set; }
        public DateOnly WorkTame { get; set; }
        public float Hours { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int ApplicationUserId { get; set; }
        public User User { get; set; }
    }
}
