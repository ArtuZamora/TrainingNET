using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Models
{
    public class UserRequestModel
    {
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime birthdate { get; set; }
        [Required(ErrorMessage = "El monto del préstamo es requerido")]
        public decimal amount { get; set; }
        public MonthModel month { get; set; }
        public string ip { get; set; }
    }
}
