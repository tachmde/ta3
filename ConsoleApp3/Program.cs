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
        "Якi механiзми забезпечують рух тектонiчних плит на Землi?",
        "Якi види дiабету iснують i якi їх симптоми?",
        "Якi фактори впливають на здоров'я людини в мiських умовах?",
        "Якi хiмiчнi елементи складають атмосферу Землi i який вплив вони мають на клiмат?",
        "Якi основнi принципи дiї сонячних батарей i як вони перетворюють сонячну енергiю на електрику?",
        "Якi види забруднення повiтря i якi наслiдки вони можуть мати для здоров'я людини?",
        "Якi механiзми виникнення торнадо i якi наслiдки вони можуть мати для людей та природи?",
        "Якi фактори впливають на вибiр конкретної стратегiї управлiння проектом?",
        "Якi способи зберiгання та обробки даних використовуються в машинному навчаннi?",
        "Якi етапи складають процес розробки програмного забезпечення i " +
        "якi методологiї можна використовувати для його органiзацiї?",
        };
        static List<string> task = new List<string>
        {
        "Напишіть програму на Python, яка знаходить середнє арифметичне " +
        "довільної кількості чисел, введених користувачем з клавіатури.",
        "Створіть веб-сайт з використанням HTML та CSS, який містить заголовок," +
        " меню з трьома пунктами, фото та текстовий блок з описом.",
        "Розробіть базу даних на SQL для зберігання інформації " +
        "про користувачів веб-сайту, що містить ім'я, прізвище, електронну пошту та пароль.",
        "Розробіть алгоритм на мові програмування Python для сортування масиву чисел методом бульбашки",
        "Реалізуйте алгоритм на мові програмування C++, який знаходить найбільший спільний дільник двох чисел.",
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
