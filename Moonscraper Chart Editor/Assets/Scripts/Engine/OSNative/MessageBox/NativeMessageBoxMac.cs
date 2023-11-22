#if UNITY_STANDALONE_OSX

using System;
using System.Runtime.InteropServices;

public class NativeMessageBoxMac : INativeMessageBox
{
    [DllImport("NativeMessageBoxMac", CharSet = CharSet.Ansi)]
    private static extern int ShowOkMessage(string text, string caption);

    [DllImport("NativeMessageBoxMac", CharSet = CharSet.Ansi)]
    private static extern int ShowYesNoMessage(string text, string caption);

    [DllImport("NativeMessageBoxMac", CharSet = CharSet.Ansi)]
    private static extern int ShowYesNoCancelMessage(string text, string caption);

    public NativeMessageBox.Result Show(string text, string caption, NativeMessageBox.Type messageBoxType, NativeWindow childWindow)
    {
        switch (messageBoxType)
        {
            case NativeMessageBox.Type.OK:
                return (NativeMessageBox.Result)ShowOkMessage(text, caption);

            case NativeMessageBox.Type.YesNo:
                return (NativeMessageBox.Result)ShowYesNoMessage(text, caption);

            case NativeMessageBox.Type.YesNoCancel:
                return (NativeMessageBox.Result)ShowYesNoCancelMessage(text, caption);

            default:
                break;
        }

        UnityEngine.Debug.Assert(false, "Unhandled messagebox type " + messageBoxType);
        throw new NotImplementedException();
    }
}

#endif
