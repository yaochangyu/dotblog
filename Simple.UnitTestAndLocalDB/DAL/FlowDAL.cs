using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FlowDAL
    {
        public IEnumerable<Member> GetMembers()
        {
            IEnumerable<Member> result = null;
            using (var db = new DalDbContext())
            {
                result = db.Members.AsNoTracking().ToList();
            }
            return result;
        }
    }
}