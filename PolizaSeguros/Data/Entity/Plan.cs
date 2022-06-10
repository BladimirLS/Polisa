namespace PolizaSeguros.Data.Entity
{
    public class Plan
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Dues { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

    }
}
