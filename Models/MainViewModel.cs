using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MainApp.Web.Models
{
     public class MainViewModel
     {
          public UserMinimal User { get; set; }
          public List<UserDbTable> Users { get; set; }
          public string MaskEmail(string email)
          {
               var displayCase = email;
               var partToBeObfuscated = Regex.Match(displayCase, @"[^@]*").Value;

               if (partToBeObfuscated.Length > 3)
               {
                    var obfuscation = "";
                    for (var i = 0; i < partToBeObfuscated.Length - 3; i++)
                         obfuscation += "*";

                    displayCase = string.Format("{0}{1}{2}", displayCase[0], obfuscation, displayCase.Substring(partToBeObfuscated.Length - 1));
               }
               else if (partToBeObfuscated.Length - 3 == 0)
               {
                    displayCase = string.Format("{0}**{1}", displayCase[0], displayCase.Substring(2));
               }

               return displayCase;
          }
     }
}