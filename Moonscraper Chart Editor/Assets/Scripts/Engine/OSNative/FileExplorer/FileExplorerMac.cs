#if UNITY_STANDALONE_OSX
using System.Runtime.InteropServices;

public class FileExplorerMac : IFileExplorer
{
    [DllImport("FileExplorerMac", CharSet = CharSet.Ansi)]
    private static extern string FileExplorerMac_OpenFile(string title, string extensions);

    [DllImport("FileExplorerMac", CharSet = CharSet.Ansi)]
    private static extern string FileExplorerMac_OpenFolder();

    [DllImport("FileExplorerMac", CharSet = CharSet.Ansi)]
    private static extern string FileExplorerMac_SaveFile(string title, string extensions);

    public bool OpenFilePanel(ExtensionFilter filter, string defaultExtension, out string resultPath)
    {
        resultPath = FileExplorerMac_OpenFile(filter.name, string.Join(';', filter.extensions));
        return !string.IsNullOrEmpty(resultPath);
    }

    public bool OpenFolderPanel(out string resultPath)
    {
        resultPath = FileExplorerMac_OpenFolder();
        return !string.IsNullOrEmpty(resultPath);
    }

    public bool SaveFilePanel(ExtensionFilter filter, string defaultFileName, string defaultExtension, out string resultPath)
    {
        resultPath = FileExplorerMac_SaveFile(filter.name, string.Join(';', filter.extensions));
        return !string.IsNullOrEmpty(resultPath);
    }
}
#endif