using Simple.BindingSourceEF.DAL;
using Simple.BindingSourceEF.DAL.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Simple.BindingSourceEF.UI
{
    public partial class Form1 : Form
    {
        public IBusinessFlowDao BusinessFlowDao { get; set; }
        private Account _currentAccount = null;
        public Form1()
        {
            InitializeComponent();
            //Database.SetInitializer(new ThreeLayerDropCreateDatabaseAlways());
            if (this.BusinessFlowDao == null)
            {
                this.BusinessFlowDao = new BusinessFlowDao();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Account_BindingSource.PositionChanged += Account_BindingSource_PositionChanged;
            this.Account_BindingSource.DataSource = this.BusinessFlowDao.GetAllAccounts().ToList();
        }


        private void Account_BindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            var account = new Account();
            e.NewObject = account;

            this.BusinessFlowDao.InsertAccount(account);
        }

        private void AccountLog_BindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            var accountLog = new AccountLog() { LastLoginTime = DateTime.Now };
            e.NewObject = accountLog;

            this.BusinessFlowDao.InsertAccountLog(this._currentAccount, accountLog);
        }

        private void Account_BindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var account = (Account)this.Account_BindingSource.Current;
            this.BusinessFlowDao.DeleteAccount(account);
            this.Account_BindingSource.Remove(account);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var accountLog = (AccountLog)this.AccountLog_BindingSource.Current;
            this.BusinessFlowDao.DeleteAccountLog(accountLog);
            this.AccountLog_BindingSource.Remove(accountLog);
        }

        private void Account_BindingSource_PositionChanged(object sender, EventArgs e)
        {
            var source = (BindingSource)sender;

            if (source.Position < 0)
            {
                this.AccountLog_BindingSource.DataSource = null;
                return;
            }
            this._currentAccount = (Account)source.Current;
            var queryAccountLogs = this.BusinessFlowDao.GetAllAccountLogs(this._currentAccount.Id);
            if (!queryAccountLogs.Any())
            {
                this.AccountLog_BindingSource.DataSource = null;
                return;
            }
            this.AccountLog_BindingSource.DataSource = queryAccountLogs.ToList();
        }

        private void Account_BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.BusinessFlowDao.Commit();
        }
    }
}