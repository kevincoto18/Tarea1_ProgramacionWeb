using Tarea1.Modelo;

namespace Tarea1.Data
{
    public class OceanoData
    {
        public static List<Oceano> ListaOceanos;
        Oceano oceano = new Oceano();

        public OceanoData()
        {
            ListaOceanos = new List<Oceano>();
            oceano.Id_Oceano = 1;
            oceano.Descripcion_Oceano = "Oceano Atlantico";
            oceano.Fecha_PezenOceano = "10/10/2002";
            ListaOceanos.Add(oceano);
        }

        public List<Oceano> ListarOceanos()
        {
            return ListaOceanos;
        }

        public bool AgregarOceano(Oceano Oceanonuevo)
        {
            try
            {
                ListaOceanos.Add(Oceanonuevo);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public Oceano filtrado(int id)
        {
            foreach (Oceano oceano in ListaOceanos)
            {
                if (oceano.Id_Oceano == id)
                {
                    return oceano;
                }
            }
            return null;
        }

        public bool EditarOceano(Oceano oceano)
        {

            bool editado;
            try
            {
                bool encontrado = false;
                var id = oceano.Id_Oceano;
                foreach (var i in ListaOceanos)
                {
                    if (i.Id_Oceano == id)
                        encontrado = true;
                }
                if (encontrado)
                {
                    try
                    {
                        ListaOceanos.RemoveAll(x => x.Id_Oceano == id);
                        ListaOceanos.Add(oceano);
                        editado = true;
                    }
                    catch (Exception)
                    {
                        editado = false;
                        throw;
                    }
                }
                else
                {
                    editado = false;
                    return editado;
                }
            }
            catch (Exception)
            {
                editado = false;

            }
            return editado;
        }

        public bool EliminarOceano(int id)
        {
            try
            {
                ListaOceanos.RemoveAll(i => i.Id_Oceano == id);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
