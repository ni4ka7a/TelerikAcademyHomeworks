namespace _03.AjaxWithMvc.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IStudiosService
    {
        IQueryable<Studio> GetAll();
    }
}
