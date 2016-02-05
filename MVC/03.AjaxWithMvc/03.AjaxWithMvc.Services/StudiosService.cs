namespace _03.AjaxWithMvc.Services
{
    using Contracts;
    using System.Linq;
    using Models;
    using System;
    using Data;
    public class StudiosService : IStudiosService
    {
        private IRepository<Studio> studios;

        public StudiosService(IRepository<Studio> studios)
        {
            this.studios = studios;
        }

        public IQueryable<Studio> GetAll()
        {
            return this.studios.All();
        }
    }
}
