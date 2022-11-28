using System.IO;
using System.Text.RegularExpressions;
using BlogServer.Facades;
using BlogServer.Messages;
namespace BlogServer.Data;

public class CategoryService
{
    ContextService ctx;
    string dataPath;

    public CategoryService(ContextService ctx)
    {
        this.ctx = ctx;

        DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory);
        if (dir.Parent != null)
        {
            this.dataPath = Path.Combine(dir.Parent.FullName, "Docs");
        }
        else
        {
            System.Console.WriteLine("Cant Find Dir");
        }
    }

    public string OnReqLoadBlog(int id)
    {
        bool has = ctx.BlogRepo.TryGet(id, out BlogModel blog);
        if (has)
        {
            return blog.content;
        }
        System.Console.WriteLine("blog not found: " + id);
        return "";
    }

    public BlogTitleMessage[] OnReqLoadBlogs()
    {
        if (IsNeedReload())
        {
            BuildBlogs(dataPath);
            ctx.BlogRepo.SetUndirty();
            ctx.CategoryRepo.SetUndirty();
        }
        var all = ctx.BlogRepo.GetBlogs();
        var arr = new BlogTitleMessage[all.Count()];
        int i = 0;
        foreach (var blog in all)
        {
            arr[i] = new BlogTitleMessage()
            {
                id = blog.id,
                title = blog.title,
                filePath = blog.filePath
            };
                System.Console.WriteLine("blog.filePath:" + blog.filePath);

            i += 1;
        }
        return arr;
    }

    public IEnumerable<CategoryModel> OnReqLoadCategory()
    {
        if (IsNeedReload())
        {
            BuildCategories(dataPath);
            ctx.BlogRepo.SetUndirty();
            ctx.CategoryRepo.SetUndirty();
        }
        return ctx.CategoryRepo.GetCategories();
    }

    bool IsNeedReload()
    {

        var blogRepo = ctx.BlogRepo;
        if (blogRepo.IsDirty)
        {
            return true;
        }

        var categoryRepo = ctx.CategoryRepo;
        if (categoryRepo.IsDirty)
        {
            return true;
        }

        return false;
    }

    void BuildCategories(string dirPath)
    {
        var dirs = Directory.GetDirectories(dirPath);
        for (int i = 0; i < dirs.Length; i += 1)
        {
            var dir = dirs[i];
            var name = Path.GetFileName(dir);
            string[] childrenDir = Directory.GetDirectories(dir);
            string[] childrenFile = Directory.GetFiles(dir);
            var category = new CategoryModel();
            category.name = name;
            category.childrenDir = childrenDir;
            category.childrenFile = childrenFile;
            ctx.CategoryRepo.Add(category);
            BuildCategories(dir);
        }
    }

    static int id = 1;
    void BuildBlogs(string dirPath)
    {
        var dirs = Directory.GetDirectories(dirPath);
        for (int i = 0; i < dirs.Length; i += 1)
        {
            var dir = dirs[i];
            var files = Directory.GetFiles(dir, "*.md");
            for (int j = 0; j < files.Length; j += 1)
            {
                var file = files[j];
                var fileName = Path.GetFileName(file).Replace(".md", "");
                var blog = new BlogModel();
                blog.id = id;
                blog.title = fileName;
                var content = File.ReadAllText(file);
                blog.content = content;
                blog.filePath = Path.GetRelativePath(Environment.CurrentDirectory, file);
                ctx.BlogRepo.Add(blog);
                id += 1;
            }
            BuildBlogs(dir);
        }
    }

}