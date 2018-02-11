using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Descripción breve de clsordendeservicio
/// </summary>
public class clsordendeservicio : clsconexion
{
    string tabla = "tbl_orden_servicio";
    private int idorden, idcliente, idcategoria1, idcategoria2, idestado, idempleado, idservicio;
    private decimal importe;
    private string solicitud, solucion;
    private DateTime fecharegistro, fechasolucion;

    public clsordendeservicio(int idorden, int idcliente, int idcategoria1, int idcategoria2,
        int idestado, int idempleado, int idservicio, decimal importe, string solicitud,
        string solucion, DateTime fecharegistro, DateTime fechasolucion)
    {
        this.idorden = idorden;
        this.idcliente = idcliente;
        this.idcategoria1 = idcategoria1;
        this.idcategoria2 = idcategoria2;
        this.idestado = idestado;
        this.idempleado = idempleado;
        this.idservicio = idservicio;
        this.importe = importe;
        this.solicitud = solicitud;
        this.solucion = solucion;
        this.fecharegistro = fecharegistro;
        this.fechasolucion = fechasolucion;
    }

    public int Idorden
    {
        set { idorden = value; }
        get { return idorden; }
    }
    public int Idcliente
    {
        set { idcliente = value; }
        get { return idcliente; }
    }
    public int Idcategoria1
    {
        set { idcategoria1 = value; }
        get { return idcategoria1; }
    }
    public int Idcategoria2
    {
        set { idcategoria2 = value; }
        get { return idcategoria2; }
    }
    public int Idestado
    {
        set { idestado = value; }
        get { return idestado; }
    }
    public int Idempleado
    {
        set { idempleado = value; }
        get { return idempleado; }
    }
    public int Idservicio
    {
        set { idservicio = value; }
        get { return idservicio; }
    }
    public decimal Importe
    {
        set { importe = value; }
        get { return importe; }
    }
    public string Solicitud
    {
        set { solicitud = value; }
        get { return solicitud; }
    }
    public string Solucion
    {
        set { solucion = value; }
        get { return solucion; }
    }
    public DateTime Fecharegistro
    {
        set { fecharegistro = value; }
        get { return fecharegistro; }
    }
    public DateTime Fechasolucion
    {
        set { fechasolucion = value; }
        get { return fechasolucion; }
    }

    public void agregar()
    {
        conectar(tabla);
        DataRow fila;
        fila = Data.Tables[tabla].NewRow();
        //fila["idorden"] = Idorden;//es autoincremental
        fila["idcliente"] = Idcliente;
        fila["fecha_registro"] = Fecharegistro;
        fila["fecha_solucion"] = Fechasolucion;
        fila["idcategoria1"] = Idcategoria1;
        fila["idcategoria2"] = Idcategoria2;
        fila["idestado"] = Idestado;
        fila["idempleado"] = Idempleado;
        fila["solicitud"] = Solicitud;
        fila["solucion"] = Solucion;
        fila["importe"] = Importe;
        fila["idservicio"] = Idservicio;


        Data.Tables[tabla].Rows.Add(fila);
        AdaptadorDatos.Update(Data, tabla);
    }
    //recupera ultimo registro
    public int recuperaultimoregistro()
    {
        conectar(tabla);
        DataRow fila;
        //se carga la informacion del item seleccionado en los espacios correspondientes
        int x = Data.Tables[tabla].Rows.Count - 1;
        fila = Data.Tables[tabla].Rows[x];
        Idorden = int.Parse(fila["idorden"].ToString());//solo requerimos el numero de orden

        return Idorden;
    }
    
}