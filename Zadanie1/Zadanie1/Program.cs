using System;
using Zadanie1;


//zmienna obsługująca przejscia między menu wyższego stopnia (menu główne, menu produktów, menu magazynów i menu adresów)
//wartości ujemne oznaczają błędy
int exit = 1;

//zmienna obsługująca akcje wykonywaną na mniejszym menu (dodawanie, edycja, usuwanie);
int action = 0;


//listy zapisujące wszystkie dane w aplikacji
List<Product> products = new List<Product>();
List<Storage> storages = new List<Storage>();
List<Address> addresses = new List<Address>();


//pętla obsługująca całe menu
for(; ; )
{
    switch (exit)
    {
        //menu główne
        case 1:
            MainMenu();
            break;

        //menu główne z informają o błędzie 
        case -1:
            Console.WriteLine("Coś poszło nie tak, proszę nie wprowadzać niewłaściwych informacji\n");
            MainMenu();
            break;
            

        //menu produktów
        case 2:
            ProductMenu();
            break;

        //menu produktów z informacją o błędzie
        case -2:
            Console.WriteLine("Coś poszło nie tak, proszę nie wprowadzać niewłaściwych informacji\n");
            ProductMenu();
            break;


        //menu magazynów
        case 3:
            StorageMenu();
            break;

        //menu magazynów z informacją o błędzie
        case -3:
            Console.WriteLine("Coś poszło nie tak, proszę nie wprowadzać niewłaściwych informacji\n");
            StorageMenu();
            break;


        //menu adresów
        case 4:
            AddressMenu();
            break;

        //menu adresów z informacją o błędzie
        case -4:
            Console.WriteLine("Coś poszło nie tak, proszę nie wprowadzać niewłaściwych informacji\n");
            AddressMenu();
            break;


        //obsługa wyjścia z aplikacji;
        case 5:
            Environment.Exit(0);
            break;
    }
    Console.Clear();
}

//funkcja wyświetlająca menu główne
void MainMenu()
{
    Console.WriteLine("Witaj w edytorze magazynów!\n" +
        "Wybierz opcje:\n" +
        "1. Edycja produktów\n" +
        "2. Edycja magazynów\n" +
        "3. Edycja adresów\n" +
        "4. Wyjście\n");
    try
    {
        exit = Convert.ToInt32(Console.ReadLine()) + 1;
        if (exit < 1 || exit > 5)
        {
            throw new Exception();
        }
    }
    catch
    {
        exit = -1;
    }
}

