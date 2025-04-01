using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Project.Command;
using Project.Infrastructure;
using Project.Model;

namespace Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhysicalPersonController : ControllerBase
{
    private PhysicalPersonsDbContext _dbContext;
    public PhysicalPersonController(PhysicalPersonsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]//create
    public IActionResult CreatePhysicalPerson(CreatePersonCommandDto physicalPerson)
    {
        var person = new PhysicalPerson
        {
            Name = physicalPerson.name,
            LastName = physicalPerson.lastname,
            BirthDate = physicalPerson.birthdate,
            Gender = physicalPerson.gender,
            PersonalId = physicalPerson.personID,
            PhoneNumbers = physicalPerson.Phonenumbers?.Select(x => new PhoneNumber
            {
                Number = x.PhoneNumber,
                Type = x.type
            }).ToList()
        };


        if (physicalPerson.city is not null)
        {
            var existingCity = _dbContext.City.FirstOrDefault(x => x.Name == physicalPerson.city.name);

            if (existingCity is not null)
            {
                person.City = existingCity;
            }
            else
            {
                person.City = new City
                {
                    Name = physicalPerson.city.name
                };
            }
        }

        _dbContext.PhysicalPersons.Add(person);
        _dbContext.SaveChanges();

        return Ok(person.Id);
    }




    [HttpDelete("{id}")] // delete
    public async Task<IActionResult> DeletePhysicalPerson(int id)
    {
        // Find the person by ID
        var person = await _dbContext.PhysicalPersons.Include(p => p.PhoneNumbers).FirstOrDefaultAsync(p => p.Id == id);


        if (person == null)
            return NotFound();
        _dbContext.PhysicalPersons.Remove(person);
        await _dbContext.SaveChangesAsync();
        return Ok(person);
    }


    [HttpPut("{id}")]//update
    public async Task<IActionResult> UpdatePhysicalPerson(int id, CreatePersonCommandDto updatePerson)
    {
        var person = await _dbContext.PhysicalPersons.Include(p => p.PhoneNumbers).FirstOrDefaultAsync(p => p.Id == id);
        if (person == null)
            return NotFound();

        person.Name = updatePerson.name;
        person.LastName = updatePerson.lastname;
        person.Gender = updatePerson.gender;
        person.PersonalId = updatePerson.personID;
        person.BirthDate = updatePerson.birthdate;

        person.PhoneNumbers = updatePerson.Phonenumbers.Select(p => new PhoneNumber
        {
            Number = p.PhoneNumber,
            Type = p.type
        }).ToList();

        if (updatePerson.city != null)
        {
            
            var cityName = updatePerson.city.name; 

            if (!string.IsNullOrEmpty(cityName))
            {
                // find the city by its name
                var city = await _dbContext.City.FirstOrDefaultAsync(c => c.Name == cityName);

                if (city != null)
                {
                    
                    person.City = city;
                }
                else
                {
                    // If city is empty, create a new city
                    var newCity = new City { Name = cityName };
                    _dbContext.City.Add(newCity);  
                    person.City = newCity;         
                }
            }
        }


        _dbContext.PhysicalPersons.Update(person);
        await _dbContext.SaveChangesAsync();//will wait until all changes saved, and then continue.

        return Ok(person);
    }

    



}