using FilesFinder.Lib;

namespace FilesFinder.Tests
{
    public class FilesfinderTests
    {
        [Fact]
        public void Is_File_Exists() {
            TextFinder textFinder = new TextFinder("fileText.txt");
            Assert.True(textFinder.Lines.Count > 0);
        }
    }
}
