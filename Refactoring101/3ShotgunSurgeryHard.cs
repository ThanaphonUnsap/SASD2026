using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring101.ShotgunSurgeryHard;

public class Customer
{
    public required string Name { get; set; }
    public required string Address { get; set; }
}
public class CustomerReader
{
    public Customer ReadCustomer()
    {
        string name = Console.ReadLine()!;
        string address = Console.ReadLine()!;
        return new Customer() { Name = name, Address = address };
    }
}
public class CustomerWriter
{
    public void WriterCustomer(Customer customer)
    {
        Console.WriteLine(customer.Name);
        Console.WriteLine(customer.Address);
    }
}
