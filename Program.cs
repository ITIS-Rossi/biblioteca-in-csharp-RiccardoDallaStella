// See https://aka.ms/new-console-template for more information
Autore orwell = new Autore("Orwell", "George", true, new DateOnly(1903, 6, 25));
Autore yourcenar = new Autore("Yourcenar", "Marguerite", false, new DateOnly(1903, 6, 8));
Autore dallas = new Autore("Dalla Stella", "Riccardo", true, new DateOnly(2006, 10 , 19));


Libro uno = new Libro("1984", orwell, 1949, 333);
Libro due = new Libro("Memorie di Adriano", yourcenar, 1951, 354);
Libro tre = new Libro("La stanchezza", dallas, 2018, 5);
Libro quattro = new Libro("Ci vediamo mercoledì", dallas, 2023, 1);

Console.WriteLine(dallas);

/*int i = 0;
foreach (Libro libro in new Libro[] {uno, due})
    Console.WriteLine($"Libro n.{++i}: {libro}");*/

foreach (Libro libro in dallas.libriPubblicati)
    Console.WriteLine($" > {libro}");