namespace BlogServer.Data;

public class CategoryService {

    public string name;

    public CategoryService() {
        this.name = "yoyo";
    }

    public async Task OnAwakeAsync() {
        await Task.Delay(1000);
        System.Console.WriteLine("OnAwakeAsync");
    }
    
}