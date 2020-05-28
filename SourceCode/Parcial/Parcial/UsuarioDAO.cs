using System;
using System.Collections.Generic;
using System.Data;

namespace Parcial
{
    public class UsuarioDAO
    {
        public static List<Usuario> getLista()
        {
            string consulta = "select * from appuser";

            DataTable dt = Conexion.realizarConsulta(consulta);

            List<Usuario> lista = new List<Usuario>();
            foreach (DataRow fila in dt.Rows)
            {
                Usuario u = new Usuario();
                u.idUsuario = Convert.ToInt32(fila[0].ToString());
                u.nombre = fila[1].ToString();
                u.usuario = fila[2].ToString();
                u.contra = fila[3].ToString();
                u.admin = Convert.ToBoolean(fila[4].ToString());

                lista.Add(u);
            }
            return lista;
        }
    }
}