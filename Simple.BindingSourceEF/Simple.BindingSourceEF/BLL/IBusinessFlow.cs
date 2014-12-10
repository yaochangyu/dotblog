namespace Simple.BindingSourceEF.BLL
{
    public interface IBusinessFlow
    {
        bool IsValid(string userId, string password);
    }
}