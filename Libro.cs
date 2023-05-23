public class Libro {
    private string titolo;
    private Autore autore;
    private int anno;
    private int pagine;

    public Libro(string titoloLibro, Autore autoreLibro, int annoLibro, int pagineLibro){
        this.titolo = titoloLibro;
        this.autore = autoreLibro;
        this.anno = annoLibro;
        this.pagine = pagineLibro;
        autoreLibro.aggiungi(this);
    }

    public override string ToString(){
        return $"'{this.titolo}' del {this.anno}";
    }

    public int AnnoPubblicazione {
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