using ExpensesBE.EntityModels;

namespace ExpensesBE.DAL
{
    public interface IExpenseDAL
    {
        Task<List<Entry>> GetData();
        Task<string> SaveData(Entry req);
        Task<string> DeleteData(int entryid);
        Task<string> UpdateData(Entry req);
    }
}
