using System;
namespace AdressBookWebApiManager.Services
{
	public class Person
	{
		public int id { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string email { get; set; }
	}
	public class AdressBookService : IAdressBookService
	{
		readonly List<Person> PersonList = new();

		public List<Person> getAllPeople() => PersonList;

		public Person addPerson (Person person)
		{
			PersonList.Add(person);
			return person;
		}

		public void deletePerson(int id)
		{
			var Person = PersonList.FirstOrDefault(x => x.id == id);
			if (Person == null)
			{
				throw new ArgumentException("Person not found by id =", id.ToString());
			}
				PersonList.Remove(Person);
		}

		public IEnumerable<Person> findPersonByName(string name)
		{
			var Person = PersonList.FirstOrDefault(x => x.firstName == name);
            if (Person == null)
            {
                throw new ArgumentException("Person not found by name =", name);
            }
			return PersonList.Where(x => x.firstName == name);
        }

    }
}

