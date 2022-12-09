using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void Test()
    {
        var input = System.IO.File.ReadAllLines("input.txt");
        foreach (var line in input)
        {
            OS.ParseLine(line);
        }
        
        Assert.Equal(12545514, OS.Size());
    }                


    public static class OS
    {
        private static readonly Directory _root = new () { Name = "/", ParentDirectory = null };
        private static Directory? _currentDirectory;
        private static long TotalUsedSpace => _root.Size;
        private static long AvailableFreeSpace => 70000000 - TotalUsedSpace;
        private static long SpaceRequiredToFree => 30000000 - AvailableFreeSpace;
        public static void ParseLine(string input)
        {
            if (input[0] == '$')
                ParseCommand(input);
            else if (input[..3] == "dir")
                AddDirectory(input);
            else
                AddFile(input);
        }
        private static void AddFile(string input)
        {
            _currentDirectory!.Files.Add(new File(input.Split(" ")[1], int.Parse(input.Split(" ")[0])));
        }
        private static void AddDirectory(string input)
        {
            _currentDirectory!.Directories.Add(new Directory
            {
                Name = input.Split(" ")[1], ParentDirectory = _currentDirectory,
            });
        }
        private static void ParseCommand(string input)
        {
            var cmd = input.Split(" ")[1];
            if (cmd != "cd")
                return;

            var dirName = input.Split(" ")[2];
            if (dirName == "..")
                _currentDirectory = _currentDirectory?.ParentDirectory;
            else
            {
                _currentDirectory = dirName == _root.Name ? _root : _currentDirectory?.Directories.First(x => x.Name == dirName);
            }
        }

        public record File(string Name, int Size);
        
        public record Directory
        {
            public required string Name { get; set; }
            [JsonIgnore]
            public Directory? ParentDirectory { get; set; }
            public List<Directory> Directories { get; set; } = new();
            [JsonIgnore]
            public List<File> Files { get; set; } = new();
            public int Size => Files.Sum(f => f.Size) + Directories.Sum(d => d.Size);
        }

        private static IEnumerable<Directory> GetDirectoriesToDelete(List<Directory>? directories = null)
        {
            directories ??= _root!.Directories;
            var dirs = new List<Directory>();
            foreach (var directory in directories.Where(directory => directory.Size > SpaceRequiredToFree))
            {
                dirs.Add(directory);
                if (directory.Directories.Count > 0) 
                    dirs.AddRange(GetDirectoriesToDelete(directory.Directories));
            }

            return dirs;
        }

        public static int Size()
        {
            var dirs = GetDirectoriesToDelete();
            return dirs.Min(d => d.Size);
        }
    }
    
    
}
