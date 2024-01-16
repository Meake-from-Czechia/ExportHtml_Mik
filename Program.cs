namespace ExportHtml_Mik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            var range = ui.GetRange();
            OrderParser orderParser = new OrderParser();
            List<Order> orders = orderParser.ParseCSV("game_orders.csv");
            DTOListGenerator dtoLG = new DTOListGenerator();
            dtoLG.orderList = orders.Where(x => x.OrderDate >= range.Item1 && x.OrderDate <= range.Item2).ToList();
            List<OrderDTO> orderDTOs = dtoLG.GetDTOList();
            DTO_HTML_Serializer serializer = new(orderDTOs, "template.html", "export.html", range.Item1, range.Item2);
            serializer.Serialize();
            Console.WriteLine("Export is complete.");
            Console.ReadKey();
        }
    }
}
