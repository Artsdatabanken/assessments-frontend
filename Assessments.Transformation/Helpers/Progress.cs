using ByteSizeLib;
using ShellProgressBar;

namespace Assessments.Transformation.Helpers
{
    public static class Progress
    {
        public static ProgressBar ProgressBar;
        public static long UploadFileSize;
        
        public static void UploadProgressChanged(object _, long bytesUploaded) => ProgressBar.Tick((int) GetProgressPercentage(UploadFileSize, bytesUploaded), $"Laster opp vurderinger {ByteSize.FromBytes(bytesUploaded).MegaBytes:#} MB av {ByteSize.FromBytes(UploadFileSize).MegaBytes:#} MB");

        private static double GetProgressPercentage(double totalSize, double currentSize) => currentSize / totalSize * 100;
    }
}