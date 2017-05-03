using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoBancariaGabrielZarpelon.Model;
using MySql.Data.MySqlClient;

namespace AplicacaoBancariaGabrielZarpelon.DAL
{
    class BancoDados
    {
        public static string caminho = "SERVER=localhost;UID=root;Password=root;Database=app_banco;";
        public static MySqlConnection Conexao = new MySqlConnection(caminho);
        public static MySqlCommand comandos = new MySqlCommand();

        public static void CriacaoBaseDados()
        {
            caminho = "SERVER=localhost;UID=root;Password=root;";
            Conexao = new MySqlConnection(caminho);
            Conexao.Open();
            string criandoBanco = "CREATE DATABASE IF NOT EXISTS app_banco;" +
                "CREATE TABLE if not exists app_banco.conta(id_conta numeric(10) not null primary key," +
                    "nome varchar(50), saldo numeric(10, 2), data_cadastro date);" +
                    "CREATE TABLE if not exists app_banco.movimentacao(id_movimentacao numeric(10) not null," +
                    "tipo varchar(50), valor numeric(10, 2), data_movimentacao date, id_conta numeric(10) not null);";
            comandos = new MySqlCommand(criandoBanco, Conexao);
            comandos.ExecuteNonQuery();
            Conexao.Close();
            caminho = "SERVER=localhost;UID=root;Password=root;Database=app_banco;";
            Conexao = new MySqlConnection(caminho);
            Conexao.Open();
            string alterarFK = "ALTER TABLE app_banco.movimentacao ADD primary key (Id_movimentacao,Id_conta); " +
                                "ALTER TABLE app_banco.movimentacao ADD foreign key (Id_conta)references conta(ID_conta); ";
            comandos = new MySqlCommand(alterarFK, Conexao);
            comandos.ExecuteNonQuery();
            Conexao.Close();

        }

        public static void Cadastro(Conta conta, Movimentacao movimentacao)
        {
            try
            {
                caminho = "SERVER=localhost;UID=root;Password=root;Database=app_banco;";
                Conexao = new MySqlConnection(caminho);
                Conexao.Open();
                //INSERT INTO `app_banco`.`conta` (`id_conta`, `nome`, `saldo`, `data_cadastro`) VALUES('1', 'andre', '300.49', '2017-05-01');
                string dataSql = conta.data.Year + "-" + conta.data.Month + "-" + conta.data.Day;
                string inserir = "INSERT INTO conta (id_conta,nome,saldo,data_cadastro)" +
                    "values('" + conta.numeroConta + "','" + conta.nome + "','" + Convert.ToString(conta.saldo).Replace(",", ".") + "','" + dataSql + "');" +
                    "INSERT INTO movimentacao (id_movimentacao,tipo,valor,data_movimentacao,id_conta)" +
                    "values('" + '1' + "','" + movimentacao.tipo + "','" + Convert.ToString(conta.saldo).Replace(",", ".") + "','" + dataSql + "','" + conta.numeroConta + "')";
                comandos = new MySqlCommand(inserir, Conexao);
                comandos.ExecuteNonQuery();
                Conexao.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro de Comandos: " + ex.Message);
            }

        }
    }
}
