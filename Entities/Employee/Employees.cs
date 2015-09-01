
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Employees
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public long AddressId { get; set; }
        [ForeignKey("Id")]
        public virtual List<Address> Addresses { get; set; }
    }

    public class Manager
    {
        public long ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual Employee ManagerDetails { get; set; }
        public long EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee EmployeeDetails { get; set; }
    }

    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public AddressType AddressType { get; set; }
    }

    public enum AddressType
    {
        Shipping,
        Billing
    }

    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public long OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual Employee Owner { get; set; }
    }
}
