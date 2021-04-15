namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class StateBaseEntity : BaseIdentity<int>
    {
        public string StateName { get; set; }
    }
}
