using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

[Route("api/warehouses2")]
[ApiController]
public class Warehouses2Controller : ControllerBase
{   
    private readonly SqlServerDatabaseServiceProcedure _service;
    private static readonly int PROCEDURE_ERROR = 18; 
    public Warehouses2Controller(SqlServerDatabaseServiceProcedure services)
    {
        _service = services;
    }
    [HttpPost]
    public async Task<IActionResult> Post(Request_Order request)
    {
        try
        {
            var lastVal =  await _service.AddProductToWarehouse(request);
            return StatusCode((int)HttpStatusCode.Created,lastVal);
        }
        catch (SqlException ex)
        {
            if (ex.Class == PROCEDURE_ERROR)
            {
                return NotFound();
            }
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
        catch(Exception)
        {
             return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}