namespace _04.WorkingWithData.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class InputTweetModel
    {
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}