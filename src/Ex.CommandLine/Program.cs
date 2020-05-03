using System;
using System.Diagnostics;
using System.IO;

namespace Ex.CommandLine
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var process = new Process();
			process.StartInfo.LoadUserProfile = true;
			process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
			process.StartInfo.FileName = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
			process.StartInfo.Arguments = $@"www.google.com";

			process.StartInfo.UseShellExecute = false;

			process.StartInfo.RedirectStandardOutput = true;
			process.OutputDataReceived += (sender, data) =>
			{
				Console.WriteLine(data.Data);
			};
			process.StartInfo.RedirectStandardError = true;
			process.ErrorDataReceived += (sender, data) =>
			{
				Console.WriteLine(data.Data);
			};

			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
		}
	}
}
