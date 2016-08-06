using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTarea1.Model;

namespace WebTarea1.Repository
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public Customer GetById(int id)
        {
            using (var db = new WebContextDb())
            {
                return db.Customers.FirstOrDefault(c => c.CustomerID == id);
            }
        }
    }
}
