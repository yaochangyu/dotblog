using Simple.BindingSourceEF.DAL;

namespace Simple.BindingSourceEF.BLL
{
    public class BusinessFlow : IBusinessFlow
    {
        private IBusinessFlowDao _dao = new BusinessFlowDao();

        public bool IsValid(string userId, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}