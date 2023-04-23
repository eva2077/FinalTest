using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalTest.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace FinalTest.Controllers;

public class HomeController : Controller
{

    private Context _context { get; set; }
    public HomeController(Context temp)
    {
        _context = temp;
    }
    //The list will be pasted to the view
    public IActionResult Index()
    {
        var x = _context.Books
            //.Where(x => x.Category == "Comedy")
            .ToList();

        return View(x);
    }

    //Get the form
    [HttpGet]
    public IActionResult Form()
    {

        return View();
    }

    //Add to list from the form 
    [HttpPost]
    public IActionResult Form(Book response)
    {

        _context.Add(response);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


    //Get info to edit
    [HttpGet]
    public IActionResult Edit(int id)
    {
        //populate with the right movie info based on id
        var application = _context.Books.Single(x => x.BookID == id);
        //Take you to the form 
        return View("Form", application);
    }
    //post info of edit
    [HttpPost]
    public IActionResult Edit(Book change)
    {
        _context.Update(change);
        _context.SaveChanges();
        return RedirectToAction("Form");
    }


    //Allow user to delete
    [HttpGet]
    public IActionResult Delete(int id)
    {
        //get information of the movieId that will be deleted based on id
        var application = _context.Books.Single(x => x.BookID == id);
        return View(application);
    }

    //Post deleted results 
    [HttpPost]
    public IActionResult Delete(Book response)
    {
        _context.Books.Remove(response);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}

