using System;

public class Node
{
    public string Musica;
    public Node Proxima;
    public Node Anterior;

    public Node(string musica)
    {
        Musica = musica;
        Proxima = null;
        Anterior = null;
    }
}

public class Playlist
{
    private Node inicio;
    private Node fim;

    public void AdicionarMusica(string nome)
    {
        Node novoNo = new Node(nome);
        if (inicio == null)
        {
            inicio = novoNo;
            fim = novoNo;
        }
        else
        {
            fim.Proxima = novoNo;
            novoNo.Anterior = fim;
            fim = novoNo;
        }

        Console.WriteLine($"Música '{nome}' adicionada.");
    }

    public void TocarPlaylist()
    {
        Console.WriteLine("\n--- Tocando Playlist ---");
        Node atual = inicio;

        while (atual != null)
        {
            Console.WriteLine($"Tocando: {atual.Musica}");
            atual = atual.Proxima;
        }

        Console.WriteLine("Fim da playlist.\n");
    }
}

class Program
{
    static void Main()
    {
        Playlist minhaPlaylist = new Playlist();
        minhaPlaylist.AdicionarMusica("Bohemian Rhapsody");
        minhaPlaylist.AdicionarMusica("Stairway to Heaven");
        minhaPlaylist.AdicionarMusica("Hotel California");
        minhaPlaylist.TocarPlaylist();
    }
}