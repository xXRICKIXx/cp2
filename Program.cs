using System.Globalization;

// ===================== CONSTANTES =====================
const double MEDIA_APROVACAO = 7.0;
const double MEDIA_RECUPERACAO = 5.0;
const double NOTA_MINIMA = 0.0;
const double NOTA_MAXIMA = 10.0;
const int QUANTIDADE_NOTAS = 3;

// ===================== VARIÁVEIS DO PROGRAMA =====================
CultureInfo cultura = CultureInfo.GetCultureInfo("pt-BR");
string nomeAluno = "";
double[] notas = new double[QUANTIDADE_NOTAS];
bool alunoCadastrado = false;
bool notasLancadas = false;
int opcao;

// ===================== MÉTODOS =====================
void ExibirMenu()
{
    Console.WriteLine();
    Console.WriteLine("===== CALCULADORA DE NOTAS =====");
    if (alunoCadastrado)
    {
        Console.WriteLine($"Aluno atual: {nomeAluno}");
    }
    Console.WriteLine("1 - Cadastrar aluno");
    Console.WriteLine("2 - Lançar notas");
    Console.WriteLine("3 - Calcular média");
    Console.WriteLine("4 - Sair");
    Console.WriteLine("================================");
}

int LerOpcaoMenu()
{
    int opcaoLida;

    while (true)
    {
        Console.Write("Escolha uma opção: ");
        string entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out opcaoLida))
        {
            Console.WriteLine("Entrada inválida! Digite apenas números (1 a 4).");
            continue;
        }

        if (opcaoLida < 1 || opcaoLida > 4)
        {
            Console.WriteLine("Opção inexistente! Escolha um número de 1 a 4.");
            continue;
        }

        break;
    }

    return opcaoLida;
}

void CadastrarAluno()
{
    while (true)
    {
        Console.Write("Digite o nome do aluno: ");
        string entrada = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(entrada))
        {
            Console.WriteLine("O nome não pode ser vazio. Tente novamente.");
            continue;
        }

        nomeAluno = entrada.Trim();
        alunoCadastrado = true;
        break;
    }

    // Um novo aluno começa sem notas
    notasLancadas = false;
    Console.WriteLine($"Aluno '{nomeAluno}' cadastrado com sucesso!");
}

double LerNota(int numeroNota)
{
    double nota;

    while (true)
    {
        Console.Write($"Digite a {numeroNota}ª nota ({NOTA_MINIMA} a {NOTA_MAXIMA}): ");
        string entrada = Console.ReadLine();

        if (!double.TryParse(entrada, NumberStyles.Float, cultura, out nota))
        {
            Console.WriteLine("Entrada inválida! Digite um número (use vírgula para decimais, ex: 7,5).");
            continue;
        }

        if (nota < NOTA_MINIMA || nota > NOTA_MAXIMA)
        {
            Console.WriteLine($"Nota fora do intervalo! Digite um valor entre {NOTA_MINIMA} e {NOTA_MAXIMA}.");
            continue;
        }

        break;
    }

    return nota;
}

void LancarNotas()
{
    if (!alunoCadastrado)
    {
        Console.WriteLine("Cadastre um aluno primeiro (opção 1).");
        return;
    }

    Console.WriteLine($"Lançando notas de {nomeAluno}:");

    for (int i = 0; i < notas.Length; i++)
    {
        notas[i] = LerNota(i + 1);
    }

    notasLancadas = true;
    Console.WriteLine("Notas lançadas com sucesso!");
}

double CalcularMedia()
{
    double soma = 0;

    for (int i = 0; i < notas.Length; i++)
    {
        soma += notas[i];
    }

    return soma / notas.Length;
}

void ExibirSituacao(double media)
{
    string situacao = media switch
    {
        >= MEDIA_APROVACAO => "Aprovado",
        >= MEDIA_RECUPERACAO => "Recuperação",
        _ => "Reprovado"
    };

    Console.WriteLine($"Aluno: {nomeAluno}");
    Console.WriteLine($"Média: {media:F2}");
    Console.WriteLine($"Situação: {situacao}");
}

void ExecutarCalculoMedia()
{
    if (!alunoCadastrado)
    {
        Console.WriteLine("Cadastre um aluno primeiro (opção 1).");
        return;
    }

    if (!notasLancadas)
    {
        Console.WriteLine("Lance as notas primeiro (opção 2).");
        return;
    }

    double media = CalcularMedia();
    ExibirSituacao(media);
}

// ===================== PROGRAMA PRINCIPAL =====================
while (true)
{
    ExibirMenu();
    opcao = LerOpcaoMenu();

    if (opcao == 4)
    {
        Console.WriteLine("Encerrando o programa. Até logo!");
        break;
    }

    switch (opcao)
    {
        case 1:
            CadastrarAluno();
            break;
        case 2:
            LancarNotas();
            break;
        case 3:
            ExecutarCalculoMedia();
            break;
    }
}
