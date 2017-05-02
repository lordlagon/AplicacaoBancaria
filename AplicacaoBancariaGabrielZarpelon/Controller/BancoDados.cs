using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoBancariaGabrielZarpelon.Model;
using MySql.Data.MySqlClient;

namespace AplicacaoBancariaGabrielZarpelon.Controller
{
    class BancoDados
    {
        
        public static MySqlConnection Conexao = new MySqlConnection("SERVER=localhost;Database=app_banco;UID=root;Password=root;");
        

        public static void Cadastro(Conta conta)
        {
            try
            {
                Conexao.Open();

                //INSERT INTO `app_banco`.`conta` (`id_conta`, `nome`, `saldo`, `data_cadastro`) VALUES('1', 'andre', '300.49', '2017-05-01');
                string dataSql = conta.data.Year + "-" + conta.data.Month + "-" + conta.data.Day;
                string inserir = "INSERT INTO conta (id_conta,nome,saldo,data_cadastro)" +
                    "values('" + conta.numeroConta + "','" + conta.nome + "','" + Convert.ToString(conta.saldo).Replace(",",".") + "','" + dataSql + "')";
                MySqlCommand comandos = new MySqlCommand(inserir, Conexao);
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
