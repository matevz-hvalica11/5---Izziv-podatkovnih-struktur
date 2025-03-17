using System;
using System.Collections.Generic;
using System.Linq;

class HashNode
{
    public string Key { get; set; }  // Ključ (npr. "ime", "priimek", "kraj", ...)
    public string Value { get; set; } // Vrednost, povezana s ključem (npr. "Avgust", "Mlakar", ...)

    public HashNode(string key, string value)
    {
        Key = key;
        Value = value;
    }
}

class HashTable
{
    private const double LoadFactorThreshold = 0.7; // Prag za povečanje tabele (ko tabela doseže 70% zasedenosti, se poveča)
    private int _size;  // Trenutna velikost tabele (število bucketov)
    private int _count;  // Število shranjenih elementov
    private LinkedList<HashNode>[] _buckets; // Polje povezanih seznamov

    public HashTable(int initialSize = 5)
    {
        _size = initialSize;
        _buckets = new LinkedList<HashNode>[_size];
        for (int i = 0; i < _size; i++)
        {
            _buckets[i] = new LinkedList<HashNode>();
        }
    }

    private int GetHash(string key) // Izračuna hash indeks za dani ključ
    {
        return Math.Abs(key.GetHashCode()) % _size;
    }

    public void Insert(string key, string value) // Doda nov element v tabelo ali posodobo obstoječo vrednost
    {
        if (_count >= _size * LoadFactorThreshold)
        {
            Resize();
        }

        int index = GetHash(key);
        foreach (var node in _buckets[index])
        {
            if (node.Key == key)
            {
                node.Value = value; // Posodobi obstoječo vrednost
                return;
            }
        }

        _buckets[index].AddLast(new HashNode(key, value));
        _count++;
    }

    public string Search(string key)
    {
        int index = GetHash(key);
        var node = _buckets[index].FirstOrDefault(n => n.Key == key);
        return node != null ? node.Value : "Ni najdeno";
    }

    public void Delete(string key)
    {
        int index = GetHash(key);
        var node = _buckets[index].FirstOrDefault(n => n.Key == key);
        if (node != null)
        {
            _buckets[index].Remove(node);
            _count--;
        }
    }

    private void Resize()
    {
        int newSize = _size * 2;
        var newBuckets = new LinkedList<HashNode>[newSize];
        for (int i = 0; i < newSize; i++)
        {
            newBuckets[i] = new LinkedList<HashNode>();
        }

        foreach (var bucket in _buckets)
        {
            foreach (var node in bucket)
            {
                int newIndex = Math.Abs(node.Key.GetHashCode()) % newSize;
                newBuckets[newIndex].AddLast(node);
            }
        }

        _buckets = newBuckets;
        _size = newSize;
    }

    public void Print()  // Izpiše vse elemente v hash tabeli
    {
        Console.WriteLine("HashTable stanje:");
        for (int i = 0; i < _size; i++)
        {
            Console.Write($"Bucket {i}: ");
            foreach (var node in _buckets[i])
            {
                Console.Write($"[{node.Key}: {node.Value}] -> ");  // Če je več elementov v enem "bucketu", jih izpiše v verižni obliki
            }
            Console.WriteLine("null");
        }
    }
}
