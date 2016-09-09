using System;
using System.Collections.Generic;
using System.Linq;

namespace InvSys.Shared.Core.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> ToList<T>(this Enum mask)
        {
            if (typeof(T).IsSubclassOf(typeof(Enum)) == false)
                throw new ArgumentException();

            return Enum.GetValues(typeof(T))
                                 .Cast<Enum>()
                                 .Where(m => mask.HasFlag(m))
                                 .Cast<T>();
        }
    }
}
