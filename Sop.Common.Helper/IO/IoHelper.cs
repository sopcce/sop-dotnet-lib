using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Sop.Common.Helper.IO
{
    public static class IoHelper
    {
        public static readonly Encoding GB2312 = Encoding.GetEncoding(936);

        public static readonly string AllowUploadOrDeleteFileTypes = string.Empty;

        public const string AllowReadeOrWriteFileTypes = ".html|.htm|.txt|.css|.js|.log|.xml";

        public const string AllowAdFileTypes = ".jpg|.jpeg|.gif|.png|.swf";

        public const string AllowImageAndMediasFileTypes = ".jpg|.jpeg|.gif|.png|.swf|.mid|.wav|.mp3";

        public const string AllowImageFileTypes = ".jpg|.jpeg|.gif|.png";

        public const string SerializedFileExtension = ".sop";

        public static bool IsAllowedFileType(string FileName, string FileTypes)
        {
            if (string.IsNullOrEmpty(FileName))
            {
                return false;
            }

            string text = Path.GetExtension(FileName).ToLower();
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            FileTypes = $"|{FileTypes}|".ToLower();
            if (!FileTypes.Contains($"|{text}|"))
            {
                return false;
            }

            return true;
        }

        public static string ReadTextFile(string FilePath, int EncodingCodepage)
        {
            if (!IsAllowedFileType(FilePath, ".html|.htm|.txt|.css|.js|.log|.xml"))
            {
                return string.Empty;
            }

            if (!File.Exists(FilePath))
            {
                return string.Empty;
            }

            string empty = string.Empty;
            Encoding encoding = (EncodingCodepage != 0) ? Encoding.GetEncoding(EncodingCodepage) : GB2312;
            try
            {
                using (FileStream stream =
                    new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(stream, encoding))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool WriteTextFile(string FilePath, string Content, int EncodingCodepage)
        {
            if (!IsAllowedFileType(FilePath, ".html|.htm|.txt|.css|.js|.log|.xml"))
            {
                return false;
            }

            bool flag = false;
            try
            {
                using (FileStream stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
                {
                    Encoding encoding = Encoding.GetEncoding(EncodingCodepage);
                    using (StreamWriter streamWriter = new StreamWriter(stream, encoding))
                    {
                        streamWriter.Write(Content);
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool WriteTextFileByAppend(string FilePath, string Content, int EncodingCodepage)
        {
            if (!IsAllowedFileType(FilePath, ".html|.htm|.txt|.css|.js|.log|.xml"))
            {
                return false;
            }

            bool flag = false;
            try
            {
                using (FileStream stream = new FileStream(FilePath, FileMode.Append, FileAccess.Write))
                {
                    Encoding encoding = Encoding.GetEncoding(EncodingCodepage);
                    using (StreamWriter streamWriter = new StreamWriter(stream, encoding))
                    {
                        streamWriter.Write(Content);
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool DeleteFile(string FilePath)
        {
            if (!IsAllowedFileType(FilePath, AllowUploadOrDeleteFileTypes))
            {
                return false;
            }

            bool result = true;
            try
            {
                File.Delete(FilePath);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public static bool MoveOrRenameFile(string FilePath, string NewFilePath)
        {
            if (!IsAllowedFileType(FilePath, AllowUploadOrDeleteFileTypes))
            {
                return false;
            }

            if (File.Exists(NewFilePath))
            {
                return false;
            }

            bool result = false;
            try
            {
                if (File.Exists(FilePath))
                {
                    File.Move(FilePath, NewFilePath);
                    return true;
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        public static void CopyFile(string SrcFilePath, string DestFilePath)
        {
            if (File.Exists(SrcFilePath))
            {
                File.Copy(SrcFilePath, DestFilePath, overwrite: true);
            }
        }

        public static string GenerateNewRandomFilename(string OriginalFilename)
        {
            Random random = new Random();
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmssffff"), random.Next(0, 10)) +
                   Path.GetExtension(OriginalFilename);
        }

        public static string GetFileExtension(string FilePath)
        {
            string text = Path.GetExtension(FilePath);
            if (text == null)
            {
                text = string.Empty;
            }

            return text.ToLower();
        }

        public static string[] GetFileInfo(string FilePhysicalPath)
        {
            string[] obj = new string[3]
            {
                "0",
                null,
                null
            };
            DateTime minValue = DateTime.MinValue;
            obj[1] = minValue.ToString();
            obj[2] = "";
            string[] array = obj;
            if (string.IsNullOrEmpty(FilePhysicalPath))
            {
                return array;
            }

            FileInfo fileInfo = new FileInfo(FilePhysicalPath);
            if (!fileInfo.Exists)
            {
                return array;
            }

            array[0] = fileInfo.Length.ToString();
            DateTime lastWriteTime = fileInfo.LastWriteTime;
            array[1] = lastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            array[2] = $"\"{lastWriteTime.Ticks}\"";
            return array;
        }

        public static bool FileExists(string FilePath)
        {
            return File.Exists(FilePath);
        }

        public static byte[] ReadByteArrayFromStream(Stream InputStream)
        {
            try
            {
                byte[] array = new byte[InputStream.Length];
                int i = 0;
                for (int num = array.Length; i < num; i += InputStream.Read(array, i, num - i))
                {
                }

                return array;
            }
            catch
            {
                throw;
            }
        }

        public static string GetRandomCharsCanUseForFilename(int Length)
        {
            if (Length <= 0)
            {
                return string.Empty;
            }

            StringBuilder stringBuilder = new StringBuilder();
            while (stringBuilder.Length < Length)
            {
                stringBuilder.Append(Path.GetRandomFileName().Replace(".", ""));
            }

            return stringBuilder.ToString().Substring(0, Length);
        }

        public static T ReadSerializedData<T>(string FilePath) where T : class
        {
            if (!Path.HasExtension(FilePath))
            {
                FilePath = string.Format("{0}{1}", FilePath, ".yps");
            }

            if (!File.Exists(FilePath))
            {
                return null;
            }

            T result = null;
            try
            {
                using (FileStream serializationStream =
                    new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    result = (T) new BinaryFormatter().Deserialize(serializationStream);
                    return result;
                }
            }
            catch
            {
                return result;
            }
        }

        public static bool WriteSerializedData<T>(string FilePath, T SerializableObject) where T : class
        {
            if (!Path.HasExtension(FilePath))
            {
                FilePath = string.Format("{0}{1}", FilePath, ".yps");
            }

            bool result = true;
            try
            {
                using (FileStream serializationStream = new FileStream(FilePath, FileMode.Create))
                {
                    new BinaryFormatter().Serialize(serializationStream, SerializableObject);
                    return result;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteSerializedFile(string FilePath)
        {
            if (!Path.HasExtension(FilePath))
            {
                FilePath = string.Format("{0}{1}", FilePath, ".yps");
            }
            else if (!Path.GetExtension(FilePath).ToLower().Equals(".yps"))
            {
                return false;
            }

            bool result = true;
            try
            {
                File.Delete(FilePath);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public static bool FolderExists(string DirPath)
        {
            return Directory.Exists(DirPath);
        }

        public static string[] GetAllFileNamesOfDir(string DirPath)
        {
            try
            {
                return Directory.GetFiles(DirPath);
            }
            catch
            {
                throw;
            }
        }

        public static FileInfo[] GetAllFilesInfoOfDir(string DirPath)
        {
            try
            {
                FileInfo[] result = null;
                DirectoryInfo directoryInfo = new DirectoryInfo(DirPath);
                if (directoryInfo.Exists)
                {
                    result = directoryInfo.GetFiles();
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        public static string[] GetAllFoldersOfDir(string DirPath)
        {
            try
            {
                return Directory.GetDirectories(DirPath);
            }
            catch
            {
                throw;
            }
        }

        public static DirectoryInfo[] GetAllFoldersInfoOfDir(string DirPath)
        {
            try
            {
                DirectoryInfo[] result = null;
                DirectoryInfo directoryInfo = new DirectoryInfo(DirPath);
                if (directoryInfo.Exists)
                {
                    result = directoryInfo.GetDirectories();
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        public static bool CreateDir(string DirPath)
        {
            if (Directory.Exists(DirPath))
            {
                return false;
            }

            try
            {
                Directory.CreateDirectory(DirPath);
            }
            catch
            {
                throw;
            }

            return true;
        }

        public static bool DeleteDir(string DirPath)
        {
            try
            {
                if (Directory.Exists(DirPath))
                {
                    Directory.Delete(DirPath, recursive: true);
                }
            }
            catch
            {
                throw;
            }

            return true;
        }

        public static long GetDirSize(string DirPath, bool AndSubdirectorys)
        {
            long num = 0L;
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(DirPath);
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo fileInfo in files)
                {
                    num += fileInfo.Length / 1024 + 1;
                }

                if (!AndSubdirectorys)
                {
                    return num;
                }

                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                foreach (DirectoryInfo directoryInfo2 in directories)
                {
                    num += GetDirSize(directoryInfo2.FullName, AndSubdirectorys: true);
                }

                return num;
            }
            catch
            {
                throw;
            }
        }

        public static string DirectoryName(string DirPath)
        {
            return Path.GetFileName(DirPath.Trim('\\', ' '));
        }

        public static string GetParentDirectoryPath(string DirPath, string LockInBasePath)
        {
            if (string.IsNullOrEmpty(LockInBasePath))
            {
                return DirPath;
            }

            string text = DirPath.TrimEnd('\\', ' ');
            text = text.Substring(0, text.LastIndexOf("\\") + 1);
            if (!text.StartsWith(LockInBasePath, StringComparison.CurrentCultureIgnoreCase))
            {
                text = DirPath;
            }

            return text;
        }
    }
}
