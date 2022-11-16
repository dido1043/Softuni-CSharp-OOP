using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string ivestagatedClass, params string[] nameOfFields)
        {
            var sb = new StringBuilder();
            var type = Type.GetType(ivestagatedClass);
        
            sb.AppendLine($"Class under investigation: {type}");
        
            var instance = Activator.CreateInstance(type);
        
            var fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.Public | BindingFlags.NonPublic);
        
        
            foreach (var field in fieldInfos.Where(x => nameOfFields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }
            return sb.ToString().Trim();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            var sb = new StringBuilder();
            //Print all errors
            var type = Type.GetType(className);

            var classFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.Public);
            var publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            //getter
            foreach (var method in nonPublicMethods.Where(n => n.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            //setter
            foreach (var method in publicMethods.Where(n => n.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();
            var type = Type.GetType(className);

            var classMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            foreach (var item in classMethods)
            {
                sb.AppendLine(item.Name);
            }
            return sb.ToString().Trim();
        }
        public string CollectGettersAndSetters(string className)
        {
            var sb = new StringBuilder();
            var type = Type.GetType(className);

            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in methods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in methods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return sb.ToString().Trim();
        }
    }
}
