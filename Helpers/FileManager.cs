namespace IndigoBilet1.Helpers
{
    public static class FileManager
    {
        public static string SaveFile(this IFormFile formFile, string rootpath, string filepath)
        {
            string fileName = formFile.FileName;


            if(fileName != null)
            {
                fileName = (fileName.Length>64 ? fileName.Substring(fileName.Length-15,15) : fileName);
                fileName= Guid.NewGuid().ToString()+fileName;
                string path = Path.Combine(rootpath,filepath,fileName);
                
                using(FileStream filestream = new FileStream(path,FileMode.Create))
                {
                    formFile.CopyTo(filestream);
                }
            }


            return fileName;
        } 


        public static bool CheckFileLength(this IFormFile formFile ,double length)
        {
            if(formFile != null)
                if (formFile.Length > length) return false;
            
            return true;
                    
        }
        public static bool CheckFileType(this IFormFile formFile)
        {
            if(formFile != null)
                if(formFile.ContentType!="image/jpeg" && formFile.ContentType!="image/png") return false;
            return true;
        }
    }
}
