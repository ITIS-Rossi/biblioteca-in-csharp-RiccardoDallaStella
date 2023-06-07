public class Biblioteca{ //Creazione classe Biblioteca
    private string nome;
    private int autori;
    private string autoriPath = "autori.csv";
    private string libriPath = "libri.csv";
    private int libri;
    private List<Autore> elencoAutori;
    private List<Libro> elencoLibri;
    public Biblioteca(string nomeBiblioteca){ //Costruttore di base
        this.nome = nomeBiblioteca;
        this.elencoAutori = new List<Autore>();
        this.elencoLibri = new List<Libro>();
    }

    public override string ToString(){ //Metodo ToString
        return $"La Biblioteca si chiama '{nome}' e possiede {autori} autori e {libri} libri";
    }

    // LF: Cosa succede se aggiungo dei libri nuovi ad un autore già presente ?!?
    public void AggiungiAutore(Autore autore){ //Metodo aggiungi autore che li aggiunge alla lista di autori della biblioteca e aggiunge anche tutti i suoi libri
        this.elencoAutori.Add(autore);
        autori++;
        foreach(Libro libro in autore.libriPubblicati){
            elencoLibri.Add(libro);
            libri++;
        }
    }

    public Autore[] AutoriInAnno(int anno){ //Diverse proprietà che tornano tutti gli autori nati in quell'anno, tutti i libri pubblicati in quell'anno, l'elenco degli autori;
        return this.elencoAutori.FindAll(autore => autore.AnnoNascita == anno).ToArray(); //Un'altra che torna un elenco di libri e un metodo che torna il numero di pagine totale della Biblioteca
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

    public bool SalvaCSV(){ //Metodo SalvaCSV
        if(File.Exists(autoriPath) && File.Exists(libriPath)){ //Controlla se i due file esistono
            File.WriteAllText(autoriPath, string.Empty); //Svuotano i file
            File.WriteAllText(libriPath, string.Empty);
            using (StreamWriter autor = new StreamWriter(autoriPath)){ //Preso in uso il file autori.csv
                autor.WriteLine("Cognome;Nome;Genere;Nascita"); //Scrittura della prima riga
                foreach(Autore autore in this.elencoAutori){ //Ciclo foreach che scrive le diverse righe come devono essere, degli autori presenti nella Biblioteca
                    string riga = $"{autore.Cognome};{autore.Nome};{autore.Genere};{autore.AnnoCompleto}";
                    autor.WriteLine(riga);
                }
            } //Chiusura file
            using (StreamWriter libr = new StreamWriter(libriPath)){ //Preso in uso il file libri.csv
                libr.WriteLine("Titolo;Cognome#Nome;Anno;Pagine"); //Scrittura della prima riga
                foreach(Libro libro in this.elencoLibri){ //Ciclo foreach che scrive le diverse righe come devono essere, dei libri presenti nella Biblioteca
                    string riga = $"{libro.Titolo};{libro.CognomeAutore}#{libro.NomeAutore};{libro.AnnoPubblicazione};{libro.Pagine}"; 
                    libr.WriteLine(riga);
                }
            } //Chiusura file
            return true;
        }
        return false;
    }

    public bool CaricaCSV(){ //Metodo CaricaCSV
        if(File.Exists(autoriPath) && File.Exists(libriPath)){ //Controlla se i due file esistono
            elencoAutori.Clear(); //Svuota l'elenco degli autori della Biblioteca
            using (StreamReader autor = new StreamReader(autoriPath)){ //Preso in uso il file autori.csv
                string? riga = autor.ReadLine(); //Skip prima riga
                riga = autor.ReadLine(); //Lettura riga
                while(riga != null){ //Finché la riga non è finita esegui il ciclo
                    string[] valori = riga.Split(';'); //Dividi la riga in base ai punti e virgola
                    bool sex;
                    if(valori[2] == "M") //Gestione del sesso
                        sex = true;
                    else sex = false;
                    string year = valori[3].Substring(0,4); //Gestione dell'anno
                    string month = valori[3].Substring(4,2); //Gestione del mese
                    string day = valori[3].Substring(6,2); //Gestione del giorno
                    string data = $"{year},{month},{day}"; //Scrittura della data nel formato richiesto
                    Autore autore = new Autore(valori[0], valori[1], sex, DateTime.Parse(data)); //Creazione dell'autore e aggiunta nell'elenco degli autori della biblioteca
                    elencoAutori.Add(autore);
                    riga = autor.ReadLine(); //Passa alla riga dopo
                }
            } //Chiusura file
            using (StreamReader libr = new StreamReader(libriPath)){ //Preso in uso il file libri.csv
                string? riga = libr.ReadLine(); //Skip prima riga
                riga = libr.ReadLine(); //Lettura riga
                while(riga != null){ //Finché la riga non è finita esegui il ciclo
                    string[] valori = riga.Split(';'); //Dividi la riga in base ai punti e virgola
                    string[] nomeCompleto = valori[1].Split('#'); //Il campo dell'autore lo dividi in cognome e nome in variabili distinti e assemblale in una
                    string nomeAutore = $"{nomeCompleto[0]} {nomeCompleto[1]}";
                    int i = elencoAutori.FindIndex(autor => autor.nomeCompleto == nomeAutore); //Cerca l'autore che corrisponde al nome e cognome richiesto
                    Libro libro = new Libro(valori[0], elencoAutori[i], int.Parse(valori[2]), int.Parse(valori[3])); //Creazione del libro e aggiunta nell'elenco dei libri della biblioteca
                    elencoLibri.Add(libro); 
                    riga = libr.ReadLine(); //Passa alla riga dopo
                }
            }
            return true;
        }
        else return false;
    }
}
