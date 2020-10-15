using System;

namespace ConsoleQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Объявление экземпляров классов
            Enemy Enemy = new Enemy();
            Player Player = new Player();

            // Вывод 
            Console.WriteLine("");
            Enemy.Talk("Привет, я подсяду?", 50);
            Enemy.DoAction("Садиться к вам");
            Console.WriteLine("");

            // Блок условия продолжения
            bool dialog_continue = Player.Answer("Вы согласны?(ДА / НЕТ): ", "Да", "Нет");

            if (dialog_continue)
            {
                Player.Talk("Да, конечно, можешь присесть", 50);
            }
            else
            {
                Player.Talk("Пошла в пизду, хуйня обоссаная", 50);
                Enemy.Talk("Ясно, я сумасшедшая. Как и все. Ладно, извини, что потревожила. Я отсяду.", 40);
                Enemy.DoAction("Отсаживается");
                Console.WriteLine("Вы не сумели выебать тыкву...");
                Console.ReadLine();
                Environment.FailFast("Bye"); // Быстрое уничтожение процесса
            }

            // Блок диалога
            Enemy.Talk("Почему у меня на рюкзаке радужный значок? Ну, просто мне понравился радужный значок.", 50);
            Enemy.DoAction("Показывает радужно-пидорский значок");
            System.Threading.Thread.Sleep(100);
            Player.Talk("Что? Я не спрашивал же.", 90);
            Player.Clear();

            System.Threading.Thread.Sleep(100);
            Enemy.Talk("Поддерживаю ли я ЛГБТ? Да.", 70);
            Player.Talk("Какое ЛГБТ, о чем ты? Ты со мной?", 90);
            Player.Clear();

            System.Threading.Thread.Sleep(100);
            Enemy.Talk("Да, я являюсь частью сообщества. А почему ты спрашиваешь?", 70);
            Player.Talk("... ", 400);
            Player.Clear();

            System.Threading.Thread.Sleep(100);
            Enemy.Talk("В смысле навязываю тебе что-то? Так ты же сам спросил. Ладно.", 70);
            Player.Talk("С. Кем. Ты. Блять. Разговариваешь?", 90);
            Player.Clear();

            System.Threading.Thread.Sleep(100);
            Enemy.Talk("Хочу ли я свою подругу? Боже, нет, конечно. Почему я должна ее хотеть?", 70);
            Player.Talk("Бляяяяяять...", 150);
            Player.Clear();

            System.Threading.Thread.Sleep(100);
            Enemy.Talk("В смысле всех? Нет, постой, это не так работает немножко. Тебе объяснить?", 50);
            Player.Talk("АААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААА", 10);
            Player.Talk("ОТЪЕБИИИИИИИИИИИИИИИИИИИИИИИИИИИИИСЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬ", 10);
            Player.Clear();

            System.Threading.Thread.Sleep(100);
            Enemy.Talk("Не надо пропагандировать? Я не пропагандирую, ты просто сам спросил у меня… ", 70);
            Enemy.Talk("Ясно, я сумасшедшая. Как и все. Ладно, извини, что потревожила. Я отсяду.", 70);
            Enemy.DoAction("Отсаживается");
            Player.Talk("НАКОНЕЦ-ТО", 60);
            Player.Clear();

            Console.WriteLine("Вы не сумели закадрить тыкву...");
            Console.ReadLine();
        }
    }

    class Enemy
    {
        /*
         * Класс, отвечающий за действия от "Тыквы".
         * Методы: Talk, DoAction
         * 
         * Talk - вывод текста, с перебиранием посимвольно, который выводится за определенный промежуток
         * времени, с выставлением собственного цвета.
         * 
         * DoAction - эмуляция выполнения к-либо действия. Выделяется фиолетовым цветом.(В принципе тот же Talk
         * только в немного другом стиле).
         * 
         * Поле name отвечает за имя, которое, я так думаю, понятно из контекста.
         */

        string name = "Тыква";
        public void Talk(string text, int sleep_time_ms)
        {
            int text_length = text.Length; // Выявление длинны текста и присваивание ее к переменной

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow; // Цвет текста
            Console.Write("{0} говорит: ", name);

            // Перебирание переменной по-символьно и вывод их на экран с определенной частотой
            for (int i = 0; i < text_length; i++)
            {
                System.Threading.Thread.Sleep(sleep_time_ms);
                Console.Write(text[i]);
            }

            Console.ResetColor(); // Сброс цвета 
        }

        public void DoAction(string action)
        {
            action = ("*" + action + "*"); // Изменение переменной, с добавлением "*" по бокам
            int action_length = action.Length; // Выявление длинны текста и присваивание ее к переменной

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkMagenta; // Изменение цвета текста

            // Перебирание переменной по-символьно и вывод их на экран с определенной частотой
            for (int i = 0; i < action_length; i++)
            {
                System.Threading.Thread.Sleep(100);
                Console.Write(action[i]);
            }

            Console.ResetColor(); // Сброс цвета
        }
    }

    class Player
    {
        /*
         * Класс, отвечающий за действия от "игрока".
         * Методы: Talk, Answer, Clear
         * 
         * Talk - вывод текста, с перебиранием посимвольно, который выводится за определенный промежуток
         * времени, с выставлением собственного цвета.
         * 
         * Answer - запрос на ввод переменной пользователя, на основе которого выводится текст и изменяется
         * сценарий программы. Используется цикл While для проверки данных пользователя, который прекращается
         * при ответе, не содержащий ошибок.
         * 
         * Clear - очистка консоли и продолжение диалога
         */

        public void Talk(string text, int sleep_time_ms)
        {
            int text_length = text.Length;

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White; // Изменение цвета текста
            Console.Write("Вы отвечаете: ");

            // Перебирание переменной по-символьно и вывод их на экран с определенной частотой
            for (int i = 0; i < text_length; i++)
            {
                System.Threading.Thread.Sleep(sleep_time_ms);
                Console.Write(text[i]);
            }

            Console.ResetColor();
        }
        public bool Answer(string question, string good_answer, string bad_answer)
        {
            bool result = false;
            string answer;
            int question_length = question.Length; // Присваивание переменной длинны другой
            bool check = true;

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White; // Изменение цвета текста

            while (check == true)
            {
                // Перебирание переменной по-символьно и вывод их на экран с определенной частотой
                for (int i = 0; i < question_length; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    Console.Write(question[i]);
                }

                // Присваивание переменной answer значения, которое вводит пользователь
                // , измененное на строчные буквы методом ToLower()
                answer = Console.ReadLine().ToLower();

                // Проверка введеного на соответствие вариантам, при неверном введении цикл повторяется.
                switch (answer)
                {
                    case "да":
                        check = false;
                        result = true;
                        continue;
                    case "нет":
                        check = false;
                        result = false;
                        continue;
                    default:
                        check = true;
                        continue;
                }
            }

            Console.ResetColor(); // Обновление цвета
            return result;
        }
        public void Clear()
        {
            Console.ReadLine();
            Console.Clear();
        }
    }
}
