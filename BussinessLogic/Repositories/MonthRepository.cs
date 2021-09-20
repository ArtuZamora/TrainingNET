using BussinessLogic.Interfaces;
using BussinessLogic.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Repositories
{
    public class MonthRepository : IMonthRepository
    {
        public List<MonthModel> GetMonths()
        {
            using (var db = new LoanFeeControlEntities())
            {
                var months = db.sp_get_months().Select(MapToApp).ToList();
                return months;
            }
        }
        private MonthModel MapToApp(sp_get_months_Result months)
        {
            return new MonthModel
            {
                idMonth = months.idMonth,
                description = months.description
            };
        }
    }
}
