using System;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            product.Event += RecordToFile;

            Console.Write("Введите данные о продукте\n" +
            "1) Наименование продукта:");
            product.Name = Console.ReadLine();

            Console.Write("2) Производитель: ");
            product.Brand = Console.ReadLine();

            double price=0;
            while (price==0)
            {
                Console.Clear();
                Console.Write($"Введите данные о продукте\n" +
                $"1) Наименование продукта: {product.Name}\n" +
                $"2) Производитель: {product.Brand}\n"+
                $"3) Цена продукта: ");
                double.TryParse(Console.ReadLine(), out price);
                product.Price = price;

            }

            ConsoleKeyInfo key;
            while (true)
            {
            
                Console.WriteLine("Введите Tab");
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Tab)
                {
                    product.Add(product);
                    break;
                }
            }
        }
        static void RecordToFile(Product product)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Product));
            try
            {
                using (var stream = new FileStream("products.xml", FileMode.OpenOrCreate))
                {
                    serializer.Serialize(stream, product);
                    Console.WriteLine("Ваши данные записаны!");
                }
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

/*1)Что такое рефлексия. Приведите пример динамического подключения библиотеки
 2) Что такое сериализация. Покажите XML сериализацию
 3) Можно ли изменить строку. Покажите как
 4) Создайте generic c ограничением IDisposible
 5) Приведите плюсы и минусы итерфейсов и абстрактных классов
 6) Что такое nullable тип? Зачем он нужен



    Ответы:
     
    1) Что такое рефлексия? Приведите пример динамического подключения библиотеки?

    Технология рефлексии позволяет определить все составные элементы класса(поля, методы, свойства) если мы незнаем его "начинку".
    Для подключения dll необходимо  пространство имен System.Reflection.
    
    Пример:

        using System.Reflection;





    2) Что такое сериализация? Покажите XML сериализацию?

    Сериализация - это преобразования объекта в поток байтов.

    Форматы сериализации:
    бинарный
    SOAP 
    xml
    JSON

   Пример Xml-сериализации:

    XmlSerializer formatter = new XmlSerializer(typeof(массив объектов[]));
 
    using (FileStream fs = new FileStream("файл.xml", FileMode.OpenOrCreate))
    {
        formatter.Serialize(fs, объекты массива);
    }

    3) Можно ли изменить строку? Покажите как?
     
    Чтобы заменить один символ или подстроку на другую, применяется метод Replace:
    Пример:
    
    string text = "хороший день";
    text = text.Replace("хороший", "плохой");
    



    4) Создайте generic c ограничением IDisposible

        public class Объект<T> : IDisposable
        {
                private readonly поле;

                public void Dispose()
                {
                    поле_поля.Close();
                }
        }



    5) Приведите плюсы и минусы итерфейсов и абстрактных классов

    Абстрактный класс — это класс, у которого не реализован один или больше методов 
    Его методы реализуются классами наследованными от него 


    Интерфейс — это контракт который обязуется выполнить объект (описывает некоторое семейство типов и содержит лишь декларации операций)

    Абстрактный класс нужен, когда нужно семейство классов, у которых есть много общих признаков. 
    
    Интерфейс нужен обычно когда описывается только интерфейс (тавтология). 
    Например, один класс хочет дать другому возможность доступа к некоторым своим методам, 
    но не хочет себя «раскрывать». Поэтому он просто реализует интерфейс.

    Интерфейс способен реализовать ромбовидное наследование



    6) Что такое nullable тип? Зачем он нужен

    nullable - это как условие(проверка), перед тем как присвоить объекту значение. 
    пример:
    int? z1 = 5;
    
     
     */
