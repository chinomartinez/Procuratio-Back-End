namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO
{
    public interface IEntityEditionFormInitializerDTO<TDTO> where TDTO : IDTO
    {
        public TDTO BaseProperties { get; set; }
    }
}
