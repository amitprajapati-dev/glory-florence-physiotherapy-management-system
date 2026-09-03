using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class CategoryService : ICategory
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public List<Category> GetAllCategory()
    {
        return _context.Categories.ToList();
    }

    public Category? GetCategoryById(int id)
    {
        return _context.Categories.Find(id);
    }

    public bool AddCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteCategoryById(int id)
    {
        var category = _context.Categories.Find(id);

        if (category == null)
        {
            return false;
        }

        _context.Categories.Remove(category);
        _context.SaveChanges();

        return true;
    }
}