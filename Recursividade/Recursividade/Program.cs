using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine(
            "Digite o caminho de uma pasta (ex: C:\\Windows\\Web ou . para atual):"
        );

        string caminhoInicial = Console.ReadLine() ?? ".";

        if (caminhoInicial == ".")
            caminhoInicial = Directory.GetCurrentDirectory();

        try
        {
            Console.WriteLine($"\nExplorando: {caminhoInicial}\n");
            ExplorarDiretorios(caminhoInicial, 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao acessar pasta: " + ex.Message);
        }
    }

    // Função recursiva
    static void ExplorarDiretorios(string caminho, int nivel)
    {
        try
        {
            // Indentação visual baseada no nível de recursão
            string indentacao = new string('-', nivel * 2);

            // 1. Processar arquivos da pasta atual
            string[] arquivos = Directory.GetFiles(caminho);
            foreach (string arquivo in arquivos)
            {
                Console.WriteLine($"{indentacao} 📄 {Path.GetFileName(arquivo)}");
            }

            // 2. Chamada recursiva para cada subdiretório
            string[] subDiretorios = Directory.GetDirectories(caminho);
            foreach (string dir in subDiretorios)
            {
                Console.WriteLine($"{indentacao} 📁 [{Path.GetFileName(dir)}]");
                ExplorarDiretorios(dir, nivel + 1);
            }
        }
        catch (UnauthorizedAccessException)
        {
            // Ignora pastas sem permissão de acesso
        }
    }
}