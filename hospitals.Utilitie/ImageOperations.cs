using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace hospitals.Utilities;

public class ImageOperations
{
    IWebHostEnvironment _env;
    public ImageOperations(IWebHostEnvironment env)
    {
        _env = env;
    }

    public string ImageUpload(IFormFile file)
    {
        string filename = null;
        if (file != null)
        {
            string fileDirctory = Path.Combine(_env.WebRootPath, "Images");
            filename = Guid.NewGuid() + "-" + file.FileName;
            string filePath = Path.Combine(fileDirctory, filename);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fs);
            }

        }

        return filename;
    }
}
