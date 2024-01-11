using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly SampleDbContext _regcontext;
        public RegistrationRepository(SampleDbContext context)
        {
            _regcontext = context;
        }
        public Registration FindProductByNumber(long number)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registration> GetAllRegistration()
        {
           
            try
            {
                IEnumerable<Registration> all =_regcontext.Registration.FromSqlRaw<Registration>($"exec Getall");
                return all.ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        public void Insert(Registration product)
        {
            try
            {
                _regcontext.Database.ExecuteSqlRaw($"exec InsertRegistration '{product.UserName}','{product.Password}','{product.ConformPassword}'");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Login(string username, string password)
        {
            try
            {
                var check = _regcontext.Registration.FromSqlRaw<Registration>($"exec Checkpassword '{username}','{password}'").ToList();

                if (check.Count > 0 & check != null)
                    return true;
                else
                    return false;
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Register(Registration regs)
        {
            var res = _regcontext.Registration.FromSqlRaw<Registration>($"exec CheckRegistration '{regs.UserName}','{regs.Password}','{regs.ConformPassword}'").ToList();
            if (res.Count > 0 & res != null)
                return false;
            else
                return true;

        }

    }
}
