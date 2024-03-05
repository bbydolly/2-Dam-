using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer3
{
	internal class PeopleManager
	{
		public List<Person> people = new List<Person>();

		public int Position(int age)
		{
			int aux = 0;
			for (int i = 0; i < people.Count; i++)
			{
				if (age > people[i].Age)
				{
					aux = i;
				}
			}
			return 0;
		}

		public int Position(string lastName)
		{
			for (int i = 0; i < people.Count; i++)
			{
				if (people[i].LastName.ToLower().StartsWith(lastName.ToLower()))
				{
					return i;
				}
			}
			return -1;
		}

		public bool Delete(int max, int min = 0)
		{
			try
			{
				for (int i = people.Count - 1; i >= 0; i--)
				{
					if (i <= max && i >= min)
					{
						people.RemoveAt(i);
					}
				}

			}
			catch (ArgumentOutOfRangeException)
			{
				return false;
			}
			catch (ArgumentException)
			{
				return false;
			}
			return true;
		}
		public void AddPerson(Person person)
		{
			people.Insert(Position(person.Age), person);
		}
	}
}
