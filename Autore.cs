public class Autore {
    private string cognome;
    private string nome;
    private bool sesso;
    private int anno;
    private DateOnly data;
    private List<Libro> libri;

    public Autore(string cognomeAutore, string nomeAutore, bool sessoAutore, DateOnly dataAutore){
        this.cognome = cognomeAutore;
        this.nome = nomeAutore;
        this.sesso = sessoAutore;
        this.data = dataAutore;
        this.anno = dataAutore.Year;
        this.libri = new List <Libro>();
    }

    public override string ToString(){
        if(this.sesso)
        return $"{this.cognome} {this.nome} autore nato il {this.data}";
        else
        return $"{this.cognome} {this.nome} autrice nata il {this.data}";
    }

    public int AnnoNascita {
        get { return anno;}
    }

    public String nomeCompleto {
        get { return $"{cognome} {nome}";}
    }

    public DateTime dataDiNascita {
        set { this.data = DateOnly.FromDateTime(value > DateTime.Now ? DateTime.Now : value);}
    }

    public int aggiungi(Libro newLibro){
        this.libri.Add(newLibro);
        return this.libri.Count;
    }

    public Libro[] libriPubblicati{
        get { return this.libri.ToArray();}
    }
}