using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.ProcuratioFramework.String
{
    public static class StringHelper
    {
        /// <summary>
        /// Replace the last occurrence of a string
        /// </summary>
        /// <param name="Source">It is the string on which you want to do the operation.</param>
        /// <param name="Find">It is the string that you want to replace</param>
        /// <param name="Replace">It is the string that you want to replace it with</param>
        /// <returns></returns>
        public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);

            return result;
        }
    }
}
