using List.Models;
using List.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace List.Controllers
{
    [Route("api/list")]
    public class ListController : Controller
    {
        private readonly IListRepository list;
        private readonly ILogger<ListController> _logger;
        
        public ListController(ILogger<ListController> logger, IListRepository listRepository)
        {
            _logger = logger;
            list = listRepository;
        }

        // get all items
        // get api/list
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(list.GetItems());
        }

        // get one item
        // get api/list/id
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            return Ok(list.GetOne(id));
        }

        // add an item
        // post api/list
        [HttpPost("")]
        public IActionResult Create([FromBody] Item item)
        {
            list.Add(item);
            return Created("","");
        }

        // edit an item
        // put api/list/id
        [HttpPut("{id}")]
        public IActionResult Edit([FromBody] Item item)
        {
            list.Edit(item);
            return Ok();
        }

        // delete item by id
        // delete api/list/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            list.Delete(id);
            return Ok();
        }
    }
}
