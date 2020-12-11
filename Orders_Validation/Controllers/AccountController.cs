﻿using Orders_Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Orders_Validation.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    { 
        // GET: /Account/ 
        public ActionResult Login() 
        { 
            return View(); 
        } 

        [HttpPost] 
        public ActionResult Login(LogOnModel model, string returnUrl) { 
            if (ModelState.IsValid) { 
                if (Membership.ValidateUser(model.UserName, model.Password)) { 
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe); 
                    if (Url.IsLocalUrl(returnUrl)) { 
                        return Redirect(returnUrl); 
                    } 
                    else { 
                        return RedirectToAction("Index", "Orders"); 
                    } 
                } else{ 
                    ModelState.AddModelError("", "Невірний пароль або логін"); 
                }
                }
             return View(model); 
        }

            public ActionResult LogOff() { 
            FormsAuthentication.SignOut(); 
            return RedirectToAction("Login", "Account"); 
        }

            public ActionResult Register() { 
            return View(); 
        }

                 [HttpPost] 
                 public ActionResult Register(RegisterModel model) {
                 if (ModelState.IsValid)
                 {
                  MembershipCreateStatus createStatus; 
                  Membership.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);
                    if (createStatus == MembershipCreateStatus.Success) { 
                    FormsAuthentication.SetAuthCookie(model.UserName, false); 
                    return RedirectToAction("Login", "Account"); 
                } 
                else { ModelState.AddModelError("", "Помилка при реєстрації"); 
                         }
                    }
                     return View(model);
                 } 
    }
}