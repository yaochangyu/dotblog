using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Simple.LinqOrderByString
{
    public static class LinqExtension
    {
        public static IEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> sources, string propertyName)
        {
            return orders(sources, propertyName, false);
        }

        public static IEnumerable<TSource> OrderByDescending<TSource>(this IEnumerable<TSource> sources, string propertyName)
        {
            return orders(sources, propertyName, true);
        }

        private static IEnumerable<TSource> orders<TSource>(IEnumerable<TSource> sources, string propertyName, bool isDescending)
        {
            PropertyInfo propertyInfo = typeof(TSource).GetProperty(propertyName);
            if (propertyInfo == null)
            {
                return sources;
            }
            if (isDescending)
            {
                return sources.OrderByDescending(x => propertyInfo.GetValue(x, null));
            }
            else
            {
                return sources.OrderBy(x => propertyInfo.GetValue(x, null));
            }
        }

        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> sources, string propertyName, params object[] values)
        {
            return orders(sources, propertyName, "OrderBy");
        }

        public static IQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> sources, string propertyName, params object[] values)
        {
            return orders(sources, propertyName, "OrderByDescending");
        }

        private static IQueryable<TSource> orders<TSource>(IQueryable<TSource> sources, string propertyName, string orderExpression)
        {
            var type = typeof(TSource);
            var propertyInfo = type.GetProperty(propertyName);
            var parameter = Expression.Parameter(type, "parameter");
            var propertyAccess = Expression.MakeMemberAccess(parameter, propertyInfo);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(
                typeof(Queryable),
                orderExpression,
                new Type[] { type, propertyInfo.PropertyType },
                sources.Expression, Expression.Quote(orderByExp));
            return sources.Provider.CreateQuery<TSource>(resultExp);
        }
    }
}