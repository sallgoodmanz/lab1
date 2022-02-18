using System;
using System.Collections.Generic;
using BLL;
using BLL.Entities;
using BLL.Interfaces;

namespace PL
{
    public static class ConsoleMenu
    {
        #region entities
        
        static IProductData productData;
        static ISubscriber sub;
        static Request request;
        static IPostalOffice postalOffice;
        static IStorage storage = new ProductStorage();
        static List<ISubscriber> subscriberList = new List<ISubscriber>();
        static PrintingTheDailyOffice dailyPrinting = new PrintingTheDailyOffice(storage);
        static PrintinNewTimesOffice newTimesPrinting = new PrintinNewTimesOffice(storage);
        #endregion

        #region service methods
        private static Subscriber CreateSubAccount()
        {
            Console.Clear();
            Console.Write("Ім'я: "); string inputName = Console.ReadLine();
            if (!MyRegEx.Name.IsMatch(inputName)) throw new MyRegException("Ім'я");

            Console.Write("Прізвище: "); string inputSurname = Console.ReadLine();
            if (!MyRegEx.Surname.IsMatch(inputSurname)) throw new MyRegException("Прізвище");

            Console.Write("Домашня адреса: "); string inputHomeAddress = Console.ReadLine();

            return new Subscriber(inputName, inputSurname, inputHomeAddress);
        }
        private static ISubscriber GetSubscriberData()
        {
            Console.Clear(); Console.WriteLine("Введіть дані передплатника: ");
            Console.Write("Ім'я: "); string inputName = Console.ReadLine();
            if (!MyRegEx.Name.IsMatch(inputName)) throw new MyRegException("Ім'я");

            Console.Write("Прізвище: "); string inputSurname = Console.ReadLine();
            if (!MyRegEx.Surname.IsMatch(inputSurname)) throw new MyRegException("Прізвище");

            Console.Write("Домашня адреса: "); string inputHomeAddress = Console.ReadLine();

            var sub = GetSubscriber(inputName, inputSurname, inputHomeAddress);
            if (sub != null)
            {
                return sub;
            }
            return null;
        }
        private static void OutputSub(ISubscriber sub)
        {
            Console.WriteLine("\nІм'я: " + sub.Name);
            Console.WriteLine("Прізвище: " + sub.Surname);
            Console.WriteLine("Місце проживання: " + sub.HomeAddress);
            Console.Write("Наявні товари: ");
            if (sub.GetListOfProducts().Count != 0)
            {
                foreach (var product in sub.GetListOfProducts())
                {
                    Console.WriteLine($"\n{product.Name}, {product.EditionNumber}\n");
                }
            }
            else Console.WriteLine("Список пуст");
        }
        private static ISubscriber GetSubscriber(string name, string surname, string homeAddress)
        {
            foreach (var sub in subscriberList)
            {
                if (sub.Name == name && sub.Surname == surname && sub.HomeAddress == homeAddress)
                {
                    return sub;
                }
            }
            return null;
        }
        private static bool RemoveSub(ISubscriber sub) { return subscriberList.Remove(sub); }
        private static void PrintGoods(string editionNumber)
        {
            for (int i = 0; i < 5; i++)
            {
                dailyPrinting.printMagazine("Daily журнал", editionNumber);
            }
            for (int i = 0; i < 5; i++)
            {
                dailyPrinting.printNewspaper("Daily газета", editionNumber);
            }

            for (int i = 0; i < 5; i++)
            {
                newTimesPrinting.printMagazine("Daily журнал", editionNumber);
            }
            for (int i = 0; i < 5; i++)
            {
                newTimesPrinting.printNewspaper("Daily газета", editionNumber);
            }
        }
        #endregion

        public static void MainMenu()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\t\tMAIN MENU");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("1 - Меню передплатника");
                    Console.WriteLine("2 - Меню поштового відділеня");
                    Console.WriteLine("3 - Закінчити роботу");
                    Console.WriteLine("-----------------------------------------");

                    string str = Console.ReadLine();
                    int _str = int.Parse(str);

                    switch (_str)
                    {
                        case 1:
                            {
                                SubscriberMenu();
                                break;
                            }
                        case 2:
                            {
                                PostalOfficeMenu();
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                Environment.Exit(0);
                                break;
                            }


                        default:
                            Console.Clear();
                            Console.Write("Перевірте коректність вводу даних!\n\nНатисніть ENTER щоб повернутись до MAIN MENU");
                            Console.ReadKey();
                            break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($@"Exception: {e.Message}");
                Console.Write("\nНатисніть ENTER щоб повернутись до MAIN MENU");
                Console.ReadKey();
                MainMenu();
            }
        }

