using System;
using System.Collections.Generic;
using NUnit.Framework;

public static class Globals
{
    public static string[] names = { "Александр", "Екатерина", "Максим", "Анна", "Иван", "Ольга", "Дмитрий", "Наталья", "Сергей", "Юлия", "Артем", "Татьяна", "Александра", "Владимир", "Мария", "Андрей", "Елена", "Игорь", "Анастасия", "Павел", "Светлана", "Кирилл", "Оксана", "Виктор", "Людмила", "Николай", "Лариса", "Роман", "Ирина", "Глеб" };
    public static string[] surnames = { "Иваненко", "Петренко", "Григоренко", "Мельник", "Коваленко", "Шевченко", "Герасименко", "Кравченко", "Захаренко", "Марченко", "Павленко", "Гончаренко", "Тимченко", "Игнатенко", "Кучеренко", "Лебедь", "Бондаренко", "Лысенко", "Черновол", "Костенко", "Мазепа", "Даниленко", "Федоренко" };
    public static string[] streets = { "вул. Володимирська", "вул. Лесі Українки", "вул. Тарасівська", "вул. Шевченківська", "просп. Героїв Небесної Сотні", "вул. Київська", "вул. Івана Франка", "пров. Льва Толстого", "вул. Сагайдачного", "вул. Пушкінська", "вул. Прорізна", "вул. Золотоворітська", "наб. Подільська", "вул. Ярославів Вал", "вул. Олеся Гончара", "вул. Липська", "вул. Велика Житомирська", "вул. Грушевського", "вул. Михайлівська", "вул. Верхній Вал", "узвіз Андріївський", "наб. Дніпровська", "вул. Лук'янівська", "бул. Тараса Шевченка", "вул. Червоноармійська", "вул. Маршала Гречка", "вул. Костянтинівська", "пл. Бессарабська", "вул. Саксаганського", "вул. Антоновича" };
}

public class Student
{
    public string name;
    public string surname;
    public int age;
    public string address;
    public string phone_number;
    public int grade;

    public Student(string name, string surname, int age, string address, string phone_number, int grade)
    {
        this.name = name;
        this.surname = surname;
        if (age < 0)
        {
            throw new Exception("Age must be non-negative integer.");
        }
        this.age = age;
        this.address = address;
        this.phone_number = phone_number;
        if (grade < 0)
        {
            throw new Exception("Grade must be non-negative integer.");
        }
        else if (grade > 100)
        {
            throw new Exception("Grade must not be greater than 100.");
        }
        this.grade = grade;
    }

    public static bool operator ==(Student a, Student b)
    {
        return a.grade == b.grade;
    }
    public static bool operator !=(Student a, Student b)
    {
        return a.grade != b.grade;
    }
}

public class Group
{
    public List<Student> students;
    private string groupName;
    private string specialization;
    private int courseNumber;

    public Group()
    {
        this.students = new List<Student>();
        Random rand = new Random(DateTime.Now.Second);
        for (int i = 0; i < rand.Next(5, 30); i++)
        {
            this.students.Add(new Student(Globals.names[rand.Next(Globals.names.Length)], Globals.surnames[rand.Next(Globals.surnames.Length)], rand.Next(18, 23), $"{Globals.streets[rand.Next(Globals.streets.Length)]}, {rand.Next(1, 99)}", $"+380{rand.Next(111111111, 999999999)}", rand.Next(0, 100)));
        }
        this.students.Sort((x, y) => string.Compare(x.surname, y.surname));
        this.groupName = "Group";
        this.specialization = "Specialization";
        this.courseNumber = 1;
    }

    public Group(List<Student> students)
    {
        this.students = new List<Student>(students);
        this.students.Sort((x, y) => string.Compare(x.surname, y.surname));
        this.groupName = "Group";
        this.specialization = "Specialization";
        this.courseNumber = 1;
    }

    public Group(Group group)
    {
        this.students = new List<Student>(group.students);
        this.students.Sort((x, y) => string.Compare(x.surname, y.surname));
        this.groupName = group.groupName;
        this.specialization = group.specialization;
        this.courseNumber = group.courseNumber;
    }

    public Group(List<Student> students, string groupName, string specialization, int courseNumber)
    {
        this.students = new List<Student>(students);
        this.students.Sort((x, y) => string.Compare(x.surname, y.surname));
        if (groupName == "")
        {
            throw new Exception("Group name must not be empty string.");
        }
        this.groupName = groupName;
        if (specialization == "")
        {
            throw new Exception("Specialization must not be empty string.");
        }
        this.specialization = specialization;
        if (courseNumber < 0)
        {
            throw new Exception("Course number must be non-negative integer.");
        }
        this.courseNumber = courseNumber;
    }

    public static bool operator ==(Group a, Group b)
    {
        return a.students.Count == b.students.Count;
    }
    public static bool operator !=(Group a, Group b)
    {
        return a.students.Count != b.students.Count;
    }

