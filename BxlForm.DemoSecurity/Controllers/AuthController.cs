using BxlForm.DemoSecurity.Infrastructure;
using BxlForm.DemoSecurity.Models.Client.Data;
using BxlForm.DemoSecurity.Models.Client.Repositories;
using BxlForm.DemoSecurity.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly ISessionManager _sessionManager;

        public AuthController(IAuthRepository authRepository, ISessionManager sessionManager)
        {
            _authRepository = authRepository;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            if (_sessionManager.User is not null)
                return RedirectToAction("Index", "Contact");

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if (_sessionManager.User is not null)
                return RedirectToAction("Index", "Contact");

            if (!ModelState.IsValid)
                return View(form);

            User user = _authRepository.Login(form.Email, form.Passwd);

            if(user is null)
            {
                ModelState.AddModelError("", "Email ou mot de passe invalide!!!");
                return View(form);
            }

            _sessionManager.User = new UserSession() { Id = user.Id, LastName = user.LastName, FirstName = user.FirstName, IsAdmin = user.IsAdmin };           

            return RedirectToAction("Index", "Contact");
        }

        public IActionResult Register()
        {
            if (_sessionManager.User is not null)
                return RedirectToAction("Index", "Contact");

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterForm form)
        {
            if (_sessionManager.User is not null)
                return RedirectToAction("Index", "Contact");

            if (!ModelState.IsValid)
                return View(form);

            _authRepository.Register(new User(form.LastName, form.FirstName, form.Email, form.Passwd));
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            if (_sessionManager.User is null)
                return RedirectToAction("Login");

            //en ASP .Net MVC Classic ==> Session.Abandon()
            _sessionManager.Clear();
            return RedirectToAction("Login");
        }
    }
}
