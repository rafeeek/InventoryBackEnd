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
    public class ProcessController : ControllerBase
    {
        #region Ctor
        private readonly I_InventoryGeneric<ProcessVM> processRepo;

        public ProcessController(I_InventoryGeneric<ProcessVM> ProcessRepo)
        {
            processRepo = ProcessRepo;
        }
        #endregion


        [HttpPost]
        [Route("addprocess")]
        public void AddProcess(ProcessVM obj)
        {
            processRepo.Creat(obj);
        }


        [HttpGet]
        [Route("getProcessId")]
        public ProcessVM getProcessId()
        {

            var data = processRepo.MyLastId();
            return data;
        }

        [HttpDelete]
        [Route("DeleteProcess")]
        public void DeleteProcess(string ProcessId)
        {
            processRepo.Delete(ProcessId);
        }

        [HttpPatch]
        [Route("UpdataProcess")]
        public void UpdataProcess(ProcessVM obj)
        {
            processRepo.Update(obj);
        }
    }
}
