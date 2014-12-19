using AutoMapper;
using Simple.ModelBindingSortAndPaging.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Simple.ModelBindingSortAndPaging
{
    [DataObject]
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Dictionary<string, string> _checkeds = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    return;
            //}

            //if (this.Session["ChequeSelected"] != null)
            //{
            //    this._checkeds = this.Session["ChequeSelected"] as Dictionary<string, string>;
            //}
            //else
            //{
            //    this._checkeds = new Dictionary<string, string>();
            //    this.Session["ChequeSelected"] = this._checkeds;
            //}

            //var checkString = Request.Form["ChequeSelected"];
            //if (checkString == null)
            //    return;
            //var builder = new StringBuilder();
            //builder.Append("Vous have selected the following checks :<br/>");

            //// we'll need a split to get the individual ids
            //var values = checkString.Split(',');
            //foreach (var value in values)
            //{
            //    bool isCheck = false;
            //    foreach (KeyValuePair<string, string> check in this._checkeds.ToArray())
            //    {
            //        if (check.Key == value)
            //        {
            //            isCheck = true;
            //            break;
            //        }
            //    }
            //    if (isCheck)
            //    {

            //        this._checkeds[value] = "checked";
            //    }
            //    else
            //    {
            //        this._checkeds[value] = "";
            //    }
            //}
            //foreach (var check in this._checkeds)
            //{
            //    if (!string.IsNullOrWhiteSpace(check.Value))
            //    {
            //        builder.Append("<br/>");
            //        builder.Append(check.Key);
            //    }
            //}

            //Response.Write(builder.ToString());

            //GridView1.DataBind();
        }

        private ThreeLayerDbContext _db = null;

        public WebForm1()
        {
            if (this._db == null)
            {
                this._db = new ThreeLayerDbContext();
            }
        }


        public IEnumerable<AccountViewModel> GetAllAccounts(int startRowIndex, int maximumRows, string sortByExpression, out int totalRowCount)
        {
            if (string.IsNullOrWhiteSpace(sortByExpression))
            {
                sortByExpression = "帳號 ASC";
            }

            string[] split = null;
            var columnName = string.Empty;
            var sort = string.Empty;

            if (sortByExpression.Contains(' '))
            {
                split = sortByExpression.Split(' ');
                columnName = split[0];
                sort = split[1];
            }
            else
            {
                columnName = sortByExpression;
                sort = "ASC";
            }
            var mapName = Mapper.FindTypeMapFor<AccountViewModel, Account>()
                                  .GetPropertyMaps()
                                  .FirstOrDefault(p => p.SourceMember.Name == columnName)
                                  .DestinationProperty.Name;

            //這樣寫同等 select * from 
            //var accounts = this._db.Accounts.OrderBy(mapName + " " + sort)
            //                       .Skip(startRowIndex)
            //                       .Take(maximumRows)
            //                       .Select(Mapper.Map<AccountViewModel>);

            var accounts = this._db.Accounts.OrderBy(mapName + " " + sort)
                            .Skip(startRowIndex)
                            .Take(maximumRows)
                            .Select(p => new AccountViewModel()
                            {
                                帳號 = p.UserId,
                                年齡 = p.Age,
                                電話 = p.Phone,
                                外號 = p.NickName
                            });
            totalRowCount = this._db.Accounts.Count();

            return accounts;
        }

        public void UpdateAccount(AccountViewModel accountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            var account = Mapper.Map<Account>(accountViewModel);
            var query = this._db.Accounts.FirstOrDefault(a => a.UserId == account.UserId);
            if (query == null)
            {
                return;
            }

            Mapper.Map(accountViewModel, query);
            this._db.SaveChanges();
        }

        public void DeleteAccount(AccountViewModel accountViewModel)
        {
            var account = Mapper.Map<Account>(accountViewModel);

            var query = this._db.Accounts.FirstOrDefault(a => a.UserId == account.UserId);
            if (query == null)
            {
                return;
            }
            this._db.Accounts.Remove(query);
            this._db.SaveChanges();
        }

        public void InsertAccount(AccountViewModel accountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            var account = Mapper.Map<Account>(accountViewModel);

            this._db.Accounts.Add(account);
            account.Password = "亂數產生";
            try
            {
                this._db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


        }
        //public string NumeroChequeInclus(string numero)
        //{
        //    if (this.Session["ChequeSelected"] != null)
        //    {
        //        this._checkeds = this.Session["ChequeSelected"] as Dictionary<string, string>;
        //    }
        //    else
        //    {
        //        this._checkeds = new Dictionary<string, string>();
        //        this.Session["ChequeSelected"] = this._checkeds;
        //    }


        //    if (this._checkeds.ContainsKey(numero))
        //    {
        //        if (this._checkeds[numero] == "checked")
        //        {
        //            return "checked";

        //        }
        //        {
        //            this._checkeds[numero] = null;
        //            return "null";
        //        }


        //    }
        //    else
        //    {
        //        this._checkeds[numero] = null;
        //    }
        //    return null;
        //}


    }
}