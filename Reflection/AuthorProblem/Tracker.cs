using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var getMethods = type.GetMethods(BindingFlags.Public|BindingFlags.Static|BindingFlags.Instance);
            foreach (var item in getMethods)
            {
                if (item.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = item.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine("{0} is written by {1}", item.Name, attr.Name);
                    }
                }
            }
        }
    }
}
