using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mundo.Api.Models.Pets;
using Mundo.Business.Entities;
using Mundo.Business.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mundo.Api.Controllers
{
    [Route("api/[controller]")]
    public class PetController : MainController
    {
        private IPetRepository _petRepository;
        public PetController(IMapper mapper, INotificator notificator, IPetRepository petRepository) : base(mapper, notificator)
        {
            _petRepository = petRepository;
        }

        [HttpGet()]
        public async Task<ActionResult> GetAll()
        {
            var pets = await _petRepository.GetAll();

            return Ok(pets);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var pet = await _petRepository.GetById(id);

            return Ok(pet);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreatePetViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _petRepository.Add(_mapper.Map<Pet>(model));

            return CustomResponse(model);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, EditPetViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _petRepository.Update(_mapper.Map<Pet>(model));

            return CustomResponse(model);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _petRepository.Delete(id);

            return CustomResponse();
        }
    }
}
