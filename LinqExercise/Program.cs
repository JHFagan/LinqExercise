using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //DONE//Print the Sum and Average of numbers
            var sum = numbers.Sum(i => i);
            Console.WriteLine(sum);

            var avg = numbers.Average(i => i);
            Console.WriteLine(avg);

            //DONE//Order numbers in ascending order and decsending order. Print each to console.
            var ascending = numbers.OrderBy(num => num);
            //var ascending = from i in numbers
            //                orderby i ascending
            //                select i;
            foreach (int i in ascending)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            var descending = numbers.OrderByDescending(num => num);
            //var descending = from i in numbers
            //                orderby i descending
            //                select i;
            foreach (int i in descending)
            {
                Console.Write(i + " ");
            }

            //DONE//Print to the console only the numbers greater than 6
            Console.WriteLine();
            var greater = numbers.Where(num => num > 6);
            //var greater = from i in numbers
            //              where i > 6
            //              select i;
            foreach (int i in greater)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            //DONE//Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            //var only4 = from i in numbers
            //            where i > 5
            //            orderby i ascending
            //            select i;
            foreach (int i in ascending.Take(4))
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            //DONE//Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.SetValue(26, 4);
            var myAge = descending.OrderByDescending(num => num);
            //var myAge = from i in numbers
            //            orderby i descending
            //            select i;
            foreach (int i in myAge)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();


            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //DONE//Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.

            //var csList = employees.Where(name => name.FirstName.ToLower().Min() == 'c' || name.FirstName.ToLower().Min() == 's');
            var csList = employees.Where(name => name.FirstName.ToLower()[0] == 'c' || name.FirstName.ToLower()[0] == 's')
                .OrderBy(name => name.FirstName);
            foreach (var employee in csList)
            {
                Console.WriteLine(employee.FirstName);
            }
            Console.WriteLine();

            //DONE//Order this in acesnding order by FirstName.
            //var ascendingemp = employees.OrderBy(name => name.FirstName);
            foreach (var employee in csList)
            {
                Console.WriteLine(employee.FirstName + " " + employee.LastName);
            }
            Console.WriteLine();

            //DONE//Print all the employees' FullName and Age who are over the age 26 to the console.
            var over26 = employees.Where(age => age.Age > 26).OrderBy(age => age.Age).ThenBy(age => age.FirstName);
            foreach (var employee in over26)
            {
                Console.WriteLine(employee.FullName + ": " + employee.Age);
            }
            Console.WriteLine();

            //DONE//Order this by Age first and then by FirstName in the same result.
            //var employeesSort = employees.OrderBy(age => age.Age).ThenBy(age => age.FirstName);
            foreach (var employee in over26)
            {
                Console.WriteLine(employee.FullName + ": " + employee.Age);
            }
            Console.WriteLine();

            //DONE//Print the Sum and then the Average of the employees' YearsOfExperience
            var sumAndYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine(sumAndYOE.Sum(x => x.YearsOfExperience));
            Console.WriteLine(sumAndYOE.Average(x => x.YearsOfExperience));

            //DONE//if their YOE is less than or equal to 10 AND Age is greater than 35
            
            foreach(var employee in sumAndYOE)
            {
                Console.WriteLine(employee.FullName + " Age: " + employee.Age + " Years of Experience: " + employee.YearsOfExperience);
            }
            Console.WriteLine();

            //DONE//Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Jack", "Fagan", 26, 100000000)).ToList();
            foreach(var employee in employees)
            {
                Console.WriteLine(employee.FullName + " Age: " + employee.Age + " Years of Experience: " + employee.YearsOfExperience);
            }
            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
