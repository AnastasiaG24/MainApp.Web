using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MainApp.Web.Models;


namespace MainApp.Web.Extensions
{
     public static class HttpContextExtensions
     {
          public static UserMinimal GetMySessionObject(this HttpContext current)
          {
               return (UserMinimal)current?.Session["_mySessionObject"];
          }
          public static void SetMySessionObject(this HttpContext current, UserMinimal profile)
          {
               current.Session.Add("_SessionObject", profile);
          }
     }
}