using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class MedicalRecordRepository : RepositoryBase<MedicalRecord>, IMedicalRecordRepository
    {

        public MedicalRecordRepository(PetAppDbContext petAppDbContext):base(petAppDbContext)
        {

        }

        public void CreateMedicalRecord(MedicalRecord medicalRecord)
        {
            throw new NotImplementedException();
        }

        public Test GetMedicalRecord(int medicalRecordId)
        {
            throw new NotImplementedException();
        }
    }
}
