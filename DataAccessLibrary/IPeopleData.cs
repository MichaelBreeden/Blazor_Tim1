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
        Task<List<PersonModel>> GetPeople(string sql);
        Task InsertPerson(PersonModel person);
    }
}