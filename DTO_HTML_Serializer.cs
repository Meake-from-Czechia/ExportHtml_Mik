namespace ExportHtml_Mik
{
    public class DTO_HTML_Serializer
    {
        public List<OrderDTO> OrderDTOs { get; set; }
        public string TemplatePath { get; set; }
        public string FilePath { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DTO_HTML_Serializer(List<OrderDTO> orders, string templPath, string filePath, DateTime from, DateTime to)
        {
            OrderDTOs = orders;
            TemplatePath = templPath;
            FilePath = filePath;
            From = from;
            To = to;
        }
        public void Serialize()
        {
            string htmlString = File.ReadAllText(TemplatePath);
            htmlString = htmlString.Replace("{0}", Convert.ToString(From)).Replace("{1}", Convert.ToString(To));
            string[] partsOfTemplate = htmlString.Split("{2}");
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                sw.Write(partsOfTemplate[0]);
                foreach (string line in SerializeDTOs())
                {
                    sw.WriteLine(line);
                }
                sw.Write(partsOfTemplate[1]);
            }
        }
        private List<string> SerializeDTOs()
        {
            return OrderDTOs.Select(x => $"<tr><td>{x.GameTitle}</td><td>{x.CopiesBought}</td><td>{x.MostBoughtPlatform}</td><td>{x.LastPurchaseDate}</td></tr>").ToList();
        }
    }
}
