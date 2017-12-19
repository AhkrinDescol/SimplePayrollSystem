using System;
namespace SimplePayroll
{
	public class Admin : Staff
	{
		public Admin(string name) : base(name, adminHourlyRate){}
		
		public override void CalculatePay()
		{
			BasicPay = hoursWorked * adminHourlyRate;
			if (hoursWorked > 160)
			{
				OvertimePay = (hoursWorked - 160) * OvertimeRate;
			}
			else
			{
				OvertimePay = 0;
			}
			TotalPay = BasicPay + OvertimePay;
		}
		
		public override string ToString()
		{
			return "Staff Type: Admin, Name: " + NameOfStaff + ", TotalPay: "
				+ TotalPay + ", BasicPay: " + BasicPay + ", HoursWorked: "
				+ HoursWorked + ".";
		}
		
		public float OvertimePay
		{
			get;
			private set;
		}
		
		private const float OvertimeRate = 15.5f;
		private const float adminHourlyRate = 30.0f;
	}
}
