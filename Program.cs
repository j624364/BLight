using System;
using System.IO;
using System.Collections.Generic;

const string backlightsDirectoryPath = "/sys/class/backlight/";
const int difference = 10;

string? getBrightnessFilePath()
{
	if (!Directory.Exists(backlightsDirectoryPath))
	{
		Console.WriteLine(backlightsDirectoryPath + " does not exist!");
		return null;
	}

	string[] possibleDirectories = Directory.GetDirectories(backlightsDirectoryPath);

	if (possibleDirectories.Length == 0)
	{
		Console.WriteLine(backlightsDirectoryPath + " has no subdirectories!");
		return null;
	}

	foreach (var directory in possibleDirectories)
	{
		string filePath = directory + "/brightness";

		if (File.Exists(filePath))
		{
			return filePath;
		}
	}

	Console.WriteLine(backlightsDirectoryPath + " has no valid subdirectories!");
	return null;
}

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

