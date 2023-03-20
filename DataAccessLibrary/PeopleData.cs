using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    internal class PeopleData : IPeopleData // now need to put this in startup.cs for injection
    {
        public PeopleData(ISqlDataAccess db)
        {
            _db = db;
        }

        public ISqlDataAccess _db { get; }

        public Task<List<PersonModel>> GetPeople()
        {
            string sql = "select * from dbo.People"; // could be mroe efficient

            return _db.LoadData<PersonModel, dynamic>(sql, new { }); // no parameters, No awaiting here.
        }

        public Task InsertPerson(PersonModel person)
        {
            string sql = @"insert into  dbo.People (FirstName, LastName, EmailAddress) 
                            values (@FirstName, @LastName, @EmailAddress);";

            return _db.SaveData(sql, person); // No awaiting here.
        }

        /*  CREATE TABLE[dbo].[People]
            (
             [ID] [int] IDENTITY(1,1) NOT NULL,
            --[RequestID] [int] NOT NULL,
            [LastName] [varchar] (50) NOT NULL,
            [FirstName] [varchar] (50) NOT NULL,
            [EmailAddress] [varchar] (50) NOT NULL,
            [DateOfBirth] [datetime] NOT NULL,
         CONSTRAINT[PK_People] PRIMARY KEY CLUSTERED
        (
            [ID] ASC
        )WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON[PRIMARY]
        ) ON[PRIMARY]

        insert into People values ('Seaton', 'Dick', 'dseaton@lakecountyil.gov', '1916-03-12')
        insert into People values ('Duquesne', 'Blacky', 'bduquesne@lakecountyil.gov', '1918-06-11')
        insert into People values ('Franklin', 'Ben', 'bfranklin@lakecountyil.gov', '17156-03-17')
        */
    }
}
