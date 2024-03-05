using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteLinkFace.Models;
using TesteLinkFace.Service.AlunoService;

namespace TesteLinkFace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoInterface _alunoInterface;
        public AlunoController(IAlunoInterface alunoInterface) 
        {
        _alunoInterface = alunoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<AlunosModel>>>> GetAlunos() 
        {
        return Ok(await _alunoInterface.GetAlunos());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ServiceResponse<AlunosModel>>> GetAlunoById(int Id)
        {
            ServiceResponse<AlunosModel> serviceResponse = await _alunoInterface.GetAlunoById(Id);
            return Ok(serviceResponse);
        }
       

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<AlunosModel>>>> CreatAluno(AlunosModel novoAluno)
        {
            return Ok(await _alunoInterface.CreatAluno(novoAluno));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<AlunosModel>>>> UpdateAluno(AlunosModel editadoAluno)
        {
        ServiceResponse<List<AlunosModel>> serviceResponse = await _alunoInterface.UpdateAluno(editadoAluno);
            return Ok(serviceResponse);
        }

        [HttpPut("InativaAluno/{Id}")]
        public async Task<ActionResult<ServiceResponse<List<AlunosModel>>>> InativaAluno(int Id)
        {
            ServiceResponse<List<AlunosModel>> serviceResponse = await _alunoInterface.InativaAluno(Id);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<AlunosModel>>>> DeleteAluno(int Id)
        {
            ServiceResponse<List<AlunosModel>> serviceResponse = await _alunoInterface.DeleteAluno(Id);
            return Ok(serviceResponse);
        }

    }
}
