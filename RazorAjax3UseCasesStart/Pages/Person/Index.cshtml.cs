﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkysFormsDemo.Data;
using SkysFormsDemo.Services;

namespace SkysFormsDemo.Pages.Person
{
    //[Authorize(Roles="Admin,Customer")]
    public class IndexModel : PageModel
    {
        private readonly IPersonService _personService;
        private readonly ApplicationDbContext _dbContext;

        public List<PersonViewModel> Persons { get; set; }

        public class PersonViewModel
        {
            public int Id { get; set; }       
            public string Name { get; set; }
            public string City { get; set; }
            public string Email { get; set; }
        }

        public IndexModel(IPersonService personService, ApplicationDbContext dbContext)
        {
            _personService = personService;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Persons = _personService.GetPersons().Select(r => new PersonViewModel
            {
                City = r.City,
                Id = r.Id,
                Name = r.Name,
                Email = r.Email
            }).ToList();
        }
    }
}