using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces
{
    /// <summary>
    /// Interfaz para implementar el método <see cref="CreateForeignKeys"/> 
    /// y ejecutarse en el Startup que verifica las migración.
    /// </summary>
    public interface ICreateForeignKey
    {
        void CreateForeignKeys();
    }
}
