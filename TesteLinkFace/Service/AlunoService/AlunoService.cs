using Microsoft.EntityFrameworkCore;
using TesteLinkFace.DataContext;
using TesteLinkFace.Models;

namespace TesteLinkFace.Service.AlunoService
{
    public class AlunoService : IAlunoInterface
    {
        private readonly ApplicationDbContext _context;
        public AlunoService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<AlunosModel>>> CreatAluno(AlunosModel novoAluno)
        {
            ServiceResponse<List<AlunosModel>> serviceResponse = new ServiceResponse<List<AlunosModel>>();
            
            try 
            {
            if(novoAluno == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Necessário Informar Dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                _context.Add(novoAluno);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Alunos.ToList();
            }catch (Exception ex) 
            {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AlunosModel>>> DeleteAluno(int Id)
        {
            ServiceResponse<List<AlunosModel>> serviceResponse = new ServiceResponse<List<AlunosModel>>();
            try
            {
                AlunosModel aluno = _context.Alunos.FirstOrDefault(x => x.Id == Id);

                if (aluno == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Aluno Não Localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Alunos.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<AlunosModel>> GetAlunoById(int Id)
        {
            ServiceResponse<AlunosModel> serviceResponse = new ServiceResponse<AlunosModel> ();
            try
            {

                AlunosModel aluno = _context.Alunos.FirstOrDefault(x => x.Id == Id);
                
                if (aluno == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Aluno Não localizado!";
                    serviceResponse.Sucesso = false;
                }
                serviceResponse.Dados = aluno;


            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
       

        public async Task<ServiceResponse<List<AlunosModel>>> GetAlunos()
        {
            ServiceResponse < List<AlunosModel>> serviceResponse = new ServiceResponse<List<AlunosModel>> ();
            try
            {
                serviceResponse.Dados = _context.Alunos.ToList();
                if (serviceResponse.Dados.Count == 0) 
                {
                    serviceResponse.Mensagem = "Nenhum Dado Encontrado!";
                }
            }catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AlunosModel>>> InativaAluno(int id)
        {
            ServiceResponse<List<AlunosModel>> serviceResponse = new ServiceResponse<List<AlunosModel>>();
            try 
            {

                AlunosModel aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);
                if (aluno == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Aluno Não Localizado!";
                    serviceResponse.Sucesso= false;
                }

                aluno.Ativo = false;
                aluno.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Alunos.Update(aluno);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Alunos.ToList();

            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AlunosModel>>> UpdateAluno(AlunosModel editadoAluno)
        {
            ServiceResponse<List<AlunosModel>> serviceResponse = new ServiceResponse<List<AlunosModel>>();
            try
            {
            AlunosModel aluno = _context.Alunos.AsNoTracking().FirstOrDefault(x => x.Id==editadoAluno.Id);
                if (aluno == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Aluno Não Localizado!";
                    serviceResponse.Sucesso = false;
                }

                aluno.DataDeAlteracao = DateTime.Now.ToLocalTime();
                _context.Alunos.Update(editadoAluno);
                await _context.SaveChangesAsync();

                serviceResponse.Dados= _context.Alunos.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

    }
}
