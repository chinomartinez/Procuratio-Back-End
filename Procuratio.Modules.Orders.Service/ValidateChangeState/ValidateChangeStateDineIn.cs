using Procuratio.Modules.Orders.DataAccess.EF.Repositories;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.ValidateChangeState
{
    internal class ValidateChangeStateDineIn : IValidateChangeStateDineIn
    {
        public void SetFromWithoutStateToInProgress(DineIn dineIn)
        {
            dineIn.DinerInStateID = (short)DineInState.State.InProgress;
        } 
    }
}
