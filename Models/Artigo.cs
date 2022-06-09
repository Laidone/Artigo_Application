using System.ComponentModel.DataAnnotations;

namespace Artigo_Application.Models
{
    public class Artigo
    {
        [Key]
        public int id { get; set; }
        public string Título { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Conteúdo { get; set; }
    }
}
