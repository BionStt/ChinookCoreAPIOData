using ChinookCoreAPIOData.Domain.Converters;
using System.Collections.Generic;
using System.Linq;

namespace ChinookCoreAPIOData.Domain.Extensions
{
    public static class ConvertExtensions
    {
        public static IEnumerable<TTarget> ConvertAll<TSource, TTarget>(
            this IEnumerable<IConvertModel<TSource, TTarget>> values) 
            => values.Select(value => value.Convert());
    }
}