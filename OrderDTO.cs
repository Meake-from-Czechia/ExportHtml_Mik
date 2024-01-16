namespace ExportHtml_Mik
{
    public class OrderDto
    {
        public string GameTitle { get; set; }
        public int CopiesBought { get; set; }
        public string MostBoughtPlatform { get; set; }
        public DateTime LastPurchaseDate { get; set; }
        public OrderDto(string gameTitle, int copiesBought, string mostBoughtPlatform, DateTime lastPurchaseDate) 
        {
            GameTitle = gameTitle;
            CopiesBought = copiesBought;
            MostBoughtPlatform = mostBoughtPlatform;
            LastPurchaseDate = lastPurchaseDate;
        }
    }
}
