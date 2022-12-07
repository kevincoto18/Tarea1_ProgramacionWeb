namespace Tarea1.Modelo
{
    public class Pez
    {
        public int Id_pez { get; set; }
        public string Nombre_pez { get; set; }

        public string Fecha_pez { get; set; }
        
        public List<Oceano> OceanoPez { get; set; }
    }
}
