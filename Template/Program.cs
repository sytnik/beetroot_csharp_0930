
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleApplication1
{
    class Program
    {
        static int Searchelement(string searche, List<string> mainlist)
        {
            int number=-1;

            for (int i = 0; i< mainlist.Count; i++)

            {
                if (searche == mainlist[i])

                {
                    number = i; break;
                }
            }

            return number;
        }
        


        static void Main()
        {
            List<string> FirstName = new List<string>() { "Tom", "Bob", "Sam" }, LastName = new List<string>() { "Tom", "Bob", "Sam" }, Number = new List<string>() { "+79", "+76", "+78" };

            int result = -5;
            int option = -5;


            while (option != -1)
            {
                Console.WriteLine("1.Search by last name \n" +
                              "2.Search by name \n" +
                              "3.Search by number \n" +
                              "4.Add new contact \n" +
                              "5.All contact \n" +
                              "-1.End");
                option = Convert.ToInt32(Console.ReadLine());
                string element;
                switch (option)
                {
                    case 1:
                        element = Console.ReadLine();
                        result = Searchelement(element, FirstName);
                        Console.WriteLine("Number: " + result + " Name:" + FirstName[result] + " LastName: " + LastName[result] + " Number:" + Number[result] + "\n");
                        break;
                    case 2:
                        element = Console.ReadLine();
                        result = Searchelement(element, LastName);
                        Console.WriteLine("Number: " + result + " Name:" + FirstName[result] + " LastName: " + LastName[result] + " Number:" + Number[result] + "\n");
                        break;
                    case 3:
                        element = Console.ReadLine();
                        result = Searchelement(element, Number);
                        Console.WriteLine("Number: "+result+" Name:" + FirstName[result] + " LastName: " + LastName[result] + " Number:" + Number[result] + "\n");
                        break;
                    case 4:
                        FirstName.Add(Console.ReadLine());
                        LastName.Add(Console.ReadLine());
                        Number.Add(Console.ReadLine());
                        break;
                    case 5:
                        for (int i=0;i<FirstName.Count;i++)
                        {
                            Console.WriteLine("Number:"+i+" Name:"+ FirstName[i] + " LastName: " + LastName[i]+ " Number:" + Number[i]+"\n");
                        }
                        break;
                    case -1:
                        result = -1;
                        break;
                }
            }

        }
    }
}