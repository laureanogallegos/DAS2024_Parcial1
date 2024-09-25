using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraDrogueria
    {
        private static readonly Lazy<ControladoraDrogueria> instancia = new(() => new ControladoraDrogueria());

        private ControladoraDrogueria() { }

        public static ControladoraDrogueria Instance => instancia.Value;

        public ReadOnlyCollection<Drogueria> RecuperarDroguerias()
        {
            try
            {
                return RepositorioDroguerias.Instancia.ListaDroguerias;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }


        public bool AgregarDrogueria(Drogueria drogueria)
        {
            try
            {
                var existeDrogueria = RepositorioDroguerias.Instancia.ListaDroguerias.FirstOrDefault(a => a.Cuit == drogueria.Cuit);
                if (existeDrogueria == null)
                {
                    RepositorioDroguerias.Instancia.Agregar(drogueria);
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

            public bool ModificarDrogueria(Drogueria drogueria)
            {
                try
                {
                    var existeDrogueria = RepositorioDroguerias.Instancia.ListaDroguerias.FirstOrDefault(a => a.Cuit == drogueria.Cuit);
                    if (existeDrogueria == null)
                    {
                        RepositorioDroguerias.Instancia.Modificar(drogueria);
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

        public bool EliminarDrogueria(Drogueria drogueria)
        {
            try
            {
                var existeDrogueria = RepositorioDroguerias.Instancia.ListaDroguerias.FirstOrDefault(a => a.Cuit == drogueria.Cuit);
                if (existeDrogueria == null)
                {
                    RepositorioDroguerias.Instancia.Eliminar(drogueria);
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
