namespace ShortLink.Client.Data.ViewModels
{
    public class GetUrlViewModel
    {
        public int Id { get; set; }
        public string OriginalLink { get; set; }
        public string ShortLink { get; set; }
        public int NoOfClicks { get; set; }
        public int? UserId { get; set; }

        public GetUserViewModel? User { get; set; }
    }
}
