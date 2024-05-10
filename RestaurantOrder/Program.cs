using RestaurantOrder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Repo o1 = new Repo();
        Order order1 = o1.OrderMany();
        order1.Display();
    }
}