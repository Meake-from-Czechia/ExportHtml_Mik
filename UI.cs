namespace ExportHtml_Mik
{
    public class UI
    {
        string[] months = new[] { "leden", "únor", "březen", "duben", "květen", "červen", "červenec", "srpen", "září", "říjen", "listopad", "prosinec" };
        public (DateTime, DateTime) GetRange()
        {
            DateTime from = GetDate("Zadejte počátek hledání v objednávkách (formát '<měsíc> <rok>'): ", false);
            DateTime to = GetDate("Zadejte konec hledání v objednávkách (poslední den v měsíci; formát '<měsíc> <rok>'): '", true);
            return (from, to);
        }
        private DateTime GetDate(string msg, bool konec)
        {
            string input;
            string[] inputArr;
            int year;
            int month;
            do
            {
                Console.Write(msg);
                input = Console.ReadLine();
                inputArr = input.Trim().ToLower().Split(' ');
            } while (!(inputArr.Length == 2 && months.Any(x => x == inputArr[0]) && int.TryParse(inputArr[1], out year)));
            month = Array.IndexOf(months, inputArr[0]) + 1;
            return DateTime.Parse($"{year}-{month}-{(konec ? DateTime.DaysInMonth(year, month) : "01")}");
        }
    }
}
