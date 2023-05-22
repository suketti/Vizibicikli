namespace ConsoleApp1
{
    internal class Program
    {
        static List<Rentals> list = new List<Rentals>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("kolcsonzesek.txt");
            sr.ReadLine();
            while (!sr.EndOfStream) 
            {
                var fields = sr.ReadLine().Split(';');
                Rentals rental = new Rentals(fields[0], fields[1][0], int.Parse(fields[2]), int.Parse(fields[3]), int.Parse(fields[4]), int.Parse(fields[5]));

                list.Add(rental);
            }
            if (list.Count(x=>x.Name == "Kata") == 0)
            {
                Console.WriteLine("Nem volt ilyen kolcsonzes");
            } else
            {
                list.Where(x => x.Name == "Kata")
                    .ToList()
                    .ForEach(x => Console.WriteLine($"{x.SHour}:{x.SMinute}-{x.EHour}:{x.EMinute}"));
            }

            Console.Write("7. feladat: Adjon meg egy időpontot óra:perc ablakban: ");
            string inputTime = Console.ReadLine();
            int inputHour = Convert.ToInt32(inputTime.Split(':')[0]);
            int inputMinute = Convert.ToInt32(inputTime.Split(':')[1]);
            int osszido = inputHour * 60 + inputMinute;

            list.Where(x => x.SHour * 60 + x.SMinute < osszido && osszido < x.EHour * 60 + x.EMinute).ToList()
                .ForEach(x => Console.WriteLine($"{x.SHour}:{x.SMinute}-{x.EHour}:{x.EMinute} : {x.Name}"));


            int dailyIncome = 2400 * (list.Sum(x => x.timeLength()) / 30 + 1);
            Console.WriteLine($"8. feladat: A napi bevétel: {dailyIncome} Ft");

            StreamWriter sw = new StreamWriter("F.txt");
            list.Where(x => x.VIden == 'F')
                .ToList()
                .ForEach(x => sw.WriteLine($"{x.SHour} : {x.SMinute} - {x.SHour}:{x.SMinute} : {x.Name}"));
            sw.Close();

            list.GroupBy(x => x.VIden)
               .OrderBy(x => x.Key)
               .ToList()
               .ForEach(x => Console.WriteLine($"{x.Key} - {x.Count()}"));
        }
    }
}