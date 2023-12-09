using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoPED
{
    internal class Program
    {
        public class Produto
        {
            public string Pnome;
            public double Upreco;
            public int idProduto;
            public string MDunidade;
            public double quantidadeDis;
            public string areaP;

        }

        public class Cliente
        {
            public int idCliente;
            public string cidade;
            public string Cnome;
            public int anoNascimento;
        }
        public class Venda
        {
            public int idCliente;
            public double quantidadeD;
            public string areaV;
            public string Cnome;
            public string Pnome;
            public double precoT;
            public double Upreco;
            public double quantidadeC;
        }
        public static System.Text.Encoding UTF8 { get; }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Dictionary<string, List<Cliente>> clientes = new Dictionary<string, List<Cliente>>();
            Dictionary<string, List<Produto>> loja = new Dictionary<string, List<Produto>>();
            List<Venda> vendas = new List<Venda>();
            string caminho = "../../../Ficheiros/", nome, nomecid;
            double mediaCid, maisCaro;
            bool verificar, input = false, input2 = true;
            string areamaior, resposta, confirmaçao;
            int opcao, numeroP, idade, contaIda, contaNomes, id, numeroP1;
            lerficheiroVendas(vendas, caminho + "Venda.txt");
            lerficheiroClientes(clientes, caminho + "Clientes.txt");
            lerficheiroLoja(loja, caminho + "Loja.txt");
            while (input2 == true)
            {
                try
                {
                    do
                    {
                        Console.WriteLine("\n-------  MENU  -------");
                        Console.WriteLine("Escolha uma opção ");
                        Console.WriteLine("1 - Introduza um produto novo");
                        Console.WriteLine("2 - Introduza um cliente novo");
                        Console.WriteLine("3 - Mostrar os produtos");
                        Console.WriteLine("4 - Cidade com mais clientes");
                        Console.WriteLine("5 - Idade média dos clientes");
                        Console.WriteLine("6 - Área com mais produtos");
                        Console.WriteLine("7 - Compra de produto");
                        Console.WriteLine("8 - Verificar se existe em stock");
                        Console.WriteLine("9 - Verifique o seu histórico de compras");
                        Console.WriteLine("10 - Pessoas com idade superior a idade a inserir");
                        Console.WriteLine("11 - Número de pessoas em que existem na cidade a inserir");
                        Console.WriteLine("12 - Verificar se existe nome inserido");
                        Console.WriteLine("13 - Verificar se produto inserido existe");
                        Console.WriteLine("14 - Produtos de maior receita");
                        Console.WriteLine("15 - Qual o produto mais caro?");
                        Console.WriteLine("16 - ");
                        Console.WriteLine("17 - Maior área vendida");
                        Console.WriteLine("18 - Cliente que gastou mais");
                        Console.WriteLine("19 - Preço medio dos produtos por area");
                        Console.WriteLine("0 - Sair");
                        Console.WriteLine("**************************\n");
                        opcao = Convert.ToInt32(Console.ReadLine());
                        switch (opcao)
                        {
                            case 1:
                                Console.Write("\nIntroduza o número de produtos que pretenda adicionar:");
                                numeroP = Convert.ToInt32(Console.ReadLine());
                                ProdutoNovo(loja, numeroP, caminho);
                                break;
                            case 2:
                                Console.Write("\nIntroduza o número de clientes que pretenda adicionar:");
                                numeroP1 = Convert.ToInt32(Console.ReadLine());
                                AdicionarClientes(clientes, numeroP1, caminho);
                                break;
                            case 3:
                                mostrarProdutos(loja);
                                break;
                            case 4:
                                Console.WriteLine("A cidade com mais clientes é " + cidademaisClientes(clientes) + ".");
                                break;
                            case 5:
                                mediaCid = mediaidades(clientes);
                                Console.WriteLine("A média de idades dos clientes é " + mediaCid);
                                break;
                            case 6:
                                areamaior = areamaisProdutos(loja);
                                Console.WriteLine("A área com mais produtos é " + areamaior + ".");
                                break;
                            case 7:
                                CompraProduto(vendas, loja, clientes, caminho);
                                Console.WriteLine("Pretende gravar na base de dados? Insira S/N ");
                                resposta = Console.ReadLine();
                                if (resposta == "S")
                                {
                                    GravarFicheiroVenda(vendas, caminho + "Venda.txt");
                                    GravarFicheiroProduto(loja, caminho + "Loja.txt");
                                }
                                break;
                            case 8:
                                stockBaixoMostrar(loja);
                                break;
                            case 9:
                                while (input == false)
                                {
                                    Console.WriteLine("Qual o nome que deseja verificar nas compras?");
                                    nome = Console.ReadLine();
                                    input = mostrarComprasCliente(vendas, nome);
                                    if (input == false)
                                    {
                                        Console.WriteLine("O nome inserido nao existe, introduza um novo  nome válido!");
                                    }
                                }
                                break;
                            case 10:
                                Console.WriteLine("De qual idade deseja verificar quantos clientes existe acima dela");
                                idade = Convert.ToInt32(Console.ReadLine());
                                contaIda = numeroPessoasAcimaIdade(clientes, idade);
                                Console.WriteLine("Existe " + contaIda + " acima da idade inserida (" + idade + ")");
                                break;
                            case 11:
                                Console.WriteLine("Qual nome para  verificar se existe?");
                                nome = Console.ReadLine();
                                Console.WriteLine("E  a cidade?");
                                nomecid = Console.ReadLine();
                                contaNomes = contarNomes(clientes, nome, nomecid);
                                Console.WriteLine("Com o nome (" + nome + ") existe " + contaNomes + " pessoa(s) na cidade (" + nomecid + ").");
                                break;
                            case 12:
                                Console.WriteLine("Qual nome deseja pretende ver se existe?");
                                nome = Console.ReadLine();
                                verificar = verificarCliente(clientes, nome);
                                if (verificar == true)
                                {
                                    Console.WriteLine("O nome inserido existe.");
                                }
                                else
                                {
                                    Console.WriteLine("O nome inserido  não existe");
                                }
                                break;
                            case 13:
                                Console.WriteLine("Qual o id que pretende ver  se existe?");
                                id = Convert.ToInt32(Console.ReadLine());
                                verificarProdPorCodigo(loja, id);
                                break;
                            case 14:
                                geraMaisReceita(vendas);
                                break;
                            case 15:
                                maisCaro = prodMaisCaro(loja);
                                Console.WriteLine("O produto mais caro é: " + maisCaro);
                                break;
                            case 16:
                                break;
                            case 17:
                                areaMaisvendida(vendas);
                                break;
                            case 18:
                                clienteMaisgasto(vendas);
                                break;
                            case 19:
                                mediaPrecoArea(loja);
                                break;
                            case 0:
                                Console.WriteLine("Pretende gravar na base de dados? Insira S/N ");
                                confirmaçao = Console.ReadLine();
                                if (confirmaçao == "S" || confirmaçao == "s")
                                {
                                    GravarFicheiroVenda(vendas, caminho + "Venda.txt");
                                    GravarFicheiroProduto(loja, caminho + "Loja.txt");
                                    GravarFicheiroCliente(clientes, caminho + "Clientes.txt");
                                }
                                break;
                            default:
                                Console.WriteLine("Opção Inválida!");
                                break;
                        }
                    } while (opcao != 0);
                }
                catch (Exception)
                {
                    Console.WriteLine("Use apenas  números!");
                }
            }
        }


        public static void lerficheiroClientes(Dictionary<string, List<Cliente>> clientes, string caminho)
        {
            StreamReader F = new StreamReader(caminho);
            try
            {
                string linha, cid;
                string[] parts;
                List<Cliente> lista;
                cid = F.ReadLine();
                while (cid != null)
                {
                    lista = new List<Cliente>();
                    clientes.Add(cid, lista);
                    linha = F.ReadLine();
                    while (linha.Equals("----------------------------------------------") == false)
                    {
                        parts = linha.Split(';');
                        Cliente p = new Cliente();
                        p.idCliente = Convert.ToInt32(parts[0]);
                        p.Cnome = parts[1].Trim();
                        p.cidade = parts[2];
                        p.anoNascimento = Convert.ToInt32(parts[3]);
                        p.cidade = cid;
                        clientes[cid].Add(p);
                        linha = F.ReadLine();
                    }


                    cid = F.ReadLine();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ficheiro nao foi  encontrado!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro de I/O: " + e.Message);

            }
            catch (Exception err)
            {
                Console.WriteLine("Erro geral na execução: " + err.Message);
            }
            finally
            {
                if (F != null)
                    F.Close();
            }
        }

        public static void lerficheiroLoja(Dictionary<string, List<Produto>> dici, string caminho)
        {
            StreamReader F = new StreamReader(caminho);
            try
            {
                string linha, area;
                string[] parts;
                List<Produto> lista;
                area = F.ReadLine();
                while (area != null)
                {
                    lista = new List<Produto>();
                    dici.Add(area, lista);
                    linha = F.ReadLine();
                    while (linha.Equals("----------------------------------------------") == false)
                    {
                        parts = linha.Split(';');
                        Produto p = new Produto();
                        p.idProduto = Convert.ToInt32(parts[0]);
                        p.Pnome = parts[1].Trim();
                        p.Upreco = Convert.ToDouble(parts[2]);
                        p.MDunidade = parts[3];
                        p.quantidadeDis = Convert.ToDouble(parts[4]);
                        dici[area].Add(p);
                        linha = F.ReadLine();
                    }
                    area = F.ReadLine();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ficheiro nao foi  encontrado!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro de I/O: " + e.Message);

            }
            catch (Exception err)
            {
                Console.WriteLine("Erro geral na execução: " + err.Message);
            }
            finally
            {
                if (F != null)
                    F.Close();
            }
        }

        public static void lerficheiroVendas(List<Venda> lista, string caminho)
        {
            StreamReader F = new StreamReader(caminho);
            try
            {
                String linha;
                String[] parts;
                while ((linha = F.ReadLine()) != null)
                {
                    parts = linha.Split(';');
                    Venda p = new Venda();
                    p.idCliente = Convert.ToInt32(parts[0]);
                    p.Cnome = parts[1];
                    p.areaV = parts[2];
                    p.Pnome = parts[3];
                    p.Upreco = Convert.ToDouble(parts[4]);
                    p.quantidadeD = Convert.ToDouble(parts[5]);
                    p.quantidadeC = Convert.ToDouble(parts[6]);
                    p.precoT = Convert.ToDouble(parts[7]);
                    lista.Add(p);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ficheiro não foi encontrado!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro de I/O: " + e.Message);

            }
            catch (Exception err)
            {
                Console.WriteLine("Erro geral na execução: " + err.Message);
            }
            finally
            {
                if (F != null)
                    F.Close();
            }
        }

        public static void ProdutoNovo(Dictionary<string, List<Produto>> dici, int numeroP, string caminho)
        {
            List<Produto> lista;
            string area;
            bool input = true;
            for (int i = 0; i < numeroP; i++)
            {
                Produto p = new Produto();
                {
                    Console.Write("\nÁrea: ");
                    p.areaP = Console.ReadLine();
                    area = p.areaP.Trim();
                } while (p.areaP.Trim() == "") ;

                while (input == true)
                {
                    try
                    {
                        Console.Write("\nId: ");
                        p.idProduto = Convert.ToInt32(Console.ReadLine());
                        input = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Insira um número!");
                    }

                }
                input = true;

                do
                {
                    Console.Write("Nome do Produto: ");
                    p.Pnome = Console.ReadLine();
                } while (p.Pnome.Trim() == "");

                while (input == true)
                {
                    try
                    {
                        do
                        {
                            Console.Write("Preço: ");
                            p.Upreco = Convert.ToDouble(Console.ReadLine());
                            input = false;
                        } while (p.Upreco <= 0);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Insira um número!");
                    }

                }
                input = true;

                do
                {
                    Console.Write("Unidade de Medida(kg ou und): ");
                    p.MDunidade = Console.ReadLine();

                } while (p.MDunidade.Trim().ToLower() != "kg" && p.MDunidade.Trim().ToLower() != "und");

                while (input == true)
                {
                    try
                    {
                        do
                        {
                            do
                            {
                                Console.Write("Stock: ");
                                p.quantidadeDis = Convert.ToDouble(Console.ReadLine());
                                input = false;
                            } while (p.quantidadeDis / Math.Truncate(p.quantidadeDis) != 1 && p.MDunidade == "und");
                        } while (p.quantidadeDis <= 0);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Insira um número!");
                    }

                }
                input = true;

                if (dici.ContainsKey(area) == false)
                {
                    lista = new List<Produto>();
                    lista.Add(p);
                    dici.Add(area, lista);
                }
                else
                    dici[area].Add(p);
            }
            string confirmaçao;
            Console.WriteLine("Pretende gravar na base de dados? Insira S/N ");
            confirmaçao = Console.ReadLine().ToLower();
            if (confirmaçao == "S")
            {
                GravarFicheiroProduto(dici, caminho + "Loja.txt");
            }
        }

        public static void GravarFicheiroProduto(Dictionary<string, List<Produto>> produto, string caminho)
        {
            StreamWriter writer = new StreamWriter(caminho);
            try
            {
                foreach (KeyValuePair<string, List<Produto>> prod in produto)
                {
                    writer.WriteLine(prod.Key);
                    foreach (Produto prodw in prod.Value)
                    {
                        writer.WriteLine("\t" + prodw.idProduto + ";" + prodw.Pnome + ";" + prodw.Upreco + ";" + prodw.MDunidade + ";" + prodw.quantidadeDis);
                    }
                    writer.WriteLine("----------------------------------------------");
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message, "Erro!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static void AdicionarClientes(Dictionary<string, List<Cliente>> clientes, int numeroP1, string caminho)
        {
            List<Cliente> lista;
            string cidade;
            bool input = true;
            for (int i = 0; i < numeroP1; i++)
            {
                Cliente p = new Cliente();
                while (input == true)
                {
                    try
                    {
                        Console.Write("\nId do Cliente: ");
                        p.idCliente = Convert.ToInt32(Console.ReadLine());
                        input = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Insira um número!");
                    }

                }
                input = true;

                do
                {
                    Console.Write("Nome do Cliente: ");
                    p.Cnome = Console.ReadLine();
                } while (p.Cnome.Trim() == "");

                do
                {
                    Console.Write("Cidade: ");
                    p.cidade = Console.ReadLine();
                    cidade = p.cidade.Trim();
                } while (p.cidade.Trim() == "");

                while (input == true)
                {
                    try
                    {
                        do
                        {
                            Console.Write("Data de Nascimento: (no formato yyyymmdd)");
                            p.anoNascimento = Convert.ToInt32(Console.ReadLine());
                            input = false;
                        } while (p.anoNascimento <= 0);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Insira um número!");
                    }

                }
                input = true;

                if (clientes.ContainsKey(cidade) == false)
                {
                    lista = new List<Cliente>();
                    lista.Add(p);
                    clientes.Add(cidade, lista);
                }
                else
                    clientes[cidade].Add(p);
                string confirmaçao = "";
                Console.WriteLine("Pretende gravar na base de dados? Insira S/N ");
                confirmaçao = Console.ReadLine();
                if (confirmaçao == "S")
                {
                    GravarFicheiroCliente(clientes, caminho + "Clientes.txt");
                }
            }
        }

        public static void GravarFicheiroCliente(Dictionary<string, List<Cliente>> clientes, string caminho)
        {
            StreamWriter writer = new StreamWriter(caminho);

            try
            {

                foreach (KeyValuePair<string, List<Cliente>> cliente in clientes)
                {
                    writer.WriteLine(cliente.Key);
                    foreach (Cliente pes in cliente.Value)
                    {
                        writer.WriteLine("\t" + pes.idCliente + ";" + pes.Cnome + ";" + pes.cidade + ";" + pes.anoNascimento);
                    }
                    writer.WriteLine("----------------------------------------------");
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message, "Erro!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static void GravarFicheiroVenda(List<Venda> vendas, string caminho)
        {
            StreamWriter writer = new StreamWriter(caminho);

            try
            {
                foreach (Venda v in vendas)
                {
                    writer.WriteLine(v.idCliente + ";" + v.Cnome + ";" + v.areaV + ";" + v.Pnome + ";" + v.Upreco + ";" + v.quantidadeD + ";" + v.quantidadeC + ";" + v.precoT);
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message, "Erro!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static void mostrarProdutos(Dictionary<string, List<Produto>> loja)
        {
            foreach (KeyValuePair<string, List<Produto>> mostrar in loja)
            {
                Console.WriteLine(mostrar.Key + " -> ");
                foreach (Produto prod in mostrar.Value)
                {

                    Console.WriteLine("\t" + prod.idProduto + " - " + prod.Pnome + " - " + prod.Upreco + "€" + " - " + prod.quantidadeDis + " " + prod.MDunidade);
                }
            }
        }

        public static string cidademaisClientes(Dictionary<string, List<Cliente>> clientes)
        {
            int maior = -100;
            string cidademaior = "";
            foreach (KeyValuePair<string, List<Cliente>> mostrar in clientes)
            {
                if (mostrar.Value.Count() > maior)
                {
                    maior = mostrar.Value.Count();
                    cidademaior = mostrar.Key;
                }
            }
            return cidademaior;
        }

        public static double mediaidades(Dictionary<string, List<Cliente>> clientes)
        {
            int soma = 0, dataNasc, hoje, idade, cont = 0;
            double media;
            foreach (KeyValuePair<string, List<Cliente>> elem in clientes)
            {
                foreach (Cliente pes in elem.Value)
                {
                    dataNasc = pes.anoNascimento;
                    hoje = 2022;
                    idade = hoje - dataNasc;
                    soma = soma + idade;
                    cont++;
                }
            }
            media = (double)soma / cont;
            return media;
        }


        public static string areamaisProdutos(Dictionary<string, List<Produto>> loja)
        {
            int maior = -100;
            string maiorarea = "";
            foreach (KeyValuePair<string, List<Produto>> prod in loja)
            {
                if (prod.Value.Count > maior)
                {
                    maior = prod.Value.Count;
                    maiorarea = prod.Key;
                }
            }
            return maiorarea;
        }

        public static string CompraProduto(List<Venda> lista, Dictionary<string, List<Produto>> loja, Dictionary<string, List<Cliente>> clientes, string caminho)
        {
            Venda v = new Venda();
            string nome, nomeProd;
            Console.WriteLine("Qual é o seu nome?");
            nome = Console.ReadLine();
            string nEnco = "";
            bool encontrou = false;
            foreach (KeyValuePair<string, List<Cliente>> mostrar in clientes)
            {
                foreach (Cliente cliente in mostrar.Value)
                {
                    if (cliente.Cnome.ToLower() == nome.ToLower())
                    {
                        v.idCliente = cliente.idCliente;
                        encontrou = true;
                        v.Cnome = cliente.Cnome;
                    }
                }
            }
            if (encontrou == false)
            {
                nEnco = "O  nome inserido  não existe";
                Console.WriteLine(nEnco);
                return nEnco;
            }
            encontrou = false;
            mostrarProdutos(loja);
            Console.WriteLine("Qual produto que deseja comprar?");
            nomeProd = Console.ReadLine();
            foreach (KeyValuePair<string, List<Produto>> mostra in loja)
            {
                foreach (Produto prod in mostra.Value)
                {
                    if (prod.Pnome.ToLower().Trim() == nomeProd.ToLower())
                    {
                        encontrou = true;
                        v.Pnome = prod.Pnome;
                        v.Upreco = prod.Upreco;
                        v.quantidadeD = prod.quantidadeDis;
                        v.areaV = mostra.Key;
                        Console.WriteLine("Quantos deseja comprar?");
                        v.quantidadeC = Convert.ToDouble(Console.ReadLine());
                        while (v.quantidadeC > v.quantidadeD || v.quantidadeC < 0)
                        {
                            Console.WriteLine("Só existe " + v.quantidadeD + " disponivel .Insira uma quantidade válida");
                            Console.WriteLine("Quantos deseja comprar?");
                            v.quantidadeC = Convert.ToDouble(Console.ReadLine());

                        }

                        prod.quantidadeDis = prod.quantidadeDis - v.quantidadeC;
                        v.precoT = prod.Upreco * v.quantidadeC;
                        v.quantidadeD = prod.quantidadeDis;
                    }

                }
            }
            if (encontrou == false)
            {
                nEnco = "O produto nao  existe";
                Console.WriteLine(nEnco);
                return nEnco;
            }
            lista.Add(v);
            nEnco = "Compra efetuada!";
            Console.WriteLine(nEnco);
            return nEnco;
        }

        public static void stockBaixoMostrar(Dictionary<string, List<Produto>> loja)
        {
            Console.WriteLine("Produtos que necessitam de repor stock!!!! (quantidade menor que 3");
            foreach (KeyValuePair<string, List<Produto>> mostrar in loja)
            {

                foreach (Produto prod in mostrar.Value)
                {
                    if (prod.quantidadeDis < 3)
                    {
                        Console.WriteLine(mostrar.Key + " -> ");
                        Console.WriteLine("\t" + prod.idProduto + " - " + prod.Pnome + " - " + prod.Upreco + " - " + prod.MDunidade + " - " + prod.quantidadeDis);

                    }
                }
            }
        }

        public static bool mostrarComprasCliente(List<Venda> vendas, string nome)
        {
            bool input = false;
            foreach (Venda v in vendas)
            {
                if (nome.ToLower() == v.Cnome.ToLower())
                {
                    Console.WriteLine(v.idCliente + ";" + v.Cnome + ";" + v.Pnome + ";" + v.quantidadeC + ";" + v.Upreco);
                    input = true;
                }
            }
            return input;
        }

        public static int numeroPessoasAcimaIdade(Dictionary<string, List<Cliente>> clientes, int idadeIntr)
        {
            int contaP = 0;
            int dataNasc, hoje, idade;
            foreach (KeyValuePair<string, List<Cliente>> mostrar in clientes)
            {
                foreach (Cliente pes in mostrar.Value)
                {
                    dataNasc = pes.anoNascimento;
                    hoje = 2022;
                    idade = hoje - dataNasc;
                    if (idadeIntr > idade)
                    {

                        contaP++;
                    }
                }

            }

            return contaP;
        }

        public static int contarNomes(Dictionary<string, List<Cliente>> clientes, string nome, string nomecid)
        {
            int count = 0;
            string[] partes;

            foreach (KeyValuePair<string, List<Cliente>> mostrar in clientes)
            {
                foreach (Cliente pes in mostrar.Value)
                {
                    partes = pes.Cnome.Split(' ');
                    if (nomecid.ToLower() == pes.cidade.ToLower())
                    {
                        for (int n = 0; n < partes.Length; n++)
                        {
                            if (partes[n].ToLower() == nome.ToLower())
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }

        public static bool verificarCliente(Dictionary<string, List<Cliente>> clientes, string nome)
        {
            bool verificar = false;
            foreach (KeyValuePair<string, List<Cliente>> mostrar in clientes)
            {
                foreach (Cliente cliente in mostrar.Value)
                {
                    if (cliente.Cnome.ToLower() == nome.ToLower())
                    {
                        verificar = true;

                    }
                }
            }
            return verificar;
        }

        public static void verificarProdPorCodigo(Dictionary<string, List<Produto>> loja, int id)
        {
            bool verifica = false;
            foreach (KeyValuePair<string, List<Produto>> mostrar in loja)
            {
                foreach (Produto prod in mostrar.Value)
                {
                    if (prod.idProduto == id)
                    {
                        verifica = true;
                        Console.WriteLine(mostrar.Key + " -> " + prod.Pnome + " -> " + prod.quantidadeDis);
                    }
                }
            }
            if (verifica == false)
            {
                Console.Write("Esse id não está associado a nenhum produto");
            }
        }

        public static double prodMaisCaro(Dictionary<string, List<Produto>> loja)
        {
            double maior = 0;
            foreach (KeyValuePair<string, List<Produto>> mostrar in loja)
            {
                foreach (Produto prod in mostrar.Value)
                {
                    if (prod.Upreco > maior)
                    {
                        maior = prod.Upreco;
                    }
                }
            }
            return maior;
        }

        public static void mediaPrecoArea(Dictionary<string, List<Produto>> loja)
        {
            double media;
            double soma = 0;

            foreach (KeyValuePair<string, List<Produto>> mostrar in loja)
            {
                foreach (Produto prod in mostrar.Value)
                {
                    soma = soma + prod.Upreco;

                }

                media = soma / mostrar.Value.Count();
                Console.WriteLine("A media de preços d´" + mostrar.Key + " é de: " + media);
            }

        }

        public static void geraMaisReceita(List<Venda> vendas)
        {
            Dictionary<string, double> maisreceita = new Dictionary<string, double>();
            string produto;
            double gastocliente;
            double maior = 0;
            foreach (Venda v in vendas)
            {
                produto = v.Pnome;
                gastocliente = v.precoT;
                if (maisreceita.ContainsKey(produto))
                {
                    maisreceita[produto] = gastocliente + gastocliente;
                }
                else
                {
                    maisreceita.Add(produto, gastocliente);
                }
            }
            foreach (KeyValuePair<string, double> receita in maisreceita)
            {
                if (receita.Value >= maior)
                {
                    maior = receita.Value;
                }
            }
            foreach (KeyValuePair<string, double> receita in maisreceita)
            {
                if (receita.Value == maior)
                {
                    Console.WriteLine("O produto que gera mais receita (" + maior + "€) é " + receita.Key + ".");
                }
            }
        }

        public static void areaMaisvendida(List<Venda> vendas)
        {
            Dictionary<string, double> areavend = new Dictionary<string, double>();
            string area;
            double quant;
            double maior = -100;
            foreach (Venda v in vendas)
            {
                area = v.areaV;
                quant = v.quantidadeC;
                if (areavend.ContainsKey(area))
                {
                    areavend[area] = quant + quant;
                }
                else
                {
                    areavend.Add(area, quant);
                }
            }
            foreach (KeyValuePair<string, double> receita in areavend)
            {
                if (receita.Value >= maior)
                {
                    maior = receita.Value;
                }
            }
            foreach (KeyValuePair<string, double> receita in areavend)
            {
                if (receita.Value == maior)
                {
                    Console.WriteLine("A área mais vendida é " + receita.Key + " com um total de  " + maior + " produtos.");
                }
            }
        }

        public static void clienteMaisgasto(List<Venda> vendas)
        {
            Dictionary<string, double> clientegastos = new Dictionary<string, double>();
            string cliente;
            double gastos;
            double maior = 0;
            foreach (Venda v in vendas)
            {
                cliente = v.Cnome;
                gastos = v.precoT;
                if (clientegastos.ContainsKey(cliente))
                {
                    clientegastos[cliente] = gastos + gastos;
                }
                else
                {
                    clientegastos.Add(cliente, gastos);
                }
            }
            foreach (KeyValuePair<string, double> receita in clientegastos)
            {
                if (receita.Value >= maior)
                {
                    maior = receita.Value;
                }
            }
            foreach (KeyValuePair<string, double> receita in clientegastos)
            {
                if (receita.Value == maior)
                {
                    Console.WriteLine("O cliente com mais gastos (" + maior + "€) é " + receita.Key + ".");
                }
            }
        }
    }
}



















































































































































































































































































































































































































































































































































































































































































































































