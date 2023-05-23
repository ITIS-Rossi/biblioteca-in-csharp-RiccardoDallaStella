public class Biblioteca{
    private string nome;
    private int autori;
    private string autoriPath = "autori.csv";
    private string libriPath = "libri.csv";
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

    public void SalvaCSV(){
        using (StreamWriter autor = new StreamWriter(autoriPath)){
            autor.WriteLine("Cognome;Nome;Genere;Nascita");
            foreach(Autore autore in this.elencoAutori){
                string riga = $"{autore.Cognome};{autore.Nome};{autore.Genere};{autore.AnnoCompleto}";
                autor.WriteLine(riga);
            }
        }
        using (StreamWriter libr = new StreamWriter(libriPath)){
            libr.WriteLine("Titolo;Cognome#Nome;Anno;Pagine");
            foreach(Libro libro in this.elencoLibri){
                string riga = $"{libro.Titolo};{libro.CognomeAutore}#{libro.NomeAutore};{libro.AnnoPubblicazione};{libro.Pagine}";
                libr.WriteLine(riga);
            }
        }
        Console.WriteLine("Salvataggio avvenuto correttamente!!!");
    }

    public bool CaricaCSV(){
        if(File.Exists(autoriPath) && File.Exists(libriPath)){
            elencoAutori.Clear();
            using (StreamReader autor = new StreamReader(autoriPath)){
                string? riga = autor.ReadLine();
                riga = autor.ReadLine();
                while(riga != null){
                    string[] valori = riga.Split(';');
                    bool sex;
                    if(valori[2] == "M")
                        sex = true;
                    else sex = false;
                    string year = valori[3].Substring(0,4);
                    string month = valori[3].Substring(4,2);
                    string day = valori[3].Substring(6,2);
                    string data = $"{year},{month},{day}";
                    Autore autore = new Autore(valori[0], valori[1], sex, DateOnly.Parse(data));
                    elencoAutori.Add(autore);
                    riga = autor.ReadLine();
                }
            }
            using (StreamReader libr = new StreamReader(libriPath)){
                string? riga = libr.ReadLine();
                riga = libr.ReadLine();
                while(riga != null){
                    string[] valori = riga.Split(';');
                    string[] cognomeAutore = valori[1].Split('#');
                    int i = elencoAutori.FindIndex(autor => autor.Cognome == cognomeAutore[0]);
                    Libro libro = new Libro(valori[0], elencoAutori[i], int.Parse(valori[2]), int.Parse(valori[3]));
                    elencoLibri.Add(libro);
                    riga = libr.ReadLine();
                }
            }
            return true;
        }
        else return false;
    }
}