//funkcja wyświetlająca menu i podmenu produktów
void ProductMenu()
{
    switch (action)
    {
        //obsługa podmenu produktów
        case 0:
            if (products.Count == 0)
            {
                Console.WriteLine("Nie ma jeszcze żadnych produktów\n");
            }
            else
            {
                Console.WriteLine("Lista wszystkich produktów: ");
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + products[i].ProductName);
                }
            }
            Console.WriteLine(
                "Wybierz co chcesz zrobić:\n" +
                "1. Dodaj produkt\n" +
                "2. Usuń produkt\n" +
                "3. Edytuj produkt\n" +
                "4. Wyświetl wszystkie informacje o produkcie\n" +
                "5. Powrót do menu głównego"
                );
            try
            {
                action = Convert.ToInt32(Console.ReadLine());
                if(action < 1 || action > 5)
                {
                    throw new Exception();
                }
                exit = 2;
            }
            catch
            {
                exit = -2;
            }
            break;


        //obsługa menu dodawania produktu
        case 1:
            try
            {
                Console.WriteLine("Podaj nazwę produktu:");
                string productName = Console.ReadLine();
                Console.WriteLine("Podaj nazwę producenta:");
                string producerName = Console.ReadLine();
                Console.WriteLine("Podaj nazwę kategorii:");
                string categoryName = Console.ReadLine();
                Console.WriteLine("Podaj identyfikator:");
                string id = Console.ReadLine();
                Console.WriteLine("Podaj cenę:");
                string price = Console.ReadLine();
                Console.WriteLine("Podaj opis:");
                string desc = Console.ReadLine();

                products.Add(new Product(productName, producerName, categoryName, desc, id, price));

                exit = 2;
            }
            catch
            {
                exit = -2;
            }
            action = 0;
            break;

        //obsługa usuwania produktów
        case 2:
            if (products.Count == 0)
            {
                Console.WriteLine("Nie ma jeszcze żadnych produktów.\n" +
                    "Wciśnij enter aby wrócić do menu.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wybierz produkt do usunięcia: ");
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + products[i].ProductName);
                }
            }

            try
            {
                products.RemoveAt(Convert.ToInt32(Console.ReadLine())-1);
                exit = 2;
            }
            catch
            {
                exit = -2;
            }

            action = 0;
            break;

        //obsługa edycji produktów
        case 3:
            if (products.Count == 0)
            {
                Console.WriteLine("Nie ma jeszcze żadnych produktów.\n" +
                    "Wciśnij enter aby wrócić do menu.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wybierz produkt do edycji: ");
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + products[i].ProductName);
                }
            }
            try
            {
                int temp = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                Console.WriteLine("Wybierz pole do edycji:\n" +
                    "1. Nazwa produktu\n" +
                    "2. Cena\n" +
                    "3. Opis\n");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Stara nazwa:\n" + products[temp].ProductName);
                        Console.WriteLine("Wpisz nową nazwę:");
                        products[temp].ProductName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Stara cena:\n" + products[temp].Price);
                        Console.WriteLine("Wpisz nową cenę:");
                        products[temp].Price = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Stary opis:\n" + products[temp].Desc);
                        Console.WriteLine("Wpisz nowy opis:");
                        products[temp].Desc = Console.ReadLine();
                        break;
                    default:
                        throw new Exception();
                }
                exit = 2;
            }
            catch
            {
                exit = -2;
            }
            action = 0;
            break;

        //obsługa wyświetlania informacji
        case 4:
            if (products.Count == 0)
            {
                Console.WriteLine("Nie ma jeszcze żadnych produktów.\n" +
                    "Wciśnij enter aby wrócić do menu.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wybierz produkt, którego informacje należy wyświetlić: ");
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + products[i].ProductName);
                }
            }

            try
            {
                int temp = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Nazwa produktu: " + products[temp].ProductName +
                    "\nNazwa producenta: " + products[temp].ProducerName +
                    "\nKategoria: " + products[temp].Category +
                    "\nIdentyfikator: " + products[temp].Id +
                    "\nCena: " + products[temp].Price +
                    "\nOpis: " + products[temp].Desc);
                Console.WriteLine("Wciśnij enter aby wrócić do menu.");
                Console.ReadLine();
                exit = 2;
            }
            catch
            {
                exit = -2;
            }
            action = 0;
            break;

        //powrót do menu głównego
        case 5:
            exit = 1;
            action = 0;
            break;

        //obsługa błędu poza zakresem
        default:
            exit = -2;
            action = 0;
            break;
    }
}

