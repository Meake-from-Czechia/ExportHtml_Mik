namespace ExportHtml_Mik
{
    public class OrderCsvReader
    {
        private OrderLineParser LineParser;
        public OrderCsvReader()
        {
            LineParser = new();
        }

        public List<Order> ParseCSV(string path)
        {
            int i = 1;
            List<Order> result = new List<Order>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        i++;
                        result.Add(LineParser.ParseLine(sr.ReadLine(), i));
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occured while parsing CSV. \nMore details: {ex.Message}");
                Environment.Exit(15);
                return null;
            }
        }
    }
}
