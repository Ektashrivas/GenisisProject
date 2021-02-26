using System;
using System.Collections.Generic;
using System.Text;
using GenesisDAL;
using GenesisDAL.Models;
using MongoDB.Driver;
namespace GenesisDAL
{
   public  class GenesisImp:IGenesis
    {
        public IMongoDatabase GetConn()
        {
            return new MongoClient("mongodb://localhost:27017").GetDatabase("Genesis");
        }

        public GeneralPurposeEntity PurifyGeneral(GeneralPurposeEntity ob)
        {
            if (ob.Brand == null)
                ob.Brand = "";
            if (ob.Product == null)
                ob.Product = "";
            if (ob.Channel == null)
                ob.Channel = "";
            if (ob.Engine == null)
                ob.Engine = "";

            return ob;
        }
        public IEnumerable<GeneralPurposeEntity> GeneralPurpose_Retreive(GeneralPurposeEntity attributes)
        {
            PurifyGeneral(attributes);
            var res = GetConn().GetCollection<GeneralPurposeEntity>("GeneralPurpose").Find(x => (string.IsNullOrEmpty(attributes.Brand) || x.Brand.ToLower().Contains(attributes.Brand.ToLower())) && (string.IsNullOrEmpty(attributes.Product) || x.Product.ToLower().Contains(attributes.Product.ToLower())) && (string.IsNullOrEmpty(attributes.Channel) || x.Channel.ToLower().Contains(attributes.Channel.ToLower())) && (string.IsNullOrEmpty(attributes.Engine) || x.Engine.ToLower().Contains(attributes.Engine.ToLower()))).ToList();

            return res;
        }

        public bool GeneralPurpose_Update(GeneralPurposeEntity p)
        {
            try
            {
                var conn = GetConn();

                var res = conn.GetCollection<GeneralPurposeEntity>("GeneralPurpose").UpdateOne(x => x.Brand == p.Brand && x.Product == p.Product && x.Channel == p.Channel, Builders<GeneralPurposeEntity>.Update.Set("Engine", p.Engine));
                if (res.ModifiedCount <= 0)
                    return false;
            }
           catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public PrivateLabelEntity PurifyPrivate(PrivateLabelEntity ob)
        {
            if (ob.BrandingCode == null)
                ob.BrandingCode = "";
            if (ob.BrandingCodeId == null)
                ob.BrandingCodeId = "";
            if (ob.Organisation == null)
                ob.Organisation = "";
            if (ob.Orchestration == null)
                ob.Orchestration = "";
            if (ob.Classification == null)
                ob.Classification = "";
            if (ob.Program == null)
                ob.Program = "";
            if (ob.EquifexProgramType == null)
                ob.EquifexProgramType = "";
            if (ob.AdjudicationEngine == null)
                ob.AdjudicationEngine = "";
            if (ob.UWEngine == null)
                ob.UWEngine = "";

            return ob;
        }
        public IEnumerable<PrivateLabelEntity> PrivateLabel_Retreive(PrivateLabelEntity attributes)
        {
           PurifyPrivate(attributes);

            var res = GetConn().GetCollection<PrivateLabelEntity>("PrivateLabel").Find(x => (string.IsNullOrEmpty(attributes.BrandingCode) || x.BrandingCode.ToLower().Contains(attributes.BrandingCode.ToLower())) && (string.IsNullOrEmpty(attributes.BrandingCodeId) || x.BrandingCodeId.ToLower().Contains(attributes.BrandingCodeId.ToLower())) && (string.IsNullOrEmpty(attributes.Classification) || x.Classification.ToLower().Contains(attributes.Classification.ToLower())) && (string.IsNullOrEmpty(attributes.Organisation) || x.Organisation.ToLower().Contains(attributes.Organisation.ToLower())) && (string.IsNullOrEmpty(attributes.Orchestration) || x.Orchestration.ToLower().Contains(attributes.Orchestration.ToLower())) && (string.IsNullOrEmpty(attributes.Program) || x.Program.ToLower().Contains(attributes.Program.ToLower())) && (string.IsNullOrEmpty(attributes.EquifexProgramType) || x.EquifexProgramType.ToLower().Contains(attributes.EquifexProgramType.ToLower())) && (string.IsNullOrEmpty(attributes.AdjudicationEngine) || x.AdjudicationEngine.ToLower().Contains(attributes.AdjudicationEngine.ToLower())) && (string.IsNullOrEmpty(attributes.UWEngine) || x.UWEngine.ToLower().Contains(attributes.UWEngine.ToLower()))).ToList();

            return res;
        }
        public bool PrivateLabel_Update(PrivateLabelEntity v)
        {
            try
            {
                var conn = GetConn();

                var res = conn.GetCollection<PrivateLabelEntity>("PrivateLabel").UpdateOne(x => x.BrandingCodeId == v.BrandingCodeId && x.BrandingCode == v.BrandingCode && x.Classification == v.Classification && x.Orchestration == v.Orchestration && x.Program == v.Program && x.Organisation == v.Organisation && x.EquifexProgramType == v.EquifexProgramType && x.AdjudicationEngine == v.AdjudicationEngine, Builders<PrivateLabelEntity>.Update.Set("UWEngine", v.UWEngine));
                if (res.ModifiedCount <= 0)
                    return false;
            }
              
           catch(Exception ex)
            {
                throw ex;
            }
           return true;
        }
       
        public bool InsertGeneral(GeneralPurposeEntity model)
        {
            try
            {

               var database = GetConn();
                database.GetCollection<GeneralPurposeEntity>("GeneralPurpose").InsertOne(model);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
