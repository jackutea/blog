namespace BlogServer.Data;

public class CategoryModel
{
    public int id;
    public string name;
    public string[] childrenDir;
    public string[] childrenFile;

    public CategoryModel() { }

}