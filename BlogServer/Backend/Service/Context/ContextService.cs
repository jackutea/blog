using BlogServer.Data;
namespace BlogServer.Facades;

public class ContextService {

    AppStateModel appStateModel;
    public AppStateModel AppStateModel => appStateModel;

    BlogRepo blogRepo;
    public BlogRepo BlogRepo => blogRepo;

    CategoryRepo categoryRepo;
    public CategoryRepo CategoryRepo => categoryRepo;

    public ContextService() {
        this.appStateModel = new AppStateModel();
        this.blogRepo = new BlogRepo();
        this.categoryRepo = new CategoryRepo();
    }

}