

using ExpensesBE.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace ExpensesBE.DAL
{
    public class ExpenseDAL:IExpenseDAL
    {
        public ExpensesDBContext expensesDBContext;
        public ExpenseDAL(ExpensesDBContext _ExpensesDBContext)
        {
            expensesDBContext = _ExpensesDBContext;
        }
        public async Task<List<Entry>> GetData()
        {
            List<Entry> data = expensesDBContext.Entries.AsNoTracking().ToList();
            return await Task.FromResult(data);
        }

        public async Task<string> SaveData(Entry req)
        {
            try
            {
                
                Entry obj = new Entry();
                obj.Description = req.Description;
                obj.Value = req.Value;
                obj.Type = req.Type;
                var i = expensesDBContext.Entries.Add(obj);
                
                await expensesDBContext.SaveChangesAsync();
                return await Task.FromResult("True");
            }
            catch(Exception ex)
            {
                return await Task.FromResult("False");
            }
           
        }

        public async Task<string> DeleteData(int entryid)
        {
            try
            {
                Entry t;
                t = expensesDBContext.Entries.Where(c => c.EntryId == entryid).FirstOrDefault();
                expensesDBContext.Entries.Remove(t);
                expensesDBContext.SaveChanges();
                return await Task.FromResult("True");

            }
            catch(Exception ex)
            {
                return await Task.FromResult("False");
            }
        }

        public async Task<string> UpdateData(Entry req)
        {
            try
            {
                var updatedat = expensesDBContext.Entries.Where(c => c.EntryId == req.EntryId).FirstOrDefault();
                updatedat.Description = req.Description;
                updatedat.Type = req.Type;
                updatedat.Value = req.Value;
                expensesDBContext.SaveChanges();
                return await Task.FromResult("True");
            }
            catch(Exception ex)
            {
                return await Task.FromResult("False");
            }
        }

    }
}
