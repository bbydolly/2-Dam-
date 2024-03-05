using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer3
{
	internal class Employee : Person
	{
		private double salary;
		private int irpf;
		private string phone;

		public Employee(string firstName, string lastName, int age, string dni, double salary, string phone)
			: base(firstName, lastName, age, dni)
		{
			Salary = salary;
			Phone = phone;
		}

		public Employee() : base()
		{
			Salary = 0;
			Phone = "";
		}

		public double Salary
		{
			set
			{
				salary = value;
				irpf = value < 600 ? 7 : value < 3000 ? 15 : 20;
			}
			get
			{
				return salary;
			}
		}
		public int Irpf { get { return irpf; } }
		public string Phone { get { return $"+34 {phone}"; } set { phone = value; } }
		public override void ShowData()
		{
			base.ShowData();
			Console.WriteLine($"Salary: {Salary}.\n" +
				$"IRPF: {Irpf}%.\n" +
				$"Phone number: {Phone}.");
		}
		public void ShowData(int option)
		{
			switch (option)
			{
				case 1:
					Console.WriteLine($"First name: {FirstName}.");
					break;
				case 2:
					Console.WriteLine($"Last names: {LastName}.");
					break;
				case 3:
					Console.WriteLine($"Age: {Age}.");
					break;
				case 4:
					Console.WriteLine($"DNI: {Dni}.");
					break;
				case 5:
					Console.WriteLine($"Salary: {Salary}.");
					break;
				case 6:
					Console.WriteLine($"IRPF: {Irpf}%.");
					break;
				default:
					Console.WriteLine($"Phone: {Phone}.");
					break;
			}
		}
		public override double Taxes()
		{
			return Irpf * Salary / 100;
		}
	}
}
