namespace LinkedList
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int StudentId { get; set; }
        public string TheoryExamResult { get; set; }
        public string PracticalTasksResult { get; set; }
        public Student(string name, string surname, int studentId, string theoryExamResult, string
            practicalTasksResult)
        {
            Name = name;
            Surname = surname;
            StudentId = studentId;
            TheoryExamResult = theoryExamResult;
            PracticalTasksResult = practicalTasksResult;
        }
    }
}

namespace LinkedList
{
    internal class Program
    {
        static List<string> question = new List<string>
        {
        "Яка різниця між мовами програмування високого та низького рівня?",
        "Що таке алгоритм, і яка його роль у програмуванні?",
        "Які основні принципи ООП (об'єктно-орієнтованого програмування)?",
        "Що таке замикання (closure) в програмуванні, і як вони використовуються?",
        "Що таке API (інтерфейс програмування застосунків) і для чого він використовується?",
        "Які основні типи даних і операції з ними в мовах програмування?",
        "Які основні методи сортування, і які вони мають характеристики?",
        "Що таке асинхронне програмування і навіщо воно потрібне?",
        "Якi способи зберiгання та обробки даних використовуються в машинному навчаннi?",
        "Яка різниця між статичною та динамічною типізацією мов програмування?",
        "Які основні принципи безпеки програмного забезпечення, які важливі для програмістів?",
        };
        static List<string> task = new List<string>
        {
        "Створення калькулятора: Напишіть програму, яка приймає введення від користувача для виконання простих арифметичних операцій, таких як додавання, віднімання, множення та ділення." ,
        "Розробка списку завдань (to-do list): Створіть програму, яка дозволяє користувачу додавати, видаляти та відзначати завдання як виконані в простому списку завдань.",
        "Конвертер одиниць вимірювання: Реалізуйте програму, яка дозволяє користувачеві конвертувати одиниці вимірювання, такі як температура (Цельсій в Фаренгейт), довжина, вага тощо.",
        "Генератор паролів: Створіть програму, яка генерує випадкові паролі заданої довжини та складності.",
        "Інтерпретатор Markdown: Напишіть програму, яка конвертує текст, написаний у форматі Markdown, у відповідний HTML-код.",
        };
        static void Main(string[] args)
        {
            LinkedList<Student> exam = new LinkedList<Student>(new List<Student>()
            {
            new Student("Борис", "Калашніков", 1, " ", " "),
            new Student("Олександр", "Геннадієв", 2, " ", " "),
            new Student("Едуард", "Iванюк", 3, " ", " "),
            new Student("Андрій", "Шапочник", 4, " ", " "),
            new Student("Григорiй", "Авдієнко", 5, " ", " "),
            new Student("Анна", "Калугіна", 6, " ", " "),
            new Student("Владислав", "Шевченко", 7, " ", " ")
            });
            Console.WriteLine("Студенти, що складають iспит:");
            foreach (Student student in exam)
            {
                Console.WriteLine($"Студент {student.Name} {student.Surname}, номер залiковки:{ student.StudentId}\n ");
            }
            Console.WriteLine("Теоретичнi завдання - 1 \nПрактичнi завдання - 2");
            TheoryExamResult(exam);
            PracticalTasksResult(exam);
            Console.ReadKey();
            TheoryExamResult(exam);
            PracticalTasksResult(exam);
            foreach (var student in exam)
            {
                Console.WriteLine($"Студент {student.Name} {student.Surname}, номер у спику:{{ student.StudentId}},\" +  $\"теоретичнi запитання: {{ student.TheoryExamResult}},практика: {{ student.PracticalTasksResult}}\n ");
            }
        }
        static void TheoryExamResult(LinkedList<Student> exam)
        {
            var questionfromprevstudent = GetRandomQuestion(question);
            foreach (var student in exam)
            {
                List<string> questions = new List<string>()
                {
                GetRandomQuestion(question),
                GetRandomQuestion(question),
                questionfromprevstudent,
                };
                var uniqueQuestions = questions.Distinct().ToList();
                if (uniqueQuestions.Count < 3)
                {
                    questions.Add(GetRandomQuestion(question));
                }
                Console.WriteLine("\nТеоретичнi запитання для цього студента: ");
                foreach (var item in uniqueQuestions)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Студент склав екзамен? +/-");
                student.TheoryExamResult = Console.ReadLine();
                questionfromprevstudent = questions[new Random().Next(0, questions.Count)];
                Console.WriteLine($"Студент {student.Name} {student.Surname}, " +
                $"номер залiковки: {student.StudentId}, теоретичнi запитання:{{ student.TheoryExamResult}} \n");
            Console.ReadKey();
                Console.Clear();
            }
        }
        static void PracticalTasksResult(LinkedList<Student> exam)
        {
            var taskfromprevstudent = GetRandomTask(task);
            foreach (var student in exam)
            {
                List<string> tasks = new List<string>()
                {
                GetRandomTask(task),
                GetRandomTask(task),
                taskfromprevstudent,
                };
                var uniqueQuestions = tasks.Distinct().ToList();
                if (uniqueQuestions.Count < 3)
                {
                    tasks.Add(GetRandomTask(task));
                }
                Console.WriteLine("\nПрактичнi завдання для цього студента: ");
                foreach (var item in uniqueQuestions)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Студент склав екзамен? +/-");
                student.PracticalTasksResult = Console.ReadLine();
                taskfromprevstudent = task[new Random().Next(0, task.Count)];
                Console.WriteLine($"Студент {student.Name} {student.Surname}, " +
                $"номер залiковки: {student.StudentId}, практика:{student.PracticalTasksResult}");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static string GetRandomQuestion(List<string> question)
        {
            Random random = new Random();
            int randomQuestion = random.Next(0, question.Count);
            return (question[randomQuestion]);
        }
        static string GetRandomTask(List<string> task)
        {
            Random random = new Random();
            int randomTask = random.Next(0, task.Count);
            return (task[randomTask]);
        }
    }
}
