using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System;
using LetsHang.Models;

namespace LetsHang.Controller
{
  [Route("api/v1/[Controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly UserContext _context;

    public UserController( UserContext context)
    {
      _context = context;
    }
  }
}