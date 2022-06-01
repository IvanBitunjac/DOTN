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
  public class UpdateModel : PageModel
  {
    private readonly AppDbContext db = null;

    [BindProperty]
    public Employee Employee { get; set; }
    public List<SelectListItem> Countries { get; set; }
    public string Message { get; set; }
    public bool DataFound { get; set; } = true;

    public UpdateModel(AppDbContext db)
    {
      this.db = db;
    }


    public void OnGet(int id)
    {
      Employee = db.Employees.Find(id);

      if(Employee == null)
      {
        DataFound = false;
        Message = "Employee ID not found";
      }
      else
      {
        DataFound = true;
        Message = "";
      }
    }

    public void OnPost()
    {
      if (ModelState.IsValid)
      {
        try
        {
          db.Employees.Update(Employee);
          db.SaveChanges();
          Message = "Employee Updated Successfully";
        }
        catch (DbUpdateException ex1)
        {
          Message = ex1.Message;
          if (ex1.InnerException != null)
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
