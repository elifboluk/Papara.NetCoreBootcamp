using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using OwnerAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace OwnerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        public List<Owner> oList = new List<Owner>
        {
            new Owner()
            {
                Id= 1,
                Name="Ada",
                Surname="Lovelace",
                Date=new System.DateTime(2022,10,28),
                Comment="First comment.",
                Type="AL"
            },

            new Owner()
            {
                Id= 2,
                Name="Jade",
                Surname="Raymond",
                Date=new System.DateTime(2021,09,27),
                Comment="Second comment.",
                Type="JR"
            },

            new Owner()
            {
                Id= 3,
                Name="Sara",
                Surname="Haider",
                Date=new System.DateTime(2020,08,26),
                Comment="Third comment.",
                Type="SH"
            },

            new Owner()
            {
                Id= 4,
                Name="Corrinne",
                Surname="Yu",
                Date=new System.DateTime(2019,07,25),
                Comment="Third comment.",
                Type="CY"
            }
        };


        // Get
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Owner))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("AllList")]
        [HttpGet]
        public IActionResult GetAllOwner()
        {
            if (oList.Any())
            {
                return Ok(oList);
            }
            else
            {
                return BadRequest("Owner List not found!");
            }
        }

        // Post
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Owner))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("")]
        [HttpPost]
        public IActionResult AddOwner(Owner model)
        {
            var oList = new List<Owner>();
            oList.Add(model);
            if (oList.Any(o => o.Comment.Contains("hack")))
            {
                return NotFound();
            }
            else
            {
                return Ok(oList);
            }
        }

        // Delete
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Owner))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteOwner(int id)
        {
            var owner = oList.SingleOrDefault(o => o.Id == id);

            if (owner != null)
            {
                oList.Remove(owner);
                return Ok(oList);
            }
            else
            {
                return NotFound();
            }
        }

        // Put
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Owner))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("Update")]
        [HttpPut]
        public IActionResult Update(int id, Owner owner)
        {
            if (id != owner.Id)
            {
                return BadRequest();
            }
            var ownerList = oList.OrderBy(o => o.Id).ToList<Owner>();
            var update = ownerList.FirstOrDefault(o => o.Id == id);
            update.Name = owner.Name;
            update.Surname = owner.Surname;
            update.Date = owner.Date;
            update.Comment = owner.Comment;
            update.Type = owner.Type;
            return Ok();

        }
    }
}
