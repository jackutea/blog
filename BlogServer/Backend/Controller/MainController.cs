namespace BlogServer.Controller;

public class MainController
{

    public void Init()
    {
        DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory);
        var srcDir = Path.Combine(dir.Parent.FullName, "Docs");
        var dstDir = Path.Combine(Environment.CurrentDirectory, "wwwroot", "docs");
        if (!Directory.Exists(dstDir))
        {
            Directory.CreateDirectory(dstDir);
        }
        CopyMarkdownsRecurs(srcDir, dstDir);

    }

    void CopyMarkdownsRecurs(string srcDir, string dstDir)
    {
        DirectoryInfo dir = new DirectoryInfo(srcDir);
        if (!dir.Exists)
        {
            return;
        }
        foreach (FileInfo file in dir.GetFiles())
        {
            if (file.Extension == ".md" || file.Extension == ".png")
            {
                string dstFile = Path.Combine(dstDir, file.Name);
                file.CopyTo(dstFile, true);
            }
        }
        foreach (DirectoryInfo subDir in dir.GetDirectories())
        {
            string dstSubDir = Path.Combine(dstDir, subDir.Name);
            if (!Directory.Exists(dstSubDir))
            {
                Directory.CreateDirectory(dstSubDir);
            }
            CopyMarkdownsRecurs(subDir.FullName, dstSubDir);
        }
    }

}