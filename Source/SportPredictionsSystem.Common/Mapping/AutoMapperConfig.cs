namespace SportPredictionsSystem.Common.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    public class AutoMapperConfig
    {
        private readonly IEnumerable<Assembly> assemblies;

        public AutoMapperConfig(IEnumerable<Assembly> assemblies)
        {
            this.assemblies = assemblies;
        }

        public void Execute()
        {
            var types = this.assemblies.SelectMany(a => a.GetExportedTypes()).ToList();

            Mapper.Initialize(configuration =>
            {
                LoadStandardFromMappings(types, configuration);

                LoadStandardToMappings(types, configuration);

                LoadCustomMappings(types, configuration);
            });
        }

        private static void LoadStandardFromMappings(IEnumerable<Type> types, IProfileExpression configuration)
        {
            var maps = GetFromMaps(types);

            CreateMappings(maps, configuration);
        }

        private static void LoadStandardToMappings(IEnumerable<Type> types, IProfileExpression configuration)
        {
            var maps = GetToMaps(types);

            CreateMappings(maps, configuration);
        }

        private static void LoadCustomMappings(IEnumerable<Type> types, IConfiguration configuration)
        {
            var maps = from t in types
                       from i in t.GetInterfaces()
                       where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                             !t.IsAbstract &&
                             !t.IsInterface
                       select (IHaveCustomMappings)Activator.CreateInstance(t);

            foreach (var map in maps)
            {
                map.CreateMappings(configuration);
            }
        }

        private static IEnumerable<TypesMap> GetFromMaps(IEnumerable<Type> types)
        {
            var fromMaps = from t in types
                           from i in t.GetInterfaces()
                           where i.IsGenericType &&
                                 i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                                 !t.IsAbstract &&
                                 !t.IsInterface
                           select new TypesMap
                           {
                               Source = i.GetGenericArguments()[0],
                               Destination = t
                           };

            return fromMaps;
        }

        private static IEnumerable<TypesMap> GetToMaps(IEnumerable<Type> types)
        {
            var toMaps = from t in types
                         from i in t.GetInterfaces()
                         where i.IsGenericType &&
                               i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                               !t.IsAbstract &&
                               !t.IsInterface
                         select new TypesMap
                         {
                             Source = t,
                             Destination = i.GetGenericArguments()[0]
                         };

            return toMaps;
        }

        private static void CreateMappings(IEnumerable<TypesMap> maps, IProfileExpression configuration)
        {
            foreach (var map in maps)
            {
                configuration.CreateMap(map.Source, map.Destination);
            }
        }
    }
}