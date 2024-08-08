namespace WebApplication1.Models
{
    public class Tarea
    {
        private long _id;
        public long Id
        {
            set { _id = value; }
            get { return _id; }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string? _descripcion;
        public string? Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private int? _duracionH;
        public int? DuracionH
        {
            get { return _duracionH; }
            set { _duracionH = value; }
        }

        private string? _responsable;
        public string? Responsable
        {
            get { return _responsable; }
            set { _responsable = value; }
        }

        private DateTime? _date;
        public DateTime? Date
        {
            get { return _date; }
            set { _date = value; }
        }

        // Constructor corregido
        public Tarea(long id, string nombre, string? descripcion = null, int? duracionH = null, string? responsable = null, DateTime? date = null)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _duracionH = duracionH;
            _responsable = responsable;
            _date = date;
        }
    }
}
