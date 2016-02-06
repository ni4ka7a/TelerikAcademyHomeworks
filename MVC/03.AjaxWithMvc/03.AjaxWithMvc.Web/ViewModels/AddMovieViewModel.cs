namespace _03.AjaxWithMvc.Web.ViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class AddMovieViewModel
    {
        public ICollection<SelectListItem> Studios { get; set; }

        public ICollection<SelectListItem> People { get; set; }
    }
}