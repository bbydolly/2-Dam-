using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer3
{
	internal class EspecialEmployee : Employee, IGoosePasta
	{
		public EspecialEmployee(string firstName, string lastName, int age, string dni, double salary, string phone)
			: base(firstName, lastName, age, dni, salary, phone)
		{
			ExtraMoney = 0;
		}

		public EspecialEmployee() : base()
		{
			ExtraMoney = 0;
		}

		public double ExtraMoney { get; set; }

		public override double Taxes()
		{
			return base.Taxes() + (base.Taxes() / 100 * 0.5);
		}

		public double GainMoney(double totalProfit)
		{
			if (totalProfit <= 0)
			{
				return 0;
			}
			Salary = totalProfit / 100 * 0.5;
			return Salary;
		}
	}
}
