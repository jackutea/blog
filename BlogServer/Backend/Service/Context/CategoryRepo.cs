using BlogServer.Data;

namespace BlogServer.Facades;

public class CategoryRepo {

    Dictionary<string, CategoryModel> all;

    bool isDirty;
    public bool IsDirty => isDirty;

    public CategoryRepo() {
        this.all = new Dictionary<string, CategoryModel>();
        this.isDirty = true;
    }

    public void Add(CategoryModel category) {
        if (category.name == null) {
            System.Console.WriteLine("category.name is null");
            return;
        }
        all.Add(category.name, category);
        isDirty = true;
    }

    public IEnumerable<CategoryModel> GetCategories() {
        return all.Values;
    }

    public void SetUndirty() {
        isDirty = false;
    }

    public bool TryGet(string name, out CategoryModel category) {
        return all.TryGetValue(name, out category);
    }

    public bool TryRemove(string name) {
        bool has = all.Remove(name);
        if (has) {
            isDirty = true;
        }
        return has;
    }

}