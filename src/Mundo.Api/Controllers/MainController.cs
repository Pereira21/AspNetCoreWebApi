﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mundo.Business.Interfaces;
using Mundo.Business.Notifications;
using System.Linq;

namespace Mundo.Api.Controllers
{
    [ApiController]
    public class MainController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly INotificator _notificator;

        public MainController(IMapper mapper, INotificator notificator)
        {
            _mapper = mapper;
            _notificator = notificator;
        }

        protected bool OperacaoValida()
        {
            return !_notificator.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida()) return Ok(new { success = true, data = result });

            return BadRequest(new { success = false, errors = _notificator.ObterNotificacoes().Select(n => n.Mensagem) });

        }
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);

            return CustomResponse();
        }

        private void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string errorMsg)
        {
            _notificator.Handle(new Notification(errorMsg));
        }
    }
}
