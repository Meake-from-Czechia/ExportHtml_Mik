#pragma warning disable CS8600
namespace ExportHtml_Mik
{
    public class OrderToDtoCreator
    {
        public List<Order> Orders;
        public OrderToDtoCreator()
        {
            Orders = new List<Order>();
        }
        public OrderToDtoCreator(List<Order> orders)
        {
            Orders = orders;
        }
        public List<OrderDto> GetDtoList()
        {
            List<string> gameTitles = Orders.DistinctBy(x => x.GameTitle)
                .Select(x => x.GameTitle)
                .ToList();
            List<OrderDto> result = new();
            foreach (string title in gameTitles)
            {
                List<Order> filteredOrders = GetOrderListByTitle(title);
                int copiesBought = filteredOrders.Count();
                string mostBoughtPlatform = filteredOrders.GroupBy(o => o.Platform)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault();
                DateTime lastPurchaseDate = filteredOrders.MaxBy(x => x.OrderDate).OrderDate;
                result.Add(new(title, copiesBought, mostBoughtPlatform, lastPurchaseDate));
            }
            return result;
        }
        private List<Order> GetOrderListByTitle(string gameTitle)
        {
            return Orders.Where(order => order.GameTitle == gameTitle).ToList();
        }
    }
}
