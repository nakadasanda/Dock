using Dock.Model.Controls;

namespace Dock.Model
{
    /// <summary>
    /// Navvigate adapter contract for the <see cref="IDock"/>
    /// </summary>
    public interface INavigationAdapter
    {
        /// <summary>
        /// Sets a value that indicates whether  there is at least one entry in back navigation
        /// </summary>
        bool CanGoBack { get; }

        /// <summary>
        /// Sets a value that indicates whether  there is at least one entry in forward navigation
        /// </summary>
        bool CanGoForward { get; }

        /// <summary>
        /// Navigate to the most recent entry in back navigation history, if there is one
        /// </summary>
        void GoBack();

        /// <summary>
        /// Navigate to the most recent entry in forward navigation history, if there is one
        /// </summary>

        void GoForward();

        /// <summary>
        /// Implementation of th <see cref="IDock.Navigate(object)"/>
        /// </summary>
        /// <param name="root"> An object that content to navigate to </param>
        /// <param name="bSnapshot">The flag indicating to make snapshot </param>
        void Navigate(object root, bool bSnapshot);

        /// <summary>
        /// Implemention of the <see cref="IRootDock.ShowWindows()"/> 
        /// </summary>
        void ShowWindows();

        /// <summary>
        /// Implemention of the <see cref="IRootDock.ExitWindows()"/> 
        /// </summary>
        void ExitWindows();

        /// <summary>
        /// Implemention of the <see cref="IRootDock.CloseWindows()"/> 
        /// </summary>
        void Close();
    }
}
