using System.ComponentModel.DataAnnotations;

namespace ShortLink.Client.Data.ViewModels
{
    public class PostUrlViewModel
    {
        [Required(ErrorMessage ="Url is required")]
        [RegularExpression("^https?://([\\w-]+\\.)+[\\w-]+(/[\\w\\-./?%&=]*)?$", ErrorMessage = "Invalid URL format")]
        public string Url { get; set; }
    }
}
