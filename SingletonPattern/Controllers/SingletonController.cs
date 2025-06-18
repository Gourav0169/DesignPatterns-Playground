using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SingletonPattern.Models;
using SingletonPattern.Services;

namespace SingletonPattern.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SingletonController : ControllerBase
	{
		private readonly ISingletonService _singletonService;
		public SingletonController(ISingletonService singletonService)
		{
			_singletonService = singletonService;
		}
		[HttpGet]
		public DemoClass GetDemoClassSingletonInstance(DemoClass instance)
		{
			instance = _singletonService.BasicSingletonInstance(() => DemoClass.CreateDemoClassInstance());
		    return instance;
		}
	}
}
