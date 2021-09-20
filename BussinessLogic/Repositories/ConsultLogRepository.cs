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
    public class ConsultLogRepository : IConsultLogRepository
    {
        public List<ConsultLogModel> GetConsultlog()
        {
            using (var db = new LoanFeeControlEntities())
            {
                return db.sp_get_log().Select(MapToApp).ToList();
            }
        }
        private ConsultLogModel MapToApp(sp_get_log_Result log_Result)
        {
            return new ConsultLogModel
            {
                idConsult = log_Result.ID_de_consulta,
                dateConsult = log_Result.Fecha_de_consulta,
                age = log_Result.Edad,
                amount = log_Result.Monto,
                months = log_Result.Meses,
                quota = log_Result.Valor_Cuota,
                ipConsult = log_Result.IP_de_Consulta
            };
        }
    }
}
