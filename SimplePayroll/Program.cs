using System;

namespace SimplePayroll
{
	class Program
	{
		static void Main(string[] args)
		{
			int month = 0, year = 0;
			while (year == 0)
			{
				Console.Write("Please enter the year: ");
				if (!int.TryParse(Console.ReadLine(), out year))
				{
					Console.WriteLine("ERROR: Not a number.");
					continue;
				}
				
			}
			while (month == 0)
			{
				Console.Write("Please enter the month (1-12): ");
				if (!int.TryParse(Console.ReadLine(), out month))
				{
					Console.WriteLine("ERROR: Not a number.");
					continue;
				}
				if (month < 1 || month > 12)
				{
					Console.WriteLine("ERROR: Not a valid month.");
					month = 0;
					continue;
				}
			}
			var myStaff = FileReader.ReadStaffFile("StaffNames.txt");
			for (int i = 0; i < myStaff.Count; ++i)
			{
				Console.Write("Enter hours worked of {0}: ",
					myStaff[i].NameOfStaff);
				int hoursWorked = 0;
				if (!int.TryParse(Console.ReadLine(), out hoursWorked))
				{
					Console.WriteLine("ERROR: Not a number.");
					--i; // Retry current staff member.
					continue;
				}
				myStaff[i].HoursWorked = hoursWorked;
				myStaff[i].CalculatePay();
				Console.WriteLine(myStaff[i].ToString());
			}
			var ps = new PaySlip(month, year);
			ps.GeneratePaySlip(myStaff);
			ps.GenerateSummary(myStaff);
		}
	}
}
