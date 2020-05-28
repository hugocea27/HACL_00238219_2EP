namespace Parcial
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string contra { get; set; }
        public bool admin { get; set; }

        public Usuario()
        {
            idUsuario = 0;
            nombre = "";
            usuario = "";
            contra = "";
            admin = false;
        }
    }
}