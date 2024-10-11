using System.Collections.Generic;
using System;

namespace appmvcWithDB.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();
        List<Sejour> ObtientTousLesSejours();
        int AjouterUtilisateur(string nom, string password);
        Utilisateur Authentifier(string nom, string password);
        Utilisateur ObtenirUtilisateur(int id);
        Utilisateur ObtenirUtilisateur(string idStr);
    }
}
