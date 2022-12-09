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
            oceano.Fecha_PezenOceano = "0000";
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
                foreach (var i in ListaOceanos)
                {
                    if (i.Id_Oceano == Oceanonuevo.Id_Oceano)
                    {
                        return false;
                    }
                }
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
                        foreach(var i in PezData.ListaPeces)
                        {
                            foreach( var ii in i.OceanoPez)
                            {
                                if(ii.Id_Oceano == id)
                                {
                                    i.OceanoPez.RemoveAll(i => i.Id_Oceano == id);
                                    i.OceanoPez.Add(oceano);
                                    break;
                                }
                            }
                        }
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
                if (!ListaOceanos.RemoveAll(i => i.Id_Oceano == id).Equals(0))
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
