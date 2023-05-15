public class Biblioteca{
    private string nome;
    private int autori;
    private int libri;
    private List<Autore> elencoAutori;
    private List<Libro> elencoLibri;
    public Biblioteca(string nomeBiblioteca){
        this.nome = nomeBiblioteca;
        this.elencoAutori = new List<Autore>();
        this.elencoLibri = new List<Libro>();
    }

    public override string ToString(){
        return $"La Biblioteca si chiama '{nome}' e possiede {autori} autori e {libri} libri";
    }

    public void AggiungiAutore(Autore autore){
        this.elencoAutori.Add(autore);
        autori++;
        foreach(Libro libro in autore.libriPubblicati){
            elencoLibri.Add(libro);
            libri++;
        }
    }

    public Autore[] AutoriInAnno(int anno){
        return this.elencoAutori.FindAll(autore => autore.AnnoNascita == anno).ToArray();
    }

    public Libro[] LibriInAnno(int anno){
        return this.elencoLibri.FindAll(libro => libro.AnnoPubblicazione == anno).ToArray();
    }

    public Autore[] ElencoAutori{
        get { return this.elencoAutori.ToArray();}
    }

    public Libro[] ElencoLibri{
        get { return this.elencoLibri.ToArray();}
    }

    public int TotalePagine(int totalePagine){
        foreach(Libro libro in elencoLibri){
            totalePagine += libro.PagineLibro;
        }
        return totalePagine;
    }
}