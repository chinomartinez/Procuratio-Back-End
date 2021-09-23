namespace Procuratio.ProcuratioFramework.ProcuratioFramework.ValidateChangeStateBase
{
    public interface IValidateChangeStateBase<TEntity>
    {
        void ValidateAndSetStateBeforeCreate(TEntity newEntity);

        void ValidateAndSetStateBeforeUpdate(TEntity currentEntity);
    }
}
