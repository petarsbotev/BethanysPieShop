﻿namespace BethanysPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethanysPieShopDbContext _context;

        public CategoryRepository(BethanysPieShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> AllCategories => _context.Categories.OrderBy(c => c.CategoryName);
    }
}
