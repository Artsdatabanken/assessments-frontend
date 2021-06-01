using Artsdatabanken;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class RL2006ViewModel
    {
        //public List<Redlist2006Assessment> Redlist2006Results { get; set; } = new();
        public IPagedList<Redlist2006Assessment> Redlist2006Results { get; set; }
    }

}