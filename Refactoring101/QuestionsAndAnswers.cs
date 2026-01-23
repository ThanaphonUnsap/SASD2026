using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring101
{
    // Do Refactoring the following code:
    public class QuestionsAndAnswers
    {
        // 1. Mysterious Name
        public double Calc(double a, double b)
        {
            return a > b ? a : b;
        }
        // Max - return the maximum value between a and b
        public double GetMaximum(double first, double second)
        {
            return Math.Max(first, second);
        }

        // 2. Duplicate Code
        // Before Refactoring
        public void Print()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("   Mr.Harry Potter");
            Console.WriteLine("***********************");
            Console.WriteLine();

            Console.WriteLine("***********************");
            Console.WriteLine("   Ms.Mary Poppin");
            Console.WriteLine("***********************");
            Console.WriteLine();

            Console.WriteLine("***********************");
            Console.WriteLine("   Mr.Johny Black");
            Console.WriteLine("***********************");
            Console.WriteLine();
        }
        // After Refactoring
        public void PrintRefactored()
        {
            PrintStudent("Mr.Harry Potter");
            PrintStudent("Ms.Mary Poppin");
            PrintStudent("Mr.Johny Black");
        }
        private void PrintStudent(string name)
        {
            Console.WriteLine("***********************");
            Console.WriteLine("   " + name);
            Console.WriteLine("***********************");
            Console.WriteLine();
        }

        // 3. Shotgun Surgery
        public class Shotgun1
        {
            public void DisplayStudents()
            {
                Console.WriteLine("Student Count = " + 48);
            }
        }
        public class Shotgun2
        {
            public void PrintTotal()
            {
                Console.WriteLine("Total Students : " + 48);
            }
        }
        // After Refactoring
        public class StudentStatistics
        {
            private const int StudentCount = 48;

            public void DisplayStudentCount()
            {
                Console.WriteLine($"Student Count = {StudentCount}");
            }

            public void PrintTotalStudents()
            {
                Console.WriteLine($"Total Students : {StudentCount}");
            }

            // 4. Data Clump
            public void PrintDate(int day, int month, int year)
            {
                Console.WriteLine($"{day:00}/{month:00}/{year:0000}");
            }
            public class Date
            {
                public required int Day { get; set; }
                public required int Month { get; set; }
                public required int Year { get; set; }

                public string Format()
                {
                    return $"{Day:00}/{Month:00}/{Year:0000}";
                }
            }

            // 5. Feature Envy
            //     จากข้อที่แล้ว น่าจะได้สร้างคลาส Date ขึ้นมา
            //     ในคลาส Date นั้นให้สร้าง method: public string Format()
            //      ปรับให้ PrintDate(...) ของเดิม ไปเรียก date.Format() ดังกล่าว
            public class FeatureEnvy
            {
                public void PrintDate(Date date)
                {
                    Console.WriteLine(date.Format());
                }
            }
        }
    }
}
