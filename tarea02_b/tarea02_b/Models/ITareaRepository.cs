namespace tarea02_b.Models
{
    public interface ITareaRepository
    {
        public void Add(Tarea tarea);

        public Tarea Get(int id);

        public void Delete(int id);

        public IList<Tarea> GetClientes();
    }
}
