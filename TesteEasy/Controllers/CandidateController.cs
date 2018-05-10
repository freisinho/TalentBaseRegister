using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using TesteEasy.Models;
using TesteEasy.Models.Dto;
using TesteEasy.Models.Entities;

namespace TesteEasy.Controllers
{
    public class CandidateController : ApiController
    {
        public readonly CandidateDbSet Context = new CandidateDbSet();

        // GET: api/Candidate
        public async Task<List<GetCandidatesDto>> GetCandidates()
        {
            var candidates = Context.Candidates
                .Include(obj => obj.Email)
                .Include(obj => obj.Phone)
                .AsNoTracking();

            var candidate = await (from a in candidates
                                   select new
                                   {
                                       a.Id,
                                       Email = a.Email.Address,
                                       Phone = a.Phone.Number,
                                       a.Name
                                   }).ToListAsync();


            var candidatesDto = Mapper.Map<List<GetCandidatesDto>>(candidate);

            return candidatesDto;
        }

        // GET: api/Candidate/5
        [ResponseType(typeof(CandidateDto))]
        public async Task<CandidateDto> GetCandidate(int id)
        {
            var candidate = await Context.Candidates
                .Include(candidateObj => candidateObj.Email)
                .Include(candidateObj => candidateObj.Skype)
                .Include(candidateObj => candidateObj.Phone)
                .Include(candidateObj => candidateObj.Address.City.State)
                .Where(item => item.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var candidateKnowledges = await (from x in Context.CandidateKnowledges
                                             where x.CandidateId == id
                                             select new
                                             {
                                                 x.CandidateId,
                                                 x.Evaluation,
                                                 x.Technology.Name,
                                                 TechnologyId = x.Technology.Id
                                             }).ToListAsync();

            var knowlodges = Mapper.Map<List<CandidateKnowledgeDto>>(candidateKnowledges);

            var candidateDto = Mapper.Map<CandidateDto>(candidate);

            candidateDto.CandidateKnowledge = knowlodges;

            return candidateDto;
        }

        // PUT: api/Candidate/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidate(int id, Candidate candidate)
        {
            var knowledges = candidate.CandidateKnowledge;

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != candidate.Id) return BadRequest();

            foreach (var knowledgeCandidate in knowledges)
                Context.Entry(knowledgeCandidate).State = EntityState.Modified;


            Context.Entry(candidate.Email).State = EntityState.Modified;
            Context.Entry(candidate.Phone).State = EntityState.Modified;
            Context.Entry(candidate.Address.City.State).State = EntityState.Modified;
            Context.Entry(candidate.Address.City).State = EntityState.Modified;
            Context.Entry(candidate.Skype).State = EntityState.Modified;
            Context.Entry(candidate.Bank).State = EntityState.Modified;
            Context.Entry(candidate).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Candidate
        public async Task<int> PostCandidate(Candidate candidate)
        {
            Context.Candidates.Add(candidate);

            await Context.SaveChangesAsync();

            return candidate.Id;
        }

        // DELETE: api/Candidate/5
        [ResponseType(typeof(Candidate))]
        public async Task<IHttpActionResult> DeleteCandidate(int id)
        {
            var candidate = await Context.Candidates.FindAsync(id);
            if (candidate == null) return NotFound();

            Context.Candidates.Remove(candidate);
            await Context.SaveChangesAsync();

            return Ok(candidate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) Context.Dispose();
            base.Dispose(disposing);
        }

        private bool CandidateExists(int id)
        {
            return Context.Candidates.Count(e => e.Id == id) > 0;
        }
    }
}