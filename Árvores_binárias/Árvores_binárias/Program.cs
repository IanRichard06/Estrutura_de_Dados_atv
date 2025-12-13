using System;
public class Node
{
    public int Valor;
    public Node Esquerda;
    public Node Direita;
    public Node(int valor)
    {
        Valor = valor;
        Esquerda = null;
        Direita = null;
    }
}
public class ArvoreBinaria
{
    public Node Raiz;
    public void Inserir(int valor)
    {
        Raiz = InserirRecursivo(Raiz, valor);
    }

    private Node InserirRecursivo(Node atual, int valor)
    {
        if (atual == null) return new Node(valor);
        if (valor < atual.Valor)
            atual.Esquerda = InserirRecursivo(atual.Esquerda, valor);
        else if (valor > atual.Valor)
            atual.Direita = InserirRecursivo(atual.Direita, valor);
        return atual;
    }

    public void ImprimirEmOrdem(Node atual)
    {
        if (atual != null)
        {
            ImprimirEmOrdem(atual.Esquerda);
            Console.Write(atual.Valor + " ");
            ImprimirEmOrdem(atual.Direita);
        }
    }
}
class Program
{
    static void Main()
    {
        ArvoreBinaria arvore = new ArvoreBinaria();
        int[] numeros = { 45, 10, 7, 90, 12, 50, 13, 39, 57 };
        Console.WriteLine("Inserindo: " + string.Join(", ", numeros));
        foreach (int n in numeros) arvore.Inserir(n);
        Console.Write("Árvore Ordenada (Em-Ordem): ");
        arvore.ImprimirEmOrdem(arvore.Raiz);
        Console.WriteLine();
    }
}