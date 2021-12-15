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

int? getCurrentVal()
{
	string? brightnessFilePath = getBrightnessFilePath();
	if (brightnessFilePath == null)
	{
		return null;
	}

	string brightnessFileContents = File.ReadAllText(brightnessFilePath).Trim();

	try
	{
		return Convert.ToInt32(brightnessFileContents);
	}
	catch
	{
		return null;
	}
}

void writeValue(int val)
{
	string? brightnessFilePath = getBrightnessFilePath();
	if (brightnessFilePath == null)
	{
		return;
	}

	string brightnessFileContents = val.ToString();
	try
	{
		File.WriteAllText(brightnessFilePath, brightnessFileContents);
	}
	catch
	{
		Console.WriteLine("Could not write file");
	}
}

void writeDifference(int difference)
{
	int? currentVal = getCurrentVal();
	if (currentVal == null)
	{
		return;
	}

	writeValue((int)currentVal + difference);
}

void writeUsage()
{
	Console.WriteLine("Usage: ./BLight subcommand (options)");
	Console.WriteLine("Subcommands:");
	Console.WriteLine();
	Console.WriteLine(" inc     : Increment the brightness");
	Console.WriteLine(" dec     : Decrement the brightness");
	Console.WriteLine(" help    : Display the usage");
	Console.WriteLine();
}

if (args.Length == 0)
{
	writeUsage();
}
else if (args[0] == "inc")
{
	writeDifference(difference);
}
else if (args[0] == "dec")
{
	writeDifference(-difference);
}
else if (args[0] == "help")
{
	writeUsage();
}
else
{
	writeUsage();
}

