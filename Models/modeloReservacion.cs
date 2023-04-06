using System.Data;
using System.Data.SqlClient;

namespace CubiculosTEC.Models;

public class Reservacion{

    public int idEstudiante;

    public string estudianteReservador;
    public int idCubiculo;

    public string nombreCubiculo;
    public string fechaDeUso;
    public string horaInicio;
    public string horaFinal;
    public string confirmacion;
    public string fechaDeReservacion;

    public int idReservacion;

    public string horasUtilizado;




    public Reservacion(){

    }

    public static List<Reservacion> reservacionesUsuario(int pIdUsuario){
        List<Reservacion> todasReservaciones = new List<Reservacion>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "SELECT Reservaciones.idCubiculo idCubiculo, Cubiculos.nombre nombreC, idEstudiante, fechaDeUso, horaInicio, horaFinal, confirmacion, fechaDeReservacion, idReservacion FROM Reservaciones INNER JOIN Cubiculos ON Reservaciones.idCubiculo = Cubiculos.idCubiculo WHERE idEstudiante=@pIdUsuario;";

        SqlCommand cmd = new SqlCommand(query,conectado);

        cmd.Parameters.AddWithValue("@pIdUsuario",pIdUsuario);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Reservacion objeto = new Reservacion(){
                    idEstudiante=Int32.Parse(dr["idEstudiante"].ToString()),
                    idCubiculo=Int32.Parse(dr["idCubiculo"].ToString()),
                    idReservacion=Int32.Parse(dr["idReservacion"].ToString()),
                    fechaDeUso=dr["fechaDeUso"].ToString(),
                    horaInicio=dr["horaInicio"].ToString(),
                    horaFinal=dr["horaInicio"].ToString(),
                    confirmacion=dr["confirmacion"].ToString(),
                    fechaDeReservacion=DateTime.Parse(dr["fechaDeUso"].ToString()).Date.ToShortDateString(),
                    nombreCubiculo=dr["nombreC"].ToString(),

                };
                todasReservaciones.Add(objeto);
            }
        }
        conectado.Close();
        return todasReservaciones;
    }


    public static Boolean confirmarReservacion(int idReservacion){
        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "confirmarReservacion @idReservacion;";

        SqlCommand cmd = new SqlCommand(query,conectado);

        cmd.Parameters.AddWithValue("@idReservacion",idReservacion);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Reservacion objeto = new Reservacion(){
                    idEstudiante=Int32.Parse(dr["idCubiculo"].ToString()),
                    idCubiculo=Int32.Parse(dr["idEstudiante"].ToString()),
                };
            }
        }
        conectado.Close();
        return true;

    }

    public static List<Reservacion> todasReservaciones(){
        List<Reservacion> todasReservaciones = new List<Reservacion>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "SELECT idCubiculo, Estudiantes.idEstudiante idEstudiante,Estudiantes.nombre nombre, Estudiantes.apellido1 apellido1 ,Estudiantes.apellido2 apellido2, fechaDeUso, horaInicio, horaFinal, confirmacion, fechaDeReservacion, idReservacion FROM Reservaciones INNER JOIN Estudiantes ON Reservaciones.idEstudiante = Estudiantes.idEstudiante;";

        SqlCommand cmd = new SqlCommand(query,conectado);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Reservacion objeto = new Reservacion(){
                    idReservacion = Int32.Parse(dr["idReservacion"].ToString()),
                    idCubiculo=Int32.Parse(dr["idCubiculo"].ToString()),
                    idEstudiante=Int32.Parse(dr["idCubiculo"].ToString()),
                    horasUtilizado = (TimeSpan.Parse(dr["horaFinal"].ToString())-TimeSpan.Parse(dr["horaInicio"].ToString())).ToString(),
                    fechaDeUso=DateTime.Parse(dr["fechaDeUso"].ToString()).Date.ToShortDateString(),
                    fechaDeReservacion=DateTime.Parse(dr["fechaDeReservacion"].ToString()).Date.ToShortDateString(),
                    estudianteReservador=dr["nombre"].ToString()+" "+dr["apellido1"].ToString()+" "+dr["apellido2"].ToString(),

                };
                todasReservaciones.Add(objeto);
            }
        }
        
        conectado.Close();
        return todasReservaciones;
    }


}