//funkcja wyświetlająca menu i podmenu magazynów
void StorageMenu()
{
    switch (action)
    {
        //obsługa podmenu magazynów
        case 0:
            if (products.Count == 0)
            {
                Console.WriteLine("Nie ma jeszcze żadnych magazynów\n");
            }
            else
            {
                Console.WriteLine("Lista wszystkich magazynów: ");
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + storages[i].Address.City + " " + storages[i].Address.Street + " " + storages[i].Address.BuildingNumber + " " + storages[i].Address.ApartamentNumber);
                }
            }
            Console.WriteLine(
                "Wybierz co chcesz zrobić:\n" +
                "1. Stwóż magazyn\n" +
                "2. Dodaj produkt\n" +
                "3. Usuń produkt\n" +
                "4. Edytuj ilość produktów\n" +
                "5. Wyświetl wszystkie produkty w magazynie\n" +
                "6. Powrót do menu głównego"
                );
            try
            {
                action = Convert.ToInt32(Console.ReadLine());
                if (action < 1 || action > 6)
                {
                    throw new Exception();
                }
                exit = 3;
            }
            catch
            {
                exit = -3;
            }
            break;

        //tworzenie magazynu
        case 1:

            if(addresses.Count == 0)
            {
                Console.WriteLine("Najpierw dodaj jakiś adres!");
                Console.WriteLine("Wciśnij enter aby wrócić");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wybierz adres na którym jest magazyn:");
                for(int i = 0; i < addresses.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + addresses[i].City + " " + addresses[i].Street + " " + addresses[i].BuildingNumber + " " + addresses[i].ApartamentNumber);
                }

                try
                {
                    storages.Add(new Storage(addresses[Convert.ToInt32(Console.ReadLine())]));
                    exit = 3;
                }
                catch
                {
                    exit = -3;
                }
            }

            action = 0;
            break;

        //dodawanie produktów
        case 2:
            if (storages.Count == 0)
            {
                Console.WriteLine("Najpierw utwóż magazyn!");
                Console.WriteLine("Wciśnij enter aby wrócić");
                Console.ReadLine();
            }
            else
            if (products.Count == 0)
            {
                Console.WriteLine("Najpierw dodaj jakieś produkty!");
                Console.WriteLine("Wciśnij enter aby wrócić");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wybierz magazyn, do którego chcesz dodać produkt:");
                for (int i = 0; i < storages.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + storages[i].Address.City + " " + storages[i].Address.Street + " " + storages[i].Address.BuildingNumber + " " + storages[i].Address.ApartamentNumber);
                }

                try
                {
                    int temp = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("Wybierz produkt, ktory chcesz dodać:");
                    for (int i = 0; i < products.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + products[i].ProductName);
                    }

                    try
                    {
                        storages[temp - 1].Products.Add(products[Convert.ToInt32(Console.ReadLine()) - 1]);
                        exit = 3;
                    }
                    catch
                    {
                        exit = -3;
                    }
                }
                catch
                {
                    exit = -3;
                }
                

                
            }
            action = 0;
            break;

        //usuwanie produktów
        case 3:
            if (storages.Count == 0)
            {
                Console.WriteLine("Najpierw utwóż magazyn!");
                Console.WriteLine("Wciśnij enter aby wrócić");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wybierz magazyn, do którego chcesz dodać produkt:");
                for (int i = 0; i < storages.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + storages[i].Address.City + " " + storages[i].Address.Street + " " + storages[i].Address.BuildingNumber + " " + storages[i].Address.ApartamentNumber);
                }

                try
                {
                    int temp = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("Wybierz produkt, ktory chcesz usunąć:");
                    for (int i = 0; i < storages[temp].Products.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + storages[temp].Products[i].ProductName);
                    }

                    try
                    {
                        storages[temp].Products.RemoveAt(Convert.ToInt32(Console.ReadLine())-1);
                        exit = 3;
                    }
                    catch
                    {
                        exit = -3;
                    }
                }
                catch
                {
                    exit = -3;
                }
            }
            action = 0;
            break;

        //edycja ilości produktów
        case 4:
            if (storages.Count == 0)
            {
                Console.WriteLine("Najpierw utwóż magazyn!");
                Console.WriteLine("Wciśnij enter aby wrócić");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wybierz magazyn, który edytujesz:");
                for (int i = 0; i < storages.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + storages[i].Address.City + " " + storages[i].Address.Street + " " + storages[i].Address.BuildingNumber + " " + storages[i].Address.ApartamentNumber);
                }

                try
                {
                    int temp = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("Wybierz produkt, ktory chcesz edytować:");
                    for (int i = 0; i < storages[temp].Products.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + storages[temp].Products[i].ProductName);
                    }

                    try
                    {
                        int temp2 = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            Console.WriteLine("Podaj nową ilosć:");
                            storages[temp].Products[temp2].amount = Convert.ToInt32(Console.ReadLine());
                            exit = 3;
                        }
                        catch
                        {
                            exit = -3;
                        }
                    }
                    catch
                    {
                        exit = -3;
                    }
                }
                catch
                {
                    exit = -3;
                }
            }
            action = 0;
            break;

        //wyświetlanie produktów z magazynu
        case 5:
            if (storages.Count == 0)
            {
                Console.WriteLine("Najpierw utwóż magazyn!");
                Console.WriteLine("Wciśnij enter aby wrócić");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wybierz magazyn, który chcesz sprawdzić:");
                for (int i = 0; i < storages.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + storages[i].Address.City + " " + storages[i].Address.Street + " " + storages[i].Address.BuildingNumber + " " + storages[i].Address.ApartamentNumber);
                }

                try
                {
                    int temp = Convert.ToInt32(Console.ReadLine());
                    for(int i = 0; i < storages[temp].Products.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + storages[temp].Products[i].ProductName);
                    }
                    Console.WriteLine("Wciśnij enter aby wrócić do menu.");
                    Console.ReadLine();
                    exit = 3;
                }
                catch
                {
                    exit = -3;
                }
            }
            action = 0;
            break;

        //powrót do menu głównego
        case 6:
            exit = 1;
            action = 0;
            break;

        //obsługa błędu poza zakresem
        default:
            exit = -3;
            action = 0;
            break;
    }
}

