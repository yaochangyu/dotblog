﻿using System;
using System.Collections.Generic;
using DAL;
using Infrastructure;

namespace BLL
{
    public class MemberBLL
    {
        private readonly MemberDAL _dal;

        public MemberBLL()
        {
            if (this._dal == null)
            {
                this._dal = new MemberDAL();
            }
        }

        public IEnumerable<MemberViewModel> GetMasters(Page page)
        {
            IEnumerable<MemberViewModel> results = null;
            results = this._dal.GetMasters(page);

            return results;
        }

        public IEnumerable<MemberLogViewModel> GetDetails(Guid id)
        {
            IEnumerable<MemberLogViewModel> results = null;
            results = this._dal.GetDetails(id);

            return results;
        }
    }
}