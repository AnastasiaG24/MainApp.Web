using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Product;
using eUseControl.Domain.Entities.Res;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eUseControl.BusinessLogic.Core
{
     internal class AdminApi : ISession, IAdminOfert
     {
        private readonly UserContext db;

        public AdminApi()
        {
            db = new UserContext();
        }

        public void AddOfert(Ofert ofert)
        {
            // TODO add validation
            if (ofert.Name == "")
            {
                throw new System.ArgumentException("Insereaza numele ofertei");
            }
            if (ofert.Description == "")
            {
                throw new System.ArgumentException("Insereaza descrierea ofertei");
            }
            if (ofert.EndDate <= ofert.StartDate)
            {
                throw new System.ArgumentException("Data de sfarsit trebuie sa fie dupa cea de inceput");
            }
            if (ofert.Price <= 0)
            {
                throw new System.ArgumentException("Pretul trebuie sa fie mai mare ca 0");
            }
            // add some business logic

            var exists = db.Oferts.FirstOrDefault(newOfert => newOfert.Name == ofert.Name &&
            newOfert.StartDate == ofert.StartDate &&
            newOfert.EndDate == ofert.EndDate);

            if (exists != null)
            {
                throw new InvalidOperationException("O ofertă cu același nume și perioadă există deja.");
            }
            // add to database dar ea inca nu-i
            db.Oferts.Add(ofert);
            db.SaveChanges();
        }

        public LevelStatus CheckLevel(string key)
        {
            var user = db.Users.FirstOrDefault(searchedUser => searchedUser.Username == key);

            if (user == null)
            {
                throw new ArgumentException($"Utilizatorul cu ID-ul {key} nu a fost găsit.");
            }

            return new LevelStatus
            {
                Level = user.Level,
                SessionTime = user.LastLogin
            };
        }

        public void DeleteOfertById(int id)
        {
            var ofert = db.Oferts.FirstOrDefault(toBeDeletedOfert => toBeDeletedOfert.Id == id);

            if (ofert == null)
            {
                throw new ArgumentException($"Nu s-a găsit nicio ofertă cu ID-ul {id}.");
            }

            db.Oferts.Remove(ofert);
            db.SaveChanges();
        }

        public List<Ofert> GetAllOferts()
        {
            return db.Oferts.ToList();
        }

        public Ofert GetOfertById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID-ul ofertei nu poate fi nepozitiv.");
            }

            var ofert = db.Oferts.FirstOrDefault(searchedOfert => searchedOfert.Id == id);

            if (ofert == null)
            {
                throw new ArgumentException($"Oferta cu ID-ul {id} nu a fost găsită.");
            }

            return ofert;
        }

        public void UpdateOfert(Ofert ofert)
        {
            if (ofert.Name == "")
            {
                throw new System.ArgumentException("Insereaza numele ofertei");
            }
            if (ofert.Description == "")
            {
                throw new System.ArgumentException("Insereaza descrierea ofertei");
            }
            if (ofert.EndDate <= ofert.StartDate)
            {
                throw new System.ArgumentException("Data de sfarsit trebuie sa fie dupa cea de inceput");
            }
            if (ofert.Price <= 0)
            {
                throw new System.ArgumentException("Pretul trebuie sa fie mai mare ca 0");
            }

            var existingOfert = db.Oferts.FirstOrDefault(updatedOfert => updatedOfert.Id == ofert.Id);

            if (existingOfert == null)
            {
                throw new ArgumentException($"Nu s-a găsit nicio ofertă cu ID-ul {ofert.Id}.");
            }
            db.SaveChanges();
        }

        public ActionStatus UserLogin(UserLoginData data)
        {
            var status = new ActionStatus();

            if (string.IsNullOrEmpty(data.Credential) || string.IsNullOrEmpty(data.Password))
            {
                status.Status = false;
                status.StatusMessage = "Credențialele nu pot fi goale.";
                return status;
            }

            var user = db.Users.FirstOrDefault(u => u.Username == data.Credential || u.Email == data.Credential);

            if (user == null)
            {
                status.Status = false;
                status.StatusMessage = $"Utilizatorul '{data.Credential}' nu a fost găsit.";
                return status;
            }
            if (user.Password != data.Password)
            {
                status.Status = false;
                status.StatusMessage = "Parola este incorectă.";
                return status;
            }
            user.LastLogin = data.LoginDataTime;
            user.LastIp = data.LoginIp;
            db.SaveChanges();
            return status;
        }
    }
}
