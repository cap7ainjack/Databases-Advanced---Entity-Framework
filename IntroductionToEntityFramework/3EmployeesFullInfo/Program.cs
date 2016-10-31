using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _3EmployeesFullInfo
{
    using Models;
    using System.Globalization;

    class Program
    {
        static void Main()
        {
            using (var context = new SoftUniContext())
            {

                // // 3.Employees full information
                //var employees = context.Employees;

                //foreach (var empl in employees)
                //{
                //    Console.WriteLine($"{empl.FirstName} {empl.LastName} {empl.MiddleName} {empl.JobTitle} {empl.Salary}");
                //}

                // //4.	Employees with Salary Over 50 000

                //var employees = context.Employees.Where(empl => empl.Salary > 50000).Select(empl => empl.FirstName);

                //foreach (string emplName in employees)
                //{
                //    Console.WriteLine(emplName);
                //}


                // //5.	Employees from Seattle

                //var employees = context.Employees.Where(empl => empl.Department.Name == "Research and Development")
                //                                .OrderBy(empl => empl.Salary)
                //                                .ThenByDescending(empl => empl.FirstName);

                //foreach (var empl in employees)
                //{
                //    Console.WriteLine($"{empl.FirstName} {empl.LastName} from {empl.Department.Name} - ${empl.Salary:F2}");
                //}

                // //6.	Adding a New Address and Updating Employee

                //var adress = new Address()
                //{
                //    TownID = 4,
                //    AddressText = "Vitoshka 15"
                //};

                //Employee nakov = context.Employees.Where(empl => empl.LastName == "Nakov").FirstOrDefault();
                //nakov.Address = adress;

                //context.SaveChanges();

                //var employees = context.Employees.OrderByDescending(e => e.AddressID).Take(10);

                //foreach (var empl in employees)
                //{
                //    Console.WriteLine(empl.Address.AddressText);
                //}


                ////7.	Delete Project by Id
                //var projectToDelete = context.Projects.Find(2);
                //var employeesWithProject2 = projectToDelete.Employees.Where(empl => empl.Projects.Contains(projectToDelete));

                ////foreach (var empl in employeesWithProject2)
                ////{
                ////    empl.Projects.Remove(projectToDelete);
                ////}

                //projectToDelete.Employees.Clear();

                //context.Projects.Remove(projectToDelete);
                //context.SaveChanges();

                //var projects = context.Projects.Take(10);
                //foreach (var prj in projects)
                //{
                //    Console.WriteLine(prj.Name);
                //}

                ////8.	Find employees in period
                //var employees = context.Employees.
                //                Where(empl =>
                //                        empl.Projects.Count(prj => prj.StartDate.Year >= 2001
                //                                            && prj.StartDate.Year <= 2003) > 0).Take(30);

                //foreach (var empl in employees)
                //{
                //    Console.WriteLine($"{empl.FirstName} {empl.LastName} {empl.Manager.FirstName}");

                //    foreach (var project in empl.Projects)
                //    {
                //        Console.WriteLine($"--{project.Name} {project.StartDate} {project.EndDate}");
                //    }
                //}


                ////9.	Addresses by town name 
                //var adresses = context.Addresses.OrderByDescending(adr => adr.Employees.Count)
                //                                .ThenBy(adr => adr.Town.Name).Take(10);

                //foreach (var adress in adresses)
                //{
                //    int numOfEmpl = adress.Employees.Count();
                //    Console.WriteLine($"{adress.AddressText}, {adress.Town.Name} - {numOfEmpl} employees");
                //}

                ////10.	Employee with id 147 sorted by project names 
                //var employee147 = context.Employees.Find(147);

                //Console.WriteLine($"{employee147.FirstName} {employee147.LastName} {employee147.JobTitle}");

                //var projects = employee147.Projects.OrderBy(pr => pr.Name);

                //foreach (var prj in projects)
                //{
                //    Console.WriteLine($"{prj.Name}");
                //}

                ////11.	Departments with more than 5 employees
                //var departments = context.Departments.Where(dep => dep.Employees.Count > 5)
                //                                    .OrderBy(dep => dep.Employees.Count);

                //foreach (var dep in departments)
                //{
                //    //string manager = context.Employees.Where(em => em.EmployeeID == dep.ManagerID)
                //    //                                .Select(em => em.FirstName).First();

                //    var ala = context.Employees.First(x => x.EmployeeID == dep.ManagerID);

                //    Console.WriteLine($"{dep.Name} {ala.FirstName}");

                //    foreach (var empl in dep.Employees)
                //    {
                //        Console.WriteLine($"{empl.FirstName} {empl.LastName} {empl.JobTitle}");
                //    }
                //}


                //////15.	Find Latest 10 Projects
                //var projects = context.Projects.OrderByDescending(pr => pr.StartDate).Take(10);

                //foreach (var proj in projects.OrderBy(pr => pr.Name))
                //{
                //    Console.WriteLine($"{proj.Name} {proj.Description} {proj.StartDate} {proj.EndDate}");
                //}


                ////16.	Increase Salaries
                //var employees = context.Employees.Where(empl => empl.Department.Name == "Engineering"
                //                                                 || empl.Department.Name == "Tool Design"
                //                                                 || empl.Department.Name == "Marketing"
                //                                                 || empl.Department.Name == "Information Services");

                //foreach (var empoyee in employees)
                //{
                //    empoyee.Salary = (empoyee.Salary * 0.12m) + empoyee.Salary;
                //    Console.WriteLine($"{empoyee.FirstName} {empoyee.LastName} (${empoyee.Salary})");
                //}
                //context.SaveChanges();

                ////18.	Find Employees by First Name starting with ‘SA’

                //var employees = context.Employees.Where(empl => empl.FirstName.StartsWith("SA"));

                //foreach (var empl in employees)
                //{
                //    Console.WriteLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle} - (${empl.Salary})");
                //}

                ////19.	First Letter


            }
        }
    }
}
