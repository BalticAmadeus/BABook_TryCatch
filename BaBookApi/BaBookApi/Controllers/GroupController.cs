using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BaBookApi.Mapping;
using BaBookApi.ViewModels;
using DataAccess.Repositories;


namespace BaBookApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GroupController : ApiController
    {
        private readonly GroupRepository _repository;

        public GroupController()
        {
            _repository = new GroupRepository();
        }

        [Route("api/groups")]
        public IHttpActionResult GetGroups()
        {
            try
            {
                var groups = _repository.GetLoadedList();
                var groupsVm = new List<GroupViewModel>();
                groups.ForEach(x => groupsVm.Add(DomainToViewModelMapping.MapGroupViewModel(x)));

                return Ok(groupsVm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}