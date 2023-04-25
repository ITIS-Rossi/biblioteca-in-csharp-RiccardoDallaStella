public class Autore {
    private string cognome;
    private string nome;
    private bool sesso;
    private DateOnly data;

    public Autore(string cognomeAutore, string nomeAutore, bool sessoAutore, DateOnly dataAutore){
        this.cognome = cognomeAutore;
        this.nome = nomeAutore;
        this.sesso = sessoAutore;
        this.data = dataAutore;
    }

    public override string ToString(){
        if(this.sesso)
        return $"{this.cognome} {this.nome} autore nato il {this.data}";
        else
        return $"{this.cognome} {this.nome} autrice nata il {this.data}";
    }

    /*private string[] elenco;
    public string elencoLibri(){
        return $"Ecco l'elenco dei suoi libri: {this.elenco}";
    }*/
}