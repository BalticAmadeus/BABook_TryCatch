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

        [HttpPost]
        [Route("api/groups")]
        public IHttpActionResult CreateGroup(NewGroupViewModel model)
        {
            try
            {
                //TODO: leisti si veiksama tik adminui
                _repository.Add(ViewModelToDomainMapping.NewGroupViewModelToModel(model));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        [Route("api/groups/{groupId}")]
        public IHttpActionResult DeleteGroup(int groupId)
        {
            try
            {
                //TODO: leisti si veiksma tik adminui
                var currentEvent = _repository.SingleOrDefault(x => x.GroupId == groupId) ??
                                   throw new Exception("Group with this ID doesn't exist!");
                _repository.Remove(currentEvent);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}