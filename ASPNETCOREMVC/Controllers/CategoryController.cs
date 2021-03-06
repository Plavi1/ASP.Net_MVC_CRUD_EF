﻿using ASPNETCOREMVC.Data;
using ASPNETCOREMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }
        //GET Create
        public IActionResult Create()
        {            
            return View();
        }
        //POST Create
        [HttpPost]                  //definisemo da je ovo post action metoda
        [ValidateAntiForgeryToken] //Sigurnost 
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if(obj==null)
            {
                return NotFound();
            }    
            return View(obj);
        }
        //POST Edit
        [HttpPost]                  //definisemo da je ovo post action metoda
        [ValidateAntiForgeryToken] //Sigurnost 
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST Delete
        [HttpPost]                  //definisemo da je ovo post action metoda
        [ValidateAntiForgeryToken] //Sigurnost 
        public IActionResult PostDelete(int id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            };           
            _db.Category.Remove(obj);
            _db.SaveChanges();
                return RedirectToAction("Index");
            
           
        }
    }
}
