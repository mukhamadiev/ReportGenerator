using System.Collections.Generic;
using System.Threading.Tasks;
using ReportGenerator.Domain.Models;

namespace ReportGenerator.Data.Repositories
{
    public interface IOrdersRepository
    {
        Task<IReadOnlyCollection<Order>> GetByYearAsync(int year);
    }
}