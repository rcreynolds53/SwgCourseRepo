﻿using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Edit(int studentId)
        {
            var student = StudentRepository.Get(studentId);

            var viewModel = new StudentVM();

            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());
            viewModel.Student.StudentId = student.StudentId;
            viewModel.Student.FirstName = student.FirstName;
            viewModel.Student.LastName = student.LastName;
            viewModel.Student.GPA = student.GPA;
            viewModel.Student.Major = student.Major;
            viewModel.Student.Courses = student.Courses;
            viewModel.Student.Address = student.Address;
            viewModel.CoursesCheckBoxes = (from course in CourseRepository.GetAll()
                                           select new CoursesCheckBoxItem { Course = course, IsSelected = student.Courses.Any(c => c.CourseId == course.CourseId) }).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            var selectedCourses = studentVM.CoursesCheckBoxes.Where(c => c.IsSelected).Select(c=>c.Course.CourseId);
            studentVM.Student.Courses = new List<Course>();
            foreach (var course in selectedCourses)
                studentVM.Student.Courses.Add(CourseRepository.Get(course));
            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
            //studentVM.Student.GPA = StudentRepository
            StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
            StudentRepository.Edit(studentVM.Student);
            return RedirectToAction("List");

        }
    }
}