using System.Diagnostics;

namespace ExportHtml_Mik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // User-editable
            string exportPath = "export.html";
            string csvPath = "game_orders.csv";
            string templatePath = "template.html";


            UserInterface ui = new UserInterface();
            SearchRange range = ui.GetRange();

            OrderCsvReader orderParser = new OrderCsvReader();
            List<Order> orders = orderParser.ParseCSV(csvPath);

            OrderDtoMapper dtoCreator = new OrderDtoMapper(orders.Where(order => order.OrderDate >= range.From && order.OrderDate <= range.To).ToList()) ;
            List<OrderDto> orderDtos = dtoCreator.GetDtoList();

            DtoToHtmlSerializer serializer = new(orderDtos, templatePath, exportPath, range.From, range.To);
            serializer.Serialize();

            Console.WriteLine("Export is complete.");
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(exportPath)
            {
                UseShellExecute = true
            };
            p.Start();
            Console.ReadKey();
        }

    }
}
