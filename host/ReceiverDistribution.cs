namespace SofaTap;

/// <summary>Mac-only receiver distribution capabilities.</summary>
internal static class ReceiverDistribution
{
    internal static bool IsMacAppStore => false;

    // Disabled to prevent iPhone from locking into fragile AX live editing sessions.
    // This allows iPhone to use standard review-and-send mode for 100% reliable text & voice input.
    internal static bool SupportsTextInspection => false;

    internal static string DataDirectory(string? requested) => requested ?? Credentials.DefaultDirectory;

    internal static ITextFocusProbe? CreateTextFocus(bool dryRun) => null;

    internal static Func<ILiveTextEditor>? CreateTextEditorFactory(bool dryRun) => null;
}
