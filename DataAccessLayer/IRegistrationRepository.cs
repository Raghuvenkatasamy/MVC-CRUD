﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public interface IRegistrationRepository
    {
        public void Insert(Registration product);

        public Registration FindProductByNumber(long number);
        public IEnumerable<Registration> GetAllRegistration();

        public bool Login(string username, string password);

        public bool Register(Registration regs);
        public void DeleteRecord(long id);
        public void UpdateRecord(long id,Registration regs);

    }
}
