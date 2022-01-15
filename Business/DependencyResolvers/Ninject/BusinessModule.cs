using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMovieDal>().To<EfMovieDal>().InSingletonScope();
            Bind<IMovieService>().To<MovieManager>().InSingletonScope();

            Bind<IGenreDal>().To<EfGenreDal>().InSingletonScope();
            Bind<IGenreService>().To<GenreManager>().InSingletonScope();

            Bind<IMovieGenreDal>().To<EfMovieGenreDal>().InSingletonScope();
            Bind<IMovieGenreService>().To<MovieGenreManager>().InSingletonScope();

            Bind<ICommentDal>().To<EfCommentDal>().InSingletonScope();
            Bind<ICommentService>().To<CommentManager>().InSingletonScope();

            Bind<IAdminDal>().To<EfAdminDal>().InSingletonScope();
            Bind<ILoginService>().To<LoginManager>().InSingletonScope();
        }
    }
}
