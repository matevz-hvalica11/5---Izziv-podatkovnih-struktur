class Program
{
    static void Main()
    {
        HashTable hashTable = new HashTable(5);  // Ustvarimo hash tabelo velikosti 5

        hashTable.Insert("ime", "Avgust");
        hashTable.Insert("priimek", "Mlakar");
        hashTable.Insert("kraj", "Stari trg pri Lozu");
        hashTable.Insert("država", "Slovenija"); 

        Console.WriteLine("Tabela po vstavljanju:");
        hashTable.Print();

        Console.WriteLine($"\nIskanje 'ime': {hashTable.Search("ime")}");
        Console.WriteLine($"Iskanje 'država': {hashTable.Search("država")}"); 

        hashTable.Delete("priimek");

        Console.WriteLine("\nTabela po brisanju:");
        hashTable.Print();
    }
}
