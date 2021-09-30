using Books.DataAccess.Data;
using Books.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Services
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            _context.OrderDetails.Add(orderDetails);
            _context.SaveChanges();
        }

        public IEnumerable<OrderDetails> GetAllOrderDetails()
        {
            return _context.OrderDetails.ToList();
        }

        public OrderDetails GetOrderDetailsById(int id)
        {
           return _context.OrderDetails.FirstOrDefault(d => d.OrderDetailsId == id);
        }

        public void UpdateOrderDetails(OrderDetails orderDetails)
        {
            _context.OrderDetails.Update(orderDetails);
            _context.SaveChanges();
        }

    }
}
