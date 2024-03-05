using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using TesteLinkFace.Enums;

namespace TesteLinkFace.Models
{
    public class AlunosModel
    {
        [Key]
        public int Id { get; set; }
        public int CodigodaMatricula { get; set; }
        public string Nome { get; set; }
        public TurmaEnum Turma { get; set; }
        public bool Ativo { get; set; }
        public string Foto { get; set;}
        public DateTime DataDeCriacao { get; set; }= DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set;}= DateTime.Now.ToLocalTime();

    }
}
