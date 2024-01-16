#pragma warning disable CS8601
namespace ExportHtml_Mik
{
    public class DTOListGenerator
    {
        public List<Order> orderList;
        public DTOListGenerator()
        {
            orderList = new List<Order>();
        }
        public List<OrderDTO> GetDTOList()
        {
            List<OrderDTO> result = orderList.DistinctBy(x => x.GameTitle)
                .Select(x => new OrderDTO(x.GameTitle, 0, string.Empty, DateTime.MinValue))
                .ToList();
            List<Order> orderListFiltered;
            for (int i = 0; i < result.Count; i++)
            {
                orderListFiltered = orderList.Where(x => x.GameTitle == result[i].GameTitle).ToList();
                result[i].CopiesBought = orderListFiltered.Count();
                result[i].MostBoughtPlatform = orderListFiltered.GroupBy(o => o.Platform)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault();
                result[i].LastPurchaseDate = orderListFiltered.MaxBy(x => x.OrderDate).OrderDate;
            }
            return result;
        }
    }
}
