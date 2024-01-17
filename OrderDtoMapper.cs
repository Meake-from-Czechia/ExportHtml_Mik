#pragma warning disable CS8600
namespace ExportHtml_Mik
{
    public class OrderDtoMapper
    {
        public List<Order> Orders;
        public OrderDtoMapper()
        {
            Orders = new List<Order>();
        }
        public OrderDtoMapper(List<Order> orders)
        {
            Orders = orders;
        }
        public List<OrderDto> GetDtoList()
        {
            List<string> gameTitles = Orders.Select(x => x.GameTitle)
                .Distinct()
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
                DateTime lastPurchaseDate = filteredOrders.Max(x => x.OrderDate);
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
