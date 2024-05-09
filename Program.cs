User
using System;

namespace BMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BMI Kalkulator");

            // Dobivanje težine od korisnika s validacijom
            double weight = GetPositiveNumber("Unesite težinu u kilogramima: ");

            // Dobivanje visine od korisnika s validacijom
            double heightInCentimeters = GetPositiveNumber("Unesite visinu u centimetrima: ");

            // Pretvaranje visine iz centimetara u metre
            double heightInMeters = heightInCentimeters / 100;

            // Izračun BMI-a koristeći težinu i pretvorenu visinu
            double bmi = weight / (heightInMeters * heightInMeters);
            Console.WriteLine($"Vaš BMI je: {bmi:N1}");

            // Kategorizacija i ispis BMI kategorije
            if (bmi < 18.5)
                Console.WriteLine("Kategorija: Premala težina");
            else if (bmi <= 25)
                Console.WriteLine("Kategorija: Normalna težina");
            else if (bmi <= 30)
                Console.WriteLine("Kategorija: Prekomjerna težina");
            else
                Console.WriteLine("Kategorija: Pretilost");

            // Izračun preporučenih granica težine na temelju visine
            double lowerWeight = 18.5 * heightInMeters * heightInMeters;
            double upperWeight = 25 * heightInMeters * heightInMeters;

            // Zaokruživanje granica težine za lakši prikaz
            lowerWeight = Math.Ceiling(lowerWeight * 10) / 10;
            upperWeight = Math.Floor(upperWeight * 10) / 10;

            Console.WriteLine($"Preporučena težina za vašu visinu je između {lowerWeight:N1} kg i {upperWeight:N1} kg.");
        }

        // Funkcija za dobivanje pozitivnog broja s konzole
        static double GetPositiveNumber(string prompt)
        {
            double number;
            Console.Write(prompt);
            // Ponavlja zahtjev dok se ne unese valjani pozitivni broj
            while (!double.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.Write("Unesite valjanu pozitivnu numeričku vrijednost: ");
            }
            return number;
        }
    }
}