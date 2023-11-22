using System;
namespace AdressBookWebApiManager.Services
{
	public interface IAdressBookService
	{
        List<Person> getAllPeople();

        Person addPerson(Person person);

        void deletePerson(int id);

        public IEnumerable<Person> findPersonByName(string name);
    }
}

