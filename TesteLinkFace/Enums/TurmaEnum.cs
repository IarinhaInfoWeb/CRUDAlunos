using System.Text.Json.Serialization;

namespace TesteLinkFace.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurmaEnum
    {
        Turma_1A,
        Turma_1B,
        Turma_2A,
        Turma_2B,
        Turma_3A,
        Turma_3B,
        Turma_4A,
        Turma_4B

    }
}
