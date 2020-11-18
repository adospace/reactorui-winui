using Microsoft.UI.Xaml.Controls;

namespace ReactorWinUI
{
    public interface INavigation
    {
        //
        // Summary:
        //     Navigates to the most recent item in back navigation history, if a Frame manages
        //     its own navigation history.
        void GoBack();
        //
        // Summary:
        //     Navigates to the most recent item in forward navigation history, if a Frame manages
        //     its own navigation history.
        void GoForward();
        //
        // Summary:
        //     Gets a value that indicates whether there is at least one entry in back navigation
        //     history.
        //
        // Returns:
        //     **true** if there is at least one entry in back navigation history; **false**
        //     if there are no entries in back navigation history or the Frame does not own
        //     its own navigation history.
        bool CanGoBack { get; }
        //
        // Summary:
        //     Gets a value that indicates whether there is at least one entry in forward navigation
        //     history.
        //
        // Returns:
        //     **true** if there is at least one entry in forward navigation history; **false**
        //     if there are no entries in forward navigation history or the Frame does not own
        //     its own navigation history.
        bool CanGoForward { get; }
        //
        // Summary:
        //     Gets the number of entries in the navigation back stack.
        //
        // Returns:
        //     The number of entries in the navigation back stack.
        int BackStackDepth { get; }
    }
}