using System;

namespace ReportGenerator.Data.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateAdded { get; set; }
    }
}