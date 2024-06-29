using System;
using Microsoft.AspNetCore;

namespace Proj2_webAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}

/*
 *  1. Создать дополнительный модуль (на подобии nancyModule)
 *  2. Создать два тестовых выйла. Json и txt для хранилища данных (на подобии БД, но без самой БД)
 *      2.1 Реализовать функционал записи, обновления, чтения и удаления данных из этих файлов
 *  3. Добавить логирование проеккта на базе Owin  
 */

