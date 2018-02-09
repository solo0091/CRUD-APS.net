using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Descripción breve de clsconexion
/// </summary>
public class clsconexion
{
    protected SqlDataAdapter AdaptadorDatos;
    protected SqlDataReader reader;
    protected DataSet data;
    protected SqlConnection oconexion = new SqlConnection();
	public clsconexion()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public void conectar(string tabla)
    {
        string strConexion = ConfigurationManager.ConnectionStrings["facturacionConnectionString"].ConnectionString;
        oconexion.ConnectionString = strConexion;
        oconexion.Open();
        AdaptadorDatos = new SqlDataAdapter("select * from " + tabla, oconexion);
        SqlCommandBuilder ejecutacomandos = new SqlCommandBuilder(AdaptadorDatos);
        Data = new DataSet();
        AdaptadorDatos.Fill(Data, tabla);
        oconexion.Close();
    }
    public DataSet Data
    {
        set { data = value; }
        get { return data; }
    }
    public SqlDataReader DataReader
    {
        set { reader = value; }
        get { return reader; }
    }

}