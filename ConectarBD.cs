using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace AgendaSQLPOO
{
    internal class ConectarBD
    {
        MySqlConnection con = new MySqlConnection();

        public ConectarBD() 
        {
            con.ConnectionString = "datasource=localhost;username=root;password=;database=agenda";
        }

        public MySqlConnection conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed) 
            {
                con.Open();
            }
            return con;
        }

        public void desconectar()
        {
            if(con.State!= System.Data.ConnectionState.Closed)
            {
                con.Close();
            }
        }
    }
}
