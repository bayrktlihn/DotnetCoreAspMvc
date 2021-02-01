using Microsoft.AspNetCore.Mvc;
using MyProject.Data;
using System.Collections.Generic;
using MyProject.Entity;
using System;
using AutoMapper;
using MyProject.WebUI.ViewModels;

namespace MyProject.WebUI.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository _personRepository;
        private MapperConfiguration _mapperConfiguration;
        

        public PersonController(IPersonRepository personRepository, MapperConfiguration mapperConfiguration)
        {
            _personRepository = personRepository;
            _mapperConfiguration = mapperConfiguration;
        }
        public IActionResult List(){
            List<Person> people = _personRepository.FindAll();
            return View(people);
        }

        public IActionResult Index(int? id){
            Person person;
            if(id == null)
                person = new Person();
            else {
                person = _personRepository.FindById(id.Value);
            }

            Mapper mapper = new Mapper(_mapperConfiguration);
            PersonViewModel personViewModel = mapper.Map<PersonViewModel>(person);


            return View(personViewModel);
        }

        [HttpPost]
        public IActionResult Index(PersonViewModel personViewModel){

            if(ModelState.IsValid){
                Mapper mapper = new Mapper(_mapperConfiguration);

                Person person = mapper.Map<Person>(personViewModel);

                _personRepository.Save(person);

                return RedirectToAction("List");
            }

            

            return View(personViewModel);


            
        }

        [HttpGet]
        public IActionResult Delete(int id){
            _personRepository.DeleteById(id);
            return RedirectToAction("List");
        }

    }
}