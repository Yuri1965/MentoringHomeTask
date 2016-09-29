using System;
using MigraDoc.DocumentObjectModel;
using System.IO;
using MigraDoc.Rendering;
using System.Collections.Generic;
using System.Threading;
using Castle.Core;

namespace ImageMerger
{
    [Interceptor("LogInterceptor")]
    public class ImageToPdfFileMerger : IImageToPdfFileMerger
    {
        public const double PDF_PAGE_TOP_MARGIN = 0.10;
        public const double PDF_PAGE_BOTTOM_MARGIN = 0.10;
        public const double PDF_PAGE_LEFT_MARGIN = 0.10;
        public const double PDF_PAGE_RIGHT_MARGIN = 0.10;

        public const int COUNT_WAIT_FILE_OPEN = 2000;
        public const int COUNT_FILE_OPEN = 10;

        private Document pdfDocument;
        private string pdfFileName;
        private string outputDirectory;
        private List<string> includeFiles;

        public ImageToPdfFileMerger(string outputDirectory, string pdfFileName)
        {
            pdfDocument = new Document();
            includeFiles = new List<string>();

            this.pdfFileName = pdfFileName;
            this.outputDirectory = String.Format("{0}{1}{2}", outputDirectory, Path.GetFileNameWithoutExtension(pdfFileName), @"\");
        }

        public string GetOutputDirectory()
        {
            return outputDirectory;
        }

        public bool AddImageFile(string imageFileName)
        {
            if (IsFileImageType(imageFileName))
            {
                var docSection = pdfDocument.AddSection();

                var addImg = docSection.AddImage(imageFileName);

                pdfDocument.DefaultPageSetup.TopMargin = PDF_PAGE_TOP_MARGIN;
                pdfDocument.DefaultPageSetup.BottomMargin = PDF_PAGE_BOTTOM_MARGIN;
                pdfDocument.DefaultPageSetup.LeftMargin = PDF_PAGE_LEFT_MARGIN;
                pdfDocument.DefaultPageSetup.RightMargin = PDF_PAGE_RIGHT_MARGIN;

                addImg.Height = pdfDocument.DefaultPageSetup.PageHeight;
                addImg.Width = pdfDocument.DefaultPageSetup.PageWidth;

                includeFiles.Add(imageFileName);
                return true;
            }
            else return false;
        }

        public void SavePdfFile()
        {
            var render = new PdfDocumentRenderer();

            render.Document = pdfDocument;
            render.RenderDocument();

            try
            {
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                render.Save(Path.Combine(outputDirectory, pdfFileName));
            }
            catch (Exception e)
            {
                LoggerUtil.LogException(new Exception(String.Format("При сохранении файла {0} произошла ошибка:\n {1}", pdfFileName, e.Message)));
            }

            foreach (var file in includeFiles)
            {
                var outFile = Path.Combine(outputDirectory, Path.GetFileName(file));

                try
                {
                    if (TryOpenFile(file))
                        File.Move(file, outFile);
                }
                catch (Exception e)
                {
                    LoggerUtil.LogException(new Exception(String.Format("При переносе файла {0} произошла ошибка:\n {1}", file, e.Message)));
                }
            }

        }

        private static bool TryOpenFile(string file)
        {
            for (int i = 0; i < COUNT_FILE_OPEN; i++)
            {
                try
                {
                    var openFile = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.None);
                    openFile.Close();

                    return true;
                }
                catch (IOException)
                {
                    Thread.Sleep(COUNT_WAIT_FILE_OPEN);
                }
            }

            return false;
        }

        private bool IsFileImageType(string imageFileName)
        {
            bool result = false;

            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(imageFileName);

                if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp) ||
                    img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg) ||
                    img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                {
                    result = true;
                }
                else
                {
                    LoggerUtil.logger.Error(String.Format("При обработке файла {0} произошла ошибка:\n {1}", imageFileName, 
                                                          "Данный тип файла не поддерживается. Изображение не будет добавлено в файл сборки."));
                }

                img.Dispose();
            }
            catch (Exception e)
            {
                // Image.FromFile throws an OutOfMemoryException 
                // if the file does not have a valid image format or
                // GDI+ does not support the pixel format of the file.
                LoggerUtil.LogException(new Exception(String.Format("При обработке файла {0} произошла ошибка (изображение не будет добавлено в файл сборки):\n {1}", 
                                                      imageFileName, e.Message)));
            }

            return result;
        }
    }
}