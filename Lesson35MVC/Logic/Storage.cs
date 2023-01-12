namespace Lesson35MVC.Logic;

public static class Storage
{
    public static string BasePath;

    public static string[] IndexTableHeaders =
        { "Id", "FirstName", "LastName", "Info", "Edit" };

    public static async Task UploadImage(int id, HttpRequest httpRequest)
    {
        var files = Directory
            .EnumerateFiles($"{BasePath}/users/", "*.*", SearchOption.TopDirectoryOnly)
            .Count(s => s.Split("/").Last().Split("-").First().Equals($"{id}"));
        //"D:\\Git\\beetroot-tasks\\Lesson35MVC\\wwwroot/users/102-1.png"
        // {userId}-{counter}.ext
        if (httpRequest.Form.Files.Any())
            foreach (var formFile in httpRequest.Form.Files)
            {
                var number = files + 1;
                var newPath = $"{BasePath}/users/{id}-{number}{Path.GetExtension(formFile.FileName)}";
                await using var fileStream = new FileStream(newPath, FileMode.Create);
                await formFile.CopyToAsync(fileStream);
            }
    }

    public static void DeleteImage(int id, string cat, string path) =>
        File.Delete($"{path}/img/{cat}/{id}.webp");
}