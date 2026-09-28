# Calculadora de Notas

Aplicação Console em C# para gerenciamento simplificado das notas de um aluno. Desenvolvida como Checkpoint individual para praticar lógica de programação, sem uso de Programação Orientada a Objetos.

## Conteúdos praticados

- Variáveis, constantes e operadores
- Estruturas condicionais (`if/else`, `switch` e switch expression)
- Estruturas de repetição (`while`, `for`) com `break` e `continue`
- Arrays
- Métodos (funções locais)
- Entrada e validação de dados com `Console.ReadLine()` e `TryParse()`

## Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download) ou superior

## Como executar

1. Crie um novo projeto Console:

   ```bash
   dotnet new console -n CalculadoraNotas
   cd CalculadoraNotas
   ```

2. Substitua o conteúdo do arquivo `Program.cs` pelo código deste projeto.

3. Execute:

   ```bash
   dotnet run
   ```

## Menu

```
===== CALCULADORA DE NOTAS =====
1 - Cadastrar aluno
2 - Lançar notas
3 - Calcular média
4 - Sair
================================
```

O menu permanece ativo até que a opção **4 - Sair** seja escolhida.

## Funcionalidades

| Opção | Método | Descrição |
|-------|--------|-----------|
| 1 | `CadastrarAluno()` | Solicita e armazena o nome do aluno. Rejeita nome vazio. |
| 2 | `LancarNotas()` | Lê 3 notas e as armazena em um array. Cada nota é validada. |
| 3 | `CalcularMedia()` e `ExibirSituacao()` | Calcula a média das 3 notas e exibe a situação do aluno. |
| 4 | — | Encerra o programa. |

### Critérios de situação

| Média | Situação |
|-------|----------|
| >= 7,0 | Aprovado |
| >= 5,0 e < 7,0 | Recuperação |
| < 5,0 | Reprovado |

## Validações

O programa informa o erro e pede o dado novamente nos seguintes casos:

- Opção de menu não numérica (ex: `abc`) ou fora do intervalo de 1 a 4
- Nota não numérica
- Nota fora do intervalo de 0 a 10
- Nome do aluno vazio ou só com espaços
- Tentativa de lançar notas sem aluno cadastrado
- Tentativa de calcular a média sem notas lançadas

> **Atenção:** as notas são lidas com a cultura `pt-BR`. Use **vírgula** para decimais (ex: `7,5`). Com ponto (`7.5`), a entrada é recusada.

## Constantes utilizadas

```csharp
const double MEDIA_APROVACAO = 7.0;
const double MEDIA_RECUPERACAO = 5.0;
const double NOTA_MINIMA = 0.0;
const double NOTA_MAXIMA = 10.0;
const int QUANTIDADE_NOTAS = 3;
```

## Testes realizados

| Notas | Média | Resultado esperado |
|-------|-------|--------------------|
| 7 / 7 / 7 | 7,00 | Aprovado |
| 5 / 5 / 5 | 5,00 | Recuperação |
| 4 / 3 / 2 | 3,00 | Reprovado |

Entradas inválidas testadas: `abc`, `-1`, `11`, texto vazio e opções de menu inexistentes.

## Estrutura do código

O projeto usa apenas o `Program.cs`, organizado em blocos:

1. **Constantes**: valores fixos do programa
2. **Variáveis do programa**: nome, array de notas e controles de estado
3. **Métodos**: `ExibirMenu`, `LerOpcaoMenu`, `CadastrarAluno`, `LerNota`, `LancarNotas`, `CalcularMedia`, `ExibirSituacao` e `ExecutarCalculoMedia`
4. **Programa principal**: laço do menu com `switch`

## Diferenciais implementados

- Switch expression em `ExibirSituacao()`
- Validações adicionais (ordem das operações e intervalo das notas)
- Menu exibindo o nome do aluno atual
- Código dividido em métodos, sem lógica concentrada no fluxo principal


## Autor
Aluno: Henrique Celso
Rm: 559687
