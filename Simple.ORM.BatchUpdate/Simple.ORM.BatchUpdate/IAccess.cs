namespace Simple.ORM.BatchUpdate
{
    public interface IAccess
    {
        int RowCount { get; set; }

        int Insert(int? rowCount = null);

        int Delete(int? rowCount = null);

        int Update(int? rowCount = null);
    }
}