public class Biblioteca{
    private string nome;
    private int elencoAutori;
    private int elencoLibri;
    public Biblioteca(string nomeBiblioteca, int elencoAutoriBiblioteca, int elencoLibriBiblioteca){
        this.nome = nomeBiblioteca;
        this.elencoAutori = elencoAutoriBiblioteca;
        this.elencoLibri = elencoLibriBiblioteca;
    }

    public override string ToString(){
        return $"La Biblioteca '{nome}' possiede {elencoAutori} autori e {elencoLibri} libri.";
    }

    public int AggiungiAutore(Autore autore){
        return elencoAutori++;
    }
}