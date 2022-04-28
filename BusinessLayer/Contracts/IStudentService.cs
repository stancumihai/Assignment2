using BusinessLayer.Contracts.Models;
using System.Collections.Generic;

namespace BusinessLayer.Contracts
{
    public interface IStudentService : IGenericService<StudentModel>
    {
        public List<AssignmentModel> GetAssignmentsByStudentId(int Id);
        public List<SubmissionModel> GetSubmissionsByStudentId(int Id);
        public List<LaboratoryModel> GetLaboratoriesByStudentId(int Id);
        public List<GradingModel> GetGradingsByStudentId(int Id);

        public FinalResultModel GetFinalResultByStudentId(int Id);

    }
}
