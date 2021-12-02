using Final_Examen.DB;
using Final_Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Examen.Repositories
{
    public interface IHomeRepository
    {
        List<Cuenta> GetAllCuentas();
    }
    public class HomeRepository: IHomeRepository
    {
        private readonly FinalContext context;
        public HomeRepository(FinalContext context)
        {
            this.context = context;
        }

        public List<Cuenta> GetAllCuentas()
        {
            return context.Cuentas.ToList();
        }
    }
}
