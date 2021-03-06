﻿using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IMedicalRecordRepository : IRepositoryBase<MedicalRecord>
    {
        MedicalRecord GetMedicalOfPetId(int petId);
    }
}
