using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncCompiler asyncCompiler = new AsyncCompiler();
            Console.WriteLine("Задача 1 добавлена");    
            var task1 = asyncCompiler.AsyncBuildProject("fkfkfkf");

            Console.WriteLine("Задача 2 добавлена");
            var task2 = asyncCompiler.AsyncBuildProject("лаллаал");

            Console.WriteLine("Задача 3 добавлена");
            var task3 = asyncCompiler.AsyncBuildProject("11111");

            Console.WriteLine("Ждем результат задачи 1");
         /*  var result1 = task1.Result;           
            Console.WriteLine($"Задача 1 выполнена результат: {string.Join(" ", result1)}");*/

            //Ждем результат задачи 2 без получения результата задачи 1.
            Console.WriteLine("Ждем результат задачи 2");
            var result2 = task2.Result;
            Console.WriteLine($"Задача 2 выполнена результат: {string.Join(" ", result2)}");

            Console.WriteLine("Ждем результат задачи 3");
            var result3 = task3.Result;
            Console.WriteLine($"Задача 3 выполнена результат: {string.Join(" ", result3)}");

            Console.WriteLine("Все задачи выполнены");
            Console.ReadKey();
        }
    }
}
