using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoBancariaGabrielZarpelon.DAL;
using AplicacaoBancariaGabrielZarpelon.Model;
using AplicacaoBancariaGabrielZarpelon.Controller;


namespace AplicacaoBancariaGabrielZarpelon
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao = null;
            Conta conta = new Conta();
            Movimentacao movimentacao = new Movimentacao();
            do
            {
                Console.Clear();
                Console.WriteLine("\n          ______________Aplicação Bancária_______________");
                Console.WriteLine("         |                                               |");
                Console.WriteLine("         |   1 - Cadastrar conta                         |");
                Console.WriteLine("         |   2 - Depósito                                |");
                Console.WriteLine("         |   3 - Saque                                   |");
                Console.WriteLine("         |   4 - Extrato Bancário                        |");
                Console.WriteLine("         |   0 - Sair                                    |");
                Console.WriteLine("         |_______________________________________________|");
                Console.WriteLine("\nDigite a opção desejada: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        conta = new Conta();
                        movimentacao = new Movimentacao();
                        Console.Clear();
                        Console.WriteLine(" -- Cadastrar Conta -- \n");
                        Console.WriteLine("Digite o número da conta: ");
                        conta.numeroConta = Console.ReadLine();
                        Console.WriteLine("Digite o nome do cliente: ");
                        conta.nome = Console.ReadLine();
                        Console.WriteLine("Digite o valor inicial da conta: ");
                        conta.saldo = Convert.ToDouble(Console.ReadLine());

                        if (ContaDAO.AddConta(conta) == true)
                        {
                            movimentacao.tipo = "Saldo Inicial";
                            movimentacao.data = DateTime.Now;
                            conta.data = DateTime.Now;
                            movimentacao.valor = conta.saldo;
                            conta.Movimentacao.Add(movimentacao);
                            BancoDados.Cadastro(conta);
                            Console.WriteLine("Conta cadastrada");
                        }
                        else
                        {
                            Console.WriteLine("Erro ao adicionar a conta");
                        }
                        break;

                    case "2":
                        conta = new Conta();
                        movimentacao = new Movimentacao();

                        Console.Clear();
                        Console.WriteLine("Digite o número de sua conta");
                        conta.numeroConta = Console.ReadLine();
                        conta = ContaDAO.BuscarContaNumeroConta(conta);
                        movimentacao.tipo = "Depósito";
                        if (conta != null)
                        {

                            Console.WriteLine("Digite o valor do depósito");
                            movimentacao.valor = Convert.ToDouble(Console.ReadLine());
                            if(movimentacao.valor > 0)
                            {
                                movimentacao.data = DateTime.Now;
                                DepositoSaque.Deposito(conta, movimentacao);
                                conta.Movimentacao.Add(movimentacao);
                            }
                            else
                            {
                                Console.WriteLine("Número inválido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Número de conta inválida");
                        }
                        break;

                    case "3":
                        conta = new Conta();
                        movimentacao = new Movimentacao();
                        Console.Clear();
                        Console.WriteLine("Digite o número de sua conta");
                        conta.numeroConta = Console.ReadLine();
                        conta = ContaDAO.BuscarContaNumeroConta(conta);
                        movimentacao.tipo = "Saque";
                        if (conta != null)
                        {

                            Console.WriteLine("Digite o valor do saque");
                            movimentacao.valor = Convert.ToDouble(Console.ReadLine());
                            if (movimentacao.valor < conta.saldo)
                            {
                                Console.WriteLine("Saque feito com sucesso");
                                movimentacao.data = DateTime.Now;
                                DepositoSaque.Saque(conta, movimentacao);
                                conta.Movimentacao.Add(movimentacao);
                            }
                            else
                            {
                                Console.WriteLine("Sem saldo!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Número de conta inválida");
                        }
                        break;

                    case "4":
                        conta = new Conta();
                        Console.Clear();
                        Console.WriteLine("Digite o número da conta");
                        conta.numeroConta = Console.ReadLine();
                        conta = ContaDAO.BuscarContaNumeroConta(conta);
                        if(conta != null)
                        {
                            Console.WriteLine(conta);
                            foreach (Movimentacao extrato in conta.Movimentacao)
                            {
                                Console.WriteLine(extrato);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Número inválido");
                        }

                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("Fechando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            
            } while (!opcao.Equals("0"));
        }
    }
}
