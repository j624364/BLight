using System;
using System.IO;

void writeValue(int val)
{
}

void writeUsage()
{
	Console.WriteLine("Usage: ./BLight");
}

if (args.Length == 0)
{
	writeUsage();
}
else if (args[0] == "inc")
{
	Console.WriteLine("Increment");
}
else if (args[0] == "dec")
{
	Console.WriteLine("Decrement");
}
else
{
	writeUsage();
}

