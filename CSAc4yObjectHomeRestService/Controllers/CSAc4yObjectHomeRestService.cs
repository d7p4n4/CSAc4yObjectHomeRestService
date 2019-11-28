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
    public class CSAc4yObjectHomeRestService : ControllerBase
    {
        private readonly MSSQLLogin _MSSQLLogin;
        private string _ConnectionString;
        private SqlConnection _DBConn;

        public CSAc4yObjectHomeRestService(IOptions<MSSQLLogin> msSQLLogin)
        {
            _MSSQLLogin = msSQLLogin.Value;
            _ConnectionString = _MSSQLLogin.connectionString;
            _DBConn = new SqlConnection(_ConnectionString);
            _DBConn.Open();
        }

        [HttpPost]
        public SetByNamesResponse SetByNames(SetByNamesRequest request)
        {
            return new Ac4yObjectObjectService(_DBConn).SetByNames(request);
        }

        [HttpPost]
        public SetByGuidAndNamesResponse SetByGuidAndNames(SetByGuidAndNamesRequest request)
        {
            return new Ac4yObjectObjectService(_DBConn).SetByGuidAndNames(request);
        }



    }
}