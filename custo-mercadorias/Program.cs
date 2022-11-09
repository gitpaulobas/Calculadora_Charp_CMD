// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

string sim_ou_nao2 = "n";
while (sim_ou_nao2 == "n" | sim_ou_nao2 == "N")
{
    Console.WriteLine("Bem vindo a Calculadora de custo de produtos da PJS Comercial: \n");
    Console.Write("Digite o número da nota fiscal: ");
    string numeronota = Console.ReadLine();
    Console.Write("Digite a data da nota fiscal: ");
    string data = Console.ReadLine();


    string sim_ou_nao = "s";
    while (sim_ou_nao == "s" | sim_ou_nao == "S")
    {

        Console.Write("Digite a quantidade total de produtos: ");
        string quantidadetotalstring = Console.ReadLine();
        bool isAlphaBet = Regex.IsMatch(quantidadetotalstring.ToString(), "[a-z]", RegexOptions.IgnoreCase);
        if (isAlphaBet || quantidadetotalstring == "")
        {
            Console.WriteLine("\nVocê digitou um caractere inválido, tente novamente.\n");
        }
        else
        {
            int quantidade_total = int.Parse(quantidadetotalstring);
            Console.Write("Digite o valor total do produto: ");
            Console.Write("R$");
            float valor_total = float.Parse(Console.ReadLine());
            Console.Write("Digite o valor do ICMS ST: ");
            Console.Write("R$");
            float icms_st = float.Parse(Console.ReadLine());
            Console.Write("Digite o valor do IPI: ");
            Console.Write("R$");
            float ipi = float.Parse(Console.ReadLine());
            Console.Write("Outro Estado e Tributada? Não = 0 | Sim = Digite o imposto da nota ( sem % ): ");
            double imposto_estado = float.Parse(Console.ReadLine());
            if (imposto_estado != 0)
            {
                double imposto_total = 18 - imposto_estado;
                Console.Clear();
                Console.WriteLine("Dados do produto:\n");
                Console.WriteLine($"Data: {data}");
                Console.WriteLine($"Número da nota fiscal: {numeronota}\n");
                double valor_unitario = ((valor_total + icms_st + ipi) / quantidade_total);
                double valor_unitario_final = valor_unitario + (valor_unitario * (imposto_total * 0.01));
                string valor_arrendodado = valor_unitario_final.ToString("0.00");
                Console.WriteLine($"Valor unitário do produto R${valor_arrendodado}\n");
                Console.WriteLine($"Para conferência:\nQuantidade total: {quantidade_total} unidades\nValor total: R${valor_total} | Valor ICMS ST: R${icms_st} | Valor IPI: R${ipi}\nDiferença Imposto: {imposto_total}%\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Dados do produto:\n");
                Console.WriteLine($"Data: {data}");
                Console.WriteLine($"Número da nota fiscal: {numeronota}\n");
                double valor_unitario = ((valor_total + icms_st + ipi) / quantidade_total);
                string valor_arrendodado = valor_unitario.ToString("0.00");
                Console.WriteLine($"Valor unitário do produto R${valor_arrendodado}\n");
                Console.WriteLine($"Para conferência:\nQuantidade total: {quantidade_total} unidades\nValor total: R${valor_total} | Valor ICMS ST: R${icms_st} | Valor IPI: R${ipi}\n");
            }


            Console.Write("S = Outro item da nota ou N = Nova nota fiscal: ");
            sim_ou_nao = Console.ReadLine();
            Console.Clear();
            //Teste
        }

    }
}

