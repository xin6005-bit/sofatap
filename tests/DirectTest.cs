using System;
using System.Linq;
using System.Runtime.InteropServices;
using SofaTap;

namespace TestApp;

class Program
{
    private const string CG = "/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics";
    private const string CF = "/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation";

    [DllImport(CG)] static extern IntPtr CGEventSourceCreate(int stateID);
    [DllImport(CG)] static extern IntPtr CGEventCreateKeyboardEvent(IntPtr source, ushort key, [MarshalAs(UnmanagedType.I1)] bool down);
    [DllImport(CG)] static extern void CGEventKeyboardSetUnicodeString(IntPtr item, nuint length, [In] ushort[] text);
    [DllImport(CG)] static extern void CGEventPost(uint tap, IntPtr item);
    [DllImport(CF)] static extern void CFRelease(IntPtr item);

    static void PostUnicode(string text)
    {
        var source = CGEventSourceCreate(-1);
        ushort[] chars = text.Select(c => (ushort)c).ToArray();

        var evDown = CGEventCreateKeyboardEvent(source, 0, true);
        CGEventKeyboardSetUnicodeString(evDown, (nuint)chars.Length, chars);
        CGEventPost(0, evDown);
        CGEventPost(1, evDown);
        CFRelease(evDown);

        var evUp = CGEventCreateKeyboardEvent(source, 0, false);
        CGEventKeyboardSetUnicodeString(evUp, (nuint)chars.Length, chars);
        CGEventPost(0, evUp);
        CGEventPost(1, evUp);
        CFRelease(evUp);

        CFRelease(source);
    }

    static void Main()
    {
        Console.WriteLine("Posting unicode text 'Hello' in 2 seconds...");
        System.Threading.Thread.Sleep(2000);
        PostUnicode("Hello");
        Console.WriteLine("Done posting!");
    }
}
