using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_W1_D4_BACK_ESERCIZIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(User.logged);
            User.ApriMenu();
            Console.ReadLine();
        }

        public static class User
        {
            public static bool logged { get; set; } = false;
            public static string Username { get; set; }
            public static string Password { get; set; }
            public static List<DateTime> ListaAccessi { get; set; } = new List<DateTime>();
            public static DateTime DataLogin { get; set; }

            

            public static void ApriMenu()
            {
                Console.WriteLine("Seleziona la scelta");
                Console.WriteLine("1. LOGIN");
                Console.WriteLine("2. LOGOUT");
                Console.WriteLine("3. VERIFICA ORA E DATA DI LOGIN");
                Console.WriteLine("4. LISTA ACCESSI");
                Console.WriteLine("5. ESCI");


                int scelta = int.Parse(Console.ReadLine());

                if (scelta == 1)
                {
                    Login();
                }
                else if (scelta == 2)
                {
                    Logout();
                }
                else if (scelta == 3)
                {
                    DataAccesso();
                }
                else if (scelta == 4)
                {
                    ListaLogin();
                }
                else if (scelta == 5)
                {
                    Console.WriteLine("Chiusura programma");
                    
                }
                else
                {
                    Console.WriteLine("Hai selezionato una voce non valida.");
                    ApriMenu();
                }

            }

            public static void Login() 
            {
                if (logged == false)
                {
                    Console.WriteLine("Inserisci il nome utente:");
                    Username = Console.ReadLine();
                    Console.WriteLine("Inserisci la password:");
                    Password = Console.ReadLine();
                    Console.WriteLine("Conferma la password inserita:");
                    string confermaPassword = Console.ReadLine();
                    if (confermaPassword == Password)
                    {
                        logged = true;
                        DataLogin = DateTime.Now;
                        ListaAccessi.Add(DataLogin);
                    }
                    else
                    {
                        Console.WriteLine("Password errata!");
                        Login();
                    }
                } else
                {
                    Console.Write("Devi prima effettuare il logout con l'utente connesso\r\n");
                }
                ApriMenu();
            }

            public static void Logout() 
            {
                if (logged == true)
                {
                    Console.WriteLine("Sei sicuro di voler uscire? y/N");
                    string confermaLogout = Console.ReadLine();
                    if (confermaLogout == "y")
                    {
                        Console.WriteLine("Logout effettuato");
                        logged = false;
                    }
                    else if (confermaLogout == "N")
                    {
                        Console.WriteLine("Sei ancora connesso!");
                    }
                    else
                    {
                        Console.WriteLine("Scelta non valida");
                        Logout();
                    }
                } else
                {
                Console.WriteLine("Non ti sei ancora connesso!");
                }

                ApriMenu();
            }

            public static void DataAccesso() 
            {
                if (logged == true)
                {
                    Console.WriteLine(DataLogin);
                } else
                {
                    Console.WriteLine("Non ti sei ancora connesso!");
                }
                ApriMenu();
            }

            public static void ListaLogin() 
            {
                    
               

                if(ListaAccessi.Count == 0)
                {
                    Console.WriteLine("Non ci sono accessi registrati!");
                } else
                {
                    foreach (DateTime item in ListaAccessi)
                    {
                        Console.WriteLine(item);
                    }
                }
               
                ApriMenu();
                
            }

            

        }
    }
}
