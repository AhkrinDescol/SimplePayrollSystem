using System;

namespace SimplePayroll
{
	public class Manager : Staff
	{
		public Manager(string name) : base(name, managerHourlyRate){}
		
		public override void CalculatePay()
		{
			base.CalculatePay();
			if (HoursWorked > 160)
			{
				Allowance = managerStandardAllowance;
				TotalPay += Allowance;
			}
		}
		
		public override string ToString()
		{
			return "Staff Type: Manager, Name: " + NameOfStaff + ", TotalPay: "
				+ TotalPay + ", BasicPay: " + BasicPay + ", HoursWorked: "
				+ HoursWorked + ".";
		}
		
		public int Allowance
		{
			get;
			private set;
		}
		
		private const int managerStandardAllowance = 1000;
		private const float managerHourlyRate = 50.0f;
	}
}
