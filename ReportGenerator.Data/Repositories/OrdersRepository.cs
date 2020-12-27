using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ReportGenerator.Data.Connection;
using ReportGenerator.Data.Converters;
using ReportGenerator.Data.Entities;
using ReportGenerator.Domain.Models;

namespace ReportGenerator.Data.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public OrdersRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IReadOnlyCollection<Order>> GetByYearAsync(int year)
        {
            using var dbConnection = _dbConnectionFactory.Create();

            var orderEntities = await dbConnection.QueryAsync<OrderEntity>(
                                    "SELECT * FROM Orders WHERE DATEPART(YEAR FROM DateAdded) = @Year",
                                    new {Year = year});

            return orderEntities.Select(x => x.ToModel()).ToArray();
        }
    }
}