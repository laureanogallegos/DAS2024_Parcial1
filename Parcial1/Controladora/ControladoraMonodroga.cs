using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraMonodroga
    {
        private static readonly Lazy<ControladoraMonodroga> instancia = new(() => new ControladoraMonodroga());

        private ControladoraMonodroga() { }

        public static ControladoraMonodroga Instance => instancia.Value;

        public ReadOnlyCollection<Monodroga> RecuperarMonodroga()
        {
            try
            {
                return RepositorioMonodrogas.Instancia.Monodrogas;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }


        public bool AgregarMonodroga(Monodroga monodroga)
        {
            try
            {
                var existeMonodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(a => a.Nombre == monodroga.Nombre);
                if (existeMonodroga == null)
                {
                    RepositorioMonodrogas.Instancia.Agregar(monodroga);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ModificarMonodroga(Monodroga monodroga)
        {
            try
            {
                var existeMonodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(a => a.Nombre == monodroga.Nombre);
                if (existeMonodroga == null)
                {
                    RepositorioMonodrogas.Instancia.Modificar(monodroga);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminarMonodroga(Monodroga monodroga)
        {
            try
            {
                var existeMonodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(a => a.Nombre == monodroga.Nombre);
                if (existeMonodroga == null)
                {
                    RepositorioMonodrogas.Instancia.Eliminar(monodroga);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
