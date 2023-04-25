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
    }

    public override string ToString(){
        return $"{this.titolo} del {this.anno} di {this.autore}";
    }
}