public class Libro { //Creazione classe Libro
    private string titolo;
    private Autore autore;
    private int anno;
    private int pagine;

    public Libro(string titoloLibro, Autore autoreLibro, int annoLibro, int pagineLibro){ //Costruttore di base e aggiungo il libro creato alla lista di libri dell'autore
        this.titolo = titoloLibro;
        this.autore = autoreLibro;
        this.anno = annoLibro;
        this.pagine = pagineLibro;
        autoreLibro.aggiungi(this);
    }

    public override string ToString(){ //metodo ToString
        return $"'{this.titolo}' del {this.anno}";
    }

    public int AnnoPubblicazione { //Diverse proprietà che tornano anno di pubblicazione, pagine, titolo, cognome autore, nome autore, numero di pagine
        get { return anno;}
    }

    public int Pagine {
        get { return pagine;}
    }

    public string Titolo {
        get { return titolo;}
    }

    public string CognomeAutore {
        get { return this.autore.Cognome;}
    }

    public string NomeAutore {
        get { return this.autore.Nome;}
    }

    public int PagineLibro {
        get { return pagine;}
    }
}