using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de clscliente
/// </summary>
public class clscliente: clsconexion
{
    string tabla = "tbl_cliente";
   
    protected string cedula,nombre, apellido1, apellido2, direccion, correo, telefono;
    protected int idcliente, idempresa;

    public clscliente(int idcliente, int idempresa, string cedula, string nombre, string apellido1, string apellido2, string direccion, string correo, string telefono)
	{  
        //var global de la clase = la varable que ingresa
        this.idcliente = idcliente;
        this.idempresa = idempresa;
        this.cedula = cedula;
        this.nombre=nombre;
        this.apellido1=apellido1;
        this.apellido2=apellido2;
        this.direccion=direccion;
        this.correo=correo;
        this.telefono=telefono;

	}
    //metodos que establesen y capturan los datos

    public int Idcliente {
        set { idcliente = value; }
        get { return idcliente; }
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
    public string Apellido1
    {
        set { apellido1 = value; }
        get { return apellido1; }
    }
    public string Apellido2
    {
        set { apellido2 = value; }
        get { return apellido2; }
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
    public string Cedula
    {
        set { cedula = value; }
        get { return cedula; }
    }

    
public void agregar()
    {
        conectar(tabla);
        DataRow fila;
        fila = Data.Tables[tabla].NewRow();
        fila["idcliente"] = Idcliente;
        fila["idempresa"] = Idempresa;
        fila["cedula"] = Cedula;
        fila["nombre"] = Nombre;
        fila["apellido1"] = Apellido1;
        fila["apellido2"] = Apellido2;
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

            if (int.Parse(fila["idcliente"].ToString().Trim()) == Idcliente)  //.trim = elimina los campos vacios
            {    //valor de la bd de un  empleado == valor del el formulario
               fila["idcliente"]=  Idcliente;
               fila["idempresa"] = Idempresa;
               fila["cedula"]= Cedula;
               fila["nombre"]= Nombre;
               fila["apellido1"] =Apellido1;
               fila["apellido2"] =Apellido2;
               fila["direccion"]= Direccion;
               fila["telefono"]= Telefono;
               fila["correo"]= Correo;  

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

            if (int.Parse(fila["idcliente"].ToString().Trim()) == valor)
            {    // si exsite el valor  de empleado sacamos los valores dela bd y los mostramos
                Idcliente = int.Parse(fila["idcliente"].ToString());
                Idempresa = int.Parse(fila["idempresa"].ToString());
                Cedula = fila["cedula"].ToString();
                Nombre = fila["nombre"].ToString();
                Apellido1 = fila["apellido1"].ToString();
                Apellido2 = fila["apellido2"].ToString().Trim();
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

            if (int.Parse(fila["idcliente"].ToString().Trim()) == valor)
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