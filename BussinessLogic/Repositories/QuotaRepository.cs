using BussinessLogic.Interfaces;
using BussinessLogic.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Repositories
{
    public class QuotaRepository : IQuotaRepository
    {
        public string GetQuota(UserRequestModel request)
        {
            using (var db = new LoanFeeControlEntities())
            {

                return db.sp_calculate_quota(
                    CalculateAge(request.birthdate),
                    request.month.idMonth,
                    request.amount,
                    request.ip)
                    .First();
            }
        }
        private static int CalculateAge(DateTime birthdate)
        {
            int age = 0;
            age = DateTime.Now.Year - birthdate.Year;
            if (DateTime.Now.DayOfYear < birthdate.DayOfYear)
                age-=1;
            return age;
        }
    }
}
