using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Orders.API.Controllers.Base;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.API.Controllers
{
    internal class DinerInController : BaseController
    {
        private readonly IDinerInService _dinerInService;

        public DinerInController(IDinerInService dinerInService)
        {
            _dinerInService = dinerInService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DinerInDetailsDTO>> GetAsync(int id)
        {
            ActionResult<DinerInDetailsDTO> dinerInDetailsDTO = await _dinerInService.GetAsync(id);

            if (dinerInDetailsDTO is null)
            {
                return NotFound();
            }

            return Ok(dinerInDetailsDTO);
        }

        //[HttpPost]
        //public async Task<ActionResult> AddAsync(DinerInCreationDto dto)
        //{
        //    await _conferenceService.AddAsync(dto);
        //    return CreatedAtAction(nameof(Get), new { id = dto.Id }, null);
        //}

        //[HttpGet]
        //public async Task<ActionResult<IReadOnlyList<ConferenceDto>>> BrowseAsync()
        //    => Ok(await _conferenceService.BrowseAsync());

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateAsync(Guid id, ConferenceDetailsDto dto)
        //{
        //    dto.Id = id;
        //    await _conferenceService.UpdateAsync(dto);
        //    return NoContent();
        //}
    }
}
