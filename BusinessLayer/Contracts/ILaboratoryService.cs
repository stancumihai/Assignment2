using BusinessLayer.Contracts.Models;
using System.Collections.Generic;

namespace BusinessLayer.Contracts
{
    public interface ILaboratoryService : IGenericService<LaboratoryModel>
    {
        public List<AssignmentModel> GetAssignmentsByLaboratoryId(long Id);
    }
}
