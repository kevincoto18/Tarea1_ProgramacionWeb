using Tarea1.Modelo;

namespace Tarea1.Data
{
    public class PezData
    {
        public static List<Pez> ListaPeces;
        Pez Pez = new Pez();
        List<Oceano> ListaOceanos = new List<Oceano>();
        Oceano ocean = new Oceano();


        public PezData()
        {
            ocean.Id_Oceano = 0;
            ocean.Descripcion_Oceano = "Ejemplo";
            ocean.Fecha_PezenOceano = "2002";
            ListaOceanos.Add(ocean);
            //---------------------------------------------
            ListaPeces = new List<Pez>();
            Pez.Id_pez = 1;
            Pez.Nombre_pez = "Pez Atlantico";
            Pez.Fecha_pez = "10/10/2002";
            Pez.OceanoPez = ListaOceanos;
            ListaPeces.Add(Pez);
        }
        public List<Pez> ListarPeces()
        {
            return ListaPeces;
        }

        public bool AgregarPez(Pez pez)
        {
            try
            {
                ListaPeces.Add(pez);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool AgregarOceanoPez(int id_pez, int id_oceano)
        {
            try
            {

                var encontrado = ListaPeces.Find(i => i.Id_pez == id_pez);
                var oceano = OceanoData.ListaOceanos.Find(i => i.Id_Oceano == id_oceano);
                if (oceano == null)
                {
                    return false;
                }
                else
                {
                    encontrado.OceanoPez.Add(oceano);
                    return true;
                }


            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Pez filtrado(int id)
        {
            foreach (Pez pez in ListaPeces)
            {
                if (pez.Id_pez == id)
                {
                    return pez;
                }
            }
            return null;
        }

        public bool PezEditado()
        {

        }

        public bool EliminarPez(int id)
        {
            try
            {
                ListaPeces.RemoveAll(i => i.Id_pez == id);
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
