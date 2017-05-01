using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace AplicacaoBancariaGabrielZarpelon.Controller
{
    class Connection
    {
        //string servidor = "localhost";  
        //String para conectar o banco de Dados
        string connectionString = "Server=yourserveraddress;Database=yourdbname;User ID=yourmysqlusername;Password=yourdbpassword;";

        MySqlConnection mydbCon = new MySqlConnection();

    }
}
