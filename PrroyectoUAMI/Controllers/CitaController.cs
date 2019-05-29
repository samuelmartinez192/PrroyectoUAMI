using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrroyectoUAMI.Models;
using PrroyectoUAMI.Repository;

namespace PrroyectoUAMI.Controllers
{
    public class CitaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Cita> citas = null;
            try
            {
                var serviceObj = new ServiceRepository("http://148.210.101.13:50240/");
                var uri = "api/Cita";
                HttpResponseMessage response = serviceObj.GetReponse(uri);
                response.EnsureSuccessStatusCode();
                citas = response.Content.ReadAsAsync<List<Cita>>().Result;
                ViewBag.Title = "Todos los usuarios";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return View(citas);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Cita cita = null;

            try
            {
                var serviceObj = new ServiceRepository("http://148.210.101.13:50240/");
                var uri = $"api/Cita/{id}";
                //var uri = $"api/user/GetUser?id={id}";
                HttpResponseMessage response = serviceObj.GetReponse(uri);
                response.EnsureSuccessStatusCode();
                cita = response.Content.ReadAsAsync<Cita>().Result;
                ViewBag.Title = "Todas las citas";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return View(cita);
        }

        public IActionResult Edit(Cita cita)
        {
            var serviceObj = new ServiceRepository("http://148.210.101.13:50240/");
            //var uri = "api/user/UpdateUser";
            var uri = "api/Cita";
            HttpResponseMessage response = serviceObj.PutResponse(uri, cita);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Cita cita = null;

            try
            {
                var serviceObj = new ServiceRepository("http://148.210.101.13:50240/");
                var uri = $"api/cita/{id}";
                //var uri = $"api/user/GetUser?id={id}";
                HttpResponseMessage response = serviceObj.GetReponse(uri);
                response.EnsureSuccessStatusCode();
                cita = response.Content.ReadAsAsync<Cita>().Result;
                ViewBag.Title = "Todos los usuarios";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return View(cita);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cita cita)
        {
            try
            {
                var serviceObj = new ServiceRepository("http://148.210.101.13:50240/");
                var uri = "api/cita";
                //var uri = "api/user/InsertUser";
                HttpResponseMessage response = serviceObj.PostResponse(uri, cita);
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
                var serviceObj = new ServiceRepository("http://148.210.101.13:50240/");
                var uri = $"api/cita/{id}";
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