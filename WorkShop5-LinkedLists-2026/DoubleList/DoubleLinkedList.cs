using DoubleList;
using Shared;

public class DoublyLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public void Add(T item)
    {
        var newNode = new Node<T>(item);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        if (item.CompareTo(_head.Data) <= 0)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
            return;
        }

        if (item.CompareTo(_tail!.Data) >= 0)
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
            return;
        }

        var current = _head;
        while (current != null && item.CompareTo(current.Data) > 0)
        {
            current = current.Next;
        }

        var prev = current!.Prev;
        prev!.Next = newNode;
        newNode.Prev = prev;
        newNode.Next = current;
        current.Prev = newNode;
    }

    public void ShowForward()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty.");
        }

        var current = _head;
        while (current != null)
        {
            Console.Write(current.Data);
            if (current.Next != null)
            {
                Console.Write(" <-> ");
            }
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void ShowBackward()
    {
        if (_tail == null)
        {
            throw new InvalidOperationException("List is empty.");
        }

        var current = _tail;
        while (current != null)
        {
            Console.Write(current.Data);
            if (current.Prev != null)
            {
                Console.Write(" <-> ");
            }
            current = current.Prev;
        }
        Console.WriteLine();
    }

    public void SortDescending()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty.");
        }

        Node<T>? current = _head;
        Node<T>? temp = null;

        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }

        temp = _head;
        _head = _tail;
        _tail = temp;
    }

    public void ShowMode()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty.");
        }

        var counts = new Dictionary<T, int>();
        var current = _head;

        while (current != null)
        {
            if (counts.ContainsKey(current.Data))
            {
                counts[current.Data]++;
            }
            else
            {
                counts[current.Data] = 1;
            }
            current = current.Next;
        }

        var maxCount = 0;
        foreach (var kvp in counts)
        {
            if (kvp.Value > maxCount)
            {
                maxCount = kvp.Value;
            }
        }

        var first = true;
        foreach (var kvp in counts)
        {
            if (kvp.Value == maxCount)
            {
                if (!first)
                {
                    Console.Write(", ");
                }
                Console.Write($"{kvp.Key} (aparece {maxCount} veces)");
                first = false;
            }
        }
        Console.WriteLine();
    }

    public void ShowChart()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty.");
        }

        var counts = new Dictionary<T, int>();
        var keys = new List<T>();
        var current = _head;

        while (current != null)
        {
            if (counts.ContainsKey(current.Data))
            {
                counts[current.Data]++;
            }
            else
            {
                counts[current.Data] = 1;
                keys.Add(current.Data);
            }
            current = current.Next;
        }

        keys.Sort();

        Console.WriteLine();
        foreach (var key in keys)
        {
            var stars = new string('*', counts[key]);
            Console.WriteLine($"{key,-8} {stars}");
        }
        Console.WriteLine();
    }

    public bool Exists(T item)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data.CompareTo(item) == 0)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void DeleteOne(T item)
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty.");
        }

        var current = _head;
        while (current != null)
        {
            if (current.Data.CompareTo(item) == 0)
            {
                RemoveNode(current);
                return;
            }
            current = current.Next;
        }

        throw new InvalidOperationException($"Element '{item}' not found.");
    }

    public void DeleteAll(T item)
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty.");
        }

        if (!Exists(item))
        {
            throw new InvalidOperationException($"Element '{item}' not found.");
        }

        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            if (current.Data.CompareTo(item) == 0)
            {
                RemoveNode(current);
            }
            current = next;
        }
    }

    private void RemoveNode(Node<T> node)
    {
        if (node.Prev != null)
        {
            node.Prev.Next = node.Next;
        }
        else
        {
            _head = node.Next;
        }

        if (node.Next != null)
        {
            node.Next.Prev = node.Prev;
        }
        else
        {
            _tail = node.Prev;
        }
    }
}