using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.ProcuratioFramework.JWT
{
	/// <summary>
	/// Nombres de claim de JWT oversoft
	/// </summary>
	public readonly struct JWTClaimNames
	{
		public const string BranchId = "branch_id";
		public const string UserFullName = "user_full_name";
		public const string Role = "role";
	}
}
