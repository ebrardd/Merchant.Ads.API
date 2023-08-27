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


namespace Merchant.Ads.API.V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MerchantController : ControllerBase
    {
        private readonly IService _merchantService;
        private readonly ILogger<MerchantController> _logger;

        public MerchantController(IService service, ILogger<MerchantController>logger)
        {
            _merchantService = service;
            _logger = logger;
            

        }
        [HttpPost]
        public IActionResult Create([FromBody] MerchantCreateRequestModel merchant)//REQAL
        {
            _merchantService.Create(merchant);
            return CreatedAtAction(nameof(Create), merchant);//aksiyonuolusturdun
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var merchant = _merchantService.GetById(Id);
            return Ok(merchant);
        }
        [HttpPost("PostAsync")]
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
        public async Task<ActionResult<MerchantModel>> Update(int id, MerchantModel merchantModel)
        {
            try
            {
                if (id != merchantModel.Id)
                    return BadRequest("MerchantModel Id mismatch");

                var merchantModelToUpdate = await _merchantService.Get(id, merchantModel);

                if (merchantModelToUpdate is null)
                    return NotFound($"MerchantModel with Id = {id} not found");

                var updatedMerchantModel = await _merchantService.Update(id, merchantModelToUpdate);

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
        
        

       /* [HttpPatch("{id}")]
        async Task<IActionResult> PartiallyUpdateMerchantForCompany(int TaxNo, int id, [FromBody] JsonPatchDocument<MerchantModel> patchDoc)
                                                                                        
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var company = await _merchantService.Company.Get(TaxNo, trackChanges: false);
            if (company == null)
            {
                _logger.LogInformation($"Company with id: {TaxNo} doesn't exist in the database.");
                return NotFound();
            }

            var merchantModelEntity = await _merchantService.MerchantModel.Get(TaxNo, id, trackChanges: true);
            if (merchantModelEntity == null)
            {
                _logger.LogInformation($"MerchantModel with id: {id} doesn't exist in the database.");
                return NotFound();
            }
                var merchantModelToPatch = _mapper.Map<MerchantModel>(merchantModelEntity);

                patchDoc.ApplyTo(merchantModelToPatch);

                _mapper.Map(merchantModelToPatch, merchantModelEntity);

                await _merchantService.Save();

                return NoContent();
            } */
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





    





