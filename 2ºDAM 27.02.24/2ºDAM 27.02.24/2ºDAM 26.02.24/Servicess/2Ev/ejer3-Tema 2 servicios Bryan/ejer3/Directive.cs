using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer3
{
	internal class Directive : Person, IGoosePasta
	{
		private int numPersons;
		private double moneyGained;

		public Directive(string firstName, string lastName, int age, string dni, string departament, int numPersons)
			: base(firstName, lastName, age, dni)
		{
			Departament = departament;
			NumPersons = numPersons;
			moneyGained = 0;
		}

		public Directive() : base()
		{
			Departament = "";
			NumPersons = 0;
			moneyGained = 0;
		}
		public string Departament { get; set; }
		public double Profit { get; set; }
		public double MoneyGained { get { return moneyGained; } }
		public int NumPersons
		{
			get
			{
				return numPersons;
			}
			set
			{
				numPersons = value;
				Profit = value < 10 ? 2 : value < 50 ? 3.5 : 4;
			}
		}
		public static Directive operator --(Directive directive)
		{
			directive.Profit = directive.Profit - 1 > 0 ? directive.Profit - 1 : 0;
			return directive;
		}

		public override void ShowData()
		{
			base.ShowData();
			Console.WriteLine($"Departament: {Departament}.\n" +
				$"Profit: {Profit}%.\n" +
				$"Number of persons in their charge: {NumPersons}.");
		}

		public override void AskData()
		{
			base.AskData();
			bool flag;
			Console.Write("Type the name of the departament: ");
			Departament = Console.ReadLine();
			int auxNumPersons;
			do
			{
				Console.Write("Type the number of persons in their charge: ");

				if (!(flag = int.TryParse(Console.ReadLine(), out auxNumPersons)))
				{
					Console.WriteLine("You have to type an integer number.");
				}
			} while (!flag);
			NumPersons = auxNumPersons;
		}
		public override double Taxes()
		{
			return MoneyGained / 100 * 30;
		}
		public double GainMoney(double totalProfit)
		{
			if (totalProfit <= 0)
			{
				Directive aux = this;
				aux--;
				return 0;
			}
			moneyGained = totalProfit / 100 * Profit;
			return moneyGained;
		}
	}
}
