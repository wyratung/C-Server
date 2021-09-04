using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA_Cukcuk_api.Controllers
{
    [Route("api/v1/positions")]
    [ApiController]
    public class PositionsController : BaseController<Position>
    {
        #region Constructors

        public PositionsController(IPositionService positionService) : base(positionService)
        {

        }

        #endregion
    }
}
