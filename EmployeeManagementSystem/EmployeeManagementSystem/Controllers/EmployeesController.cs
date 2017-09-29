﻿using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
       [HttpGet]
       public ActionResult List()
        {
            //want to put data into this View for both employee and department object.
            // to solve the Iernumerable issue, can either put () around the whole statement and then .ToList, or just change the List to Ienumerable 
            IEnumerable<EmployeeListViewModel> model = from employee in EmployeeRepository.GetAllEmployee()
                                                join department in DepartmentRepository.GetAll()
                                                on employee.DepartmentId equals department.DepartmentId
                                                select new EmployeeListViewModel()
                                                {
                                                    Name = employee.FirstName + " " + employee.LastName,
                                                    Department = department.DepartmentName,
                                                    Phone = employee.Phone,
                                                    EmployeeId = employee.EmployeeId,
                                                };

                                           
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddEmployeeViewModel model = new AddEmployeeViewModel();
            model.Departments = (from department in DepartmentRepository.GetAll()
                                 select new SelectListItem()
                                 {
                                     Text = department.DepartmentName,
                                     Value = department.DepartmentId.ToString(),
                                 }).ToList();                      
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Phone = model.Phone;
                employee.DepartmentId = model.DepartmentId;

                EmployeeRepository.Add(employee);
                return RedirectToAction("List");
            }
            else
            {
                model.Departments = (from department in DepartmentRepository.GetAll()
                                     select new SelectListItem()
                                     {
                                         Text = department.DepartmentName,
                                         Value = department.DepartmentId.ToString(),
                                     }).ToList();
                return View(model);
            }                     
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = EmployeeRepository.GetEmployee(id);

            var model = new EditEmployeeViewModel();
            model.FirstName = employee.FirstName;
            model.LastName = employee.LastName;
            model.DepartmentId = employee.DepartmentId;
            model.Phone = employee.Phone;
            model.EmployeeId = employee.EmployeeId;

            model.Departments = GetDepartmentSelectList();
            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(EditEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.EmployeeId = model.EmployeeId;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Phone = model.Phone;
                employee.DepartmentId = model.DepartmentId;

                EmployeeRepository.Edit(employee);
                return RedirectToAction("List");
            }
            else
            {
                model.Departments = GetDepartmentSelectList();
                return View(model);
            }
        }
        private List<SelectListItem> GetDepartmentSelectList ()
        {
           return (from department in DepartmentRepository.GetAll()
                                 select new SelectListItem()
                                 {
                                     Text = department.DepartmentName,
                                     Value = department.DepartmentId.ToString(),
                                 }).ToList();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeRepository.Delete(id);

            return RedirectToAction("List");
            return View();
        }
    }
}