using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRazor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRazor.Pages.EmployeeManager
{
  [Authorize(Roles = "Manager")]
  public class InsertModel : PageModel
  {
    private readonly AppDbContext db = null;

    [BindProperty]
    public Employee Employee { get; set; }
    public List<SelectListItem> Countries { get; set; }
    public string Message { get; set; }


    public InsertModel(AppDbContext db)
    {
      this.db = db;
    }

    public void OnGet()
    {
      
    }

    public void OnPost()
    {
      if (ModelState.IsValid)
      {
        try
        {
          db.Employees.Add(Employee);
          db.SaveChanges();
          Message = "Employee Inserted Successfully";
        }
        catch (DbUpdateException ex1)
        {
          Message = ex1.Message;
          if(ex1.InnerException != null)
          {
            Message += ": " + ex1.InnerException.Message;
          }
        }
        catch(Exception ex2)
        {
          Message = ex2.Message;
        }
      }
    }
  }
}
