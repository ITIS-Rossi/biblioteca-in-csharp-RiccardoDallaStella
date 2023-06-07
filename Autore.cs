public class Autore { //Creazione classe autore
    private string cognome;
    private string nome;
    private bool sesso;
    private string genere;
    private DateTime anno;
    private List<Libro> libri;

    public Autore(string cognomeAutore, string nomeAutore, bool sessoAutore, DateTime annoAutore){ //Costruttore di base, gestisco il genere dell'autore e definizione della lista
        this.cognome = cognomeAutore;
        this.nome = nomeAutore;
        this.sesso = sessoAutore;
        // LF : molto meglio 
        // this.genere = this.sesso ? "M" : "F";
        if(this.sesso)
            this.genere = "M";
        else this.genere = "F";
        this.libri = new List <Libro>();
        this.anno = annoAutore;
    }

    public override string ToString(){ //Metodo ToString
        if(this.sesso)
        return $"{this.cognome} {this.nome} autore nato il {this.anno}";
        else
        return $"{this.cognome} {this.nome} autrice nata il {this.anno}";
    }

    public int AnnoNascita { //Diverse proprietà che tornano l'anno di nascita dell'autore, l'anno completo nel formato specificato, il nome completo, il genere, il cognome, il nome;
        get { return anno.Year;} //la data di nascita, un metodo che aggiunge un libro alla lista di libri dell'autore e una che torna la lista dei libri pubblicati
    }

    public string AnnoCompleto {
        get { return $"{this.anno.ToString("yyyyMMdd")}";}
    }

    public String nomeCompleto {
        get { return $"{cognome} {nome}";}
    }

    public string Genere{
        get { return $"{genere}";}
    }
    
    public string Cognome {
        get { return $"{cognome}";}
    }

    public string Nome {
        get { return $"{nome}";}
    }

    public DateTime dataDiNascita {
        set { this.anno = DateTime.Now;}
    }

    public int aggiungi(Libro newLibro){
        this.libri.Add(newLibro);
        return this.libri.Count;
    }

    public Libro[] libriPubblicati{
        get { return this.libri.ToArray();}
    }
}
