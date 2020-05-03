using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MilleniumApplication.Models;

namespace MilleniumApplication.Controllers
{
    [Produces("application/json")]
    [FormatFilter]
    [Route("api/test")]
    [ApiController]
    public class ItemsController : ControllerBase, IDisposable
    {
        private readonly ItemsContext _context;
        //private readonly ILogger _logger;

        public ItemsController(ItemsContext context)
        {
            _context = context;
            //_logger = logger;
        }

        [HttpGet("{getAllElements}.{format?}")]
        public IEnumerable<Item> GetAllElements() =>
            _context.Items.ToList();
        

        [HttpGet("getElement/{id}.{format?}")]
        public Item GetElement(int Id)
        {
            return _context.Items.First(x => x.Id == Id);
            //try
            //{
            //    var element = _context.Items.First(x => x.Id == Id);
            //    var resultObj = Ok(element);
            //    if (element == null)
            //        throw new Exception("Element not found.");
            //    return resultObj;
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            //}
        }

        [Route("updateElement")]
        [HttpPost]
        public IActionResult UpdateElement(Item element)
        {
            try
            {
                var updateElement = _context.Items.FirstOrDefault(x => x.Id == element.Id);
                if (updateElement == null)
                    throw new Exception("Element not found.");
                updateElement.Name = element.Name;
                updateElement.Price = element.Price;
                updateElement.Description = element.Description;

                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("saveElement")]
        [HttpPut]
        public IActionResult SaveElement(Item element)
        {
            try
            {
                _context.Add(element);
                return Ok(element);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("deleteElement")]
        [HttpDelete]
        public IActionResult DeleteElement(int elementId)
        {
            try
            {
                var deleteElement = _context.Items.Find(elementId);
                if (deleteElement == null)
                    throw new Exception("You try to delete not existing element.");
                _context.Remove(deleteElement);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}