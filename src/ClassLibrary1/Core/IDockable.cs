

namespace Dock.Model
{
    /// <summary>
    ///  Dockable contract
    /// </summary>
    public interface IDockable
    {
        /// <summary>
        /// Gets or Sets dockerable id.
        /// </summary>
        string Id { get; set; }

        ///<summary>
        /// Gets or Sets dockerable title.
        ///</summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or Sets dockerable context.
        /// </summary>
        object? Context { get; set; }

        /// <summary>
        /// Gets or Sets dockerable owner.
        /// </summary>
        IDockable? Owner { get; set; }

        /// <summary>
        /// Gets or Sets dockerable factory.
        /// </summary>
        IFactory? Factory { get; set; }

        /// <summary>
        /// Called when the dockable isclosed
        /// </summary>
        /// <returns></returns>true to acceptthe close, false to cansel the close.
        bool Onclose();

        /// <summary>
        /// Called when the dockable becomes the selected dockable.
        /// </summary>
        void OnSelected();

        /// <summary>
        /// Clones <see cref="IDockable"/> object
        /// </summary>
        /// <returns></returns> The new instance or reference of the <see cref="IDockable"/> class.
        IDockable? Clone();

    }
}
