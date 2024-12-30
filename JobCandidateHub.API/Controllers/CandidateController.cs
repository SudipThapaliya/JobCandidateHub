using JobCandidateHub.Interface;
using JobCandidateHub.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JobCandidateHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService<CandidateModel> _candidateService;

        public CandidateController(ICandidateService<CandidateModel> candidateService)
        {
            _candidateService = candidateService;
        }
        [HttpPost(Name = "Post")]
        public async Task<IActionResult> Post(CandidateModel candidateModel)
        {
            ResponseModel<CandidateModel> response;
            if (ModelState.IsValid)
            {
                try
                {
                    if (await _candidateService.IsExist(candidateModel.Email))
                    {
                        response = await _candidateService.Update(candidateModel);
                    }
                    else
                    {
                        response = await _candidateService.Create(candidateModel);
                    }
                }
                catch (Exception ex)
                {
                    response = new ResponseModel<CandidateModel>()
                    {
                        ErrorMessage = [ex.Message],
                        SuccessStatus = false,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
            }
            else
            {
                var errors = new List<string>();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                response = new ResponseModel<CandidateModel>()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    SuccessStatus = false,
                    ErrorMessage = errors.ToArray()
                };
            }
            return StatusCode(response.StatusCode, response);
        }
    }
}
