namespace API.Helpers.Pager;

public class Pager<T> where T: class
{
    public string Search {get;set;}
    public int PageIndex {get;set;}
    public int PageSize {get;set;}
    public int Total {get;set;}
    public IEnumerable<T> Registers {get;set;}

    public Pager(string search, int pageIndex, int pageSize, int total, IEnumerable<T> registers)
    {
        Search = search;
        PageIndex = pageIndex;
        PageSize = pageSize;
        Total = total;
        Registers = registers;
    }

    public int TotalPages
    {
        get{
            return(int)Math.Ceiling(Total/(double)PageSize);
        }
    }

    public bool HasPreviousPage
    {
        get{
            return (PageIndex > 1);
        }
    }
    public bool HasNextPage
    {
        get{
            return (PageIndex < TotalPages);
        }
    }
} 