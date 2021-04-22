using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessStudent firstStud = new BusinessStudent("Alexey", 10000, 50);
            Student secondStud = new SportStudent("Valeriy", 5000, 15);
            firstStud.SmartCompare(firstStud, secondStud);
            firstStud.MoneyCompare(firstStud, secondStud);
            
            List<Student> students = new List<Student>() { new SportStudent("Ivan", "Rugby") };
            students[0].Money = 15000;
            students[0].EducationLevel = 25;
            students[0].Hp = 15;
            Console.WriteLine("Do you want to change your profession? Yes(1)/No(0)");
            if (Validation.DefaultValidation() == 1)
            {
                Console.WriteLine("What type of student you want to be? \n" +
                                 " 1.Businessman" +
                                 " 2.Sport" +
                                 " 3.IT");
                switch (Validation.DefaultValidation())
                {
                    case (byte)Character.Business:
                        {
                            if (!(students[0] is BusinessStudent))
                            {
                                Student newStudent = new BusinessStudent(students[0].Name);
                                newStudent = (Student)students[0].Clone();
                                students.Remove(students[0]);
                                students.Add(newStudent);
                            }
                            else Console.WriteLine("You can't be changed from Business to Business.");
                        }
                        break;
                    case (byte)Character.Sport:
                        {
                            if (!(students[0] is SportStudent))
                            {
                                Student newStudent = new BusinessStudent(students[0].Name);
                                newStudent = (Student)students[0].Clone();
                                students.Remove(students[0]);
                                students.Add(newStudent);
                            }
                            else Console.WriteLine("You can't be changed from Sport to Sport.");
                        }
                        break;
                    case (byte)Character.IT:
                        {
                            if (!(students[0] is ItStudent))
                            {
                                Student newStudent = new BusinessStudent(students[0].Name);
                                newStudent = (Student)students[0].Clone();
                                students.Remove(students[0]);
                                students.Add(newStudent);
                            }
                            else Console.WriteLine("You can't be changed from IT to IT.");
                        }
                        break;
                }
            }

            List<Student> studentsList = new List<Student>() { new BusinessStudent("Alexey", 10000, 50), new SportStudent("Valeriy", 5000, 15), new ItStudent("Grigoriy", 25000, 100) };
            studentsList.Sort();
            foreach (Student stud in studentsList)
                Console.WriteLine(stud.Name);
        }
    }
}
