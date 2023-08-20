using Merchant.Ads.API.Models;
using Microsoft.AspNetCore.Mvc;
using Merchant.Ads.API.Services;
using System.Net;

namespace Merchant.Ads.API.V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MerchantController : ControllerBase
    {
        private readonly IService _merchantService;
        public MerchantController(IService service)
        {
            _merchantService = service;
        }
        [HttpPost]
        public IActionResult Create([FromBody] MerchantModel merchant)
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
       
        }
    }
