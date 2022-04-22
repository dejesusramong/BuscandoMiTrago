using Entidades.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
namespace AccesoADatos.Generico
{
    public interface IUnidadDeTrabajo :IDisposable
    {
        BuscandoMiTragoDbContext Context { get; }
        void Commit();
    }
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public UnidadDeTrabajo(BuscandoMiTragoDbContext _context)
        {
            Context = _context;
        }

        public BuscandoMiTragoDbContext Context { get; }
        
        public void Commit()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
