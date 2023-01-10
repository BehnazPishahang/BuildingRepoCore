using Application.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DomainExtensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection, params System.Reflection.Assembly[] assemblies)
        {
            foreach (System.Reflection.Assembly assembly in assemblies)
            {
                AddAssemblyRepositories(assembly, serviceCollection);
            }
        }

        private static void AddAssemblyRepositories(System.Reflection.Assembly assembly, IServiceCollection serviceCollection)
        {
            foreach (Type repositoryClass in assembly.GetTypes().Where(a => a.Name.Contains("Repository")))
            {
                if (repositoryClass.IsGenericType)
                {
                    continue;
                }

                if (repositoryClass.IsAssignableTo(typeof(IGenericRepository)))
                {
                    if (repositoryClass.IsClass)
                    {
                        var repositoryInterface = repositoryClass.GetInterfaces().Last();
                        serviceCollection.AddScoped(repositoryInterface, repositoryClass);
                    }
                }
            }



        }
    }
}
