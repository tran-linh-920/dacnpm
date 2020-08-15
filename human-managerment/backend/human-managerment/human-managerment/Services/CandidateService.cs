using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface CandidateService
    {
        public int CountAll();
        public List<CandidateDTO> FindAll(int page, int limit, int status);
        public CandidateDTO FindOne(long id);

        public CandidateDTO Save(CandidateForm canForm);

        public CandidateDTO Replace(long id, int candidatestatus);

        public void Delete(long id);
    }
}
