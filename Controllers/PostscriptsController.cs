using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PostscriptsController : ControllerBase
    {
        private readonly ClassbookContext _context;

        public PostscriptsController(ClassbookContext context)
        {
            _context = context;
        }

        // GET: api/Postscript
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Postscript>>> GetPostscript()
        {
            if (_context.Postscript == null)
            {
                return NotFound();
            }
            return await _context.Postscript.ToListAsync();
        }

        // GET: api/Postscript/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Postscript>> GetPostscript(long id)
        {
            if (_context.Postscript == null)
            {
                return NotFound();
            }
            var postscript = await _context.Postscript.FindAsync(id);

            if (postscript == null)
            {
                return NotFound();
            }

            return postscript;
        }

        // PUT: api/Postscript/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostscript(long id, Postscript postscript)
        {
            if (id != postscript.Id)
            {
                return BadRequest();
            }

            _context.Entry(postscript).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostscriptExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Postscript
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Postscript>> PostPostscript(Postscript postscript)
        {
            if (_context.Postscript == null)
            {
                return Problem("Entity set 'ClassbookContext.Postscript'  is null.");
            }
            _context.Postscript.Add(postscript);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostscript", new { id = postscript.Id }, postscript);
        }

        // DELETE: api/Postscript/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostscript(long id)
        {
            if (_context.Postscript == null)
            {
                return NotFound();
            }
            var postscript = await _context.Postscript.FindAsync(id);
            if (postscript == null)
            {
                return NotFound();
            }

            _context.Postscript.Remove(postscript);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostscriptExists(long id)
        {
            return (_context.Postscript?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
