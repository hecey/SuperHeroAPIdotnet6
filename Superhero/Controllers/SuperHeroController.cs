using Microsoft.AspNetCore.Mvc;

namespace Superhero.Controllers;

[ApiController]
[Route("[controller]")]
public class SuperHeroController : ControllerBase
{
    private readonly DataContext _context;

    public SuperHeroController(DataContext context)
    {
        this._context = context;
    }

    [HttpGet(Name = "GetSuperHero")]
    public async Task<ActionResult<List<Superhero>>> Get()
    {

        return Ok(await _context.SuperHeroes.ToListAsync());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Superhero>> Get(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero == null)
            return NotFound();
        return Ok(hero);
    }
    [HttpPost]
    public async Task<ActionResult<List<Superhero>>> addHero(Superhero hero)
    {
        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();

        return Ok(await _context.SuperHeroes.ToListAsync());
    }
    [HttpPut]
    public async Task<ActionResult<List<Superhero>>> updateHero(Superhero superhero)
    {
        var dbhero = await _context.SuperHeroes.FindAsync(superhero.Id);
        if (dbhero == null)
            return BadRequest("Hero not found.");

        dbhero.Id = superhero.Id;
        dbhero.Name = superhero.Name;
        dbhero.FirstName = superhero.FirstName;
        dbhero.LastName = superhero.LastName;
        dbhero.Place = superhero.Place;
        await _context.SaveChangesAsync();

        return Ok(await _context.SuperHeroes.ToListAsync());
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Superhero>>> Delete(int id)
    {
        var dbhero = await _context.SuperHeroes.FindAsync(id);
        if (dbhero == null)
            return NotFound();
        _context.SuperHeroes.Remove(dbhero);
        await _context.SaveChangesAsync();


        return Ok(await _context.SuperHeroes.ToListAsync());
    }
}