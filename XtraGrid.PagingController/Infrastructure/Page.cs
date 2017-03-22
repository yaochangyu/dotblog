using System;

namespace Infrastructure
{
    /// <summary>
    ///     Class Page.
    /// </summary>
    public class Page
    {
        /// <summary>
        ///     The _is first page
        /// </summary>
        private bool _isFirstPage;

        /// <summary>
        ///     The _is last page
        /// </summary>
        private bool _isLastPage;

        /// <summary>
        ///     The _page size
        /// </summary>
        private int _pageSize;

        /// <summary>
        ///     The _page size information
        /// </summary>
        private string _pageSizeInfo;

        /// <summary>
        ///     The _skip
        /// </summary>
        private int _skip;

        public bool IsLastPage
        {
            get
            {
                this._isLastPage = this.PageIndex == this.PageSize - 1;
                return this._isLastPage;
            }
            internal set { this._isLastPage = value; }
        }

        public bool IsFirstPage
        {
            get
            {
                this._isFirstPage = this.PageIndex == 0;
                return this._isFirstPage;
            }
            internal set { this._isFirstPage = value; }
        }

        public int PageIndex { get; set; }

        public string PageIndexInfo
        {
            get
            {
                this._pageSizeInfo = string.Format("{0}/{1}", this.PageIndex + 1, this.PageSize);
                return this._pageSizeInfo;
            }
            set { this._pageSizeInfo = value; }
        }

        public int PageSize
        {
            get
            {
                if (this.TotalCount.HasValue)
                {
                    if (this.RowSize != 0)
                    {
                        var pageSize = (double) this.TotalCount / this.RowSize;
                        this._pageSize = (int) Math.Ceiling(pageSize);
                    }
                }
                return this._pageSize;
            }
            internal set { this._pageSize = value; }
        }

        public int RowSize { get; set; } = 10;

        public int Skip
        {
            get
            {
                this._skip = this.PageIndex * this.RowSize;
                return this._skip;
            }
            internal set { this._skip = value; }
        }

        public int? TotalCount { get; set; }

        public string SortExpression { get; set; }

        public string FilterExpression { get; set; }

        public void MoveFirstPage()
        {
            this.PageIndex = 0;
        }

        public void MoveLastPage()
        {
            this.PageIndex = this.PageSize - 1;
        }

        public void MoveNextPage()
        {
            if (this.PageIndex >= this.PageSize - 1)
            {
                return;
            }

            this.PageIndex++;
        }

        public void MovePreviousPage()
        {
            if (this.PageIndex <= 0)
            {
                return;
            }

            this.PageIndex--;
        }
    }
}