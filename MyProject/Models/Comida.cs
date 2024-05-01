namespace Comidas.Models
{
    public record Comida
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool FrutosMar { get; set; }

        public string Creator { get; set; }

        public Comida(Guid Id, string Name, string Creator, bool FrutosMar = false)
        {
            this.Id = Id;
            this.Name = Name;
            this.FrutosMar = FrutosMar;
            this.Creator = Creator;
        }
    }
}