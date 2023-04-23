using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalTest.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace FinalTest.Controllers;

public class HomeController : Controller
{

    private IRepo _repo { get; set; }
    public HomeController(IRepo temp)
    {
        _repo = temp;
    }
    //The list will be pasted to the view
    public IActionResult Index()
    {
        var x = _repo.Books
            //Lets you filter
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
        _repo.Add(response);
        return RedirectToAction("Index");
    }


    //Get info to edit
    [HttpGet]
    public IActionResult Edit(int id)
    {
        //populate with the right movie info based on id
        var book = _repo.GetById(id);
        //Take you to the form 
        return View("Form", book);
    }
    //post info of edit
    [HttpPost]
    public IActionResult Edit(Book change)
    {
        _repo.UpdateBook(change);
        return RedirectToAction("Index");
    }


    //Allow user to delete
    [HttpGet]
    public IActionResult Delete(int id)
    {
        //get information of the bookID that will be deleted based on id
        var book = _repo.GetById(id);
        return View(book);
    }

    //Post deleted results 
    [HttpPost]
    public IActionResult Delete(Book response)
    {
        _repo.Delete(response);

        return RedirectToAction("Index");
    }
}

