using Busines_Layer.InterFaces;
using Busines_Layer.Models;
using Microsoft.AspNetCore.Cors;
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
    public class InventoryProcController : ControllerBase
    {

        #region Ctor
        private readonly I_InventoryGeneric<InventoryProcVM> InventoryProcRepo;

        public InventoryProcController(I_InventoryGeneric<InventoryProcVM> inventoryProcRepo )
        {
            InventoryProcRepo = inventoryProcRepo;
        }
        #endregion

        [HttpGet]
        [Route("alldata")]
        public List<InventoryProcVM> alldata()
        {
            var data = InventoryProcRepo.GetAllData();
            return data;
        }

        [HttpGet]
        [Route("GetById")]
        public InventoryProcVM GetById(int id)
        {
            var data = InventoryProcRepo.GetById(id);
            return data;
        }


        [HttpPost]
        [Route("AddInvProcess")]
        public void addInvProcess(InventoryProcVM obj)
        {
            InventoryProcRepo.Creat(obj);
        }

        [HttpDelete]
        [Route("DeleteInvProcess")]
        public void DeleteInvProcess(string InventoryProcessId)
        {
            InventoryProcRepo.Delete(InventoryProcessId);
        }

        [HttpPatch]
        [Route("UpdataInvProcess")]
        public void UpdataInvProcess(InventoryProcVM obj)
        {
            InventoryProcRepo.Update(obj);
        }

    }
}
