using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Descripción breve de clsempleado
/// </summary>
public class clsempleado : clsconexion
{
    //declarar las variables glovales
    string tabla = "tbl_empleado";
    protected string nombre, usuario, contraseña;
    protected int idempleado, idacceso;

    public clsempleado(int idempleado, int idacceso, string nombre, string usuario, string contraseña)
    {
        this.idempleado = idempleado;
        this.idacceso = idacceso;
        this.nombre = nombre;
        this.usuario = usuario;
        this.contraseña = contraseña;
    }

    //metodos de la clase
    public int Idempleado
    {
        set { idempleado = value; }
        get { return idempleado; }
    }
    public int Idacceso
    {
        set { idacceso = value; }
        get { return idacceso; }
    }
    public string Nombre
    {
        set { nombre = value; }
        get { return nombre; }
    }
    public string Usuario
    {
        set { usuario = value; }
        get { return usuario; }
    }
    public string Contraseña
    {
        set { contraseña = value; }
        get { return contraseña; }
    }

    //metodos de manipulacion de datos
    //agrega un nuevo registro a la BD
    public void agregar()
    {
        conectar(tabla);
        DataRow fila;
        fila = Data.Tables[tabla].NewRow();
        fila["idempleado"] = Idempleado;
        fila["idacceso"] = Idacceso;
        fila["nombre"] = Nombre;
        fila["usuario"] = Usuario;
        fila["contraseña"] = Contraseña;

        Data.Tables[tabla].Rows.Add(fila);
        AdaptadorDatos.Update(Data, tabla);
    }
    //Actualiza el registro especificado
    public void modificar()
    {
        conectar(tabla);//sirve para conectar a la base de datos
        DataRow fila;
        int x = Data.Tables[tabla].Rows.Count - 1;//almace la cantidad de registro qe tiene la table
        for (int i = 0; i <= x; i++)
        {
            fila = Data.Tables[tabla].Rows[i]; //retorna un registro quye esta en la posicion i

            if (int.Parse(fila["idempleado"].ToString().Trim()) == Idempleado)  //.trim = elimina los campos vacios
            {    //valor de la bd de un  empleado == valor del el formulario
                fila["idempleado"] = Idempleado;    //var de bd = var del formulario
                fila["idacceso"] = Idacceso;
                fila["nombre"] = Nombre;
                fila["usuario"] = Usuario;
                fila["contraseña"] = Contraseña;
                AdaptadorDatos.Update(Data, tabla);//mandamos los datos junto a la tab modificada
            }
        }

    }
    //verifica si existe el registro
    public bool existe(int valor)
    {
        conectar(tabla);//sirve para conectar a la base de datos
        DataRow fila;

        int x = Data.Tables[tabla].Rows.Count - 1;
        for (int i = 0; i <= x; i++)
        {
            fila = Data.Tables[tabla].Rows[i];

            if (int.Parse(fila["idempleado"].ToString().Trim()) == valor)
            {    // si exsite el valor  de empleado sacamos los valores dela bd y loos mostramos
                Idempleado = int.Parse(fila["idempleado"].ToString());//valores qe se ven= val qe se tienen
                Idacceso = int.Parse(fila["idacceso"].ToString());
                Nombre = fila["nombre"].ToString();
                Usuario = fila["usuario"].ToString();
                Contraseña = fila["contraseña"].ToString();
                return true;
            }
        }
        //el objeto no existe
        return false;
    }

    //elimina un registro existente 
    public bool eliminar(int valor)
    {

        conectar(tabla);//conectamos a la bd
        DataRow fila; // alamacenamos la informacion

        int x = Data.Tables[tabla].Rows.Count - 1;//nume de registros
        for (int i = 0; i <= x; i++)
        {
            fila = Data.Tables[tabla].Rows[i];//sacamos una fila de la base

            if (int.Parse(fila["idempleado"].ToString().Trim()) == valor)
            {
                fila = Data.Tables[tabla].Rows[i];//registro actual
                fila.Delete();                    //eliminamo la fila
                DataTable tablaborrados;

                tablaborrados = Data.Tables[tabla].GetChanges(DataRowState.Deleted);//tomamos los canbios
                AdaptadorDatos.Update(tablaborrados);//actualizamos el adaptador
                Data.Tables[tabla].AcceptChanges();//qeu asepte los cambios
                return true;
            }
        }
        //el objeto no existe
        return false;
    }

    public bool login(string user, string pass)
    {
        conectar(tabla);
        DataRow fila;

        int x = Data.Tables[tabla].Rows.Count - 1;
        for (int i = 0; i <= x; i++)
        {
            fila = Data.Tables[tabla].Rows[i];

            if (fila["usuario"].ToString().Trim().ToLower() == user.Trim().ToLower() &&
                fila["contraseña"].ToString().Trim() == pass.Trim())
            {

                Idempleado = int.Parse(fila["idempleado"].ToString());
                Idacceso = int.Parse(fila["idacceso"].ToString());
                Nombre = fila["nombre"].ToString();
                Usuario = fila["usuario"].ToString();
                Contraseña = fila["contraseña"].ToString();
                return true;
            }

        }
        //el objeto no existe
        return false;
    }
}



