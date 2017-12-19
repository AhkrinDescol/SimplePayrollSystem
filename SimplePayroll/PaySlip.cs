using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimplePayroll
{
	public class PaySlip
	{
		public PaySlip(int payMonth, int payYear)
		{
			month = payMonth;
			year = payYear;
		}
		
		public void GeneratePaySlip(List<Staff> myStaff)
		{
			string filePath;
			foreach (var staffMember in myStaff)
			{
				filePath = staffMember.NameOfStaff + ".txt";
				using (var sw = new StreamWriter(filePath, true))
				{
					sw.WriteLine("PAYSLIP FOR {0} {1}",
						(MonthsOfYear)month, year);
					sw.WriteLine(new string('=', 20));
					sw.WriteLine("Name of staff: {0}", staffMember.NameOfStaff);
					sw.WriteLine("Hours worked: {0}", staffMember.HoursWorked);
					sw.WriteLine("\nBasic pay: ${0:N}", staffMember.BasicPay);
					if (staffMember.GetType() == typeof(Manager))
					{
						sw.WriteLine("Allowance: ${0:N}",
							((Manager)staffMember).Allowance);
					}
					else if (staffMember.GetType() == typeof(Admin))
					{
						sw.WriteLine("Overtime pay: ${0:N}",
							((Admin)staffMember).OvertimePay);
					}
					sw.WriteLine("\n");
					sw.WriteLine(new string('=', 20));
					sw.WriteLine("Total pay: ${0:N}", staffMember.TotalPay);
					sw.WriteLine(new string('=', 20));
					sw.Close();
				}
			}
		}
		
		public void GenerateSummary(List<Staff> myStaff)
		{
			var result =
				from staffMember in myStaff
				where staffMember.HoursWorked < 10
				orderby staffMember.NameOfStaff ascending
				select new {staffMember.NameOfStaff, staffMember.HoursWorked};
			using (var sw = new StreamWriter("summary.txt"))
			{
				sw.WriteLine("Staff with less than ten hours of work:\n");
				foreach (var lazyPerson in result)
				{
					sw.WriteLine("Name of staff: {0}, hours worked: {1}",
						lazyPerson.NameOfStaff, lazyPerson.HoursWorked);
				}
				sw.Close();
			}
		}
		
		public override string ToString()
		{
			return "month = " + month + ", year =" + year;
		}
	
		private enum MonthsOfYear{JAN = 1, FEB, MAR, APR, MAY, JUN, JUL, AUG,
			SEP, OCT, NOV, DEC}

		protected int month, year;
	}
}
