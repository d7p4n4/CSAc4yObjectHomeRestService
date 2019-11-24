using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CSLibAc4yObjectObjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CSAc4yObjectHomeRestService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CSAc4yObjectRestService : ControllerBase
    {
        private readonly MSSQLLogin _MSSQLLogin;
        private string _ConnectionString;
        private SqlConnection _DBConn;

        public CSAc4yObjectRestService(IOptions<MSSQLLogin> msSQLLogin)
        {
            _MSSQLLogin = msSQLLogin.Value;
            _ConnectionString = _MSSQLLogin.connectionString;
            _DBConn = new SqlConnection(_ConnectionString);
            _DBConn.Open();
        }

        [HttpPost]
        public SetByNamesResponse PostByName(SetByNamesRequest request)
        {
           
            SetByNamesResponse response = new Ac4yObjectObjectService(_DBConn).SetByNames(request);
            return response;
        }
    }
}