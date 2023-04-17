public class Libro {
    private string titolo;
    private string autore;
    private int anno;
    private int pagine;

    public Libro(string titoloLibro, string autoreLibro, int annoLibro, int pagineLibro){
        this.titolo = titoloLibro;
        this.autore = autoreLibro;
        this.anno = annoLibro;
        this.pagine = pagineLibro;
    }

    public override string ToString(){
        return $"{this.titolo} di {this.autore} {this.anno}";
    }
}