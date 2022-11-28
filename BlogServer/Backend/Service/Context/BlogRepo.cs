using BlogServer.Data;
namespace BlogServer.Facades;

public class BlogRepo
{

    Dictionary<int, BlogModel> all;

    bool isDirty;
    public bool IsDirty => isDirty;

    public BlogRepo()
    {
        this.all = new Dictionary<int, BlogModel>();
        this.isDirty = true;
    }

    public void Add(BlogModel blog)
    {
        bool has = all.TryAdd(blog.id, blog);
        if (has)
        {
            isDirty = true;
        }
        else
        {
            System.Console.WriteLine("blog.title is duplicated: " + blog.title);
        }
    }

    public IEnumerable<BlogModel> GetBlogs()
    {
        return all.Values;
    }

    public bool TryGet(int title, out BlogModel blog)
    {
        return all.TryGetValue(title, out blog);
    }

    public void SetUndirty()
    {
        isDirty = false;
    }

    public bool TryRemove(int title)
    {
        bool has = all.Remove(title);
        if (has)
        {
            isDirty = true;
        }
        return has;
    }

}