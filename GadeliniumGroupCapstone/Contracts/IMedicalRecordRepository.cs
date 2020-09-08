using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IMedicalRecordRepository : IRepositoryBase<MedicalRecord>
    {
        Test GetMedicalRecord(int medicalRecordId);
        void CreateMedicalRecord(MedicalRecord medicalRecord);
    }
}
