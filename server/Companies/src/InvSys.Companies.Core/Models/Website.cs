namespace InvSys.Companies.Core.Models
{
    public class Website
    {
        public int Id { get; set; }
        public WebsiteType Type { get; set; }
        public string Url { get; set; }
    }

    public enum WebsiteType
    {
        Home,
        Wikipedia,

        // Finance
        GoogleFinance,
        YahooFinance,
        MSNMoney,

        // Social Networks
        LinkedIn,
        Facebook,
        GooglePlus,
        Twitter,
        Flickr,
        Foursquare,
        Instagram,
        Pinterest,
        Tumblr,
        Vimeo,
        YouTube
    }
}