//funkcja wyświetlająca menu i podmenu adresów
void AddressMenu()
{
    switch (action)
    {
        //obsługa podmenu adresów
        case 0:
            if (addresses.Count == 0)
            {
                Console.WriteLine("Nie ma jeszcze żadnych adresów\n");
            }
            else
            {
                Console.WriteLine("Lista wszystkich adresów: ");
                for (int i = 0; i < addresses.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + addresses[i].City + " " + addresses[i].Street + " " + addresses[i].BuildingNumber + " " + addresses[i].ApartamentNumber);
                }
            }
            Console.WriteLine(
                "Wybierz co chcesz zrobić:\n" +
                "1. Dodaj adres\n" +
                "2. Usuń adres\n" +
                "3. Powrót do menu głównego"
                );
            try
            {
                action = Convert.ToInt32(Console.ReadLine());
                if (action < 1 || action > 5)
                {
                    throw new Exception();
                }
                exit = 4;
            }
            catch
            {
                exit = -4;
            }
            break;


        //obsługa menu dodawania adresu
        case 1:
            try
            {
                Console.WriteLine("Podaj Miasto:");
                string city = Console.ReadLine();
                Console.WriteLine("Podaj ulicę:");
                string street = Console.ReadLine();
                Console.WriteLine("Podaj numer budynku:");
                string building = Console.ReadLine();
                Console.WriteLine("Podaj numer apartamentu:");
                string apartment = Console.ReadLine();

                addresses.Add(new Address(street, city, building, apartment));

                exit = 4;
            }
            catch
            {
                exit = -4;
            }
            action = 0;
            break;

        //obsługa usuwania adresów
        case 2:
            if (addresses.Count == 0)
            {
                Console.WriteLine("Nie ma jeszcze żadnych adresów.\n" +
                    "Wciśnij enter aby wrócić do menu.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wybierz adres do usunięcia: ");
                for (int i = 0; i < addresses.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + addresses[i].City + " " + addresses[i].Street + " " + addresses[i].BuildingNumber + " " + addresses[i].ApartamentNumber);
                }
            }

            try
            {
                addresses.RemoveAt(Convert.ToInt32(Console.ReadLine()) - 1);
                exit = 4;
            }
            catch
            {
                exit = -4;
            }

            action = 0;
            break;

        
        
        //powrót do menu głównego
        case 3:
            exit = 1;
            action = 0;
            break;

        //obsługa błędu poza zakresem
        default:
            exit = -4;
            action = 0;
            break;
    }
}