﻿using BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interfaces
{
    public interface IConsultLogRepository
    {
        List<ConsultLogModel> GetConsultlog();
    }
}
