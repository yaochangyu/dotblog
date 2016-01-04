using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FlowBLL
    {
        private FlowDAL _dal = null;

        public FlowBLL()
        {
            if (this._dal == null)
            {
                this._dal = new FlowDAL();
            }
        }

        public IEnumerable<Member> GetMembers()
        {
            IEnumerable<Member> result = null;
            result = this._dal.GetMembers();
            return result;
        }
    }
}