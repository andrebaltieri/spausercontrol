using SpaUserControl.Api.Models.Account;
using SpaUserControl.Api.Resources;
using SpaUserControl.Domain.Contracts.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SpaUserControl.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class AccountController : ApiController
    {
        private IUserService _service;

        public AccountController(IUserService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("register")]
        public Task<HttpResponseMessage> Register(RegisterUserModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.Register(model.Name, model.Email, model.Password, model.ConfirmPassword);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Name, email = model.Email });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, String.Format("{0} : {1}", Errors.FailedToCreateNewUser, ex.Message));
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
