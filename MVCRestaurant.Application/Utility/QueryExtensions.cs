using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Application.Utility
{
    internal static class QueryExtensions
    {
        internal static IQueryable<T> Page<T>(this IQueryable<T> query, int pageSize, int pageNum) where T : class
        {
            return query.Skip((pageNum - 1) * pageSize).Take(pageSize);
        }
    }
}
