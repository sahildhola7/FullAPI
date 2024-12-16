using LearnApi.Data;
using LearnApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LearnApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LearnController : ControllerBase
    {
        private readonly LearnDbContext dbContext;
        public LearnController(LearnDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllLearns()
        {
            var allLearns = dbContext.Learns.ToList();
            return Ok(allLearns);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        public IActionResult GetLearnById(Guid Id)
        {
            var learn = dbContext.Learns.Find(Id);

            if(learn is null)
            {
                return NotFound();
            }

            return Ok(learn);
        }

        [HttpPost]
        public IActionResult AddLearn(AddLearnDto addLearnDto)
        {
            var learnEntity = new Learn()
            {
                Name = addLearnDto.Name,
                Surename = addLearnDto.Surename,
                BirthMonth = addLearnDto.BirthMonth

            };
            dbContext.Learns.Add(learnEntity);
            dbContext.SaveChanges();
            return Ok(learnEntity);

        }

        [HttpPut]
        [Route("{Id:guid}")]
        public IActionResult updateLearn(Guid Id, UpdateLearnDto updateLearnDto)
        {
           var learn = dbContext.Learns.Find(Id);

           if(learn is null){
            return NotFound();
           }
           learn.Name = updateLearnDto.Name;
           learn.Surename = updateLearnDto.Surename;
           learn.BirthMonth = updateLearnDto.BirthMonth;  

           dbContext.SaveChanges();
           return Ok(learn);  

        }

        [HttpDelete]
        [Route("{Id:guid}")]
        public IActionResult DeleteLearn(Guid Id)
        {
            var learn = dbContext.Learns.Find(Id);

            if(learn is null){
                return NotFound();
            }

            dbContext.Learns.Remove(learn);
            dbContext.SaveChanges();
            return Ok(learn);
        }
        

    }
}