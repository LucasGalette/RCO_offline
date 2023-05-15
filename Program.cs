using System;
using System.Diagnostics;
using static System.Console;
using System.Text;
using System.IO;
using System.Reflection;

namespace ConsoleCRUD
{
    class MainClass
    {
        public static void printMenu(string[] options)
        {
            foreach (string option in options)
            {
                WriteLine(option);
            }
            Write("\nEscolha a sua opção: \n");
        }
        public static void nomes_dos_alunos()
        {
            for (int i = 0; i < nomes.Count; i++)
            {
                WriteLine($"{i + 1} - {nomes[i]}\n");
            }
        }
        public static void Main(String[] args)
        {
            WriteLine(">>>> ESCOLA MUNICIPAL MARINHEIRO POPEYE <<<<\n");
            String[] options = { "1-Cadastrar",
                                 "2-Editar",
                                 "3-Excluir",
                                 "4-Listar dados dos alunos",
                                 "5-Listar alunos aprovados",
                                 "6-Listar alunos de Recuperação",
                                 "7-Listar aluno reprovados",
                                 "8-Dados da turma",
                                 "9-Situação do aluno",
                                 "10-Gravar",
                                 "11-Ler",
                                 "12-Sair\n"};
            int option = 0;
            while (true)
            {
                printMenu(options);
                try
                {
                    option = Convert.ToInt32(ReadLine());
                }
                catch (System.FormatException)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Por favor, digite uma opção entre 1 e " + options.Length);
                    ResetColor();
                    WriteLine();
                    continue;
                }
                catch (Exception)
                {
                    WriteLine("Um erro aconteceu!!");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        Editar();
                        break;
                    case 3:
                        Excluir();
                        break;
                    case 4:
                        Listar_Alunos();
                        break;
                    case 5:
                        Listar_Alunos_Aprovados();
                        break;
                    case 6:
                        Listar_Alunos_de_Recuperacao();
                        break;
                    case 7:
                        Listar_Alunos_Reprovados();
                        break;
                    case 8:
                        Dados_da_turma();
                        break;
                    case 9:
                        Situacao_do_aluno();
                        break;
                    case 10:
                        Gravar();
                        break;
                    case 11:
                        Ler();
                        break;
                    case 12:
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Por favor, digite uma opção entre 1 e " + options.Length);
                        break;
                }
            }
        }
        static List<string> nomes = new List<string>();
        static List<double> notas1 = new List<double>();
        static List<double> notas2 = new List<double>();
        static List<double> notas3 = new List<double>();
        static List<double> notas4 = new List<double>();
        static List<string> reprovados = new List<string>();
        static List<string> recuperacao = new List<string>();
        static List<string> aprovados = new List<string>();
        static List<string> medias = new List<string>();
        static List<string> status_do_aluno = new List<string>();
        private static void Cadastrar()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> CADASTRO DE ALUNOS E NOTAS <<<<\n");
            ResetColor();
            Write("Digite a quantidade de alunos que vão ser cadastrados: ");
            int I = 0;
            try
            {
                I = Convert.ToInt32(ReadLine());
            }
            catch (System.FormatException)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Por favor cabeça de guidão amassado, Digite um número inteiro (ex: 1,2,3,4...).");
                ResetColor();
                ReadKey();
                Clear();
            }
            catch (Exception)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Ocorreu um erro não esperado\n");
                ResetColor();
                ReadKey();
                Clear();
            }

            for (int i = 0; i < I; i++)
            {
                WriteLine("\nDigite o nome do aluno:");
                string nome = ReadLine();
                var repetido = nomes.Any(x => x.Contains(nome));
                if (repetido == true)
                {
                    WriteLine("Esta pessoa já existe em nossa base de dados");
                    ReadKey();
                    Clear();
                }
                else
                {
                    nomes.Add(nome);
                    Write("Digite a 1° nota do aluno: ");
                    notas1.Add(double.Parse(ReadLine()));
                    Write("Digite a 2º nota do aluno: ");
                    notas2.Add(double.Parse(ReadLine()));
                    Write("Digite a 3° nota do aluno: ");
                    notas3.Add(double.Parse(ReadLine()));
                    Write("Digite a 4º nota do aluno: ");
                    notas4.Add(double.Parse(ReadLine()));
                    WriteLine();
                }
            }
            Media();
            Status();
            Clear();
        }
        private static void Editar()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EDITAR ALUNO <<<<\n");
            ResetColor();
            string nome = "";
            nomes_dos_alunos();
            WriteLine("Digite o nome do aluno que você deseja editar:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            if (index >= 0)
            {
                WriteLine(">>>> Regitro que será editado <<<<");
                WriteLine();
                Write($"Nome: {nomes[index]}\n");
                WriteLine($"1º nota: {notas1[index]}\n");
                WriteLine($"2º nota: {notas2[index]}\n");
                WriteLine($"3º nota: {notas3[index]}\n");
                WriteLine($"4º nota: {notas4[index]}\n");
                Write("Digite o novo nome: ");
                nomes[index] = ReadLine();

                WriteLine("Deseja editar as notas do aluno(a)?\n  1- SIM |  2 - NÃO");
                int resposta = Convert.ToInt32(ReadLine());

                if (resposta == 1)
                {
                    WriteLine($"Digite a 1º nota do aluno:");
                    notas1[index] = Convert.ToInt32(ReadLine());

                    WriteLine($"Digite a 2º nota do aluno:");
                    notas2[index] = Convert.ToInt32(ReadLine());

                    WriteLine($"Digite a 3º nota do aluno:");
                    notas3[index] = Convert.ToInt32(ReadLine());

                    WriteLine($"Digite a 4º nota do aluno:");
                    notas4[index] = Convert.ToInt32(ReadLine());

                    WriteLine("NOME E NOTA EDITADO COM SUCESSO!!\n");
                }
                else
                {
                    WriteLine("NOME EDITADO COM SUCESSO!!\n");
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\nRegistro não encontrado");
                WriteLine("Possível causa: \n 1 - Nome inexistente \n 2 - Nome incompleto \n 3 - Nome digitado errado ");
                ResetColor();
                ReadKey();
                Clear();
                Editar();
            }
        }
        public static void Media()
        {
            for (int i = 0; i < nomes.Count; i++)
            {
                string media = Convert.ToString((notas1[i] + notas2[i] + notas3[i] + notas4[i]) / 4);
                medias.Add(media);
            }
        }
        private static void Excluir()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EXCLUSÃO DE ALUNO <<<<\n");
            ResetColor();
            string nome = "";
            nomes_dos_alunos();
            WriteLine("\nDigite o nome do aluno que você deseja excluir:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            int Opcao;
            if (index >= 0)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine(">>>> Regitro que será excluido <<<<\n");
                ResetColor();
                WriteLine($"Nome: {nomes[index]}");
                WriteLine($"1° nota: {notas1[index]}");
                WriteLine($"2° nota: {notas2[index]}");
                WriteLine($"3° nota: {notas3[index]}");
                WriteLine($"4° nota: {notas4[index]}\n");
                WriteLine("Continuar?");
                WriteLine("1-Sim");
                WriteLine("2-Não");
                Opcao = Convert.ToInt32(ReadLine());
                if (Opcao == 1)
                {
                    nomes.RemoveAt(index);
                    notas1.RemoveAt(index);
                    notas2.RemoveAt(index);
                    notas3.RemoveAt(index);
                    notas4.RemoveAt(index);
                    WriteLine("\nAluno excluida com sucesso!!");
                    ReadKey();
                    Clear();
                }
                else
                {
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine("Processo exclusão cancelada!!");
                    ResetColor();
                    ReadKey();
                    Clear();
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Registro não encontrado!!!");
                ResetColor();
                ReadKey();
                Clear();
                Excluir();
            }
        }
        private static void Listar_Alunos()
        {
            Clear();
            WriteLine(">>>> LISTAGEM DE ALUNOS  <<<<\n");
            Media();
            try
            {
                for (int i = 0; i < nomes.Count; i++)
                {
                    WriteLine($"{nomes[i]} | 1° nota: {notas1[i]} | 2° nota: {notas2[i]} | 3° nota: {notas3[i]} | 4° nota: {notas4[i]} | Média {medias[i]}");
                }
                ReadKey();
                Clear();
            }
            catch (System.FormatException)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Ocorreu um erro não esperado\n");
                ResetColor();
                ReadKey();
                Clear();
            }
            catch (Exception)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Ocorreu um erro não esperado\n");
                ResetColor();
                ReadKey();
                Clear();
            }
        }
        public static void Status()
        {
            aprovados.Clear();
            recuperacao.Clear();
            reprovados.Clear();
            for (int i = 0; i < nomes.Count; i++)
            {
                double media = (notas1[i] + notas2[i] + notas3[i] + notas4[i]) / 4;
                if (media >= 7)
                {
                    aprovados.Add(nomes[i]);

                }
                else if (media < 7 && media > 5)
                {

                    recuperacao.Add(nomes[i]);
                }
                else
                {
                    reprovados.Add(nomes[i]);
                }
            }
        }
        public static void Situacao_do_aluno()
        {
            WriteLine("<<<< SITUAÇÃO DO ALUNO >>>>\n");
            nomes_dos_alunos();
            WriteLine();
            Write("Digite o nome do aluno que deseja procurar: ");
            string nome = (ReadLine());
            int index = nomes.IndexOf(nome);
            double media = (notas1[index] + notas2[index] + notas3[index] + notas4[index]) / 4;
            status_do_aluno.Clear();
            if (media >= 7)
            {
                status_do_aluno.Add("Aprovado");
            }
            else if (media < 7 && media > 5)
            {
                status_do_aluno.Add("Recuperação");
            }
            else
            {
                status_do_aluno.Add("Reprovado");
            }
            WriteLine($"{nomes[index]} - 1º nota: {notas1[index]} | 2º nota: {notas2[index]} | 3° nota: {notas3[index]} | 4° nota:{notas4[index]} | Média:{media} | {status_do_aluno[0]} ");
            Status();
            ReadKey();
            Clear();
        }

        public static void Dados_da_turma()
        {
            WriteLine("<<<< DADOS DA TURMA >>>>");
            double nota1 = 0;
            double nota2 = 0;
            double nota3 = 0;
            double nota4 = 0;
            double media_da_turma = 0;
            foreach (var item in notas1)
            {
                nota1 += item;
            }
            foreach (var item2 in notas2)
            {
                nota2 += item2;
            }
            foreach (var item3 in notas3)
            {
                nota3 += item3;
            }
            foreach (var item4 in notas4)
            {
                nota4 += item4;
            }
            media_da_turma = (nota1 + nota2 + nota3 + nota4) / (nomes.Count * 4);
            WriteLine($"\nA média da turma foi de: {media_da_turma.ToString("F")}");
            Status();
            WriteLine($"Número de alunos aprovados: {aprovados.Count}");
            WriteLine($"Número de alunos em recuperação: {recuperacao.Count}");
            WriteLine($"Números de alunos reprovados: {reprovados.Count}");
            ReadKey();
            Clear();
        }
        private static void Listar_Alunos_Aprovados()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> ALUNOS APROVADOS <<<<\n");
            ResetColor();
            for (int i = 0; i < aprovados.Count; i++)
            {
                WriteLine($"{i + 1} - {aprovados[i]} ");
            }
            WriteLine();
            ReadKey();
            Clear();
        }
        private static void Listar_Alunos_de_Recuperacao()
        {
            Clear();
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine(">>>> ALUNOS DE RECUPERAÇÃO <<<<\n");
            ResetColor();
            for (int i = 0; i < recuperacao.Count; i++)
            {
                WriteLine($"{i + 1} - {recuperacao[i]} ");
            }
            WriteLine();
            ReadKey();
            Clear();
        }
        private static void Listar_Alunos_Reprovados()
        {
            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine(">>>> ALUNOS REPROVADOS <<<<\n");
            ResetColor();
            for (int i = 0; i < reprovados.Count; i++)
            {
                WriteLine($"{i + 1} - {reprovados[i]} ");
            }
            WriteLine();
            ReadKey();
            Clear();
        }
        private static void Gravar()
        {
            try
            {
                StreamWriter dados;
                string arquivo = @"C:\Users\user\source\repos\Trabajos\nomes.txt";
                dados = File.CreateText(arquivo);
                foreach (var item in nomes)
                {
                    dados.WriteLine($"{item}");
                }
                dados.Close();
                StreamWriter dados1;
                string arquivo1 = @"C:\Users\user\source\repos\Trabajos\notas1.txt";
                dados1 = File.CreateText(arquivo1);
                foreach (var item1 in notas1)
                {
                    dados1.WriteLine($"{item1}");
                }
                dados1.Close();
                StreamWriter dados2;
                string arquivo2 = @"C:\Users\user\source\repos\Trabajos\notas2.txt";
                dados2 = File.CreateText(arquivo2);
                foreach (var item2 in notas2)
                {
                    dados2.WriteLine($"{item2}");
                }
                dados2.Close();
                StreamWriter dados3;
                string arquivo3 = @"C:\Users\user\source\repos\Trabajos\notas3.txt";
                dados3 = File.CreateText(arquivo3);
                foreach (var item3 in notas3)
                {
                    dados3.WriteLine($"{item3}");
                }
                dados3.Close();
                StreamWriter dados4;
                string arquivo4 = @"C:\Users\user\source\repos\Trabajos\notas4.txt";
                dados4 = File.CreateText(arquivo4);
                foreach (var item4 in notas4)
                {
                    dados4.WriteLine($"{item4}");
                }
                dados4.Close();
                StreamWriter Media;
                string arquivo5 = @"C:\Users\user\source\repos\Trabajos\medias.txt";
                Media = File.CreateText(arquivo5);
                foreach (var medias in medias)
                {
                    Media.WriteLine($"{medias}");
                }
                Media.Close();
                StreamWriter Aprovados;
                string arquivo6 = @"C:\Users\user\source\repos\Trabajos\aprovados.txt";
                Aprovados = File.CreateText(arquivo6);
                foreach (var aprovados in aprovados)
                {
                    Aprovados.WriteLine($"{aprovados}");
                }
                Aprovados.Close();
                StreamWriter Recuperacao;
                string arquivo7 = @"C:\Users\user\source\repos\Trabajos\recuperacao.txt";
                Recuperacao = File.CreateText(arquivo7);
                foreach (var recuperacao in recuperacao)
                {
                    Recuperacao.WriteLine($"{recuperacao}");
                }
                Recuperacao.Close();
                StreamWriter Reprovados;
                string arquivo8 = @"C:\Users\user\source\repos\Trabajos\reprovados.txt";
                Reprovados = File.CreateText(arquivo8);
                foreach (var reprovados in reprovados)
                {
                    Reprovados.WriteLine($"{reprovados}");
                }
                Reprovados.Close();
                WriteLine();
            }
            catch (Exception e)
            {
                WriteLine("Erro: ", e.Message);
            }
            finally
            {
                WriteLine("Dados gravados com sucesso!!\n");
            }
            ReadKey();
            Clear();
        }
        private static void Ler()
        {
            Clear();
            WriteLine(">>>> LENDO AQUIVO <<<<\n");
            var nome = File.ReadAllLines(@"C:\Users\user\source\repos\Trabajos\nomes.txt");
            for (int i = 0; i < nome.Length; i++)
            {
                nomes.Add(nome[i]);
            }
            var nota1 = File.ReadAllLines(@"C:\Users\user\source\repos\Trabajos\notas1.txt");
            for (int x = 0; x < nota1.Length; x++)
            {
                notas1.Add(Convert.ToDouble(nota1[x]));
            }
            var nota2 = File.ReadAllLines(@"C:\Users\user\source\repos\Trabajos\notas2.txt");
            for (int x = 0; x < nota2.Length; x++)
            {
                notas2.Add(Convert.ToDouble(nota2[x]));
            }
            var nota3 = File.ReadAllLines(@"C:\Users\user\source\repos\Trabajos\notas3.txt");
            for (int x = 0; x < nota3.Length; x++)
            {
                notas3.Add(Convert.ToDouble(nota3[x]));
            }
            var nota4 = File.ReadAllLines(@"C:\Users\user\source\repos\Trabajos\notas4.txt");
            for (int x = 0; x < nota4.Length; x++)
            {
                notas4.Add(Convert.ToDouble(nota4[x]));
            }
            var media = File.ReadAllLines(@"C:\Users\user\source\repos\Trabajos\medias.txt");
            for (int x = 0; x < media.Length; x++)
            {
                medias.Add(Convert.ToString(media[x]));
            }
            var AprovadosG = File.ReadAllLines(@"C:\Users\user\source\repos\Trabajos\aprovados.txt");
            for (int x = 0; x < AprovadosG.Length; x++)
            {
                aprovados.Add(AprovadosG[x]);
            }
            var ReprovadoG = File.ReadAllLines(@"C:\Users\user\source\repos\Trabajos\reprovados.txt");
            for (int x = 0; x < ReprovadoG.Length; x++)
            {
                reprovados.Add(ReprovadoG[x]);
            }
            var RecuperacaoG = File.ReadAllLines(@"C:\Users\user\source\repos\Trabajos\recuperacao.txt");
            for (int x = 0; x < RecuperacaoG.Length; x++)
            {
                recuperacao.Add(RecuperacaoG[x]);
            }
            WriteLine("\nLeitura de dados concuída!!");
        }

    }
}