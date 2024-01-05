using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void Insert(Registration product)
        {
            try
            {
                _regcontext.Database.ExecuteSqlRaw($"exec Insertegdata '{product.UserName}','{product.Password}','{product.ConformPassword}'");
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
                var result =_regcontext.Registration.FromSqlRaw<Registration>($"exec Checkpassword '{username}','{password}'").ToList();

                if (result != null || result.Count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
