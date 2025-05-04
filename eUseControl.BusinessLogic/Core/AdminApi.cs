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
     internal class AdminApi : ISession, IAdminOfert, IAuth
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

          public bool CheckUserExists(string credential, string email)
          {
               if (string.IsNullOrWhiteSpace(credential) || string.IsNullOrWhiteSpace(email))
                    return false;

               using (var db = new UserContext())
               {
                    var exists = db.Users.Any(u =>
                        u.Credential == credential || u.Email == email);

                    return exists;
               }
          }

          public bool RegisterUser(UserRegisterData register)
          {
               if (register.Credential == "")
               {
                    throw new ArgumentException("Numele de utilizator este obligatoriu.");
               }

               if (register.Password == "")
               {
                    throw new ArgumentException("Parola este obligatorie.");
               }

               if (register.Password.Length < 8)
               {
                    throw new ArgumentException("Parola trebuie să conțină cel puțin 8 caractere.");
               }

               if (register.Password != register.ConfirmPassword)
               {
                    throw new ArgumentException("Parolele nu coincid.");
               }

               if (register.Email == "")
               {
                    throw new ArgumentException("Emailul este obligatoriu.");
               }

               if (!register.Email.Contains("@") || !register.Email.Contains("."))
               {
                    throw new ArgumentException("Formatul emailului nu este valid.");
               }

               if (register.Country == "")
               {
                    throw new ArgumentException("Țara este obligatorie.");
               }


               var exists = db.Users.FirstOrDefault(u =>
                   u.Credential == register.Credential || u.Email == register.Email);

               if (exists != null)
                    throw new InvalidOperationException("Utilizatorul sau emailul există deja.");

               var newUser = new UserDbTable
               {
                    Credential = register.Credential,
                    Password = register.Password, // TODO hash the password
                    Email = register.Email,
                    Country = register.Country,
                    CreatedAt = DateTime.Now
               };

               db.Users.Add(newUser);
               db.SaveChanges();

               return true;
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
               status.Status = true;
               status.StatusMessage = "Autentificare cu succes.";
               status.SessionKey = user.Username;
               db.SaveChanges();
               return status;
          }
     }
}
