namespace ExportHtml_Mik
{
    public class UserInterface
    {
        private readonly string[] Months = new[] { "leden", "únor", "březen", "duben", "květen", "červen", "červenec", "srpen", "září", "říjen", "listopad", "prosinec" };
        public SearchRange GetRange()
        {
            SearchRange range = new();
            DateTime from = GetDate("Zadejte počátek hledání v objednávkách (formát '<měsíc> <rok>'): ", false);
            DateTime to = GetDate("Zadejte konec hledání v objednávkách (poslední den v měsíci; formát '<měsíc> <rok>'): ", true);
            return new(from, to);
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
            } while (!(inputArr.Length == 2 && Months.Any(x => x == inputArr[0]) && int.TryParse(inputArr[1], out year)));
            month = Array.IndexOf(Months, inputArr[0]) + 1;
            return DateTime.Parse($"{year}-{month}-{(konec ? DateTime.DaysInMonth(year, month) : "01")}");
        }
    }
}
