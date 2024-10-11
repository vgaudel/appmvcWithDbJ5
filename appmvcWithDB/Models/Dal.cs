using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace appmvcWithDB.Models
{
    public class Dal : IDal
    {
        private BddContext _bddContext;
        public Dal()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public void InitializeDataBase()
        {
            DeleteCreateDatabase();
            CreerSejour("Quimper", "0236363636");
            CreerSejour("Brest", "0239393939");
            CreerSejour("Chambery", "0460040404");

            CreerUtilisateur("Valentin");
            CreerUtilisateur("Delphine");
            CreerUtilisateur("Florent");
            CreerUtilisateur("Pauline");
            CreerUtilisateur("Faustine");

            CreerSondage(new DateTime(2024,10,09));
            CreerSondage(DateTime.Now);

            CreerVote(_bddContext.Utilisateurs.Find(1), _bddContext.Sejours.Find(1), _bddContext.Sondages.Find(1)); 

        }

        public List<Sejour> ObtientTousLesSejours()
        {
            return _bddContext.Sejours.ToList();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }

        public int CreerSejour(string lieu, string telephone)
        {
            Sejour sejour = new Sejour() { Lieu = lieu, Telephone = telephone };
            _bddContext.Sejours.Add(sejour);
            _bddContext.SaveChanges();
            return sejour.Id;
        }

        public void ModifierSejour(int id, string lieu, string telephone)
        {
            Sejour sejour = _bddContext.Sejours.Find(id);

            if (sejour != null)
            {
                sejour.Lieu = lieu;
                sejour.Telephone = telephone;
                _bddContext.SaveChanges();
            }
        }

        public int CreerUtilisateur(string prenom)
        {
            Utilisateur utilisateur = new Utilisateur() { Prenom = prenom };
            _bddContext.Utilisateurs.Add(utilisateur);
            _bddContext.SaveChanges();
            return utilisateur.Id;
        }

        public int CreerSondage(DateTime date)
        {
            Sondage sondage = new Sondage
            {
                Date = date
            };
            _bddContext.Sondages.Add(sondage);
            _bddContext.SaveChanges();
            return sondage.Id;
        }
        public void CreerVote(Utilisateur utilisateur, Sejour sejour, Sondage sondage)
        {
            Vote vote = new Vote { Utilisateur = utilisateur, Sejour = sejour, Sondage = sondage };
            _bddContext.Votes.Add(vote);
            _bddContext.SaveChanges();
        }



        /******************************************************/
        /*          Méthodes pour l'authentification          */
        /******************************************************/
        public int AjouterUtilisateur(string nom, string password)
        {
            string motDePasse = EncodeMD5(password);
            Utilisateur user = new Utilisateur() { Prenom = nom, Password = motDePasse };
            this._bddContext.Utilisateurs.Add(user);
            this._bddContext.SaveChanges() ; 
            return user.Id;
        }

        public Utilisateur Authentifier(string nom, string password)
        {
            string motDePasse = EncodeMD5(password);
            Utilisateur user = this._bddContext.Utilisateurs.
                FirstOrDefault(user => (user.Prenom==nom)&&(user.Password==motDePasse));
            return user;
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return this._bddContext.Utilisateurs.Find(id);
        }

        public Utilisateur ObtenirUtilisateur(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.ObtenirUtilisateur(id);
            }
            return null;
        }

        private string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "TP_Authentification" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }
    }
}

