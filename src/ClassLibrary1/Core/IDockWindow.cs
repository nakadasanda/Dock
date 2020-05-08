using Dock.Model.Controls;

namespace Dock.Model
{
    public interface IDockWindow
    {
        /// <summary>
        /// Gets or Sets dockerable owner.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or Sets window X coordinate.
        /// </summary>
        double X { get; set; }

        /// <summary>
        /// Gets or Sets window Y coordinate.
        /// </summary>
        double Y { get; set; }

        /// <summary>
        /// Gets or Sets window width.
        /// </summary>
        double Width { get; set; }

        /// <summary>
        /// Gets or Sets window Height.
        /// </summary>
        double Height { get; set; }

        /// <summary>
        /// Gets or Sets whether htis window appears on top of all other windows.
        /// </summary>
        bool Topmost { get; set; }

        /// <summary>
        ///  Gets or Sets window Title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or Sets window owner dockable.
        /// </summary>
        IDockable? Owner { get; set; }

        /// <summary>
        /// Gets or Sets dock factory.
        /// </summary>
        IFactory? Factory { get; set; }

        /// <summary>
        /// Gets or Sets layout.
        /// </summary>
        IRootDock? Layout { get; set; }

        /// <summary>
        /// Gets or Sets dock window.
        /// </summary>
        IHostWindow? Host { get; set; }

        /// <summary>
        /// Saves Windows propaties
        /// </summary>
        void Save();

        /// <summary>
        /// Present window
        /// </summary>
        /// <param name="isDialog">The value that indicates whether window is dialog.</param>
        void Present(bool isDialog);

        /// <summary>
        /// window Exit
        /// </summary>
        void Exit();

        /// <summary>
        /// Clones <see cref="cref="IDocWindow"/> object.
        /// </summary>
        /// <returns></returns>
        IDockWindow? Clone();
    }
}
