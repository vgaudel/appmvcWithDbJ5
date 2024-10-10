using System.Collections.Generic;
using System;

namespace appmvcWithDB.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();
        List<Sejour> ObtientTousLesSejours();
    }
}
