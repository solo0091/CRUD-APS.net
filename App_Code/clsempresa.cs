using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Descripción breve de clsempresa
/// </summary>
public class clsempresa: clsconexion
{
    string tabla = "tbl_empresa";

    protected string nombre, direccion, telefono,correo;
    protected int idempresa;
    public clsempresa(int idempresa, string nombre, string direccion, string telefono, string correo)
	{
        this.idempresa = idempresa;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.correo = correo;


	}
    public int Idempresa
    {
        set { idempresa = value; }
        get { return idempresa; }
    }
   
    public string Nombre
    {
        set { nombre = value; }
        get { return nombre; }
    }
  
    public string Direccion
    {
        set { direccion = value; }
        get { return direccion; }
    }
    public string Correo
    {
        set { correo = value; }
        get { return correo; }
    }
    public string Telefono
    {
        set { telefono = value; }
        get { return telefono; }
    }

    public void agregar()
    {
        conectar(tabla);
        DataRow fila;
        fila = Data.Tables[tabla].NewRow();
        fila["idempresa"] = Idempresa;
        fila["nombre"] = Nombre;
        fila["direccion"] = Direccion;
        fila["telefono"] = Telefono;
        fila["correo"] = Correo;

        Data.Tables[tabla].Rows.Add(fila);//agregamos la fila a la table
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

            if (int.Parse(fila["idempresa"].ToString().Trim()) == Idempresa)  //.trim = elimina los campos vacios
            {    //valor de la bd de un  empleado == valor del el formulario
            
                fila["idempresa"] = Idempresa;
                fila["nombre"] = Nombre;
                fila["direccion"] = Direccion;
                fila["telefono"] = Telefono;
                fila["correo"] = Correo;

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

            if (int.Parse(fila["idempresa"].ToString().Trim()) == valor)
            {    // si exsite el valor  de empleado sacamos los valores dela bd y los mostramos
               
                Idempresa = int.Parse(fila["idempresa"].ToString());             
                Nombre = fila["nombre"].ToString();            
                Direccion = fila["direccion"].ToString().Trim();
                Telefono = fila["telefono"].ToString().Trim();
                Correo = fila["correo"].ToString().Trim();
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

            if (int.Parse(fila["idempresa"].ToString().Trim()) == valor)
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









}