using System;
using System.Collections.Generic;

class Program
{
    static List<Student> students = new List<Student>();

    static string[] courses =
    {
        "Programming with C#",
        "Database Systems",
        "Computer Networks",
        "Web Development",
        "Mathematics for Computing"
    };

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("===== STUDENT RESULTS PROCESSING SYSTEM =====");
            Console.WriteLine("1. Enter Student Results");
            Console.WriteLine("2. View Student Report");
            Console.WriteLine("3. Exit");
            Console.Write("\nChoose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    EnterStudentResults();
                    break;

                case "2":
                    ViewStudentReport();
                    break;

                case "3":
                    Console.WriteLine("\nThank you for using the Student Results Processing System.");
                    running = false;
                    break;

                default:
                    Console.WriteLine("\nInvalid option.");
                    Pause();
                    break;
            }
        }
    }

    static void EnterStudentResults()
    {
        students.Clear();

        for (int i = 0; i < 3; i++)
        {
            Console.Clear();

            Student student = new Student();

            Console.WriteLine($"Enter details for Student {i + 1}\n");

            Console.Write("Enter Full Name: ");
            student.FullName = Console.ReadLine();

            Console.Write("Enter Student ID: ");
            student.StudentId = Console.ReadLine();

            Console.Write("Enter Programme: ");
            student.Programme = Console.ReadLine();

            Console.Write("Enter Level: ");
            student.Level = Console.ReadLine();

            for (int j = 0; j < courses.Length; j++)
            {
                int score;

                while (true)
                {
                    Console.Write($"Enter score for {courses[j]}: ");

                    if (int.TryParse(Console.ReadLine(), out score)
                        && score >= 0
                        && score <= 100)
                    {
                        break;
                    }

                    Console.WriteLine("Invalid score. Score must be between 0 and 100.");
                }

                student.Scores[j] = score;
            }

            CalculateResults(student);

            students.Add(student);
        }

        Console.WriteLine("\nStudent records saved successfully.");
        Pause();
    }

    static void CalculateResults(Student student)
    {
        int total = 0;

        foreach (int score in student.Scores)
        {
            total += score;
        }

        double average = total / 5.0;

        student.TotalScore = total;
        student.AverageScore = average;

        if (average >= 80)
            student.Grade = "A";
        else if (average >= 70)
            student.Grade = "B";
        else if (average >= 60)
            student.Grade = "C";
        else if (average >= 50)
            student.Grade = "D";
        else
            student.Grade = "F";

        student.Status = average >= 50 ? "Passed" : "Failed";
    }

    static void ViewStudentReport()
    {
        Console.Clear();

        if (students.Count == 0)
        {
            Console.WriteLine("No student records found.");
            Pause();
            return;
        }

        Console.WriteLine("===== STUDENT RESULTS REPORT =====\n");

        foreach (Student student in students)
        {
            Console.WriteLine($"Student Name: {student.FullName}");
            Console.WriteLine($"Student ID: {student.StudentId}");
            Console.WriteLine($"Programme: {student.Programme}");
            Console.WriteLine($"Level: {student.Level}\n");

            for (int i = 0; i < courses.Length; i++)
            {
                Console.WriteLine($"{courses[i]}: {student.Scores[i]}");
            }

            Console.WriteLine($"\nTotal Score: {student.TotalScore}");
            Console.WriteLine($"Average Score: {student.AverageScore:F1}");
            Console.WriteLine($"Grade: {student.Grade}");
            Console.WriteLine($"Status: {student.Status}");

            Console.WriteLine("\n-------------------------------------\n");
        }

        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}