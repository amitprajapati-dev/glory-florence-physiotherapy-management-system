using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface ICategory
{
    List<Category> GetAllCategory();

    Category? GetCategoryById(int id);

    bool AddCategory(Category category);

    bool UpdateCategory(Category category);

    bool DeleteCategoryById(int id);
}