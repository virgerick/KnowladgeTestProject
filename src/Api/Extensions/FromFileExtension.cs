

using Api.Core.Syncfusion;

namespace Api.Extensions;

public static class FromFileExtension
{

    public static async Task<byte[]> GetContentAsync(this IFormFile file)
    {
        if (file is null || file.Length <= 0) throw new Exception("File not selected.");
        byte[] fileContent;
        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            stream.Seek(0, SeekOrigin.Begin);
            fileContent = stream.ToArray();
        }
        return fileContent;
    }
    public static async Task<string> GetBase64String(this IFormFile file)
    {
        var content = await file.GetContentAsync();
        return content.GetBase64String();
    }
    public static string GetBase64String(this byte[] context)
    {
        return Convert.ToBase64String(context);
    }
    public static string GetExtension(this IFormFile file)
    {
        return System.IO.Path.GetExtension(file.FileName);
    }
    public static FileType GetFileType(this IFormFile file)
    {
        var extension = file.GetExtension();
        return FileType.Supported.Where(x => x.Extension.ToLower() == extension.ToLower())
            .FirstOrDefault()!;
    }}

