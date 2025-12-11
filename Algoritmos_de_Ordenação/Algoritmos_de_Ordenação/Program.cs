using System;
class Program
{
    static void Main()
    {
        
        int[] dadosOriginais = { 72, 54, 59, 30, 31, 78, 2, 77, 82, 72 };
        Console.WriteLine("Vetor Original: " + string.Join(", ", dadosOriginais));
        Console.WriteLine("--------------------------------------------------");
       
        int[] vetorBubble = (int[])dadosOriginais.Clone();
        BubbleSort(vetorBubble);
        Console.WriteLine("Bubble Sort Resultado:    " + string.Join(", ", vetorBubble));
       
        int[] vetorSelection = (int[])dadosOriginais.Clone();
        SelectionSort(vetorSelection);
        Console.WriteLine("Selection Sort Resultado: " + string.Join(", ", vetorSelection));
         
        int[] vetorInsertion = (int[])dadosOriginais.Clone();
        InsertionSort(vetorInsertion);
        Console.WriteLine("Insertion Sort Resultado: " + string.Join(", ", vetorInsertion));
    }
     
    static void BubbleSort(int[] arr)
    {
        int temp;
         
        for (int outer = arr.Length - 1; outer >= 1; outer--)
        {
            
            for (int inner = 0; inner <= outer - 1; inner++)
            {
                if (arr[inner] > arr[inner + 1])
                {
                     
                    temp = arr[inner];
                    arr[inner] = arr[inner + 1];
                    arr[inner + 1] = temp;
                }
            }
        }
    }

   
    static void SelectionSort(int[] arr)
    {
        int min, temp;
        for (int outer = 0; outer < arr.Length; outer++)
        {
            min = outer;  

             
            for (int inner = outer + 1; inner < arr.Length; inner++)
            {
                if (arr[inner] < arr[min])
                {
                    min = inner;
                }
            }

            
            temp = arr[outer];
            arr[outer] = arr[min];
            arr[min] = temp;
        }
    }

    
    static void InsertionSort(int[] arr)
    {
        int inner, temp;
        for (int outer = 1; outer < arr.Length; outer++)
        {
            temp = arr[outer]; 
            inner = outer;
             
            while (inner > 0 && arr[inner - 1] >= temp)
            {
                arr[inner] = arr[inner - 1];
                inner -= 1;
            }
            arr[inner] = temp;  
        }
    }
}