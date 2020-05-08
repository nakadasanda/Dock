
namespace Dock.Model.Controls
{
    /// <summary>
    /// Pin dock contract
    /// </summary>
    public interface IPinDock : IDock
    {
        /// <summary>
        /// Gets or Sets dock alignment.
        /// </summary>
        Alignment Alignment { get; set; }

        /// <summary>
        /// Gets or Sets if the Dock is expanded
        /// </summary>
        bool IsExpanded { get; set; }

        /// <summary>
        /// Gets or sets if the Dock atuto hide
        /// </summary>
        bool AutoHide{get;set;}
    }
}
