using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring101.DataClump1;

// 4.1
public class DataClump1Good
{
    // Future improvement: may consider to move into Customer class ?
    public void Print(Customer customer)
    {
        // ...
    }
}
public class Customer
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required int Age { get; set; }
}
