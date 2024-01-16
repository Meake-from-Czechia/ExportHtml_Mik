namespace ExportHtml_Mik
{
    public class OrderLineParser
    {
        public Order ParseLine(string s, int index)
        {
            Order result = new();
            try
            {
                string[] s_split = s.Trim().Split(',');
                result.UserEmail = s_split[0];
                result.GameTitle = s_split[1];
                result.Platform = s_split[2];
                result.OrderDate = Convert.ToDateTime(s_split[3]);
                result.OrderLocation = s_split[4];
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error has occured while parsing line {index}. More details:\n{e.Message}");
                Environment.Exit(16);
                return null;
            }
        }
    }
}
