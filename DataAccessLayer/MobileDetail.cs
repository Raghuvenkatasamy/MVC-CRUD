using System;

namespace DataAccessLayer
{
    public class MobileDetail
    {
        public long MobileId { get; set; }
        public string Name { get; set; }
        public string ManufactureName { get; set; }
        public DateTime DateofMaufacture { get; set; }
        public long YearofMaufacture { get; set; }
        public int Quantity { get; set; }
    }
}
