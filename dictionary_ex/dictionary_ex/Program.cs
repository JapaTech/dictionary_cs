namespace dictionary_ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string caminhoArquivo = @"C:\Users\Jonathan\Desktop\Estudo\Generics-Set-Dic\dic_exercicio\dictionary_cs\dictionary_ex\votos.csv";

            Dictionary<string, int> totalVoto = new Dictionary<string, int>();

            try
            {
                using ( StreamReader sr = File.OpenText(caminhoArquivo))
                {
                    while (!sr.EndOfStream) 
                    {
                        string[] votos = sr.ReadLine().Split(',');
                        string pessoa = votos[0];
                        int qtdVotos = int.Parse(votos[1]);

                        if (totalVoto.ContainsKey(pessoa)) 
                        {
                            totalVoto[pessoa] += qtdVotos;
                        }
                        else
                        {
                            totalVoto.Add(pessoa, qtdVotos);
                        }
                    }
                }
                foreach (var item in totalVoto)
                {
                    Console.WriteLine($"{item.Key} votou {item.Value} vezes");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
