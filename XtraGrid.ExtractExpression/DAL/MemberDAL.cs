﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using DAL.EntityModel;
using Infrastructure;

namespace DAL
{
    public class MemberDAL
    {
        public MemberDAL()
        {
            Database.SetInitializer(new CreateTestDatabaseIfNotExists());
        }

        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            IEnumerable<MemberViewModel> results = null;
            using (var dbContext = new TestDbContext())
            {
                var queryable = dbContext.Members
                                         .Select(p => new MemberViewModel
                                         {
                                             Id = p.Id,
                                             Age = p.Age,
                                             Name = p.Name,
                                             Birthday = p.Birthday.Value
                                         });

                results = queryable.AsNoTracking().AsParallel().ToList();
            }

            return results;
        }

        public IEnumerable<MemberViewModel> GetMasters(Page page)
        {
            IEnumerable<MemberViewModel> results = null;
            using (var dbContext = new TestDbContext())
            {
                var queryable = dbContext.Members
                                         .Select(p => new MemberViewModel
                                         {
                                             Id = p.Id,
                                             Age = p.Age,
                                             Name = p.Name,
                                             UserId = p.UserId,
                                             Birthday = p.Birthday.Value,
                                             SequentialId = p.SequentialId
                                         });
                if (!string.IsNullOrWhiteSpace(page.FilterExpression))
                {
                    queryable = queryable.Where(page.FilterExpression);
                }
                page.TotalCount = queryable.Count();

                queryable = queryable.OrderBy(page.SortExpression);
                queryable = queryable.Skip(page.Skip).Take(page.RowSize);

                results = queryable.AsNoTracking().ToList();
            }

            return results;
        }

        public IEnumerable<MemberLogViewModel> GetDetails(Guid id)
        {
            IEnumerable<MemberLogViewModel> results = null;
            using (var dbContext = new TestDbContext())
            {
                var queryable = dbContext.MemberLogs
                                         .Select(p => new MemberLogViewModel
                                         {
                                             Id = p.Id,
                                             MemberId = p.Member.Id,
                                             Name = p.Name,
                                             Age = p.Age,
                                             Birthday = p.Birthday,
                                             UserId = p.UserId
                                         });
                queryable = queryable.Where(p => p.MemberId == id);
                results = queryable.AsNoTracking().ToList();
            }

            return results;
        }
    }
}