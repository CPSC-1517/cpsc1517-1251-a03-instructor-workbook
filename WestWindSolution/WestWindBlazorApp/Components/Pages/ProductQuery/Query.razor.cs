using Microsoft.AspNetCore.Components;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindBlazorApp.Components.Pages.ProductQuery
{
    public partial class Query
    {
        [Inject]
        public CategoryServices CategoryServices { get; set; }

        [Inject]
        public ProductServices ProductServices { get; set; }

        private List<Category>? _categories;
        private List<Product>? _categoryProducts;

        protected override async Task OnInitializedAsync()
        {
            _categories = await CategoryServices.Category_GetAllAsync();
        }
    }
}
