

namespace Dock.Model
{
    /// <summary>
    /// Host adapter contract for th <see cref="IDockWindow"/>
    /// </summary>
    public interface IHostAdapter
    {
        /// <summary>
        /// Implememtion of the <see cref="IDockWindow.Save()"/>Method
        /// </summary>
        void Save();

        /// <summary>
        /// Implememtion of the <see cref="IDockWindow.Present(bool)"/>Method
        /// </summary>
        void Present(bool isDialog);

        /// <summary>
        /// Implememtion of the <see cref="IDockWindow.Exit()"/>Method
        /// </summary>
        void Exit();
    }
}
