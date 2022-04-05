using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Application.Features._NameOfEntity_.Commands;
using Template.WebAPI.Dtos;

namespace Template.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class _NameOfEntityConroller_ : BaseController
    {
        private readonly IMapper _mapper;

        public _NameOfEntityConroller_(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Аник
        /// Ostorojьno
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<ActionResult<Guid>> CreateObject([FromBody] _NameOfEntityDto_ createDto)
        {
            var command = _mapper.Map<Create_NameOfEntity_Command>(createDto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }
    }
}
