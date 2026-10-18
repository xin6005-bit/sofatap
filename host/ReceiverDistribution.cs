namespace SofaTap;

/// <summary>Mac-only receiver distribution capabilities.</summary>
internal static class ReceiverDistribution
{
    internal static bool IsMacAppStore => false;

    // Enable text inspection so iPhone knows when a Mac input field is focused (auto-opening keyboard/voice input).
    // LiveTextEditor remains null to prevent fragile AX live sync desyncs, ensuring 100% reliable review-and-send mode.
    internal static bool SupportsTextInspection => true;

    internal static string DataDirectory(string? requested) => requested ?? Credentials.DefaultDirectory;

    internal static ITextFocusProbe? CreateTextFocus(bool dryRun) => dryRun ? null : TextFocusProbe.Create();

    internal static Func<ILiveTextEditor>? CreateTextEditorFactory(bool dryRun) => null;
}
