using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenesisDAL;
using GenesisDAL.Models;
using System;
using Moq;
namespace Genesis_UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
       
            IGenesis i = new GenesisImp();


        [TestMethod]
        public void Get_GeneralPurpose_Data_TestMethod()
        {
            GeneralPurposeEntity attributes = new GeneralPurposeEntity { Brand = "", Product = "", Channel = "i" };
            var res = i.GeneralPurpose_Retreive(attributes);
            int c = 0;
            foreach (var i in res)
                c++;
           
            Assert.IsNotNull(res);
            Assert.AreEqual(1, c);
        }

        [TestMethod]
        public void Update_GeneralPurpose_Data_TestMethod()
        {
            GeneralPurposeEntity[] p = { new GeneralPurposeEntity { Brand = "kia", Product = "pt2", Channel = "oppo", Engine="Powercurves"},
                new GeneralPurposeEntity
                {
                    Brand = "NGO",
                    Product = "PT2",
                    Channel = "ITA",
                    Engine = "Interconnect"
                }
            };

            var res = i.GeneralPurpose_Update(p[1]);
            Assert.IsTrue(res);
        }



        // The below part is for PrivateLabel

        [TestMethod]
        public void Get_PrivateLabel_TestMethod()
        {
            PrivateLabelEntity attributes = new PrivateLabelEntity();
           // PrivateLabelEntity attributes = new PrivateLabelEntity { BrandingCode = "gcp", BrandingCodeId = "", Classification = "",Organisation="",Orchestration="",Program="",EquifexProgramType="",AdjudicationEngine="",UWEngine="" };
            var res = i.PrivateLabel_Retreive(attributes);
            int c = 0;
            foreach (var m in res)
                c++;
            Assert.AreEqual(4, c);
        }

        [TestMethod]
        public void Update_PrivateLabel_TestMethod()
        {
            PrivateLabelEntity[] p = { new PrivateLabelEntity{ BrandingCodeId = "17",                                                           BrandingCode = "gcp-gc",                                               Classification = "healthcare",                                                          Organisation = "permissiblepurpose",                                                     Orchestration = "PermissiblePurpose.MABT",                                       Program = "generalmedical4tier",                                                 EquifexProgramType = "PermissiblePurpose",                                       AdjudicationEngine = "IC",                                                       UWEngine = "Interconnect"
            },
                new PrivateLabelEntity
                {
                   BrandingCodeId = "23",                                                           BrandingCode = "GCP-GC-EA",                                                   Classification = "Integration",                                                          Organisation = "healthcare",                                                      Orchestration = "PermissiblePurpose.MABT",                                       Program = "Fredmeyerprogramu21",                                                 EquifexProgramType = "PermissiblePurpose",                                      AdjudicationEngine = "IC",                                                       UWEngine = "smarts"
                }
            };
            var res = i.PrivateLabel_Update(p[0]);
            Assert.IsTrue(res);
        }
    }
    }

