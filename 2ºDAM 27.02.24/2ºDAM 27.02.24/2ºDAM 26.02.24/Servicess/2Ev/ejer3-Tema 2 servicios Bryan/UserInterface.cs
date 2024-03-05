using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer3
{
	internal class UserInterface
	{
		PeopleManager peopleManager = new PeopleManager();

		public void Start()
		{
			Employee employee = new Employee("Bryan", "Quintas Lareo", 21, "53974582", 1300, "611465284");
			Directive directive = new Directive("Xurxo", "Mayo Santos", 25, "34215968", "Finanzas", 3000);
			peopleManager.AddPerson(employee);
			peopleManager.AddPerson(directive);
			int option;
			do
			{
				Console.Write("1.- Insert new person.\n" +
				"2.- Delete persons.\n" +
				"3.- Visualize list.\n" +
				"4.- Visualize one person's data.\n" +
				"5.- Exit.\n\n" +
				"Choose an option: ");
				int.TryParse(Console.ReadLine(), out option);
				switch (option)
				{
					case 1:
						subMenuOption1();
						break;
					case 2:
						if (peopleManager.people.Count < 1)
						{
							Console.WriteLine("The list is empty, add elements before erasing them.");
						}
						else
						{
							Option2();
						}
						break;
					case 3:
						if (peopleManager.people.Count == 0)
						{
							Console.WriteLine("The list is empty.");
						}
						else
						{
							Option3();
						}
						break;
					case 4:
						if (peopleManager.people.Count == 0)
						{
							Console.WriteLine("The list is empty.");
						}
						else
						{
							Option4();
						}
						break;
					case 5:
						Console.WriteLine("Bye curro!");
						break;
					default:
						Console.WriteLine("You have to choose an option between 1 and 5.");
						break;
				}
			} while (option != 5);
		}
		public void subMenuOption1()
		{
			int option;
			do
			{
				Console.Write("\n1.- Employee.\n" +
					"2.- Directive.\n" +
					"3.- Go back.\n\n" +
					"Choose an option: ");
				int.TryParse(Console.ReadLine(), out option);
				switch (option)
				{
					case 1:
						Employee employee = new Employee();
						employee.AskData();
						peopleManager.AddPerson(employee);
						break;
					case 2:
						Directive directive = new Directive();
						directive.AskData();
						peopleManager.AddPerson(directive);
						break;
					default:
						Console.WriteLine("You have to choose an option between 1 and 3.");
						break;
				}
			} while (option != 1 || option != 2);
		}

		public void Option2()
		{
			bool error;
			int max;
			int min;
			string option;
			do
			{
				Console.Write("\nType the first position you want to delete.");
				error = !int.TryParse(Console.ReadLine(), out min);
				if (error || (min < 0 || min > peopleManager.people.Count - 1))
				{
					Console.WriteLine("\nYou have to type an integer number between 0 and " + (peopleManager.people.Count - 1) + ".");
				}
			} while (error);
			do
			{
				Console.Write("\nType the last position you want to delete.");
				error = !int.TryParse(Console.ReadLine(), out max);
				if (error || (max < min || max > peopleManager.people.Count))
				{
					Console.WriteLine("\nYou have to type an integer number between " + min + " and " + (peopleManager.people.Count - 1) + ".");
				}
			} while (error);
			do
			{
				Console.WriteLine("***************************************************");
				for (int i = min; i <= max; i++)
				{
					peopleManager.people[i].ShowData();
					Console.WriteLine("***************************************************");

				}
				Console.WriteLine("Do you want to delete these elements? (Yes/No)");
				option = Console.ReadLine().ToLower();
				if (option != "yes" || option != "no")
				{
					Console.WriteLine("You have to type \"Yes\" or \"No\"");
				}
			} while (option != "yes" || option != "no");
			if (option == "no")
			{
				peopleManager.Delete(max, min);
			}
		}
		public void Option3()
		{
			string line = "+-----++------------++----------------------++------+";
			Console.WriteLine(line);
			Console.WriteLine("| NUM || FIRST NAME ||       LAST NAME      || TYPE |");
			Console.WriteLine(line);
			for (int i = 0; i < peopleManager.people.Count; i++)
			{
				Person item = peopleManager.people[i];
				Console.WriteLine(string.Format("| {0,3} || {1,10} || {2,20} ||    {3} |", i,
					item.FirstName.Length > 10 ? item.FirstName.Substring(0, 7) + "..." : item.FirstName,
					item.LastName.Length > 20 ? item.LastName.Substring(0, 17) + "..." : item.LastName,
					item is Employee ? "E" : "D"));
				Console.WriteLine(line);
			}
		}
		public void Option4()
		{
			string msg;
			do
			{
				Console.Write("Type the start of the last name of the person you want to visualize: ");
				msg = Console.ReadLine();
				if (msg == "")
				{
					Console.WriteLine("The parameter is empty.");
				}
			} while (msg == "");
			int position = peopleManager.Position(msg);
			if (position == -1)
			{
				Console.WriteLine("That person doesn't exist.");
			}
			else
			{
				Person item = peopleManager.people[position];
				item.ShowData();
				if (item is Directive)
				{
					((Directive)item).GainMoney(1000);
				}
			}

		}
	}
}
