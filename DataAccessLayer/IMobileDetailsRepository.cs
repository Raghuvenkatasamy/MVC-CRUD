using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class IMobileDetailsRepository
    {
        public MobileDetail Insert(MobileDetail MD);
        public IEnumerable<MobileDetail> Read();
        public MobileDetail DeleteRecord(long id);
        public MobileDetail Update(long id, MobileDetail MDS);

    }
}
