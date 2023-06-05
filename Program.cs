// See https://aka.ms/new-console-template for more information
Biblioteca biblio = new Biblioteca("ITIS Rossi");
if(biblio.CaricaCSV()){
    Console.WriteLine("Caricamento avvenuto correttamente :)");
}
else{
    Autore orwell = new Autore("Orwell", "George", true, new DateTime(1903, 6, 25));
    Autore yourcenar = new Autore("Yourcenar", "Marguerite", false, new DateTime(1903, 6, 8));
    Autore dallas = new Autore("Dalla Stella", "Riccardo", true, new DateTime(2006, 10 , 19));
    Autore giovanni = new Autore("Pasqualetto", "Giovanni", true, new DateTime(2007, 12, 7));
    Autore marco = new Autore("Gorza", "Marco", true, new DateTime(2006, 09, 15));
    Autore alberto = new Autore("Barban", "Alberto", true, new DateTime(2006, 11 , 27));
    Autore federico = new Autore("Menin", "Federico", true, new DateTime(2006, 9, 19));
    Autore giuseppe = new Autore("Giuseppe", "Franchino", true, new DateTime(1900, 12, 25));
    Autore matteo = new Autore("Dalla Stella", "Matteo", true, new DateTime(2006, 9 , 21));

    Libro uno = new Libro("1984", orwell, 1949, 333);
    Libro due = new Libro("Memorie di Adriano", yourcenar, 1951, 354);
    Libro tre = new Libro("Quoi? L'eternité", yourcenar, 1988, 200);

    biblio.AggiungiAutore(orwell);
    biblio.AggiungiAutore(yourcenar);
    biblio.AggiungiAutore(dallas);
    biblio.AggiungiAutore(giovanni);
    biblio.AggiungiAutore(marco);
    biblio.AggiungiAutore(alberto);
    biblio.AggiungiAutore(federico);
    biblio.AggiungiAutore(giuseppe);
    biblio.AggiungiAutore(matteo);
}
if(biblio.SalvaCSV()){
    Console.WriteLine("Salvataggio avvenuto correttamente :)");
}
