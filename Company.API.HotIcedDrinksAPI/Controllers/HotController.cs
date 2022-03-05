using Company.API.HotIcedDrinksAPI.Models.BusinessModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Company.API.HotIcedDrinksAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/")]
    public class HotController : ControllerBase
    {
        private readonly ILogger<HotController> _logger;

        public HotController(ILogger<HotController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get all hot drinks
        /// </summary>
        /// <returns>Returns all hot drinks</returns>
        [HttpOptions]
        public IEnumerable<GetDrinkModel> Get()
        {
            _logger.LogDebug("Get hot drinks");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns one hot drink
        /// </summary>
        /// <param name="id">id of hot drink</param>
        /// <returns>Returns one drink by id</returns>
        [HttpGet]
        [Route("{id}")]
        public GetDrinkModel Get(int id)
        {
            _logger.LogDebug("Get hot drink by Id");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts one hot drink
        /// </summary>
        /// <param name="drink"></param>
        /// <returns>id of inserted model</returns>
        [HttpPost]
        public StatusCodesContainer<ReturnStatusCodes.InsertStatusCode> Insert(InsertDrinkModel drink)
        {
            _logger.LogDebug("Add hot drink");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update one a hot drink by id
        /// </summary>
        /// <param name="id">id of hot drink</param>
        /// <returns>true if updated successfully, otherwise false</returns>
        [HttpPut]
        public StatusCodesContainer<ReturnStatusCodes.UpdateStatusCode> Update(UpdateDrinkModel drink)
        {
            _logger.LogDebug("Update hot drink");
            throw new NotImplementedException();
        }


        /// <summary>
        /// Delete one hot drink by id
        /// </summary>
        /// <param name="id">id of hot drink</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public StatusCodesContainer<ReturnStatusCodes.DeleteStatusCode> Delete(int id)
        {
            _logger.LogDebug("Delete hot drink");
            throw new NotImplementedException();
        }
    }
}
