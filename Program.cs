// See https://aka.ms/new-console-template for more information
Autore orwell = new Autore("Orwell", "George", true, new DateOnly(1903, 6, 25));
Autore yourcenar = new Autore("Yourcenar", "Marguerite", false, new DateOnly(1903, 6, 8));

Libro uno = new Libro("1984", orwell, 1949, 333);
Libro due = new Libro("Memorie di Adriano", yourcenar, 1951, 354);

Console.WriteLine(orwell);
Console.WriteLine(yourcenar);

int i = 0;
foreach (Libro libro in new Libro[] {uno, due})
    Console.WriteLine($"Libro n.{++i}: {libro}");
