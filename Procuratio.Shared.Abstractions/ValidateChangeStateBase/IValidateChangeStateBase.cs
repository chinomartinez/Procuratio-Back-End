using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.ValidateChangeStateBase
{
    public interface IValidateChangeStateBase<TEntity>
    {
        void ValidateAndSetStateBeforeCreate(TEntity newEntity);

        void ValidateAndSetStateBeforeUpdate(TEntity currentEntity);
    }
}
