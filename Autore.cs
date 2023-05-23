public class Autore {
    private string cognome;
    private string nome;
    private bool sesso;
    private string genere;
    private int anno;
    private int mese;
    private int giorno;
    private DateOnly data;
    private List<Libro> libri;

    public Autore(string cognomeAutore, string nomeAutore, bool sessoAutore, DateOnly dataAutore){
        this.cognome = cognomeAutore;
        this.nome = nomeAutore;
        this.sesso = sessoAutore;
        if(this.sesso)
            this.genere = "M";
        else this.genere = "F";
        this.data = dataAutore;
        this.anno = dataAutore.Year;
        this.mese = dataAutore.Month;
        this.giorno = dataAutore.Day;
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

    public string AnnoCompleto {
        get { return $"{anno.ToString().PadLeft(4, '0')}{mese.ToString().PadLeft(2, '0')}{giorno.ToString().PadLeft(2, '0')}";}
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