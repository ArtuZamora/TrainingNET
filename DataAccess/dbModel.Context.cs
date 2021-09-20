﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LoanFeeControlEntities : DbContext
    {
        public LoanFeeControlEntities()
            : base("name=LoanFeeControlEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<string> sp_calculate_quota(Nullable<int> age, Nullable<int> idMonth, Nullable<decimal> amount, string ip)
        {
            var ageParameter = age.HasValue ?
                new ObjectParameter("age", age) :
                new ObjectParameter("age", typeof(int));
    
            var idMonthParameter = idMonth.HasValue ?
                new ObjectParameter("idMonth", idMonth) :
                new ObjectParameter("idMonth", typeof(int));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("amount", amount) :
                new ObjectParameter("amount", typeof(decimal));
    
            var ipParameter = ip != null ?
                new ObjectParameter("ip", ip) :
                new ObjectParameter("ip", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_calculate_quota", ageParameter, idMonthParameter, amountParameter, ipParameter);
        }
    
        public virtual ObjectResult<sp_get_log_Result> sp_get_log()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_get_log_Result>("sp_get_log");
        }
    
        public virtual ObjectResult<sp_get_months_Result> sp_get_months()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_get_months_Result>("sp_get_months");
        }
    }
}