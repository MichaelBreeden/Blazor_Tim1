using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    //internal interface IPeopleData
    public interface IPeopleData
    {
        ISqlDataAccess _db { get; }

        Task<List<PersonModel>> GetPeople();
        Task InsertPerson(PersonModel person);
    }
}