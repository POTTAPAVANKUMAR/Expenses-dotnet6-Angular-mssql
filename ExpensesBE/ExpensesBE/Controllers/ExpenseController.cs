using ExpensesBE.DAL;
using ExpensesBE.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private IExpenseDAL expenseDAL;
        public ExpenseController(IExpenseDAL _expenseDAL)
        {
            expenseDAL = _expenseDAL;
        }
        [HttpGet]
        [Route("api/getdata")]
        public async Task<IActionResult> GetData()
        {
            var data = await expenseDAL.GetData();
            return Ok(data);
        }

        [HttpPost]
        [Route("api/savedata")]
        public async Task<IActionResult> SaveData([FromBody]Entry req)
        {
            var data = await expenseDAL.SaveData(req);
            return Ok(data);
        }

        [HttpGet]
        [Route("api/deletedata")]
        public async Task<IActionResult> DeleteData(int entryid)
        {
            var data = await expenseDAL.DeleteData(entryid);
            return Ok(data);
        }

        [HttpPost]
        [Route("api/updatedata")]
        public async Task<IActionResult> UpdateData([FromBody] Entry req)
        {
            var data = await expenseDAL.UpdateData(req);
            return Ok(data);
        }

    }
}
