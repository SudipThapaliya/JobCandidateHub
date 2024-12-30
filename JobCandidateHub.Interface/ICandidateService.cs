using JobCandidateHub.Model;

namespace JobCandidateHub.Interface
{
    public interface ICandidateService<T>
    {
        Task<bool> IsExist(string emailAdress);
        Task<ResponseModel<T>> Create(T model);
        Task<ResponseModel<T>> Update(T model);
    }
}
