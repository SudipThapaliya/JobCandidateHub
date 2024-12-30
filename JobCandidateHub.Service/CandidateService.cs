using JobCandidateHub.Core;
using JobCandidateHub.Entity;
using JobCandidateHub.Interface;
using JobCandidateHub.Model;

namespace JobCandidateHub.Service
{
    public class CandidateService : CRUDService<Candidate>, ICandidateService<CandidateModel>
    {
        public CandidateService(JobCandidateHubDbContext context) : base(context)
        {
        }
        public async Task<bool> IsExist(string emailAdress)
        {
            return await base.Exist(x => x.Email == emailAdress);
        }
        public async Task<ResponseModel<CandidateModel>> Create(CandidateModel model)
        {
            ResponseModel<CandidateModel> response;
            try
            {
                var data = new Candidate()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    TimeIntervalEnd = model.TimeIntervalEnd,
                    TimeIntervalStart = model.TimeIntervalStart,
                    LinkedIn = model.LinkedIn,
                    GitHub = model.GitHub,
                    Comment = model.Comment,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now,
                    UpdatedBy = "Admin",
                    UpdatedDate = DateTime.Now,
                };
                var dbResponse = await InsertAsync(data);
                await Save();
                model.Email = dbResponse.Email;
                response = new ResponseModel<CandidateModel>()
                {
                    StatusCode = 200,
                    Data = model,
                    SuccessStatus = true
                };
            }
            catch (Exception ex)
            {
                response = new ResponseModel<CandidateModel>()
                {
                    StatusCode = 500,
                    SuccessStatus = false,
                    ErrorMessage = ["Internal Server Error : Error creating resource.", ex.Message]
                };
            }
            return response;
        }
        public async Task<ResponseModel<CandidateModel>> Update(CandidateModel model)
        {
            ResponseModel<CandidateModel> response;
            try
            {
                var dbResponse = await GetAsync(x => x.Email == model.Email);
                dbResponse.FirstName = model.FirstName;
                dbResponse.LastName = model.LastName;
                //Email is not updated as it is unique field and no change on data. if want to update it you can uncomment the line of code below.
                //dbResponse.Email = model.Email;
                dbResponse.PhoneNumber = model.PhoneNumber;
                dbResponse.TimeIntervalEnd = model.TimeIntervalEnd;
                dbResponse.TimeIntervalStart = model.TimeIntervalStart;
                dbResponse.LinkedIn = model.LinkedIn;
                dbResponse.GitHub = model.GitHub;
                dbResponse.Comment = model.Comment;

                dbResponse.UpdatedBy = "Admin";
                dbResponse.UpdatedDate = DateTime.Now;

                Update(dbResponse);
                await Save();
                response = new ResponseModel<CandidateModel>()
                {
                    StatusCode = 204,
                    SuccessStatus = true
                };
            }
            catch (Exception ex)
            {
                response = new ResponseModel<CandidateModel>()
                {
                    StatusCode = 500,
                    SuccessStatus = false,
                    ErrorMessage = ["Internal Server Error : Error updating resource.", ex.Message]
                };
            }
            return response;
        }
    }
}
