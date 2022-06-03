// Collections // Queue // first-in first-out // last-in last-out


using System;
using System.Collections;

class MainClass
{
    static void StatckEnqueue(Queue q, int a)
    {
        q.Enqueue(a);

        Console.WriteLine("Enqueue(" + a + ")");

        Console.Write("Queue: ");
        foreach (int i in q)
            Console.Write(i + " ");

        Console.WriteLine();
    }

    static void StatckDequeue(Queue q)
    {
        int a = (int)q.Dequeue();

        Console.Write("Dequeue - > ");
        Console.Write(a);

        Console.WriteLine();

        Console.Write("Queue: ");
        foreach (int i in q)
            Console.Write(i + " ");

        Console.WriteLine();

    }

    static void Main()
    {
        Queue q = new Queue();

        StatckEnqueue(q, 22);
        StatckEnqueue(q, 65);
        StatckEnqueue(q, 91);
        StatckDequeue(q);
        StatckDequeue(q);
        StatckDequeue(q);
    }
}