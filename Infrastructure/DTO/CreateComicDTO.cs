
namespace Infrastructure.DTO
{
    public class CreateComicDTO
    {
        public string Name { get; set; }
        public int IdEditorial { get; set; }
        public string Sinopsis  { get; set; }
        public string PrintYear { get; set; }

        public CreateComicDTO()
        {
            this.Name = String.Empty;
            this.IdEditorial = 0;
            this.Sinopsis = String.Empty;
            this.PrintYear = String.Empty;
        }

        public CreateComicDTO(string name, int idEditorial, string sinopsis, string printYear)
        {
            this.Name = name;
            this.IdEditorial = idEditorial;
            this.Sinopsis = sinopsis;
            this.PrintYear = printYear;
        }
    }
}
