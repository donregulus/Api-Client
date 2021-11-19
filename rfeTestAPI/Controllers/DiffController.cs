using Microsoft.AspNetCore.Mvc;
using rfeTestAPI.Models;



namespace rfeTestAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DiffController : ControllerBase
    {
        static List<Diff> DiffValues = new List<Diff>();

        // GET: api/<DiffController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DiffController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            Diff ? diffvalue = DiffValues.Find(f=> f.Id == id);
            if (diffvalue == null)
            {
                return NotFound();
            }
            else
            { 
                return Ok( new { result = diffvalue.ComputeDiff()});            
            }
        }

        // POST api/<DiffController>/<ID>/left
        [HttpPost("{ID}/left")]
        public void PostLeft(string ID, [FromBody] string value)
        {
            Diff ? diffValue = DiffValues.Find(f => f.Id == ID);
            if (diffValue == null)
            {
                Diff diff = new Diff(value, string.Empty, ID);
                DiffValues.Add(diff);
            }
            else
            { 
                diffValue.Left = value;            
            }
        }


        // POST api/<DiffController>/<ID>/rigth
        [HttpPost("{ID}/Right")]
        public void PostRigth(string ID, [FromBody] string value)
        {
            Diff ? diffValue = DiffValues.Find(f => f.Id == ID);
            if (diffValue == null)
            {
                Diff diff = new Diff(string.Empty, value, ID);
                DiffValues.Add(diff);
            }
            else
            { 
                diffValue.Right = value;            
            }
        }

    }
}
