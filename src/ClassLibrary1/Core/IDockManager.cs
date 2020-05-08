using Dock.Model.Controls;
using System.Text;

namespace Dock.Model
{
    /// <summary>
    /// Docking manager contract
    /// </summary>
    public interface IDockManager
    {
        /// <summary>
        /// Get or set pointer position relative to event source
        /// </summary>
        DockPoint Position { get; set; }

        /// <summary>
        /// Get or set pointer position relative to event source and translated to screen coordinates.
        /// </summary>
        DockPoint ScreenPosition { get; set; }

        /// <summary>
        /// Validates tool docking operation
        /// </summary>
        /// <param name="sourceTool">The source tool</param>
        /// <param name="targetDockable">The target dockable.</param>
        /// <param name="action">The drag action</param>
        /// <param name="operation">The dock operation</param>
        /// <param name="bExecute">The flag indicating whether to execite</param>
        /// <returns>True if docking operation can be executed otherwise false.</returns>
        bool ValidateTool(ITool sourceTool, IDockable targetDockable, DragAction action, DockOperation operation, bool bExecute);

        /// <summary>
        ///  Validates document docking operation
        /// </summary>
        /// <param name="sourceDocument">The source document</param>
        /// <param name="targetDockable">The target document</param>
        /// <param name="action">The drag action</param>
        /// <param name="operation">The dock operation</param>
        /// <param name="bExecute">The flag indicating whether to execite</param>
        /// <returns>rue if docking operation can be executed otherwise false</returns>
        bool ValidateDocument(IDocument sourceDocument, IDockable targetDockable, DragAction action, DockOperation operation, bool bExecute);

        /// <summary>
        ///  Validates Dock docking operation
        /// </summary>
        /// <param name="sourceDocument">The source dock</param>
        /// <param name="targetDockable">The target dock</param>
        /// <param name="action">The drag action</param>
        /// <param name="operation">The dock operation</param>
        /// <param name="bExecute">The flag indicating whether to execite</param>
        /// <returns>rue if docking operation can be executed otherwise false</returns>
        bool ValidateDock(IDock sourceDock, IDockable targetDock, DragAction action, DockOperation operation, bool bExecute);

        /// <summary>
        ///  Validates Dockable docking operation
        /// </summary>
        /// <param name="sourceDocument">The source dockable</param>
        /// <param name="targetDockable">The target dockable</param>
        /// <param name="action">The drag action</param>
        /// <param name="operation">The dock operation</param>
        /// <param name="bExecute">The flag indicating whether to execite</param>
        /// <returns>rue if docking operation can be executed otherwise false</returns>
        bool ValidateDockable(IDockable sourceDockable, IDockable targetDockable, DragAction action, DockOperation operation, bool bExecute);
    }
}
