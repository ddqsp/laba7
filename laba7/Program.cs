using System;

namespace LinkedListExample
{
    public class Node
    {
        public float Data { get; set; }
        public Node Next { get; set; }

        public Node(float data)
        {
            Data = data;
            Next = null;
        }
    }
    public class LinkedList
    {
        private Node head;

        public LinkedList()
        {
            head = null;
        }

        public void AddLast(float data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void InsertAfterSecond(float data)
        {
            if (head == null || head.Next == null)
            {
                Console.WriteLine("В списку недостатньо елементiв, щоб вставити пiсля другого елементу.");
                return;
            }

            Node newNode = new Node(data);
            newNode.Next = head.Next.Next;
            head.Next.Next = newNode;
        }

        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.Write("end");
        }
        public float? FindFirstGreaterThanTwice(float value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data == 2 * value)
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
        }
        public int CountElementsGreaterThan3_14()
        {
            int count = 0;
            Node current = head;
            while (current != null)
            {
                if (current.Data > 3.14)
                {
                    count++;
                }
                current = current.Next;
            }
            return count;
        }

        public LinkedList GetElementsGreaterThan(float value)
        {
            LinkedList newList = new LinkedList();
            Node current = head;
            while (current != null)
            {
                if (current.Data > value)
                {
                    newList.AddLast(current.Data);
                }
                current = current.Next;
            }
            return newList;
        }

        public void RemoveGreaterThanAverage()
        {
            if (head == null)
            {
                return;
            }

            float sum = 0;
            int count = 0;
            Node current = head;
            while (current != null)
            {
                sum += current.Data;
                count++;
                current = current.Next;
            }
            float average = sum / count;
            Node previous = null;
            current = head;
            while (current != null)
            {
                if (current.Data > average)
                {
                    if (previous == null)
                    {
                        head = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                }
                else
                {
                    previous = current;
                }
                current = current.Next;
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            bool continueRunning = true;

            Console.WriteLine("Введiть початкову кiлькiсть елементiв списку");
            int numElements;
            while (!int.TryParse(Console.ReadLine(), out numElements) || numElements < 1)
            {
                Console.WriteLine("Некоректний ввiд.");
            }

            Console.WriteLine("Введiть значення (дробовi через кому):");
            for (int i = 0; i < numElements; i++)
            {
                float element;
                while (!float.TryParse(Console.ReadLine(), out element))
                {
                    Console.WriteLine("Некоректний ввід.");
                }
                list.AddLast(element);
            }

            while (continueRunning)
            {
                Console.WriteLine("");
                Console.WriteLine("1. Вставити пiсля другого елементу");
                Console.WriteLine("2. Побачити список");
                Console.WriteLine("3. Виконати операцiї");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введiть значення для включення пiсля другого елементу:");
                        float newElement;
                        while (!float.TryParse(Console.ReadLine(), out newElement))
                        {
                            Console.WriteLine("Некоректний ввід.");
                        }
                        list.InsertAfterSecond(newElement);
                        break;

                    case 2:
                        Console.WriteLine("Список:");
                        list.PrintList();
                        break;
                    case 3:

                        Console.Write("Введiть значення для знаходження значення елменту бiльше за задане у 2 рази:");
                        float value;
                        while (!float.TryParse(Console.ReadLine(), out value))
                        {
                            Console.WriteLine("Некоректний ввід.");
                        }
                     
                        float? result = list.FindFirstGreaterThanTwice(value);  
                        if (result.HasValue)
                        {
                            Console.WriteLine($"Перший елемент бiльший за {value} у 2 рази - {result.Value}.");
                        }
                        else
                        {
                            Console.WriteLine($"Немає елементу бiльшого за {value} у 2 рази.");
                        }

                        int countGreaterThan3_14 = list.CountElementsGreaterThan3_14();
                        Console.WriteLine($"Кiлькiсть елементiв бiльша за 3,14: {countGreaterThan3_14}");

                        Console.Write("Введiть число для видалення елементiв менших за задане значення: ");
                        float filterValue;
                        while (!float.TryParse(Console.ReadLine(), out filterValue))
                        {
                            Console.WriteLine("Некоректний ввід.");
                        }
                       
                        LinkedList newList = list.GetElementsGreaterThan(filterValue);
                        Console.WriteLine($"Новий список:");
                        newList.PrintList();

                        list.RemoveGreaterThanAverage();
                        Console.WriteLine();
                        Console.WriteLine("Список з видаленими елементами, якi бiльшi за середнє значення:");
                        list.PrintList();

                        continueRunning = false;
                        break;

                    default:
                        Console.WriteLine("Некоректний ввiд. Оберiть 1, 2 або 3.");
                        break;
                }
            }
        }
    }
}
