using System;
using System.Web.Http;
using System.Threading.Tasks;
using Blackgate.DataModel;
using Blackgate.DataModel.Domain;
using Blackgate.API.Helpers;
using Blackgate.API.Models;

namespace Blackgate.API.Controllers
{
    public class CourseController : ApiController
    {
        IRepository<Course> repository;
        public CourseController(IUnitOfWork unitOfWork)
        {
            repository = unitOfWork.Repository<Course>();
        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var content = await repository.GetAll<CourseIdModel, Course>();
                return Ok(content);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var content = await repository.Get<CourseModel, Course>(id);
                return Ok(content);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public async Task<IHttpActionResult> Post([FromBody]CourseModel content)
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

        public async Task<IHttpActionResult> Put(int id, [FromBody]CourseModel content)
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
