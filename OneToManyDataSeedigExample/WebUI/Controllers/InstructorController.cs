using System;
using System.Collections.Generic;
using Data;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class InstructorController: Controller
    {
        private IInstructorRepository _instructorRepository;
        private ICourseRepository _courseRepository;

        public InstructorController(IInstructorRepository instructorRepository, ICourseRepository courseRepository)
        {
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
        }

        public IActionResult List(){
            List<Instructor> instructors = _instructorRepository.FindAll();
            return View(instructors);
        }

        public IActionResult Courses(int theId){
            Instructor instructor = _instructorRepository.FindById(theId);
            
            if(instructor == null){
                throw new NotFoundInstrunctorException("Not found Instructor");
            }

            ViewBag.Instructor = instructor;

            return View(instructor.Courses);
        }
    }

    public class NotFoundInstrunctorException : Exception{
        public NotFoundInstrunctorException(string message):base(message)
        {
            
        }
    }
}