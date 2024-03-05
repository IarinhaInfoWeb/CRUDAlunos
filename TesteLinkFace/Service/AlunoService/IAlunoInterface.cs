using TesteLinkFace.Models;

namespace TesteLinkFace.Service.AlunoService
{
    public interface IAlunoInterface
    {
        Task<ServiceResponse<List<AlunosModel>>> GetAlunos();
        Task<ServiceResponse<List<AlunosModel>>> CreatAluno(AlunosModel novoAluno);
        Task<ServiceResponse<AlunosModel>> GetAlunoById(int Id);
        Task<ServiceResponse<List<AlunosModel>>> UpdateAluno(AlunosModel editadoAluno);
        Task<ServiceResponse<List<AlunosModel>>> DeleteAluno(int Id);
        Task<ServiceResponse<List<AlunosModel>>> InativaAluno(int Id);

    }
}
