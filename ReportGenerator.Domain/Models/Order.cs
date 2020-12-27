using System;

namespace ReportGenerator.Domain.Models
{
    public class Order
    {
        public string PhoneNumber { get; }

        public DateTime DateAdded { get; }

        public Order(string phoneNumber, DateTime dateAdded)
        {
            PhoneNumber = phoneNumber;
            DateAdded = dateAdded;
        }
    }
}