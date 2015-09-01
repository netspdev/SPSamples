using Entities.Employees;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DTO.Employees
{
    public interface IEmployee
    {
        long Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        long AddressId { get; set; }
        List<Address> Addresses { get; set; }
    }

    public class Employee : IEmployee
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public long AddressId { get; set; }
        public List<DTO.Employees.Address> Addresses { get; set; }
    }

    public interface IAddress
    {
        long Id { get; set; }
        string StreetName { get; set; }
        string HouseNumber { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string Country { get; set; }
        AddressType AddressType { get; set; }
    }

    public class Address : IAddress
    {
        public long Id { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public AddressType AddressType { get; set; }
    }
}
