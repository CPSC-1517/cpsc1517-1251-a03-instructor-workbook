using Microsoft.AspNetCore.Components;
using WestWindSystem.BLL;

namespace WestWindBlazorApp.Components.Pages.ProductQuery
{
    public partial class Query
    {
        [Inject]
        public CategoryServices CategoryServices { get; set; }

        [Inject]
        public ProductServices ProductServices { get; set; }
    }
}
