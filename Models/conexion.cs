using System;
using System.Data.SqlClient;

namespace CubiculosTEC.Models;

public class SQLConexion{

    SqlConnection conex = new SqlConnection();

    static string connectionString = "Server=cubiculosTEC.mssql.somee.com;Database=CubiculosTEC;User Id=maurisq_SQLLogin_1;Password=ecs335m2na;";



    public SqlConnection establecer(){
        try{
            conex.ConnectionString=connectionString;
            conex.Open();
            Console.WriteLine("Conectado a la base de datos de CubiculosTEC");
        }
        catch(SqlException e){
            Console.WriteLine(e.ToString());
        }

        return conex;
    }

    
}

