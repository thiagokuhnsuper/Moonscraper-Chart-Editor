#if UNITY_STANDALONE_OSX

public class NativeWindow_MacOS : INativeWindow
{
    public bool IsConnectedToWindow()
    {
        return true;
    }

    public bool SetApplicationWindowPointerByName(string desiredWindowName)
    {
        return true;
    }

    public void SetWindowTitle(string title)
    {
        // Not supported
    }
}

#endif
