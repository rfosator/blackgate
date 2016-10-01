using System;
using System.Web.Http;
using System.Threading.Tasks;
using Blackgate.API.Helpers;
using Blackgate.API.Models;
using Blackgate.DataModel;
using Blackgate.DataModel.Domain;

namespace Blackgate.API.Controllers
{
    public class TopicController : ApiController
    {
        IRepository<Topic> repository;
        public TopicController(IUnitOfWork unitOfWork)
        {
            repository = unitOfWork.Repository<Topic>();
        }       

        // GET: api/Topic/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var content = await repository.Get<TopicModel, Topic>(id);
                return Ok(content);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // POST: api/Topic
        public async Task<IHttpActionResult> Post([FromBody]TopicModel content)
        {
            try
            {
                await repository.Add(content);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // PUT: api/Topic/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]TopicModel content)
        {
            try
            {
                await repository.Update(id, content);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // DELETE: api/Topic/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                await repository.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
