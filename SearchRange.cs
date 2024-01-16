namespace ExportHtml_Mik
{
    public struct SearchRange
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public SearchRange(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }
    }
}
