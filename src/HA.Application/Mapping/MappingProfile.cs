//using AutoMapper;
//using HA.Application.Common.Contract;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace HA.Application.Mapping
//{
//    public class MappingProfile : Profile
//    {
//        public MappingProfile()
//        {
//            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
//        }

//        private void ApplyMappingsFromAssembly(Assembly assembly)
//        {
//            var types = assembly.GetExportedTypes()
//                .Where(t => t.GetInterfaces().Any(i =>
//                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
//                .ToList();

//            foreach (var type in types)
//            {
//                var instance = Activator.CreateInstance(type);
//                var methodInfo = type.GetMethod("Mapping");
//                methodInfo?.Invoke(instance, new object[] { this });
//            }
//        }
//    }
//}