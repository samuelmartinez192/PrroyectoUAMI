using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrroyectoUAMI.Models;
using PrroyectoUAMI.Repository;

namespace PrroyectoUAMI.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<User> users = null;
            try
            {
                var serviceObj = new ServiceRepository();
                var uri = "api/user";
                HttpResponseMessage response = serviceObj.GetReponse(uri);
                response.EnsureSuccessStatusCode();
                users = response.Content.ReadAsAsync<List<User>>().Result;
                ViewBag.Title = "Todos los usuarios";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return View(users);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            User user = null;

            try
            {
                var serviceObj = new ServiceRepository();
                var uri = $"api/user/{id}";
                //var uri = $"api/user/GetUser?id={id}";
                HttpResponseMessage response = serviceObj.GetReponse(uri);
                response.EnsureSuccessStatusCode();
                user = response.Content.ReadAsAsync<User>().Result;
                ViewBag.Title = "All Products";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return View(user);
        }

        public IActionResult Edit(User user)
        {
            var serviceObj = new ServiceRepository();
            //var uri = "api/user/UpdateUser";
            var uri = "api/user";
            HttpResponseMessage response = serviceObj.PutResponse(uri, user);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            User user = null;

            try
            {
                var serviceObj = new ServiceRepository();
                var uri = $"api/user/{id}";
                //var uri = $"api/user/GetUser?id={id}";
                HttpResponseMessage response = serviceObj.GetReponse(uri);
                response.EnsureSuccessStatusCode();
                user = response.Content.ReadAsAsync<User>().Result;
                ViewBag.Title = "Todos los usuarios";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                var serviceObj = new ServiceRepository();
                var uri = "api/user";
                //var uri = "api/user/InsertUser";
                HttpResponseMessage response = serviceObj.PostResponse(uri, user);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var serviceObj = new ServiceRepository();
                var uri = $"api/user/{id}";
                //var uri = $"api/user/DeleteUser?id={id}";
                HttpResponseMessage response = serviceObj.DeleteResponse(uri);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return RedirectToAction("Index");
        }
    }
}