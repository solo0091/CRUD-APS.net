using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Descripción breve de clsacceso
/// </summary>
public class clsacceso : clsconexion //extendemos de la clase conexion para la util el meto conectar
{
    string tabla = "tbl_acceso";
    protected int idacceso;
    protected string descripcion;
    public clsacceso(int idacceso, string descripcion)
    {
        this.idacceso = idacceso;
        this.descripcion = descripcion;
    }

    public int Idacceso
    {
        set { idacceso = value; }
        get { return idacceso; }
    }
    public string Descripcion
    {
        set { descripcion = value; }
        get { return descripcion; }
    }

    public void agregar()
    {
        conectar(tabla);
        DataRow fila;
        fila = Data.Tables[tabla].NewRow();
        fila["idacceso"] = Idacceso;
        fila["descripcion"] = Descripcion;

        Data.Tables[tabla].Rows.Add(fila);
        AdaptadorDatos.Update(Data, tabla);
    }
    public void modificar()
    {
        conectar(tabla);
        DataRow fila;
        int x = Data.Tables[tabla].Rows.Count - 1;
        for (int i = 0; i <= x; i++)
        {
            fila = Data.Tables[tabla].Rows[i];
            //Data.Tables[tabla].Rows.Find(valor);
            if (int.Parse(fila["idacceso"].ToString().Trim()) == Idacceso)
            {
                fila["idacceso"] = Idacceso;
                fila["descripcion"] = Descripcion;

                AdaptadorDatos.Update(Data, tabla);
            }
        }
    }

    //busca el registro solicitado y retorna los valores
    public bool existe(int valor)
    {
        conectar(tabla);
        DataRow fila;
        //se carga la informacion del item seleccionado en los espacios correspondientes
        int x = Data.Tables[tabla].Rows.Count - 1;
        for (int i = 0; i <= x; i++)
        {
            fila = Data.Tables[tabla].Rows[i];

            if (int.Parse(fila["idacceso"].ToString()) == valor)
            {
                //el objeto si existe
                Idacceso = int.Parse(fila["idacceso"].ToString());
                Descripcion = fila["descripcion"].ToString();

                return true;
            }
        }
        //el objeto no existe
        return false;
    }
    public bool eliminar(int valor)
    {
        conectar(tabla);
        DataRow fila;
        //se carga la informacion del item seleccionado en los espacios correspondientes
        int x = Data.Tables[tabla].Rows.Count - 1;
        for (int i = 0; i <= x; i++)
        {
            fila = Data.Tables[tabla].Rows[i];

            if (int.Parse(fila["idacceso"].ToString()) == valor)
            {
                fila = Data.Tables[tabla].Rows[i];
                fila.Delete();
                DataTable tablaborrados;
                tablaborrados = Data.Tables[tabla].GetChanges(DataRowState.Deleted);
                AdaptadorDatos.Update(tablaborrados);
                Data.Tables[tabla].AcceptChanges();
                return true;
            }

        }
        return false;

    }



}