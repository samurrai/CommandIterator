using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    // Интерфейс Команды объявляет метод для выполнения команд.
    public interface ICommand
    {
        void Execute();
    }

    class SendData : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Sended");
        }
    }

    class Invoker
    {
        private ICommand _onStart;

        private ICommand _onFinish;

        // Инициализация команд
        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }

        public void SetOnFinish(ICommand command)
        {
            this._onFinish = command;
        }

        // Отправитель не зависит от классов конкретных команд и получателей.
        // Отправитель передаёт запрос получателю косвенно, выполняя команду.
        public void DoSomethingImportant()
        {
            _onStart.Execute();
            _onFinish.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Клиентский код может параметризовать отправителя любыми
            // командами.
            Invoker invoker = new Invoker();

            invoker.SetOnStart(new SendData());
            invoker.SetOnFinish(new SendData());

            invoker.DoSomethingImportant();

            Console.ReadLine();
        }
    }
}