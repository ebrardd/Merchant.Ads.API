using Merchant.Ads.API.Models;
using Microsoft.AspNetCore.Mvc;
using Merchant.Ads.API.Services;
using System.Net;
using Merchant.Ads.API.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Merchant.Ads.API.Repositories;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Merchant.Ads.API.V1.Models.ResponseModels;
using Merchant.Ads.API.V1.Models.RequestModels;
using MongoDB.Bson.Serialization.IdGenerators;
using Merchant.Ads.API.Validations;


namespace Merchant.Ads.API.V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MerchantController : ControllerBase
    {
        private readonly IService _merchantService;
        private readonly ILogger<MerchantController> _logger;

        public MerchantController(IService service, ILogger<MerchantController> logger)
        {
            _merchantService = service;
            _logger = logger;


        }
        /* [HttpPost]
         public IActionResult Create([FromBody] MerchantCreateRequestModel merchant)//REQAL
         {
             _merchantService.Create(merchant);
             return CreatedAtAction(nameof(Create), merchant);//aksiyonuolusturdun
         }*/
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] MerchantCreateRequestModel merchant)
        {
            await _merchantService.CreateAsync(merchant);
            return CreatedAtAction(nameof(CreateAsync), merchant);

        }

        /* [HttpGet("{Id}")]
         public IActionResult GetById(int Id)
         {
             var merchant = _merchantService.GetById(Id);
             return Ok(merchant);
         }*/
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var merchant = await _merchantService.GetByIdAsync(id);

            if (merchant == null)
            {
                return NotFound("Merchant not found.");
            }

            return Ok(merchant);
        }
        [HttpPost("{PostAsync}")]
        public async Task<IActionResult> PostAsync([FromBody] MerchantModel merchantModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MerchantModel insertedMerchant = await _merchantService.InsertMerchantAsync(merchantModel);

            return Ok(insertedMerchant);
        }

        [HttpPut("{ID}")]

        public async Task<ActionResult<MerchantModel>> UpdateAsync(int id, MerchantModel merchantModel)
        {
            try
            {
                if (id != merchantModel.Id)
                    return BadRequest("MerchantModel Id mismatch");

                var merchantModelToUpdate = await _merchantService.GetAsync(id);

                if (merchantModelToUpdate is null)
                    return NotFound($"MerchantModel with Id = {id} not found");

                var updatedMerchantModel = await _merchantService.UpdateAsync(id, merchantModel);

                if (updatedMerchantModel != null)
                {
                    return Ok(updatedMerchantModel);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
                }
            }
            catch (Exception)

            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }
        [HttpPatch("{ID}")]
        public async Task<ActionResult<MerchantModel>>PartiallyUpdate(int id, [FromBody] MerchantPatchRequestModel merchantPatchRequestModel)
        {
            var merchantModel = await _merchantService.PartiallyUpdate(id, merchantPatchRequestModel);
            if (merchantModel == null)
            {
                return NotFound("merchant not found");             
            }
            return Ok($"Updated to merchant with ID:{merchantModel.Id}");
        }

    

        [HttpDelete("{ID}")]
            
            public async Task<ActionResult<MerchantModel>> Delete(int id,MerchantModel merchantModel)
            {
                try
                {
                    var merchantModelToDelete = await _merchantService.Get(id,merchantModel);

                    if (merchantModelToDelete == null)
                    {
                        return NotFound($"Employee with Id = {id} not found");
                    }

                    var deletedMerchantModel = await _merchantService.DeleteMerchant(id,merchantModel);

                    if (deletedMerchantModel != null)
                    {
                        return Ok(deletedMerchantModel); 
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            "Error deleting data");
                    }
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error deleting data");
                }
            }
        
        }










    internal class Update
    {
    }

    public class JsonPatchDocument<T>
    {
        internal void ApplyTo(object merchantModelToPatch)
        {
            throw new NotImplementedException();
        }
    }
}





    