    public void DisplayStudents()
    {
        Console.WriteLine("+{0}+", new string('-', 159));
        Console.WriteLine("| {0,-157} |", this.groupName);
        Console.WriteLine("+{0}+", new string('-', 159));
        Console.WriteLine("| {0,-157} |", this.specialization);
        Console.WriteLine("+{0}+{1}+{2}+{3}+{4}+{5}+{6}+", new string('-', 4), new string('-', 32), new string('-', 32), new string('-', 9), new string('-', 50), new string('-', 16), new string('-', 10));
        Console.WriteLine("| {0,-2} | {1,-30} | {2,-30} | {3,-7} | {4,-48} | {5,-14} | {6,-8} |", "№", "Фамилия", "Имя", "Возраст", "Адрес", "Номер телефона", "Оценка");
        Console.WriteLine("+{0}+{1}+{2}+{3}+{4}+{5}+{6}+", new string('-', 4), new string('-', 32), new string('-', 32), new string('-', 9), new string('-', 50), new string('-', 16), new string('-', 10));
        for (int i = 0; i < this.students.Count; i++)
        {
            Console.WriteLine("| {0,-2} | {1,-30} | {2,-30} | {3,-7} | {4,-48} | {5,-14} | {6,-8} |", i + 1, this.students[i].surname, this.students[i].name, this.students[i].age, this.students[i].address, this.students[i].phone_number, this.students[i].grade);
        }
        Console.WriteLine("+{0}+{1}+{2}+{3}+{4}+{5}+{6}+", new string('-', 4), new string('-', 32), new string('-', 32), new string('-', 9), new string('-', 50), new string('-', 16), new string('-', 10));
    }

    public void AddStudent(Student student)
    {
        this.students.Add(student);
    }

    public void EditStudentData()
    {
        int age, grade, ind;
        string name, surname, address, phone_number;
        this.DisplayStudents();
        Console.WriteLine("Stud number: ");
        ind = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Stud name: ");
        name = Console.ReadLine();
        Console.WriteLine("Stud surname: ");
        surname = Console.ReadLine();
        Console.WriteLine("Stud age: ");
        age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Stud address: ");
        address = Console.ReadLine();
        Console.WriteLine("Stud phone_number: ");
        phone_number = Console.ReadLine();
        Console.WriteLine("Stud grade: ");
        grade = Convert.ToInt32(Console.ReadLine());
        this.students[ind - 1].name = name;
        this.students[ind - 1].surname = surname;
        this.students[ind - 1].age = age;
        this.students[ind - 1].address = address;
        this.students[ind - 1].phone_number = phone_number;
        this.students[ind - 1].grade = grade;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    public void EditGroupData()
    {
        int c, age, grade, ind;
        string name, surname, address, phone_number;
        do
        {
            Console.WriteLine("Choice:\n1. Name\n2. Specialization\n3. Add stud\n4. Edit stud\n5. Remove stud\n0. Exit\n");
            c = Convert.ToInt32(Console.ReadLine());
            if (c == 1)
            {
                Console.WriteLine("New name: ");
                this.groupName = Console.ReadLine();
            }
            else if (c == 2)
            {
                Console.WriteLine("New specialization: ");
                this.specialization = Console.ReadLine();
            }
            else if (c == 3)
            {
                Console.WriteLine("Stud name: ");
                name = Console.ReadLine();
                Console.WriteLine("Stud surname: ");
                surname = Console.ReadLine();
                Console.WriteLine("Stud age: ");
                age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Stud address: ");
                address = Console.ReadLine();
                Console.WriteLine("Stud phone_number: ");
                phone_number = Console.ReadLine();
                Console.WriteLine("Stud grade: ");
                grade = Convert.ToInt32(Console.ReadLine());
                this.AddStudent(new Student(name, surname, age, address, phone_number, grade));
            }
            else if (c == 4)
            {
                this.EditStudentData();
            }
            else if (c == 5)
            {
                this.DisplayStudents();
                Console.WriteLine("Stud number: ");
                ind = Convert.ToInt32(Console.ReadLine());
                this.students.RemoveAt(ind - 1);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.students.Sort((x, y) => string.Compare(x.surname, y.surname));
        } while (c != 0);
    }

    public void TransferStudent(Group toGroup, Student student)
    {
        toGroup.students.Add(student);
        this.students.Remove(student);
    }

    public void RemoveUnsuccessfulStudents()
    {
        for (int i = 0; i < this.students.Count; i++)
        {
            if (this.students[i].grade < 60)
            {
                this.students.RemoveAt(i);
                i--;
            }
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    public void RemoveLeastSuccessfulStudent()
    {
        int min = 0;
        for (int i = 0; i < this.students.Count; i++)
        {
            if (this.students[i].grade < this.students[min].grade)
            {
                min = i;
            }
        }
        this.students.RemoveAt(min);
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}

public class Program
{
    public static void Main()
    {
        Random rand = new Random(DateTime.Now.Second);
        Group group1 = new Group();
        group1.DisplayStudents();
        Group group2 = new Group(new List<Student>(), "Group 2", "Specialization 2", 2);
        group2.AddStudent(new Student(Globals.names[rand.Next(Globals.names.Length)], Globals.surnames[rand.Next(Globals.surnames.Length)], rand.Next(18, 23), $"{Globals.streets[rand.Next(Globals.streets.Length)]}, {rand.Next(1, 99)}", $"+380{rand.Next(111111111, 999999999)}", rand.Next(0, 100)));
        group2.DisplayStudents();
        Console.WriteLine("group1 == group2: {0}", group1 == group2);
        Console.WriteLine("group1.students[0] == group2.students[0]: {0}", group1.students[0] == group2.students[0]);
    }
}