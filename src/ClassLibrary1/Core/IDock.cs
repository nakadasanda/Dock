using System.Collections.Generic;

namespace Dock.Model
{
    /// <summary>
    /// Dock contract
    /// </summary>
    public interface IDock : IDockable
    {
        /// <summary>
        /// Gets or sets visible dockables
        /// </summary>
        IList<IDockable>? VisibleDockables { get; set; }
        
        /// <summary>
        ///Gets or Sets hidden dockables. 
        /// </summary>
        IList<IDockable>? HIddenDockables { get; set; }
        
        /// <summary>
        ///Gets or Sets Pinn dockables. 
        /// </summary>
        IList<IDockable>? PinnedDockerables { get; set; }

        /// <summary>
        /// Gets or sets active dockable.
        /// </summary>
        IDockable? ActiveDockable { get; set; }
        
        /// <summary>
        /// Get or sets default dockable 
        /// </summary>
        IDockable? DefaultDockable { get; set; }

        /// <summary>
        ///Gets or Sets focased dockables. 
        /// </summary>
        IDockable? FocausedDockable { get; set; }

        /// <summary>
        /// Get or Sets splitter proportion
        /// </summary>
        double Proportion { get; set; }

        /// <summary>
        ///Gets or Sets if the dockable is the currently active. 
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        ///Gets or Sets if the Dock collapses when all its children are removed
        /// </summary>
        bool IsCollaapsable { get; set; }

        /// <summary>
        ///Gets Value that indicates whether ther is ata least one entry in back navigation history
        /// </summary>
        bool CanGoback { get; }

        /// <summary>
        ///Gets value that indicates whether ther is ata least one entry in back navigation history 
        /// </summary>
        bool CanGoForward { get; }

        /// <summary>
        /// Navigates to the most recent entry in back navigation history, if there is once
        /// </summary>
        void GoBack();

        /// <summary>
        ///  Navigates to the most recent entry in forward navigation history, if there is once
        /// </summary>
        void Goforward();
        
        /// <summary>
        /// Navigate to content that is contained by an object
        /// </summary>
        /// <param name="root">An object that contains the content to navigate</param>
        void Navigate(object root);

        /// <summary>
        /// Close layout
        /// </summary>
        void Close();
    }
}
