using Business.Abstract;
using Core.Utils.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LoginManager : ILoginService
    {
        private IAdminDal _adminDal;

        public LoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public IDataResult<Admin> AdminLogin(Admin admin)
        {
            Admin loginAdmin = _adminDal.Get(x => x.Email == admin.Email && x.Password == admin.Password);
            if(loginAdmin == null)
            {
                return new ErrorDataResult<Admin>("Eposta veya şifre hatalı");
            }
            return new SuccessDataResult<Admin>(loginAdmin,"Giriş başarılı");
        }
    }
}
