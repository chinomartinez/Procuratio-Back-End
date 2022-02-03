namespace Procuratio.Shared.Abstractions.Tenant
{
    public interface ITenantService
    {
        /// <summary>
        /// Get the current branch ID.
        /// </summary>
        /// <returns>Branch ID or null if its an annonimous endpoint</returns>
        public int? GetBranchId();
    }
}
