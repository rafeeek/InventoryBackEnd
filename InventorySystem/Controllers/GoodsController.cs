using Busines_Layer.InterFaces;
using Busines_Layer.Models;
using Busines_Layer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
 


        #region Ctor
        private readonly I_InventoryGeneric<GoodsVM> InventoryRepo;

        public GoodsController(I_InventoryGeneric<GoodsVM> inventoryRepo)
        {
            InventoryRepo = inventoryRepo;
        }
        #endregion



        [HttpGet]
        [Route("alldata")]
        public List<GoodsVM> alldata()
        {
            var data = InventoryRepo.GetAllData();
            return data;
        }


    }
}
