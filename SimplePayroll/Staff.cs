using System;

namespace SimplePayroll
{
	public abstract class Staff
	{
		public Staff(string name, float rate)
		{
			NameOfStaff = name;
			hourlyRate = rate;
		}
	
		public virtual void CalculatePay()
		{
			Console.WriteLine("Calculating pay...");
			BasicPay = hoursWorked * hourlyRate;
			TotalPay = BasicPay;
		}
		
		public override string ToString()
		{
			return "Name: " + NameOfStaff + ", TotalPay: " + TotalPay
				+ ", BasicPay: " + BasicPay + ", HoursWorked: " + HoursWorked
				+ ".";
		}
		
		public float TotalPay
		{
			get;
			protected set;
		}
		
		public float BasicPay
		{
			get;
			protected set;
		}
		
		public string NameOfStaff
		{
			get;
			protected set;
		}
		
		public float HoursWorked
		{
			get
			{
				return hoursWorked;
			}
			set
			{
				hoursWorked = (value > 0) ? value : 0;
			}
		}
		
		protected float hourlyRate, hoursWorked;
	}
}
