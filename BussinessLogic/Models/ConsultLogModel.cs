using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Models
{
    public class ConsultLogModel
    {
        [Display(Name = "ID de consulta")]
        public int idConsult { get; set; }
        [Display(Name = "Fecha de consulta")]
        public DateTime dateConsult { get; set; }
        [Display(Name = "Edad")]
        public int age { get; set; }
        [Display(Name = "Monto del préstamo")]
        public decimal amount { get; set; }
        [Display(Name = "Meses del préstamo")]
        public string months { get; set; }
        [Display(Name = "Valor de cuota")]
        public decimal quota { get; set; }
        [Display(Name = "IP de consulta")]
        public string ipConsult { get; set; }

    }
}
