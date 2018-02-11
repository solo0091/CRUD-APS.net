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
    string tabla = "tbl_empleado";    // nombre de la tabla de la base de datos
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
        conectar(tabla); //nos conectamos a la base de datos(nombre de la tabla)
        DataRow fila;
        fila = Data.Tables[tabla].NewRow();//creamos un fila nueva en la tabla
        fila["idempleado"] = Idempleado;   // [nom_colu_base]=valor qe nos mandan el metodo de cada valor
        fila["idacceso"] = Idacceso;
        fila["nombre"] = Nombre;
        fila["usuario"] = Usuario;
        fila["contraseña"] = Contraseña;

        Data.Tables[tabla].Rows.Add(fila); //añadimos la nueva fila a la tabla
        AdaptadorDatos.Update(Data, tabla);//actualizamos la tabla
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
                fila["idempleado"] = Idempleado;    //var de bd = var q se mando del form a esta clase.metodo
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

        int x = Data.Tables[tabla].Rows.Count - 1;//obtenemos la cantidad de registro de la tabla
        for (int i = 0; i <= x; i++)
        {
            fila = Data.Tables[tabla].Rows[i];//sacamos un fila conpleta de la tabla

            if (int.Parse(fila["idempleado"].ToString().Trim()) == valor)
            {    // si exsite el valor  de empleado sacamos los valores dela bd y los mostramos
                Idempleado = int.Parse(fila["idempleado"].ToString());//metodo de la variable = valor de la bd
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
                fila = Data.Tables[tabla].Rows[i];//registro actual que se emcuentra en la variable fila
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

    public bool login(string user, string pass)//usuario,passwoor
    {
        conectar(tabla);
        DataRow fila;

        int x = Data.Tables[tabla].Rows.Count - 1;//contamos
        for (int i = 0; i <= x; i++)//recoremos el registro
        {
            fila = Data.Tables[tabla].Rows[i];//obtenemos una fila
              //fila["nom_de_tabla"].convertimos              
            //ToLower = convierte la cadena SerGio a sergio
            if (fila["usuario"].ToString().Trim().ToLower() == user.Trim().ToLower() &&
                fila["contraseña"].ToString().Trim() == pass.Trim())
            {          
                //<=======  se asigna a ese lado
                //pasomos los parametros a el formulario
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



