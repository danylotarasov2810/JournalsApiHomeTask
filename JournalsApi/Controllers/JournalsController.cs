using JournalsApi.Data;
using JournalsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JournalsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalsController : Controller
    {
        private readonly JournalAPIDbContext dbContext;

        public JournalsController(JournalAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetJournals()
        {
            return Ok( await dbContext.Journals.ToListAsync());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetJournal([FromRoute] Guid id)
        {
            var journal = await dbContext.Journals.FindAsync(id);

            if(journal == null)
            {
                return NotFound();
            }
            return Ok(journal);
        }

        [HttpPost]
        public async Task<IActionResult> AddJournal(AddJournalRequest addJournalRequest)
        {
            var journal = new Journal()
            {
                Id = Guid.NewGuid(),
                FullName = addJournalRequest.FullName,
                Date = addJournalRequest.Date,
                Attendance = addJournalRequest.Attendance
            };

            await dbContext.Journals.AddAsync(journal);
            await dbContext.SaveChangesAsync();

            return Ok(journal);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateJournal([FromRoute] Guid id, UpdateJournalRequest updateJournalRequest)
        {
            var  journal = await dbContext.Journals.FindAsync(id);

            if (journal != null)
            {
                journal.FullName = updateJournalRequest.FullName;
                journal.Date = updateJournalRequest.Date;
                journal.Attendance = updateJournalRequest.Attendance;

                await dbContext.SaveChangesAsync();

                return Ok(journal);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteJournal([FromRoute] Guid id)
        {
            var journal = await dbContext.Journals.FindAsync(id);

            if(journal != null)
            {
                dbContext.Remove(journal);
                await  dbContext.SaveChangesAsync();
                return Ok(journal);
            }
            return NotFound();
        }
    }
}
