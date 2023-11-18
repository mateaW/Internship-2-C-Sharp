using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Trgovina
{
    internal class Program
    {
        static List<Dictionary<string, object>> racuni = new List<Dictionary<string, object>>()
        {
            new Dictionary<string, object>
            {
                { "ID", 1 },
                { "DatumIzdavanja", new DateTime(2023,11,09) },
                { "Proizvodi", new List<Dictionary<string, object>> {
                    new Dictionary<string, object> { { "Ime", "Jogurt" }, { "Količina", 2 }, { "Cijena", 1.80m } },
                    new Dictionary<string, object> { { "Ime", "Kruh" }, { "Količina", 1 }, { "Cijena", 3m } }
                }},
                { "UkupnaCijena", 4.80m }
            },
            new Dictionary<string, object>
            {
                { "ID", 2 },
                { "DatumIzdavanja", new DateTime(2023,11,19) },
                { "Proizvodi", new List<Dictionary<string, object>> {
                    new Dictionary<string, object> { { "Ime", "Čokolada" }, { "Količina", 1 }, { "Cijena", 4.2m } },
                }},
                { "UkupnaCijena", 4.20m }
            },
            new Dictionary<string, object>
            {
                { "ID", 3 },
                { "DatumIzdavanja", new DateTime(2023,11,20) },
                { "Proizvodi", new List<Dictionary<string, object>> {
                    new Dictionary<string, object> { { "Ime", "Jogurt" }, { "Količina", 2 }, { "Cijena", 1.80m } },
                    new Dictionary<string, object> { { "Ime", "Pahuljice" }, { "Količina", 3 }, { "Cijena", 12m } }
                }},
                { "UkupnaCijena",  13.80m }
            }

        };
        static List<Dictionary<string, object>> radnici = new List<Dictionary<string, object>>()
        {
            new Dictionary<string, object>
            {
                { "ImePrezime", "Rina Miočić" },
                { "DatumRodenja", new DateTime(1988,09,11) }
            },
            new Dictionary<string, object>
            {
                { "ImePrezime", "Franko Vrsaljko" },
                { "DatumRodenja", new DateTime(1950,02,22) }
            },
            new Dictionary<string, object>
            {
                { "ImePrezime", "Marta Batinić" },
                { "DatumRodenja", new DateTime(1990,11,08) }
            },
            new Dictionary<string, object>
            {
                { "ImePrezime", "Marin Cecić" },
                { "DatumRodenja", new DateTime(2000,03,03)}
            },
            new Dictionary<string, object>
            {
                { "ImePrezime", "Stipe Bilonić" },
                { "DatumRodenja", new DateTime(1969,10,04) }
            },
            new Dictionary<string, object>
            {
                { "ImePrezime", "Lena Matulić" },
                { "DatumRodenja", new DateTime(1952,11,29) }
            }
        };

        static List<Dictionary<string, object>> artikli = new List<Dictionary<string, object>>()
        {
            new Dictionary<string, object>
            {
                { "Ime", "Kruh" },
                { "Količina", 27 },
                { "Cijena", 1.5m },
                { "DatumIsteka", new DateTime(2023,11,20) }
            },
            new Dictionary<string, object>
            {
                { "Ime", "Čokolada" },
                { "Količina", 40 },
                { "Cijena", 4.2m },
                { "DatumIsteka", new DateTime(2024,02,02) }
            },
            new Dictionary<string, object>
            {
                { "Ime", "Jogurt" },
                { "Količina", 15 },
                { "Cijena", 0.90m },
                { "DatumIsteka", new DateTime(2023, 12, 23) }
            },
            new Dictionary<string, object>
            {
                { "Ime", "Sir" },
                { "Količina", 33 },
                { "Cijena", 5.2m },
                { "DatumIsteka", new DateTime(2023,12,07) }
            },
            new Dictionary<string, object>
            {
                { "Ime", "Pahuljice" },
                { "Količina", 20 },
                { "Cijena", 4m },
                { "DatumIsteka", new DateTime(2025,06,20) }
            },
            new Dictionary<string, object>
            {
                { "Ime", "Keksi" },
                { "Količina", 52 },
                { "Cijena", 2.3m },
                { "DatumIsteka", new DateTime(2024, 05, 15) }
            }
        };

        static void Main(string[] args)
        {
            Izbornik();
        }

        static void Izbornik()
        {
            while (true)
            {
                Console.WriteLine("Izbornik:");
                Console.WriteLine("1 - Artikli");
                Console.WriteLine("2 - Radnici");
                Console.WriteLine("3 - Računi");
                Console.WriteLine("4 - Statistika");
                Console.WriteLine("0 - Izlaz iz aplikacije");

                int odabir;
                if (int.TryParse(Console.ReadLine(), out odabir))
                {
                    switch (odabir)
                    {
                        case 1:
                            Artikli();
                            break;
                        case 2:
                            Radnici();
                            break;
                        case 3:
                            Racuni();
                            break;
                        case 4:
                            Statistika();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos. Unesite brojeve 0 - 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite brojeve 0 - 4.");
                }
            }
        }

        static void Artikli()
        {
            while (true)
            {
                Console.WriteLine("Artikli:");
                Console.WriteLine("1 - Unos artikla");
                Console.WriteLine("2 - Brisanje artikla");
                Console.WriteLine("3 - Uređivanje artikala");
                Console.WriteLine("4 - Ispis");
                Console.WriteLine("0 - Povratak na glavni izbornik");

                int odabir;
                if (int.TryParse(Console.ReadLine(), out odabir))
                {
                    switch (odabir)
                    {
                        case 1:
                            UnosArtikla();
                            break;
                        case 2:
                            BrisanjeArtikla();
                            break;
                        case 3:
                            UredivanjeArtikla();
                            break;
                        case 4:
                            IspisArtikala();
                            break;
                        case 0:
                            Izbornik();
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos. Unesite brojeve 0 - 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite brojeve 0 - 4.");
                }
            }
        }

        static void UnosArtikla()
        {
            Console.WriteLine("Unos Artikla:");

            Console.Write("Unesite ime: ");
            string naziv = Console.ReadLine();

            bool postoji = artikli.Any(a => String.Equals((string)a["Ime"], naziv, StringComparison.OrdinalIgnoreCase));

            int kolicina;
            decimal cijena;
            DateTime datumIsteka;

            if (postoji)
            {
                Console.WriteLine("Artikl s tim imenom već postoji.");
            }
            else
            {
                while(true)
                {
                    Console.Write("Unesite količinu: ");
                    
                    if (!int.TryParse(Console.ReadLine(), out kolicina))
                    {
                        Console.WriteLine("Pogrešan unos za količinu. Unesite cijeli broj.");
                        continue;
                    }
                    break;
                }
                
                while (true)
                {
                    Console.Write("Unesite cijenu: ");
                    
                    if (!decimal.TryParse(Console.ReadLine(), out cijena))
                    {
                        Console.WriteLine("Pogrešan unos za cijenu. Unesite ponovo.");
                        continue;
                    }
                    break;
                }
                
                while(true)
                {
                    Console.Write("Unesite datum isteka (YYYY-MM-DD): ");
                    
                    if (!DateTime.TryParse(Console.ReadLine(), out datumIsteka))
                    {
                        Console.WriteLine("Pogrešan unos. Unesite datum u ispravnom formatu (YYYY-MM-DD).");
                        continue;
                    }
                    break;
                }
                
                Dictionary<string, object> noviArtikl = new Dictionary<string, object>
                {
                    { "Ime", naziv },
                    { "Količina", kolicina },
                    { "Cijena", cijena },
                    { "DatumIsteka", datumIsteka }
                };

                while (true)
                {
                    Console.WriteLine($"Potvrđujete li unos artikla '{naziv}' (da/ne)?");
                    string odabir = Console.ReadLine().ToLower();
                    if (odabir == "ne")
                        break;
                    else if (odabir == "da")
                    {
                        artikli.Add(noviArtikl);
                        Console.WriteLine($"Artikl '{naziv}' je dodan.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pogrešan unos.");
                        continue;
                    }                      
                }
            }     
        }

        static void BrisanjeArtikla()
        {
            while (true)
            {
                Console.WriteLine("Brisanje artikla:");
                Console.WriteLine("1 - Brisanje po imenu artikla");
                Console.WriteLine("2 - Brisanje artikala kojima je istekao rok");
                Console.WriteLine("0 - Povratak na glavni izbornik");

                int odabir;
                if (int.TryParse(Console.ReadLine(), out odabir))
                {
                    switch (odabir)
                    {
                        case 1:
                            BrisanjePoImenuArtikla();
                            break;
                        case 2:
                            BrisanjeArtiklaPoRoku();
                            break;
                        case 0:
                            Izbornik();
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                }
            }
        }
        static void BrisanjePoImenuArtikla()
        {
            Console.Write("Unesite ime artikla kojeg želite izbrisati: ");
            string ime = Console.ReadLine();

            Dictionary<string, object> artikl = artikli.FirstOrDefault(a => a["Ime"].ToString() == ime);
            
            if (artikl != null)
            {
                while (true)
                {
                    Console.WriteLine($"Potvrđujete li brisanje artikla '{ime}' (da/ne)?");
                    string odabir = Console.ReadLine().ToLower();
                    if (odabir == "ne")
                        break;
                    else if (odabir == "da")
                    {
                        artikli.Remove(artikl);
                        Console.WriteLine($"Artikl '{ime}' uspješno izbrisan.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pogrešan unos.");
                        continue;
                    }                 
                }
            }
            else
            {
                Console.WriteLine($"Artikl '{ime}' nije pronađen.");
            }
        }
        static void BrisanjeArtiklaPoRoku()
        {
            while (true)
            {
                Console.Write("Unesite datum po kojem želite izbrisati artikle (YYYY-MM-DD): ");

                if (DateTime.TryParse(Console.ReadLine(), out DateTime datum))
                {

                    List<Dictionary<string, object>> istekliArtikli = artikli
                        .Where(a => (DateTime)a["DatumIsteka"] < datum)
                        .ToList();

                    if (istekliArtikli.Count > 0)
                    {
                        Console.WriteLine($"Potvrđujete li brisanje artikala (da/ne)?");
                        string odabir = Console.ReadLine().ToLower();
                        if (odabir == "ne")
                            break;
                        else if (odabir == "da")
                        {
                            foreach (var artikl in istekliArtikli)
                            {
                                artikli.Remove(artikl);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pogrešan unos.");
                            continue;
                        }
                        Console.WriteLine($"Isteklo je {istekliArtikli.Count} artikala. Uspješno izbrisani.");
                    }
                    else
                    {
                        Console.WriteLine("Nema artikala s isteklim rokom.");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite datum u formatu YYYY-MM-DD.");
                    continue;
                }
            }
        }
        static void UredivanjeArtikla()
        {
            while (true)
            {
                Console.WriteLine("Uređivanje artikla:");
                Console.WriteLine("1 - Uređivanje proizvoda po imenu");
                Console.WriteLine("2 - Popust/poskupljenje na sve proizvode unutar trgovine");
                Console.WriteLine("0 - Povratak na glavni izbornik");

                int odabir;
                if (int.TryParse(Console.ReadLine(), out odabir))
                {
                    switch (odabir)
                    {
                        case 1:
                            UredivanjePoNazivu();
                            break;
                        case 2:
                            PopustPoskupljenje();
                            break;
                        case 0:
                            Izbornik();
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                }
            }
        }
        static void UredivanjePoNazivu()
        {
            Console.Write("Unesite ime artikla koji želite urediti: ");
            string ime = Console.ReadLine();

            Dictionary<string, object> artikl = artikli.FirstOrDefault(a => a["Ime"].ToString() == ime);

            if (artikl != null)
            {
                Console.WriteLine($"Pronađen artikl: {artikl["Ime"]} (Trenutna količina: {artikl["Količina"]}, Trenutna cijena: {artikl["Cijena"]}, Trenutni datum isteka: {artikl["DatumIsteka"]})");
                
                int kolicina;
                decimal cijena;
                DateTime datumIsteka;

                while (true)
                {
                    Console.Write("Unesite novu količinu: ");
                    
                    if (!int.TryParse(Console.ReadLine(), out kolicina))
                    {
                        Console.WriteLine("Pogrešan unos za količinu. Unesite cijeli broj.");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                
                while (true)
                {
                    Console.Write("Unesite novu cijenu: ");

                    if (!decimal.TryParse(Console.ReadLine(), out cijena))
                    {
                        Console.WriteLine("Pogrešan unos za cijenu. Unesite ponovo.");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Unesite novi datum isteka roka (YYYY-MM-DD): ");

                    if (!DateTime.TryParse(Console.ReadLine(), out datumIsteka))
                    {
                        Console.WriteLine("Pogrešan unos za datum isteka. Unesite datum u ispravnom formatu (YYYY-MM-DD).");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                                
                while (true)
                {
                    Console.WriteLine("Potvrđujete li dodavanje novog artikla (da/ne)?");
                    string odabir = Console.ReadLine().ToLower();
                    if (odabir == "ne")
                        break;
                    else if (odabir == "da")
                    {
                        Console.WriteLine($"Artikl '{ime}' uspješno uređen.");
                        artikl["Količina"] = kolicina;
                        artikl["Cijena"] = cijena;
                        artikl["DatumIsteka"] = datumIsteka;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pogrešan unos.");
                        continue;
                    }
                }        
            }
            else
            {
                Console.WriteLine($"Artikl '{ime}' nije pronađen.");
            }
        }
        static void PopustPoskupljenje()
        {

            while (true)
            {
                Console.WriteLine("Popust/poskupljenje na sve proizvode unutar trgovine:");
                Console.WriteLine("1 - Popust");
                Console.WriteLine("2 - Poskupljenje");
                Console.WriteLine("0 - Povratak na glavni izbornik");

                int odabir;
                if (int.TryParse(Console.ReadLine(), out odabir))
                {
                    switch (odabir)
                    {
                        case 1:
                            PrimjenaPopusta();
                            break;
                        case 2:
                            PrimjenaPoskupljenja();
                            break;
                        case 0:
                            Izbornik();
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                }
            }
        }  
        static void PrimjenaPopusta()
        {
            decimal postotak;

            while (true)
            {
                Console.Write("Unesite postotak popusta (npr. 10 za 10% popusta): ");
                var unos = Console.ReadLine();
                if (decimal.TryParse(unos, out postotak))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Molimo unesite ponovno broj.");
                }
            }
            while (true)
            {
                Console.WriteLine($"Potvrđujete li primjenu popusta od {postotak}% na sve proizvode (da/ne)?");
                string odabir = Console.ReadLine().ToLower();
                if (odabir == "ne")
                    break;
                else if (odabir == "da")
                {
                    foreach (var artikl in artikli)
                    {
                        decimal trenutnaCijena = (decimal)artikl["Cijena"];
                        decimal iznosPromjene = (trenutnaCijena * postotak) / 100;

                        artikl["Cijena"] = trenutnaCijena - iznosPromjene;
                    }
                    Console.WriteLine($"Svi artikli uspješno ažurirani. {postotak}% popusta primijenjeno.");
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos.");
                    continue;
                }
            }
        }
        static void PrimjenaPoskupljenja()
        {
            decimal postotak;

            while (true)
            {
                Console.Write("Unesite postotak poskupljenja (npr. 10 za 10% poskupljenja): ");
                var unos = Console.ReadLine();
                if (decimal.TryParse(unos, out postotak))
                {                   
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Molimo unesite ponovno broj.");
                }
            }
            while (true)
            {
                Console.WriteLine($"Potvrđujete li primjenu poskupljenja od {postotak}% na sve proizvode (da/ne)?");
                string odabir = Console.ReadLine().ToLower();
                if (odabir == "ne")
                    break;
                else if (odabir == "da")
                {
                    
                    foreach (var artikl in artikli)
                    {
                        decimal trenutnaCijena = (decimal)artikl["Cijena"];
                        decimal iznosPromjene =  (trenutnaCijena * postotak) / 100;

                        artikl["Cijena"] = trenutnaCijena + iznosPromjene;
                    }
                    Console.WriteLine($"Svi artikli uspješno ažurirani. {postotak}% poskupljenja primijenjeno.");
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos.");
                    continue;
                }
            }
        }
        static void IspisArtikala()
        {
            while (true)
            {
                Console.WriteLine("Ispis artikala:");
                Console.WriteLine("1 - Svih artikala kako su spremljeni");
                Console.WriteLine("2 - Svih artikala sortirano po imenu");
                Console.WriteLine("3 - Svih artikala po datumu silazno");
                Console.WriteLine("4 - Svih artikala po datumu uzlazno");
                Console.WriteLine("5 - Svih artikala sortirano po količini");
                Console.WriteLine("6 - Najprodavaniji artikl");
                Console.WriteLine("7 - Najmanje prodavan artikl");
                Console.WriteLine("0 - Povratak na glavni izbornik");

                int odabir;
                if (int.TryParse(Console.ReadLine(), out odabir))
                {
                    switch (odabir)
                    {
                        case 1:
                            IspisSve();
                            break;
                        case 2:
                            IspisIme();
                            break;
                        case 3:
                            IspisDatumSilazno();
                            break;
                        case 4:
                            IspisDatumUzlazno();
                            break;
                        case 5:
                            IspisKolicina();
                            break;
                        case 6:
                            IspisNajporodavaniji();
                            break;
                        case 7:
                            IspisNajmanjeProdavan();
                            break;
                        case 0:
                            Izbornik();
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos. Unesite brojeve 0 - 7.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite brojeve 0 - 7.");
                }
            }
        }
        static void ArtiklPrikaz(Dictionary<string, object> artikl)
        {
            Console.WriteLine($"Ime: {artikl["Ime"]}, Količina: {artikl["Količina"]}, Cijena: {artikl["Cijena"]}, Datum isteka: {artikl["DatumIsteka"]}");
        }
        static void IspisSve()
        {
            Console.WriteLine("Ispis svih artikala kako su spremljeni:");
            foreach (var artikl in artikli)
            {
                ArtiklPrikaz(artikl);
            }
        }
        static void IspisIme()
        {
            Console.WriteLine("Ispis svih artikala sortirano po imenu:");
            var sortiraniArtikli = artikli.OrderBy(a => a["Ime"]).ToList();
            foreach (var artikl in sortiraniArtikli)
            {
                ArtiklPrikaz(artikl);
            }
        }
        static void IspisDatumSilazno()
        {
            Console.WriteLine("Ispis svih artikala sortirano po datumu silazno:");
            var sortiraniArtikli = artikli.OrderByDescending(a => (DateTime)a["DatumIsteka"]).ToList();
            foreach (var artikl in sortiraniArtikli)
            {
                ArtiklPrikaz(artikl);
            }
        }
        static void IspisDatumUzlazno()
        {
            Console.WriteLine("Ispis svih artikala sortirano po datumu uzlazno:");
            var sortiraniArtikli = artikli.OrderBy(a => (DateTime)a["DatumIsteka"]).ToList();
            foreach (var artikl in sortiraniArtikli)
            {
                ArtiklPrikaz(artikl);
            }
        }
        static void IspisKolicina()
        {
            Console.WriteLine("Ispis svih artikala sortirano po količini:");
            var sortiraniArtikli = artikli.OrderBy(a => (int)a["Količina"]).ToList();
            foreach (var artikl in sortiraniArtikli)
            {
                ArtiklPrikaz(artikl);
            }
        }
        static void IspisNajporodavaniji()
        {
            Dictionary<string, int> prodajaPoArtiklu = new Dictionary<string, int>();

            foreach (var racun in racuni)
            {
                var proizvodiNaRacunu = (List<Dictionary<string, object>>)racun["Proizvodi"];

                foreach (var proizvodNaRacunu in proizvodiNaRacunu)
                {
                    string imeProizvoda = proizvodNaRacunu["Ime"] as string;
                    int kolicina = (int)proizvodNaRacunu["Količina"];

                    if (prodajaPoArtiklu.ContainsKey(imeProizvoda))
                    {
                        prodajaPoArtiklu[imeProizvoda] += kolicina;
                    }
                    else
                    {
                        prodajaPoArtiklu[imeProizvoda] = kolicina;
                    }
                }
            }

            var najprodavanijiArtikl = prodajaPoArtiklu.OrderByDescending(kv => kv.Value).FirstOrDefault();

            if (najprodavanijiArtikl.Key != null)
            {
                Console.WriteLine($"Najprodavaniji artikl je: {najprodavanijiArtikl.Key} (prodano je {najprodavanijiArtikl.Value} komada)");
            }
            else
            {
                Console.WriteLine("Nema prodavanih artikala.");
            }
        }
        static void IspisNajmanjeProdavan()
        {
            Dictionary<string, int> prodajaPoArtiklu = new Dictionary<string, int>();

            foreach (var racun in racuni)
            {
                var proizvodiNaRacunu = (List<Dictionary<string, object>>)racun["Proizvodi"];

                foreach (var proizvodNaRacunu in proizvodiNaRacunu)
                {
                    string imeProizvoda = proizvodNaRacunu["Ime"] as string;
                    int kolicina = (int)proizvodNaRacunu["Količina"];

                    if (prodajaPoArtiklu.ContainsKey(imeProizvoda))
                    {
                        prodajaPoArtiklu[imeProizvoda] += kolicina;
                    }
                    else
                    {
                        prodajaPoArtiklu[imeProizvoda] = kolicina;
                    }
                }
            }

            var najmanjeProdavanArtikl = prodajaPoArtiklu.OrderBy(kv => kv.Value).FirstOrDefault();

            if (najmanjeProdavanArtikl.Key != null)
            {
                Console.WriteLine($"Najmanje prodavan artikl je: {najmanjeProdavanArtikl.Key} (prodano je {najmanjeProdavanArtikl.Value} komada)");
            }
            else
            {
                Console.WriteLine("Nema prodavanih artikala.");
            }
        }

        static void Radnici()
        {
            while (true)
            {
                Console.WriteLine("Radnici:");
                Console.WriteLine("1 - Unos radnika");
                Console.WriteLine("2 - Brisanje radnika");
                Console.WriteLine("3 - Uređivanje radnika");
                Console.WriteLine("4 - Ispis");
                Console.WriteLine("0 - Povratak na glavni izbornik");

                int odabir;
                if (int.TryParse(Console.ReadLine(), out odabir))
                {
                    switch (odabir)
                    {
                        case 1:
                            UnosRadnika();
                            break;
                        case 2:
                            BrisanjeRadnika();
                            break;
                        case 3:
                            UredivanjeRadnika();
                            break;
                        case 4:
                            IspisRadnikaIzbor();
                            break;
                        case 0:
                            Izbornik();
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1, 2, 3 ili 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1, 2, 3 ili 4.");
                }
            }
        }
        static void UnosRadnika()
        {
            Console.WriteLine("Unos radnika:");

            Console.Write("Unesite ime i prezime radnika: ");
            string imePrezime = Console.ReadLine();

            DateTime datumRodenja;
            while (true)
            {
                Console.Write("Unesite datum rođenja (YYYY-MM-DD): ");

                if (!DateTime.TryParse(Console.ReadLine(), out datumRodenja))
                {
                    Console.WriteLine("Pogrešan unos za datum rođenja. Unesite datum u ispravnom formatu (YYYY-MM-DD).");
                    continue;
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine($"Potvrđujete li unos novog radnika (da/ne)?");
                string odabir = Console.ReadLine().ToLower();
                if (odabir == "ne")
                    break;
                else if (odabir == "da")
                {
                    Dictionary<string, object> radnik = new Dictionary<string, object>
                    {
                        { "ImePrezime", imePrezime },
                        { "DatumRodenja", datumRodenja }
                    };

                    radnici.Add(radnik);

                    Console.WriteLine("Radnik uspješno dodan.");
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos.");
                    continue;
                }
            }                                  
        }
        static void BrisanjeRadnika()
        {
            while (true)
            {
                Console.WriteLine("Brisanje radnika:");
                Console.WriteLine("1 - Brisanje radnika po imenu");
                Console.WriteLine("2 - Brisanje radnika koji imaju više od 65 godina");
                Console.WriteLine("0 - Povratak na glavni izbornik");

                int odabir;
                if (int.TryParse(Console.ReadLine(), out odabir))
                {
                    switch (odabir)
                    {
                        case 1:
                            BrisanjeRadnikaIme();
                            break;
                        case 2:
                            BrisanjeRadnika65();
                            break;
                        case 0:
                            Izbornik();
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                }
            }
        }
        static void BrisanjeRadnikaIme()
        {
            Console.WriteLine("Brisanje radnika:");
            Console.Write("Unesite ime i prezime radnika kojega želite izbrisati: ");
            string imePrezime = Console.ReadLine();

            Dictionary<string, object> radnikBrisanje = radnici.FirstOrDefault(r => String.Equals((string)r["ImePrezime"], imePrezime, StringComparison.OrdinalIgnoreCase));

            if (radnikBrisanje != null)
            {
                while (true)
                {
                    Console.WriteLine($"Potvrđujete li brisanje radnika '{imePrezime}' (da/ne)?");
                    string odabir = Console.ReadLine().ToLower();
                    if (odabir == "ne")
                        break;
                    else if (odabir == "da")
                    {
                        radnici.Remove(radnikBrisanje);
                        Console.WriteLine($"Radnik '{imePrezime}' uspješno obrisan.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pogrešan unos.");
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("Radnik s unesenim imenom i prezimenom nije pronađen.");
            }
        }
        static void BrisanjeRadnika65()
        {
            Console.WriteLine("Brisanje radnika starijih od 65 godina:");
            var radniciStarijiOd65 = radnici.Where(r => (DateTime.Now - (DateTime)r["DatumRodenja"]).TotalDays / 365.25 >= 65).ToList();

            if (radniciStarijiOd65.Any())
            {
                Console.WriteLine("Radnici stariji od 65 godina:");

                foreach (var radnik in radniciStarijiOd65)
                {
                    IspisiRadnika(radnik);
                }

                while (true)
                {
                    Console.WriteLine($"Potvrđujete li brisanje radnika starijih od 65 (da/ne)?");
                    string odabir = Console.ReadLine().ToLower();
                    if (odabir == "ne")
                        break;
                    else if (odabir == "da")
                    {
                        foreach (var radnik in radniciStarijiOd65)
                        {
                            radnici.Remove(radnik);
                        }
                        Console.WriteLine("Radnici stariji od 65 godina uspješno obrisani.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pogrešan unos.");
                        continue;
                    }
                }
            }                                    
            else
            {
                Console.WriteLine("Nema radnika starijih od 65 godina.");
            }
        }
        static void IspisiRadnika(Dictionary<string, object> radnik)
        {
            Console.WriteLine($"Ime i prezime: {radnik["ImePrezime"]}, Datum rođenja: {((DateTime)radnik["DatumRodenja"]).ToString("yyyy-MM-dd")}");
        }
        
        static void UredivanjeRadnika()
        {
            Console.WriteLine("Uređivanje radnika:");

            Console.Write("Unesite ime i prezime radnika koje želite urediti: ");
            string imePrezime = Console.ReadLine();

            Dictionary<string, object> radnikUrediti = radnici.FirstOrDefault(r => String.Equals((string)r["ImePrezime"], imePrezime, StringComparison.OrdinalIgnoreCase));

            if (radnikUrediti != null)
            {
                Console.WriteLine("Unesite nove podatke:");

                Console.Write("Novo ime i prezime: ");
                string novoImePrezime = Console.ReadLine();

                DateTime noviDatumRodenja;
                while (true)
                {
                    Console.Write("Novi datum rođenja (YYYY-MM-DD): ");

                    if (!DateTime.TryParse(Console.ReadLine(), out noviDatumRodenja))
                    {
                        Console.WriteLine("Pogrešan unos. Unesite datum u ispravnom formatu (YYYY-MM-DD).");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                while (true)
                {
                    Console.WriteLine($"Potvrđujete li promjenu podataka o radniku '{imePrezime}' (da/ne)?");
                    string odabir = Console.ReadLine().ToLower();
                    if (odabir == "ne")
                        break;
                    else if (odabir == "da")
                    {
                        radnikUrediti["ImePrezime"] = novoImePrezime;
                        radnikUrediti["DatumRodjenja"] = noviDatumRodenja;

                        Console.WriteLine("Radnik uspješno ažuriran.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pogrešan unos.");
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("Radnik s unesenim imenom i prezimenom nije pronađen.");
            }
        }
        static void IspisRadnikaIzbor()
        {
            while (true)
            {
                Console.WriteLine("Ispis radnika:");
                Console.WriteLine("1 - Ispis svih radnika (ime - godine)");
                Console.WriteLine("2 - Ispis svih radnika kojima je rođendan u tekućem mjesecu");
                Console.WriteLine("0 - Povratak na glavni izbornik");

                int odabir;
                if (int.TryParse(Console.ReadLine(), out odabir))
                {
                    switch (odabir)
                    {
                        case 1:
                            IspisImeGodine();
                            break;
                        case 2:
                            IspisRadnikaRodendan();
                            break;
                        case 0:
                            Izbornik();
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                }
            }
        }
        static void IspisImeGodine()
        {
            Console.WriteLine("Svi radnici: ");

            foreach (var radnik in radnici)
            {
                string imePrezime = (string)radnik["ImePrezime"];
                DateTime datumRodenja = (DateTime)radnik["DatumRodenja"];

                int godine = DateTime.Now.Year - datumRodenja.Year;

                Console.WriteLine($"{imePrezime} - {godine}");
            }
            
        }
        static void IspisRadnikaRodendan()
        {
            Console.WriteLine("Radnici s rođendanom u tekućem mjesecu:");

            int trenutniMjesec = DateTime.Now.Month;

            var radniciRod = radnici.Where(r => r["DatumRodenja"] is DateTime datumRodenja && datumRodenja.Month == trenutniMjesec).ToList();

            if (radniciRod.Any())
            {
                foreach (var radnik in radniciRod)
                {
                    IspisiRadnika(radnik);
                }
            }
            else
            {
                Console.WriteLine("Nema radnika s rođendanom u tekućem mjesecu.");
            }
        }
        static void Racuni()
        {
            while (true)
            {
                Console.WriteLine("Računi:");
                Console.WriteLine("1 - Unos novog računa");
                Console.WriteLine("2 - Ispis");
                Console.WriteLine("0 - Povratak na glavni izbornik");

                int odabir;
                if (int.TryParse(Console.ReadLine(), out odabir))
                {
                    switch (odabir)
                    {
                        case 1:
                            UnosNovogRacuna();
                            break;
                        case 2:
                            IspisRacuna();
                            break;
                        case 0:
                            Izbornik();
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                }
            }
        }
        static void UnosNovogRacuna()
        {
            Console.WriteLine("Unos novog računa:");

            foreach (var artikl in artikli)
            {
                ArtiklPrikaz(artikl);
            }

            List<Dictionary<string, object>> odabraniProizvodi = new List<Dictionary<string, object>>();

            while (true)
            {
                Console.Write("Unesite ime proizvoda (0 za kraj unosa): ");
                string imeProizvoda = Console.ReadLine();

                if (imeProizvoda == "0")
                    break;

                var pronadjeniProizvod = artikli.FirstOrDefault(a => String.Equals((string)a["Ime"], imeProizvoda, StringComparison.OrdinalIgnoreCase));

                if (pronadjeniProizvod != null)
                {
                    if (!odabraniProizvodi.Any(p => String.Equals((string)p["Ime"], imeProizvoda, StringComparison.OrdinalIgnoreCase)))
                    {
                        int kolicina;

                        do
                        {
                            Console.Write("Unesite količinu: ");
                            string unosKolicine = Console.ReadLine();

                            if (int.TryParse(unosKolicine, out kolicina))
                            {
                                break; 
                            }
                            else
                            {
                                Console.WriteLine("Neispravan unos. Unesite cijeli broj.");
                            }
                        } while (true);

                        int dostupnaKolicina = (int)pronadjeniProizvod["Količina"];
                        if (kolicina > dostupnaKolicina)
                        {
                            Console.WriteLine($"Nema dovoljno dostupnih proizvoda. Dostupno: {dostupnaKolicina}");
                            continue;
                        }

                        Dictionary<string, object> odabraniProizvod = new Dictionary<string, object>
                        {
                            { "Ime", pronadjeniProizvod["Ime"] },
                            { "Količina", kolicina },
                            { "Cijena", pronadjeniProizvod["Cijena"] }
                        };
                        odabraniProizvodi.Add(odabraniProizvod);
                    }
                    else
                    {
                        Console.WriteLine("Proizvod već dodan na račun. Unesite drugi proizvod.");
                    }
                }
                else
                {
                    Console.WriteLine("Proizvod nije pronađen. Unesite ispravno ime proizvoda.");
                }
            }

            if (odabraniProizvodi.Count > 0)
            {
                int noviIdRacuna = NoviIdRacuna();

                decimal ukupnaCijena = 0;
                foreach (var proizvod in odabraniProizvodi)
                {
                    ukupnaCijena += (decimal)proizvod["Cijena"] * (int)proizvod["Količina"];
                }

                DateTime datumIzdavanja = DateTime.Now;

                

                Console.WriteLine("Račun:");
                Console.WriteLine($"ID računa: {noviIdRacuna}");
                Console.WriteLine($"Datum izdavanja: {datumIzdavanja}");
                Console.WriteLine("Proizvodi na računu:");

                foreach (var proizvod in odabraniProizvodi)
                {
                    string imeProizvoda = (string)proizvod["Ime"];
                    int kolicina = (int)proizvod["Količina"];
                    decimal cijena = (decimal)proizvod["Cijena"];

                    Console.WriteLine($"{imeProizvoda} - {kolicina} kom - {cijena} e");
                }

                Console.WriteLine($"Ukupna cijena: {ukupnaCijena} e");

                Console.Write("Unesite DA za printanje, bilo što drugo za prekid: ");
                string kljuc = Console.ReadLine();

                if (kljuc.ToUpper() == "DA")
                {
                    foreach (var proizvod in odabraniProizvodi)
                    {
                        string imeProizvoda = (string)proizvod["Ime"];
                        int kolicina = (int)proizvod["Količina"];

                        var odabraniArtikl = artikli.FirstOrDefault(a => String.Equals((string)a["Ime"], imeProizvoda, StringComparison.OrdinalIgnoreCase));
                        if (odabraniArtikl != null)
                        {
                            odabraniArtikl["Količina"] = (int)odabraniArtikl["Količina"] - kolicina;

                            if ((int)odabraniArtikl["Količina"] == 0)
                            {
                                artikli.Remove(odabraniArtikl);
                            }
                        }
                    }
                    Dictionary<string, object> noviRacun = new Dictionary<string, object>
                    {
                        { "ID", noviIdRacuna },
                        { "DatumIzdavanja", datumIzdavanja },
                        { "Proizvodi", odabraniProizvodi},
                        { "UkupnaCijena", ukupnaCijena }
                    };

                    racuni.Add(noviRacun);
                    Console.WriteLine("Račun je uspješno isprintan.");
                }
                else
                {
                    Console.WriteLine("Račun je prekinut.");
                }
            }
            else
            {
                Console.WriteLine("Račun je otkazan jer nema odabranih proizvoda.");
            }
        }

        static int NoviIdRacuna()
        {
            int zadnjiIdRacuna = racuni.Any() ? racuni.Max(r => (int)r["ID"]) : 0;
            return zadnjiIdRacuna + 1;
        }

        static void IspisRacuna()
        {
            while (true)
            {
                Console.WriteLine("Ispis računa::");
                Console.WriteLine("1 - Ipis svih računa (id - datum i vrijeme - ukupni iznos)");
                Console.WriteLine("2 - Ispis računa po id-u");
                Console.WriteLine("0 - Povratak na glavni izbornik");

                int odabir;
                if (int.TryParse(Console.ReadLine(), out odabir))
                {
                    switch (odabir)
                    {
                        case 1:
                            IspisSvihRacuna();
                            break;
                        case 2:
                            IspisRacunaId();
                            break;
                        case 0:
                            Izbornik();
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite brojeve 0, 1 ili 2.");
                }
            }
        }
        static void IspisSvihRacuna()
        {
            Console.WriteLine("Ispis svih računa:");
            foreach (var racun in racuni)
            {
                int idRacuna = (int)racun["ID"];
                DateTime datumIzdavanja = (DateTime)racun["DatumIzdavanja"];
                decimal ukupnaCijena = (decimal)racun["UkupnaCijena"];

                Console.WriteLine($"{idRacuna} - {datumIzdavanja} - Ukupni iznos: {ukupnaCijena} e");
            }
        }
        static void IspisRacunaId()
        {
            Console.Write("Unesite ID računa za ispis: ");
            int uneseniID;
            while ((true))
            {
                if (int.TryParse(Console.ReadLine(), out uneseniID))
                {
                    var trazeniRacun = racuni.FirstOrDefault(r => (int)r["ID"] == uneseniID);

                    if (trazeniRacun != null)
                    {
                        Console.WriteLine($"Detalji računa ID-{uneseniID}:");
                        Console.WriteLine($"Datum izdavanja: {trazeniRacun["DatumIzdavanja"]}");
                        Console.WriteLine("Proizvodi na računu:");

                        foreach (var proizvod in (List<Dictionary<string, object>>)trazeniRacun["Proizvodi"])
                        {
                            string imeProizvoda = (string)proizvod["Ime"];
                            int kolicina = (int)proizvod["Količina"];

                            Console.WriteLine($"{imeProizvoda} - {kolicina} kom");
                        }

                        decimal ukupnaCijena = (decimal)trazeniRacun["UkupnaCijena"];
                        Console.WriteLine($"Ukupna cijena: {ukupnaCijena:C}");
                    }
                    else
                    {
                        Console.WriteLine($"Račun s ID-{uneseniID} nije pronađen.");
                    }
                    break;
                }
                
                else
                {
                    Console.WriteLine("Neispravan unos ID-a računa. Unesite cijeli broj.");
                    continue;
                }
            }
            
        }
        static void Statistika()
        {
            while(true)
            {
                Console.WriteLine("Unesite šifru za ulazak (KRUH123): ");
                var sifra = Console.ReadLine();
                if (sifra == "KRUH123")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            while (true)
            {
                Console.WriteLine("Statistika:");
                Console.WriteLine("1 - Ukupan broj artikala u trgovini");
                Console.WriteLine("2 - Vrijednost artikala koji nisu još prodani");
                Console.WriteLine("3 - Vrijednost svih artikala koji su prodani");
                Console.WriteLine("4 - Stanje po mjesecima");
                Console.WriteLine("0 - Povratak na glavni izbornik");

                int odabir;
                if (int.TryParse(Console.ReadLine(), out odabir))
                {
                    switch (odabir)
                    {
                        case 1:
                            BrojArtikalaUkupno();
                            break;
                        case 2:
                            VrijednostArtikala();
                            break;
                        case 3:
                            VrijednostProdanihArtikala();
                            break;
                        case 4:
                            Stanje();
                            break;                            
                        case 0:
                            Izbornik();
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos. Unesite brojeve 0 - 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Unesite brojeve 0 - 4.");
                }
            }
        }
        static void BrojArtikalaUkupno()
        {
            Console.WriteLine($"Ukupan broj različitih artikala u trgovini: {artikli.Count}");

            int ukupno = artikli.Sum(artikl => (int)artikl["Količina"]);
            Console.WriteLine($"Ukupan zbroj količina svih artikala: {ukupno}");
        }
        static void VrijednostArtikala()
        {
            decimal ukupno = artikli.Sum(artikl => (decimal)artikl["Cijena"] * (int)artikl["Količina"]);
            Console.WriteLine($"Ukupna vrijednost svih artikala koji još nisu prodani: {ukupno} e");
        }
        static void VrijednostProdanihArtikala()
        {
            decimal ukupnaVrijednost = 0;

            foreach (var racun in racuni)
            {
                foreach (var proizvod in (List<Dictionary<string, object>>)racun["Proizvodi"])
                {
                    int kolicina = (int)proizvod["Količina"];
                    decimal cijena = (decimal)proizvod["Cijena"];

                    ukupnaVrijednost += kolicina * cijena;
                }
            }
            Console.WriteLine($"Vrijednost svih prodanih artikala je: {ukupnaVrijednost}");
        }
        static void Stanje()
        {
            DateTime trazeniDatum;
            do
            {
                Console.Write("Unesite mjesec i godinu (MM/YYYY): ");
                var unosDatuma = Console.ReadLine();

                if (DateTime.TryParseExact(unosDatuma, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out trazeniDatum))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Neispravan unos. Molimo unesite datum u formatu MM/YYYY.");
                }
            } while (true);

            decimal ukupnaZarada = 0;

            foreach (var racun in racuni)
            {
                if ((racun["DatumIzdavanja"] is DateTime datum) &&
                    (trazeniDatum.Year == datum.Year && trazeniDatum.Month == datum.Month))
                {
                        ukupnaZarada += (decimal)racun["UkupnaCijena"];
                }
            }

            decimal iznosPlaca;
            decimal iznosNajma;
            decimal ostaliTroskovi;

            do
            {
                Console.Write("Unesite iznos plaća radnika: ");
                string unosPlaca = Console.ReadLine();

                if (decimal.TryParse(unosPlaca, out iznosPlaca))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Neispravan unos. Molimo unesite decimalni broj.");
                }
            } while (true);

            do
            {
                Console.Write("Unesite iznos najma: ");
                string unosNajma = Console.ReadLine();

                if (decimal.TryParse(unosNajma, out iznosNajma))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Neispravan unos. Molimo unesite decimalni broj.");
                }
            } while (true);

            do
            {
                Console.Write("Unesite ostale troškove: ");
                string unosTroskova = Console.ReadLine();

                if (decimal.TryParse(unosTroskova, out ostaliTroskovi))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Neispravan unos. Molimo unesite decimalni broj.");
                }
            } while (true);

            decimal ukupniTroskovi = (ukupnaZarada / 3) - iznosPlaca - ostaliTroskovi;

            if (ukupniTroskovi<0)
            {
                Console.WriteLine($"Gubitak za {trazeniDatum.ToString("MMMM yyyy")} je: {ukupniTroskovi} e");
            }
            else if (ukupniTroskovi>0)
            {
                Console.WriteLine($"Zarada za {trazeniDatum.ToString("MMMM yyyy")} je: {ukupniTroskovi} e");
            }
            else
            {
                Console.WriteLine("Ukupni troškovi su 0.");
            }               
        }
    }
}