//import subprocess
//import shutil
//import os

using System.Diagnostics;

void Run(string file, params string[] args)
{
	var proc = Process.Start(file, args);

	proc.WaitForExit();

	if (proc.ExitCode != 0)
	{
		throw new Exception($"Command '{file} {string.Join(" ", args)}' failed");
	}
}

void CopyFolder(string src, string dest)
{
	foreach (var file in Directory.EnumerateFiles(src))
	{
		File.Copy(file, Path.Join(dest, Path.GetFileName(file)), overwrite: true);
	}
}

// Copy loader
CopyFolder(
	@"C:\Users\matth\Documents\Projects\Havoc\HavocLoader\bin\Debug",
	@"C:\Users\matth\Documents\Projects\lethal mods\Lethal Company\Lethal Company_Data\Managed"
);

// Copy mod
File.Copy(
	@"C:\Users\matth\Documents\Projects\Havoc\ExampleMod\bin\Debug\ExampleMod.dll",
	Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Havoc\Mods\ExampleMod.dll"),
	overwrite: true
);

Run(@"C:\Users\matth\Documents\Projects\lethal mods\Lethal Company\Lethal Company.exe");
