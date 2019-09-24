using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SolidifyLabs.FeatureFlags.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public class MyFlag : FeatureFlag
        {
            public override string Key => "My_Flag";
        }
        private readonly IFeatureFlagService _featureFlagService;

        public ValuesController(IFeatureFlagService featureFlagService)
        {
            _featureFlagService = featureFlagService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            if (_featureFlagService.Is<MyFlag>().Enabled)
            {
                return new string[] {"wow", "such feature"};
            }
            else
            {
                return new string[] { "value1", "value2" };

            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
