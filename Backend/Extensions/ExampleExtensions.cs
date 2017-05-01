using System.Collections.Generic;
using System.Linq;
using Backend.DataObjects;

namespace Backend.Extensions
{
    public static class ExampleExtensions
    {
        public static IQueryable<Example> PerGroupFilter(this IQueryable<Example> query, List<string> groups)
        {
            return query.Where(item => groups.Contains(item.GroupId));
        }
    }
}