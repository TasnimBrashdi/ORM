using College.Models;
using College.repositories;
using College.Repositories;

namespace College
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppDbContext appDbContext = new AppDbContext();


            // Create repositories
            var studentRepository = new StudentRepository(appDbContext);
            var hostelRepository = new HostelRepository(appDbContext);
            var facultyRepository = new FacultyRepository(appDbContext);
            var subjectRepository = new SubjectRepository(appDbContext);
            var courseRepository = new CourseRepository(appDbContext);
            var departmentRepository = new DepartmentRepository(appDbContext);
            var ExamRepository = new ExamRepository(appDbContext);

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Display all student");
                Console.WriteLine("2. Add new Hostel");
                Console.WriteLine("3. Get Faculty By Department");
                Console.WriteLine("4. Count Subjects");
                Console.WriteLine("5. Get Courses With Duration");
                Console.WriteLine("6. Delete Department");
                Console.WriteLine("7. Update Exam:");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayAllStudent(studentRepository);
                        break;
                    case "2":
                        AddNewHostel(hostelRepository);
                        break;
                    case "3":
                        GetFacultyByDepartment(facultyRepository);
                        break;
                    case "4":
                        countSubject(subjectRepository);
                        break;
                    case "5":
                        GetCoursesWithDuration(courseRepository);
                        break;
                    case "6":
                        DeleteDepratment(departmentRepository);
                        break;
                    case "7":
                        UpadateExams(ExamRepository);
                        break;
                    case "8":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void DisplayAllStudent(StudentRepository repository)
        {
            var students = repository.GetAllStudents();
            Console.WriteLine("\nstudents:");
            foreach (var s in students)
            {
                Console.WriteLine($"{s.SId}: {s.FName} {s.LName} - Department: {s.DOB} -Courses  {s.Courses} -Exams: {s.Exams}");
            }
        }
        static void AddNewHostel(HostelRepository repository)
        {
            Console.Write("\nEnter Name: ");
            var Name = Console.ReadLine();
            Console.Write("Enter Number of seats: ");


            if (int.TryParse(Console.ReadLine(), out var NOSeats))
            {
                var hostel = new Hostel { HName = Name, NOSeats = NOSeats };
                repository.AddHostel(hostel);
                Console.WriteLine("HOSTEL added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid number input.");
            }
        }
        static void GetFacultyByDepartment(FacultyRepository repository)
        {
            Console.WriteLine("Enter department ID");
            if (int.TryParse(Console.ReadLine(), out var dID))
            {
                var facultyList = repository.GetFacultyByDepartment(dID);

                if (facultyList.Any())
                {
                    foreach (var faculty in facultyList)
                    {
                        Console.WriteLine($"Faculty ID: {faculty.Id}, Name: {faculty.Name}, Department ID: {faculty.DEID}");
                    }
                }
                else
                {
                    Console.WriteLine("No faculty members found for the provided department ID.");
                }
            }
            else {
                Console.WriteLine("Invalid number input.");
            }
        }
        static void countSubject(SubjectRepository repository)
        {
            var count = repository.CountSubjects();
            Console.WriteLine("\nCount Subjects:" + count);
        }
        static void GetCoursesWithDuration(CourseRepository repository)
        {
            Console.WriteLine("Enter Duration");
            if (int.TryParse(Console.ReadLine(), out var dur))
            {
                var courses = repository.GetCoursesWithDuration(dur);

                if (courses.Any())
                {
                    foreach (var c in courses)
                    {
                        Console.WriteLine($"Course ID: {c.CId}, Name: {c.CName}");
                    }
                }
                else
                {
                    Console.WriteLine("No courses found for the provided Duration.");
                }
            }
            else
            {
                Console.WriteLine("Invalid number input.");
            }

        }
        static void DeleteDepratment(DepartmentRepository repository)
        {

            Console.Write("Enter Department ID: ");


            if (int.TryParse(Console.ReadLine(), out var dId))
            {
                repository.DeleteDepartment(dId);
                Console.WriteLine("Department Delete successfully!");
            }
            else
            {
                Console.WriteLine("Invalid number input.");
            }
        }

        static void UpadateExams(ExamRepository repository)
        {
            Console.WriteLine("Enter Exam code");
            string code = Console.ReadLine();
            Console.WriteLine("Enter Exam Room");
            string room = Console.ReadLine();
            Console.WriteLine("Enter Exam Date");

            if (DateOnly.TryParse(Console.ReadLine(), out var da))
            {
                Console.WriteLine("Enter Exam Time");
                if (TimeOnly.TryParse(Console.ReadLine(), out var time))
                {
                    var Exam = new Exams { ExCode = code, Room = room, date = da, time = time };
                    repository.UpdateExam(Exam);
                    Console.WriteLine("Exam Upadte successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid number input.");
                }
            }
            else
            {
                Console.WriteLine("Invalid number input.");
            }
            


        }
    } 
}
