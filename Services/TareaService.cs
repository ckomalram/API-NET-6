using webapi.Context;
using webapi.Models;

namespace webapi.Services;

public class TareaService : ITareaService
{
    TareaContext context;

    public TareaService(TareaContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {

        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        tarea.FechaCreado = DateTime.Now;        
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);

        if (tareaActual != null)
        {
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Desc = tarea.Desc;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.CategoriaId = tarea.CategoriaId;
            
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);

        if (tareaActual != null)
        {
            context.Remove(id);
            await context.SaveChangesAsync();

        }
    }


}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);

    Task Update(Guid id, Tarea tarea);

    Task Delete(Guid id);

}