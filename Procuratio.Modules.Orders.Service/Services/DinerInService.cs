using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Services
{
    internal class DinerInService : IDinerInService
    {
        private readonly IDinerInRepository _dinerInRepository;
        private readonly IMapper _mapper;

        public DinerInService(IDinerInRepository dinerInRepository, IMapper mapper)
        {
            _dinerInRepository = dinerInRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult<DinerInDetailsDTO>> GetAsync(int id)
        {
            DinerIn dinerIn = await _dinerInRepository.GetAsync(id);

            return _mapper.Map<DinerInDetailsDTO>(dinerIn);
        }
    }
}
