using ReportGenerator.Data.Entities;
using ReportGenerator.Domain.Models;

namespace ReportGenerator.Data.Converters
{
    public static class OrderConverter
    {
        public static Order ToModel(this OrderEntity entity) => new Order(entity.PhoneNumber, entity.DateAdded);
    }
}