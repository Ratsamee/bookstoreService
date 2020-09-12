using bookstoreService.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace bookstoreService.Data
{
    public class OrderAccess : BaseDataAccess
    {
        public OrderAccess(string connectionString) : base(connectionString)
        {
        }

        public async Task<int> SaveOrder(Order order)
        {
            var parameters = new List<SqlParameter>
            {
                GetParameterOut("@order", SqlDbType.NVarChar, JsonConvert.SerializeObject(order)),
                GetParameterOut("@orderDetails", SqlDbType.NVarChar, JsonConvert.SerializeObject(order.Details))
            };
            var dt = await GetDataReader("sp_insertOrder", parameters);
            return dt.Rows.Count > 0? (int)dt.Rows[0][0]: 0;
        }

        private List<Order> GetOrderModel(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            var orders = new List<Order>();
            foreach (DataRow dr in dt.Rows)
            {
                orders.Add(new Order
                {
                    Id = (int)dr["id"],
                    UserId = (int)dr["user_id"],
                    OrderDate = (DateTime)dr["order_date"],
                    IsCancel = (bool)dr["is_cancel"],
                    IsPaid = (bool)dr["is_paid"]
                });
            }
            return orders;
        }
    }
}
