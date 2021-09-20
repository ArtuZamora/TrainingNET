using BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingProject.Models
{
    public class RequestInfoModel
    {
        public IEnumerable<MonthModel> Months { get; set; }
        public UserRequestModel UserRequest { get; set; }
    }
}