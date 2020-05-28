
using System;

namespace Parcial
{
    public static class Consultas
    {
        public static string usuarioActual;
        
        public static string obtenerNombre()
        {
            string consulta = $"select fullname from appuser where username='{usuarioActual}'";
            var dt = Conexion.realizarConsulta(consulta);
            var dr = dt.Rows[0];
            string  nombre = dr[0].ToString();

            return nombre; 
        }

        public static string obtenerContra()
        {
            string consulta = $"select password from appuser where username='{usuarioActual}'";
            var dt = Conexion.realizarConsulta(consulta);
            var dr = dt.Rows[0];
            string  contra = dr[0].ToString();

            return contra;
        }
        
        public static int obtenerId()
        {
            string consulta = $"select iduser from appuser where username='{usuarioActual}'";
            var dt = Conexion.realizarConsulta(consulta);
            var dr = dt.Rows[0];
            int id = Convert.ToInt32(dr[0].ToString());

            return id;
        }
        
        public static bool obtenerRango()
        {
            string consulta = $"select usertype from appuser where username='{usuarioActual}'";
            var dt = Conexion.realizarConsulta(consulta);
            var dr = dt.Rows[0];
            bool rango = Convert.ToBoolean(dr[0].ToString());

            return rango;
        }
    }
}