// See https://aka.ms/new-console-template for more information
Biblioteca biblio = new Biblioteca("ITIS Rossi");
if(!biblio.CaricaCSV()){
    Autore orwell = new Autore("Orwell", "George", true, new DateOnly(1903, 6, 25));
    Autore yourcenar = new Autore("Yourcenar", "Marguerite", false, new DateOnly(1903, 6, 8));
    Autore dallas = new Autore("Dalla Stella", "Riccardo", true, new DateOnly(2006, 10 , 19));


    Libro uno = new Libro("1984", orwell, 1949, 333);
    Libro due = new Libro("Memorie di Adriano", yourcenar, 1951, 354);
    Libro tre = new Libro("Quoi? L'eternité", yourcenar, 1988, 200);

    biblio.AggiungiAutore(orwell);
    biblio.AggiungiAutore(yourcenar);
}
biblio.SalvaCSV();
