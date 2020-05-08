using System;
using System.Collections.Generic;
using Dock.Model.Controls;

namespace Dock.Model
{
    /// <summary>
    /// Dock factory contract
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// Gets or Sets <see cref="IDockable,Context"/> locator registory
        /// </summary>
        IDictionary<string,Func<object>>? ContextLocator { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="IHostWindow"/> locator registry
        /// </summary>
        IDictionary<string,Func<IHostWindow>>? HostWindowLocator { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="IDockable"/> locator registry
        /// </summary>
        IDictionary<string,Func<IDockable>>? DockableLocator { get; set; }
        
        /// <summary>
        /// Create list of type <see cref="IList{T}"/>
        /// </summary>
        /// <typeparam name="T">The list item type.</typeparam>
        /// <param name="items">The initial list item</param>
        /// <returns>The new instance of <see cref="IList{T}"/></returns>
        IList<T> CreateList<T>(params T[] items);
        
        /// <summary>
        /// Creates <see cref="IRootDock"/>
        /// </summary>
        /// <returns>The new instance of the <see cref="IRootDock"/></returns>
        IRootDock CreateRootDock();

        /// <summary>
        /// Creates <see cref="IPinDock"/>
        /// </summary>
        /// <returns>The new instance of the <see cref="IPinDock"/></returns>
        IPinDock CreatePinDock();

        /// <summary>
        /// Creates <see cref="IProportionalDock"/>
        /// </summary>
        /// <returns>The new instance of the <see cref="IProportionalDock"/></returns>
        IProportionalDock CreateProportionalDock();

        /// <summary>
        /// Creates <see cref="ISplitterDock"/>
        /// </summary>
        /// <returns>The new instance of the <see cref="ISplitterDock"/></returns>
        ISplitterDock CreateSplitterDock();

        /// <summary>
        /// Creates <see cref="IToolDock"/>
        /// </summary>
        /// <returns>The new instance of the <see cref="IToolDock"/></returns>
        IToolDock CreateToolDock();

        /// <summary>
        /// Creates <see cref="IDocumentDock"/>
        /// </summary>
        /// <returns>The new instance of the <see cref="IDocumentDock"/></returns>
        IDocumentDock CreateDocumentDock();

        /// <summary>
        /// Creates <see cref="IDockWindow"/>
        /// </summary>
        /// <returns>The new instance of the <see cref="IDockWindow"/></returns>
        IDockWindow CreateDockWindow();

        /// <summary>
        /// Creates layout
        /// </summary>
        /// <returns>The new instance of the <see cref="IDock"/></returns>
        IDock CreateLayout();

        /// <summary>
        /// Gets registered host context.
        /// </summary>
        /// <param name="id">The host id</param>
        /// <returns>The locatede context.</returns>
        object? GetContext(string id);

        /// <summary>
        /// Gets registered host window.
        /// </summary>
        /// <param name="id">The host id</param>
        /// <returns>The locatede host.</returns>
        IHostWindow? GetHostWindow(string id);

        /// <summary>
        /// Gets registered host dockable.
        /// </summary>
        /// <param name="id">The host id</param>
        /// <returns>The locatede dockable.</returns>
        IDockable? GetDockable(string id);

        /// <summary>
        /// Initialize layout
        /// </summary>
        /// <param name="layout"> The layout to initialize</param>
        void InitLayout(IDockable layout);

        /// <summary>
        /// Update dock window
        /// </summary>
        /// <param name="window">The window to update.</param>
        /// <param name="owner">The window owner dockable</param>
        void UpdateDockWindow(IDockWindow window, IDockable? owner);
        
        /// <summary>
        /// Update Dockable
        /// </summary>
        /// <param name="dockable">Thw window to update.</param>
        /// <param name="owner">The window owner dockable</param>
        void UpdateDockable(IDockable dockable, IDockable? owner);

        /// <summary>
        /// Add <see cref="IDockable"/> into dock <see cref="IDock.VisibleDockables"/> collection
        /// </summary>
        /// <param name="dock">The owner dock</param>
        /// <param name="dockable"> The dock able to add</param>
        void AddDockable(IDock dock, IDockable dockable);
        
        /// <summary>
        /// Insert <see cref="IDockable"/> into dock <see cref="IDock.VisibleDockables"/> 
        /// </summary>
        /// <param name="dock">The owner dock</param>
        /// <param name="dockable">The dockable to add</param>
        /// <param name="index">The dockable index</param>
        void InsertDockable(IDock dock, IDockable dockable, int index);
        
        /// <summary>
        /// Adds window into dock windows list
        /// </summary>
        /// <param name="rootDock">The root dock</param>
        /// <param name="window"> the window to Add</param>
        void AddWindow(IRootDock rootDock, IDockWindow window);
        
        /// <summary>
        /// Removes window rom owner window list
        /// </summary>
        /// <param name="window">The window to remove</param>
        void RemoveWindow(IDockWindow window);
        
        /// <summary>
        /// Sets anavtive dockable. If the dockable is contained inside an dock it
        /// will become the selected dockable
        /// </summary>
        /// <param name="dockable">The dockable to select</param>
        void SetActiveDockable(IDockable dockable);

        /// <summary>
        /// Sets the currentry focused dockable updating IsActive Flags
        /// </summary>
        /// <param name="dock">THe dock set the focused dockable on</param>
        /// <param name="dockable">The dockable to set</param>
        /// 
        void SetFocusedDockable(IDock dock, IDockable dockable);

        /// <summary>
        /// Searchs for root dockable
        /// </summary>
        /// <param name="dockable">The dockable to find root for</param>
        /// <returns>The root dockable instance or null if root dockable was not found</returns>
        IRootDock? FindRoot(IDockable dockable);
        
        /// <summary>
        /// Searches dock dockable 
        /// </summary>
        /// <param name="dock">The dock</param>
        /// <param name="predicate">The dock able find root for</param>
        /// <returns>The dockable instance or null if dockable was not found</returns>
        IDockable? FindDockable(IDock dock, Func<IDockable, bool> predicate);

        /// <summary>
        /// Pins dockable 
        /// </summary>
        /// <param name="dockable">The document pin</param>
        void PinDockable(IDockable dockable);

        /// <summary>
        /// Removes dockable from owner <see cref="IDock.VisibleDockables"/> collection
        /// </summary>
        /// <param name="dockable">The dockable to remove</param>
        /// <param name="collapse">The flag indicating whether to collapse empty dock</param>
        void RemoveDockable(IDockable dockable, bool collapse);

        /// <summary>
        /// Remove dockable from owner <see cref="IDock.VisibleDockables"/> collection ,and call IDockable.OnClose.
        /// </summary>
        /// <param name="dockable">The dockable remove</param>
        void CloseDockable(IDockable dockable);
        
        /// <summary>
        /// Moves dockable inside <see cref="IDock.VisibleDockables" /> collection
        /// </summary>
        /// <param name="dock"> The dock</param>
        /// <param name="dockable">The source dockable</param>
        /// <param name="targetDockable">The target dockable</param>
        void MoveDockable(IDock dock, IDockable dockable, IDockable targetDockable);
        
        /// <summary>
        /// Moves dockable into anpther <see cref="IDock.VisibleDockables"/> collection
        /// </summary>
        /// <param name="sourceDock">The sorce dock</param>
        /// <param name="targetDock">The target dock</param>
        /// <param name="dockable">The sorce dockable</param>
        /// <param name="targetDockable">The target dockable</param>
        void MoveDockable(IDock sourceDock, IDock targetDock, IDockable dockable, IDockable? targetDockable);
        
        /// <summary>
        /// Swaps dockable in inside<see cref="IDock.VisibleDockables"/> Collection
        /// </summary>
        /// <param name="dock"> The dock</param>
        /// <param name="sourceDockable"> The sorce dockable</param>
        /// <param name="dockable">The target dockable</param>
        void SwapDockable(IDock dock, IDockable sourceDockable, IDockable dockable);
        
        /// <summary>
        /// Swap dockable into between<see cref="IDock.VisibleDockables"/>
        /// </summary>
        /// <param name="sourceDock">The sourcedock.</param>
        /// <param name="targetDock">The target dock</param>
        /// <param name="sourceDockable">The sorce dockable</param>
        /// <param name="targetDockable">The target dockable</param>
        void SwapDockable(IDock sourceDock, IDock targetDock, IDockable sourceDockable, IDockable targetDockable);
       
        /// <summary>
        /// Create a new split layout from sorce docker
        /// </summary>
        /// <param name="dock">The dock to perform operation on</param>
        /// <param name="dockable">The optional dockable to add split</param>
        /// <param name="operation">The dock operation</param>
        /// <returns>The new instance of the <see cref="IDock"/> class</returns>
        IDock CreateSplitLayout(IDock dock, IDockable dockable, DockOperation operation);
        
        /// <summary>
        /// Splits dock and Update owner layout
        /// </summary>
        /// <param name="dock">The dock to perform operation on</param>
        /// <param name="dockable">The optional dockable to add to split side</param>
        /// <param name="operation">The dock operation to perform</param>
        void SplitToDock(IDock dock, IDockable dockable, DockOperation operation);
        
        /// <summary>
        /// Creates dock window from sorce dockable
        /// </summary>
        /// <param name="dockable">Thedockable to embed into window</param>
        /// <returns>The new instance of the <see cref="IDockWindow"/></returns>
        IDockWindow? CreateWindowFrom(IDockable dockable);

        /// <summary>
        /// Splits dock to the <see cref="DockOperation.Window"/> and updates <see cref="IDockable.Owner"/>layout 
        /// </summary>
        /// <param name="dock">The window owner</param>
        /// <param name="dockable">The dockable to add splitted window</param>
        /// <param name="x">The window X cordinate</param>
        /// <param name="y">The window Y cordinate</param>
        /// <param name="width">The window width</param>
        /// <param name="height">The window height</param>
        void SplitToWindow(IDock dock, IDockable dockable, double x, double y, double width, double height);


    }
}
