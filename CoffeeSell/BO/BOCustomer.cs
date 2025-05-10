using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.BO
{
    public class BOCustomer
    {
        static DAOCustomer c = new DAOCustomer();
        static DAORanking r = new DAORanking();

        public static DataTable GetAllCustomer()
        {
            return c.GetAllCustomer();
        }
        public static int Add(Customer info)
        {
            info.SetRegisterDate(DateTime.Now);
            info.SetLattestBuy(DateTime.Now);
            info.SetPoints(0);
            return c.CreateCustomer(info);
        }
        public static bool UpdatePoint(int id, int point)
        {
            Customer cus = c.GetCustomerById(id);
            cus.SetLattestBuy(DateTime.Now);
            cus.SetPoints(cus.GetPoints() + point);
            return c.UpdateCustomer(cus);
        }
        public static List<Customer> GetAllCustomerList() { return c.GetCustomerList(); }
        public static Ranking GetRanking()
        {
            return r.GetRanking();  
        }
        public static bool Update(Ranking info)
        {
            return r.UpdateRanking(info);
        }
    }
}
