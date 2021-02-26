using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using GenesisDAL;
using GenesisDAL.Models;

namespace GenesisWebAPI.Controllers
{
    [Route("api/Main")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class MainController : ControllerBase
    {
        IGenesis IG;
        public MainController(IGenesis IG)
        {
            this.IG = IG;
        }

        [HttpGet]
        [Route("/api/Main/GetPartial")]
        public IEnumerable<GeneralPurposeEntity> Get([FromQuery] GeneralPurposeEntity gpe)
        {
            return IG.GeneralPurpose_Retreive(gpe);
        }

        [HttpGet]
        [Route("/api/Main/GetPartial/PrivateLabel")]
        public IEnumerable<PrivateLabelEntity> Get([FromQuery] PrivateLabelEntity ple)
        {
           
            return IG.PrivateLabel_Retreive(ple);
        }

        [HttpPut]
        [Route("/api/Main/UpdateGeneralPurposeRecords")]
        public bool Put( GeneralPurposeEntity gpe)
        {
            return IG.GeneralPurpose_Update(gpe);
        }



        [HttpPut]
        [Route("/api/Main/UpdatePrivateLabelRecords")]
        public bool Put(PrivateLabelEntity ple)
        {
            return IG.PrivateLabel_Update(ple);
        }

    }
}