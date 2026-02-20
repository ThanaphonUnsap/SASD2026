using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdapterExample;

public interface Namable
{
    string Name { get; }
}

public class Cat : Namable
{
    public string Name => "Cat";
}

public class Dog : Namable
{
    public string Name => "Dog";
}
public class Rat
{
    public string MyName => "Rat";
}
public class RatAdapter : Namable
{
    private Rat rat;
    public RatAdapter(Rat rat) => this.rat = rat;
    public string Name => rat.MyName;
}
public class Example
{
    public void Run()
    {
        Thread.Sleep(100);
        List<Namable> list = new() {new Cat(), new Dog(), new RatAdapter(new Rat())};
        list.ForEach(n => Debug.Write(n.Name + ", "));
    }
}
