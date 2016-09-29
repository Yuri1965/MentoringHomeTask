namespace ImageMerger
{
    public interface IImageToPdfFileMerger
    {
        bool AddImageFile(string imageFileName);
        string GetOutputDirectory();
        void SavePdfFile();
    }
}