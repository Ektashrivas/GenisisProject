using System;
using System.Collections.Generic;
using System.Text;
using GenesisDAL.Models;
namespace GenesisDAL
{
    public interface IGenesis
    {
        public IEnumerable<GeneralPurposeEntity> GeneralPurpose_Retreive(GeneralPurposeEntity attributes);
        public bool GeneralPurpose_Update(GeneralPurposeEntity gpe);
        bool InsertGeneral(GeneralPurposeEntity model);
        public IEnumerable<PrivateLabelEntity> PrivateLabel_Retreive(PrivateLabelEntity ple);
        public bool PrivateLabel_Update(PrivateLabelEntity p);
    }
}
