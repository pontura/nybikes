using System.IO;

namespace MantleEngine.Unity.Editor.Utilities
{
    public static class PathUtil
    {
        public static void EnsureDirectoryClean(string directory)
        {
            EnsureDirectoryRemoved(directory);
            EnsureDirectoryExists(directory);
        }

        public static void EnsureDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static void EnsureDirectoryRemoved(string directory)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
                DeleteMetaFile(directory);
            }
        }

        public static void DeleteFile(string file)
        {
            File.Delete(file);
            DeleteMetaFile(file);
        }

        public static void DeleteMetaFile(string path)
        {
            var metaPath = path + ".meta";
            if (File.Exists(metaPath))
            {
                File.Delete(metaPath);
            }
        }

        public static long PathModificationTime(string path)
        {
            if (Directory.Exists(path))
            {
                return Directory.GetLastWriteTime(path).ToFileTime();
            }
            else if (File.Exists(path))
            {
                return File.GetLastWriteTime(path).ToFileTime();
            }
            else
            {
                return 0L;
            }
        }
    }
}