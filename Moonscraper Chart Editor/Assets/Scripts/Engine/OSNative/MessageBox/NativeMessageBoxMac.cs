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
        NativeMessageBox.Result? messageResult = null;

        switch (messageBoxType)
        {
            case NativeMessageBox.Type.OK:
                messageResult = (NativeMessageBox.Result)ShowOkMessage(text, caption);
                break;

            case NativeMessageBox.Type.YesNo:
                messageResult = (NativeMessageBox.Result)ShowYesNoMessage(text, caption);
                break;

            case NativeMessageBox.Type.YesNoCancel:
                messageResult = (NativeMessageBox.Result)ShowYesNoCancelMessage(text, caption);
                break;

            default:
                break;
        }

        if (messageResult.HasValue)
        {
            UnityEngine.Input.ResetInputAxes(); // Avoid an issue where a key would keep pressed after showing a message box.
            return messageResult.Value;
        }

        UnityEngine.Debug.Assert(false, "Unhandled messagebox type " + messageBoxType);
        throw new NotImplementedException();
    }
}

#endif
