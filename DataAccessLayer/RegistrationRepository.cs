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

        public void DeleteRecord(long id)
        {
            try
            {
                var record = _regcontext.Database.ExecuteSqlRaw($"exec DeleteRecord {id}");
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Registration FindProductByNumber(long number)
        {
            try
            {
                var record= _regcontext.Registration.FromSqlRaw<Registration>($"exec Getbyid {number}").ToList().FirstOrDefault();
                return record;
            }
            catch (Exception ex)
            {
                throw;
            }
           
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

        public void UpdateRecord(long id, Registration regs)
        {
            try
            {
               var update = _regcontext.Database.ExecuteSqlRaw($"exec UpdateRecord {id},'{regs.UserName}','{regs.Password}','{regs.ConformPassword}'");
               
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
