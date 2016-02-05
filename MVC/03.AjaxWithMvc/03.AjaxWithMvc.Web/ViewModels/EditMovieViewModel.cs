namespace _03.AjaxWithMvc.Web.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class EditMovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        [Display(Description = "Studio")]
        public int StudioId { get; set; }

        [Display(Description = "Director")]
        public int DirectorId { get; set; }

        [Display(Description = "Leading Male Role")]
        public int LeadingMaleRoleId { get; set; }

        [Display(Description = "Leading Female Role")]
        public int LeadingFemaleRoleId { get; set; }

        public ICollection<SelectListItem> Studios { get; set; }

        public ICollection<SelectListItem> People { get; set; }
    }
}