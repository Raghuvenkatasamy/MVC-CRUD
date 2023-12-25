using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IMobileDetailsRepository
    {
        public MobileDetail InsertMVC(MobileDetail MD);
        public IEnumerable<MobileDetail> ReadMVC();
        public MobileDetail ReadbynumberSP(long id);
        public MobileDetail DeleteRecordMVC(long id);
        public MobileDetail UpdateMVC(long id, MobileDetail MDS);

    }
}