        #region service menus
        private static void SubscriberMenu()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\t\tSUBSCRIBER MENU");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("1 - Створити передплатника");
                    Console.WriteLine("2 - Видалити передплатника");
                    Console.WriteLine("3 - Подивитись список передплатників");
                    Console.WriteLine("4 - Повернутись до MAIN MENU");
                    Console.WriteLine("-----------------------------------------");

                    string str = Console.ReadLine();
                    int _str = int.Parse(str);

                    switch (_str)
                    {
                        case 1:
                            {
                                sub = CreateSubAccount();
                                subscriberList.Add(sub);
                                break;
                            }
                        case 2:
                            {
                                Console.Clear(); Console.WriteLine("Введіть дані передплатника якого хочете видалити: ");
                                Console.Write("Ім'я: "); string inputName = Console.ReadLine();
                                if (!MyRegEx.Name.IsMatch(inputName)) throw new MyRegException("Ім'я");

                                Console.Write("Прізвище: "); string inputSurname = Console.ReadLine();
                                if (!MyRegEx.Surname.IsMatch(inputSurname)) throw new MyRegException("Прізвище");

                                Console.Write("Домашня адреса: "); string inputHomeAddress = Console.ReadLine();

                                if (RemoveSub(GetSubscriber(inputName, inputSurname, inputHomeAddress)))
                                    Console.WriteLine("Видалення пройшло успішно!");
                                else Console.WriteLine("Передплатника не знайдено!");
                                Console.ReadKey();
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                foreach (var sub in subscriberList)
                                {
                                    OutputSub(sub);
                                }
                                Console.ReadKey();
                                break;
                            }
                        case 4:
                            {
                                MainMenu();
                                break;
                            }


                        default:
                            Console.Clear();
                            Console.Write("Перевірте коректність вводу даних!\n\nНатисніть ENTER щоб повернутись до MAIN MENU");
                            Console.ReadKey();
                            break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($@"Exception: {e.Message}");
                Console.Write("\nНатисніть ENTER щоб повернутись до SUBSCRIBER MENU");
                Console.ReadKey();
                SubscriberMenu();
            }
        }
        private static void PostalOfficeMenu()
        {
            try
            {
                postalOffice = new PostalOffice();
                postalOffice.AddStorage(storage);
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\t\tPOSTAL OFFICE MENU");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("1 - Додати запит");
                    Console.WriteLine("2 - Видалити запит");
                    Console.WriteLine("3 - Подивитись список запитів");
                    Console.WriteLine("4 - Пошук товару на складу");
                    Console.WriteLine("5 - Повернутись до MAIN MENU");
                    Console.WriteLine("-----------------------------------------");

                    string str = Console.ReadLine();
                    int _str = int.Parse(str);

                    switch (_str)
                    {
                        case 1:
                            {
                                PrintGoods("1");
                                var sub = GetSubscriberData();
                                if (sub != null)
                                {
                                    productData = new ProductData("Daily газета", "1");
                                    postalOffice.Subscribe(sub, productData);
                                }
                                else Console.WriteLine("Не знайдено бажаного передпланика!");
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                var sub = GetSubscriberData();
                                if (sub != null)
                                {
                                    productData = new ProductData("Daily газета", "1");
                                    request = new Request(sub, productData);

                                    postalOffice.Unsubscribe(request);
                                }
                                else Console.WriteLine("Не знайдено бажаного передпланика!");
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                foreach (var req in postalOffice.GetListOfRequests())
                                {
                                    Console.WriteLine($"Передплатник: {req.subscriber.Name} {req.subscriber.Surname}, {req.subscriber.HomeAddress}" +
                                                      $"\nЗапит: {req.productData.Name}, {req.productData.EditionNumber}\n\n");
                                }
                                Console.ReadKey();
                                break;
                            }
                        case 4:
                            {
                                postalOffice.Update();
                                foreach (var sub in subscriberList)
                                {
                                    sub.GotTheProduct += Sub_GotTheProduct;
                                }
                                break;
                            }
                        case 5:
                            {
                                MainMenu();
                                break;
                            }


                        default:
                            Console.Clear();
                            Console.Write("Перевірте коректність вводу даних!\n\nНатисніть ENTER щоб повернутись до POSTAL OFFICE MENU");
                            Console.ReadKey();
                            break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($@"Exception: {e.Message}");
                Console.Write("\nНатисніть ENTER щоб повернутись до POSTAL OFFICE MENU");
                Console.ReadKey();
                PostalOfficeMenu();
            }
        }

        private static void Sub_GotTheProduct(object sender, IProduct e)
        {
            var sub = sender as Subscriber;
            OutputSub(sub);
        }
        #endregion
    }
}

