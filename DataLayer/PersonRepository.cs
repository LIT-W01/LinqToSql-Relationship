using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PersonRepository
    {
        private string _connectionString;

        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Person GetPersonById(int id)
        {
            using (PersonCarsDataContext dataContext = new PersonCarsDataContext(_connectionString))
            {
                DataLoadOptions loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Person>(p => p.Cars);
                dataContext.LoadOptions = loadOptions;
                return dataContext.Persons.First(p => p.Id == id);
            }

            //PersonCarsDataContext dataContext = new PersonCarsDataContext(_connectionString);
            //Person result = dataContext.Persons.First(p => p.Id == id);
            //dataContext.Dispose();
            //return result;
        }
    }
}
