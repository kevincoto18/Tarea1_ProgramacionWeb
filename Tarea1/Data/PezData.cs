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
            ocean.Id_Oceano = 1;
            ocean.Descripcion_Oceano = "Oceano Atlantico";
            ocean.Fecha_PezenOceano = "0000";
            ListaOceanos.Add(ocean);
            //---------------------------------------------
            ListaPeces = new List<Pez>();
            Pez.Id_pez = 10;
            Pez.Nombre_pez = "Pez Payaso";
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
                foreach (var i in ListaPeces)
                {
                    if (i.Id_pez == pez.Id_pez)
                    {
                        return false;
                    }
                }
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
                bool agregado = false;
                //var encontrado = ListaPeces.Find(i => i.Id_pez == id_pez);
                //var oceano = OceanoData.ListaOceanos.Find(i => i.Id_Oceano == id_oceano);
                var encontrado = new Pez();
                var oceano = new Oceano();
                foreach (var i in ListaPeces)
                {
                    if (i.Id_pez == id_pez)
                        encontrado = i;
                }
                foreach (var i in OceanoData.ListaOceanos)
                {
                    if (i.Id_Oceano == id_oceano)
                        oceano = i;
                }
                if (!(encontrado == null || oceano == null))
                {
                    foreach (var i in ListaPeces)
                    {
                        if (i.Id_pez == encontrado.Id_pez)
                        {
                            foreach (var ii in i.OceanoPez)
                            {
                                if (ii.Id_Oceano == oceano.Id_Oceano)
                                {
                                    agregado = false;
                                }
                                else
                                {
                                    encontrado.OceanoPez.Add(oceano);
                                    agregado = true;
                                    break;
                                }
                            }
                        }
                    }

                }

                return agregado;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public List<Oceano> OceanosxPez(int id)
        {
            var oceanosdepez = new List<Oceano>();
            foreach (var i in ListaPeces)
            {
                if (i.Id_pez == id)
                {
                    foreach (Oceano ocean in i.OceanoPez)
                    {
                        oceanosdepez.Add(ocean);

                    }
                }
            }
            return oceanosdepez;

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

        public bool PezEditado(Pez pez)
        {
            List<Oceano> oceanostemporales = new List<Oceano>();

            bool editado;
            try
            {
                bool encontrado = false;
                var id = pez.Id_pez;
                foreach (var i in ListaPeces)
                {
                    if (i.Id_pez == id)
                        encontrado = true;
                    oceanostemporales = i.OceanoPez;
                }

                if (encontrado)
                {
                    ListaPeces.RemoveAll(x => x.Id_pez == id);
                    pez.OceanoPez = oceanostemporales;
                    ListaPeces.Add(pez);
                    editado = true;
                }
                else
                    editado = false;
            }
            catch (Exception)
            {

                throw;
            }
            return editado;
        }

        //--------------------------------------Editar oceanos de pez--------------------------------------
        public bool EditarOceanoporPez(int id_pez, Oceano oceano)
        {
            bool editado = false;
            var Pez_encontrado = ListaPeces.Find(i => i.Id_pez == id_pez);
            if (Pez_encontrado == null)
                return false;

            Oceano ocean = new Oceano();
            foreach (var i in Pez_encontrado.OceanoPez)
            {
                if (oceano.Id_Oceano == i.Id_Oceano)
                {
                    ocean = i;
                    ocean.Fecha_PezenOceano = oceano.Fecha_PezenOceano;
                    ListaOceanos.RemoveAll(i => i.Id_Oceano == ocean.Id_Oceano);
                    ListaOceanos.Add(ocean);
                    editado = true;
                    break;
                }
                else
                    editado = false;
            }
            if (editado)
                return true;
            else
                return false;

        }
        //--------------------------------------Editar oceanos de pez--------------------------------------
        public bool EliminarPez(int id)
        {
            try
            {
                if (!ListaPeces.RemoveAll(i => i.Id_pez == id).Equals(0))
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
