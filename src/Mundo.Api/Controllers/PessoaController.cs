using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mundo.Api.Models;
using Mundo.Business.Entity;
using Mundo.Business.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mundo.Api.Controllers
{
    [Route("api/[controller]")]
    public class PessoaController : MainController
    {
        public readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IMapper mapper, INotificator notificator, IPessoaRepository pessoaRepository) : base(mapper, notificator)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var pessoas = await _pessoaRepository.GetPessoaPets();

            return Ok(pessoas);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var pessoa = await _pessoaRepository.GetById(id);

            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<CreatePessoaViewModel>> Add(CreatePessoaViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pessoaRepository.Add(_mapper.Map<Pessoa>(model));

            return CustomResponse(model);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EditPessoaViewModel>> Update(Guid id, EditPessoaViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pessoaRepository.Update(_mapper.Map<Pessoa>(model));

            return CustomResponse(model);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            await _pessoaRepository.Delete(id);

            return CustomResponse();
        }
    }
}
