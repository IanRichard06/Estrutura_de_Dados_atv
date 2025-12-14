using System;
using System.Collections.Generic;

class Processo
{
    public string Nome { get; set; }
    public int Prioridade { get; set; }

    public Processo(string nome, int prioridade)
    {
        Nome = nome;
        Prioridade = prioridade;
    }
}

class FilaPrioridade
{
    private List<Processo> heap = new List<Processo>();

    public void Enfileirar(Processo processo)
    {
        heap.Add(processo);
        Subir(heap.Count - 1);
    }

    public Processo Desenfileirar()
    {
        if (heap.Count == 0)
            return null;

        Processo processo = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        Descer(0);

        return processo;
    }

    private void Subir(int indice)
    {
        while (indice > 0)
        {
            int pai = (indice - 1) / 2;

            if (heap[indice].Prioridade <= heap[pai].Prioridade)
                break;

            Trocar(indice, pai);
            indice = pai;
        }
    }

    private void Descer(int indice)
    {
        while (true)
        {
            int esquerdo = 2 * indice + 1;
            int direito = 2 * indice + 2;
            int maior = indice;

            if (esquerdo < heap.Count && heap[esquerdo].Prioridade > heap[maior].Prioridade)
                maior = esquerdo;

            if (direito < heap.Count && heap[direito].Prioridade > heap[maior].Prioridade)
                maior = direito;

            if (maior == indice)
                break;

            Trocar(indice, maior);
            indice = maior;
        }
    }

    private void Trocar(int a, int b)
    {
        Processo temp = heap[a];
        heap[a] = heap[b];
        heap[b] = temp;
    }

    public bool EstaVazia()
    {
        return heap.Count == 0;
    }
}

class Program
{
    static void Main()
    {
        FilaPrioridade fila = new FilaPrioridade();

        fila.Enfileirar(new Processo("Chrome", 2));
        fila.Enfileirar(new Processo("Antivirus", 5));
        fila.Enfileirar(new Processo("Editor de Texto", 1));
        fila.Enfileirar(new Processo("Sistema", 10));

        Console.WriteLine("CPU em execução...\n");

        while (!fila.EstaVazia())
        {
            Processo atual = fila.Desenfileirar();
            Console.WriteLine($"Executando processo: {atual.Nome} | Prioridade: {atual.Prioridade}");
            System.Threading.Thread.Sleep(1000);
        }

        Console.WriteLine("\nTodos os processos foram executados.");
    }
}