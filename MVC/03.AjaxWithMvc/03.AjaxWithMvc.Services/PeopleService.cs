namespace _03.AjaxWithMvc.Services
{
    using Contracts;
    using System.Linq;
    using Models;
    using System;
    using Data;
    public class PeopleService : IPeopleService
    {
        private IRepository<Person> people;

        public PeopleService(IRepository<Person> people)
        {
            this.people = people;
        }

        public IQueryable<Person> GetAll()
        {
            return this.people.All();
        }
    }
}
