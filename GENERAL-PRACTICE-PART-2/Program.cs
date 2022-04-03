using GENERAL_PRACTICE_PART_2.Exceptions;
using GENERAL_PRACTICE_PART_2.Models;
using System;

namespace GENERAL_PRACTICE_PART_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Elgun Qocayev");
            bool check = true;
            while (check)
            {
                Console.WriteLine("1. Share Status");
                Console.WriteLine("2. Get all statuses");
                Console.WriteLine("3. Get status by id");
                Console.WriteLine("4. Filter status by date");
                Console.WriteLine("0. Quit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Title name:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Contend name:");
                        string content = Console.ReadLine();

                        Status status1 = new Status(title, content);
                        status1.SharedDate = new DateTime(2022, 04, 03, 23, 49, 00);
                        try
                        {
                            user.ShareStatus(status1);
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (NotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "2":

                        foreach (var item in user.GetAllStatuses())
                        {
                            item.GetStatusInfo();
                        }
                        break;

                    case "3":

                        int bookId = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            user.GetStatusById(bookId).GetStatusInfo();
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case "4":
                        int id = Convert.ToInt32(Console.ReadLine());
                        DateTime date= Convert.ToDateTime(Console.ReadLine());

                        foreach (var item in user.FilterStatusByDate(id,date))
                        {
                            item.GetStatusInfo();
                        }
                        break;


                    case "0":
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input brother!");
                        break;
                }
            }

            //Status status = new Status("Edebiyyat", "Dede Gorgud")
            //{
            //    SharedDate = new DateTime(2022, 04, 03, 23, 49, 00)
            //};
            //status.GetStatusInfo();
        }
    }
}
