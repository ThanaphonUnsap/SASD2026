using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring101;

public class MysteriousName
{
    // 1.1
    // Bad naming
    public double Average(double a, double b) 
    {
        return (a + b) / 2;
    }
}

// 1.2
// Bad Naming
public class Queue
{
    // ...
    public int Dequeue()
    {
        //...
        throw new NotImplementedException("Ongoing implementation");
    }

    public void Enqueue(int value)
    {
        // ...
    }
}
