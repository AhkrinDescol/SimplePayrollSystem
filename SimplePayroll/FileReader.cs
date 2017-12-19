using System;
using System.IO;
using System.Collections.Generic;

namespace SimplePayroll
{
	public static class FileReader
	{
		static public List<Staff> ReadStaffFile(string fileName)
		{
			var staff = new List<Staff>();
			var result = new string[2];
			string[] separator = {", "};
			if (File.Exists(fileName))
			{
				using (var sr = new StreamReader(fileName))
				{
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();
						result = line.Split(separator, StringSplitOptions.None);
						if (result[1] == "Manager")
						{
							staff.Add(new Manager(result[0]));
						}
						else if (result[1] == "Admin")
						{
							staff.Add(new Admin(result[0]));
						}
						else
						{
							Console.WriteLine("Invalid staff type in file, {0}.",
								line);
						}
					}
					sr.Close();
				}
			}
			else
			{
				Console.WriteLine("Error: File not found.  Returning empty staff list.");
			}
			return staff;
		}
	}
}
