using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IGenreService genreService = InstanceFactory.GetInstance<IGenreService>();
            var result = genreService.Add(new Entity.Concrete.Genre() { Name = "Aksiyon", Status = true });

            Console.WriteLine(result.Message);
        }
    }
}
