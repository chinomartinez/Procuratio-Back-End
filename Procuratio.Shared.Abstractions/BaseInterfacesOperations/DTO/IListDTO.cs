namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO
{
    public interface IListDTO<TDTO> where TDTO : IDTO
    {
        public TDTO BaseProperties { get; set; }
    }
}
