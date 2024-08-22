using tarea02_b.Models;
using tarea02_b.Infraestructure.Data;

namespace tarea02_b.Infraestructure.Data
{
    public class TareaRepository : ITareaRepository
    {
        private IList<Tarea> _tareaList;
        public TareaRepository() {
            this._tareaList = new List<Tarea>();
            this._tareaList.Add(new Tarea(1, "tarea1", "t1", 1, "encargado"));
            this._tareaList.Add(new Tarea(2, "tarea2", "t2", 2, "encargado"));
            this._tareaList.Add(new Tarea(3, "tarea3", "t3", 3, "encargado"));
        }
        public void Add(Tarea tarea)
        {
            this._tareaList.Add(tarea);
        }
    
        public Tarea Get(int id)
        {
            return this._tareaList.FirstOrDefault(t => t.Id == id);
        }

        public void Delete(int id)
        {
            var tarea = this._tareaList.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                this._tareaList.Remove(tarea);
            }
        }

        public IList<Tarea> GetClientes() { return this._tareaList; }
    }
}
