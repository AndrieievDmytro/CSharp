using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/warehouses")]
[ApiController]
public class WarehousesController : ControllerBase
{   
    private readonly IDataBaseServices _service;
    public WarehousesController(IDataBaseServices services)
    {
        _service = services;
    }
    [HttpPost]
    public async Task<IActionResult> Post(Request_Order request)
    {
        try
        {
         var primaryKey = await _service.AddProductToWarehouse(request);
            return StatusCode((int)HttpStatusCode.Created, primaryKey);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}