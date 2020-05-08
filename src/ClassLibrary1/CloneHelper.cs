using System;
using System.Security.Cryptography.X509Certificates;
using Dock.Model.Controls;

namespace Dock.Model
{
    /// <summary>
    /// Clone helper
    /// </summary>
    public static class CloneHelper
    {
        /// <summary>
        /// Clone dock properties
        /// </summary>
        /// <param name="source">The source dock</param>
        /// <param name="target">The target dock</param>
        public static void CloneDockProperties(IDock source,IDock target)
        {
            target.Id = source.Id;
            target.Title = source.Title;
            target.Proportion = source.Proportion;
            target.IsActive = source.IsActive;
            target.IsCollaapsable = source.IsCollaapsable;

            if(!(source.VisibleDockables is null))
            {
                target.VisibleDockables = source.Factory?.CreateList<IDockable>();
                if(!(target.VisibleDockables is null))
                {
                    foreach(var visible in source.VisibleDockables)
                    {
                        var clone = visible.Clone();
                        if(!(clone is null))
                        {
                            target.VisibleDockables.Add(clone);
                        }
                    }
                }
            }

            if(!(source.HIddenDockables is null))
            {
                target.HIddenDockables = source.Factory?.CreateList<IDockable>();
                if(!(target.HIddenDockables is null))
                {
                    foreach(var hidden in source.HIddenDockables)
                    {
                        var clone = hidden.Clone();
                        if(!(clone is null))
                        {
                            target.HIddenDockables.Add(clone);
                        }
                    }
                }
            }
            if(!(source.PinnedDockerables is null))
            {
                target.PinnedDockerables = source.Factory?.CreateList<IDockable>();
                if(!(target.PinnedDockerables is null))
                {
                    foreach(var pinned in source.PinnedDockerables)
                    {
                        var clone = pinned.Clone();
                        if(!(clone is null))
                        {
                            target.PinnedDockerables.Add(clone);
                        }
                    }
                }
            }

            if (!(source.ActiveDockable is null) && !(source.VisibleDockables is null))
            {
                int indexActivedockable = source.VisibleDockables.IndexOf(source.ActiveDockable);
                if(indexActivedockable >= 0)
                {
                    target.ActiveDockable = target.VisibleDockables?[indexActivedockable];
                }
            }

            if(!(source.DefaultDockable is null) && !(source.VisibleDockables is null))
            {
                int indexDefaultDockable = source.VisibleDockables.IndexOf(source.DefaultDockable);
                if(indexDefaultDockable >= 0)
                {
                    target.DefaultDockable = target.VisibleDockables?[indexDefaultDockable];
                }
            }

            if(!(source.FocausedDockable is null) && !(source.VisibleDockables is null))
            {
                int indexFocusedDockable = source.VisibleDockables.IndexOf(source.FocausedDockable);
                if(indexFocusedDockable >= 0)
                {
                    target.FocausedDockable = target.VisibleDockables?[indexFocusedDockable];
                }
            }
        }

        /// <summary>
        /// Clone root Dock properties
        /// </summary>
        /// <param name="source">The source root dock</param>
        /// <param name="target">The target root dock</param>
        public static void CloneRootDockProperties(IRootDock source, IRootDock target)
        {
            target.Window = null;

            if(!(source.Top is null))
            {
                target.Top = (IPinDock?)source.Top.Clone();
            }

            if(!(source.Bottom is null))
            {
                target.Bottom = (IPinDock?)source.Bottom.Clone();
            }

            if (!(source.Right is null))
            {
                target.Right = (IPinDock?)source.Right.Clone();
            }

            if (!(source.Left is null))
            {
                target.Left = (IPinDock?)source.Left.Clone();
            }


            if(!(source.Windows is null))
            {
                target.Windows = source.Factory?.CreateList<IDockWindow>();
                if(!(target.Windows is null))
                {
                    foreach(var window in source.Windows)
                    {
                        var clone = window.Clone();
                        if(!(clone is null))
                        {
                            target.Windows.Add(clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Clone pin dock properties.
        /// </summary>
        /// <param name="source">The source pin dock</param>
        /// <param name="target">The target pin dock</param>
        public static void ClonePinDockProperties(IPinDock source,IPinDock target)
        {
            target.Alignment = source.Alignment;
            target.IsExpanded = source.IsExpanded;
            target.AutoHide = source.AutoHide;
        }

        /// <summary>
        ///  Clone proportional dock properties.
        /// </summary>
        /// <param name="source">The source proportional Dock</param>
        /// <param name="target">The target proportional Dock</param>
        public static void CloneProportionalDockProperties(IProportionalDock source, IProportionalDock target)
        {
            target.Orientation = source.Orientation;
        }

        /// <summary>
        /// Clone dock window properties
        /// </summary>
        /// <param name="source">The source dock window.</param>
        /// <param name="target">The target dock window.</param>
        public static void CloneDockWindowProperties(IDockWindow source, IDockWindow target)
        {
            target.Id = source.Id;
            target.X = source.X;
            target.Y = source.Y;
            target.Width = source.Width;
            target.Height = source.Height;
            target.Topmost = source.Topmost;
            target.Title = source.Title;

            if(!(source.Layout is null))
            {
                target.Layout = (IRootDock?)source.Layout.Clone();
            }

            if(!(target.Layout is null))
            {
                target.Layout.Window = target;
            }
        }

        /// <summary>
        /// Clone <see cref="IRootDock"/>
        /// </summary>
        /// <param name="source">The source object</param>
        /// <returns>The new instance or reference <see cref="IRootDock"/> calss</returns>
        public static IRootDock? CloneRootDock(IRootDock source)
        {
            var target = source.Factory?.CreateRootDock();
            
            if(!(target is null))
            {
                CloneDockProperties(source, target);
                CloneRootDockProperties(source, target);
            }

            return target;
        }

        /// <summary>
        /// Clone <see cref="IPinDock"/> object.
        /// </summary>
        /// <param name="source">The source object</param>
        /// <returns>The new instance or reference <see cref="IPinDock"/> calss</returns>
        public static IPinDock? ClonePinDock(IPinDock source)
        {
            var target = source.Factory?.CreatePinDock();

            if(!(target is null))
            {
                CloneDockProperties(source, target);
                ClonePinDockProperties(source, target);
            }

            return target;
        }

        /// <summary>
        /// Clone <see cref="IProportionalDock"/> object.
        /// </summary>
        /// <param name="source">The source object</param>
        /// <returns>The new instance or reference <see cref="IProportionalDock"/> calss</returns>
        public static IProportionalDock? CloneProportionalDock(IProportionalDock source)
        {
            var target = source.Factory?.CreateProportionalDock();

            if(!(target is null))
            {
                CloneDockProperties(source, target);
                CloneProportionalDockProperties(source, target);
            }

            return target;
        }

        /// <summary>
        /// Clone <see cref="ISplitterDock"/> object.
        /// </summary>
        /// <param name="source">The source object</param>
        /// <returns>The new instance or reference <see cref="ISplitterDock"/> calss<</returns>
        public static ISplitterDock? CloneSplitterDock(ISplitterDock source)
        {
            var target = source.Factory?.CreateSplitterDock();
            
            if(!(target is null))
            {
                CloneDockProperties(source, target);
            }
            return target;
        }

        /// <summary>
        /// Clone <see cref="IToolDock"/> object.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>The new instance or reference <see cref="IToolDock"/> calss</returns>
        public static IToolDock? CloenToolDocck(IToolDock source)
        {
            var target = source.Factory?.CreateToolDock();

            if(!(target is null))
            {
                CloneDockProperties(source, target);
            }

            return target;
        }

        /// <summary>
        /// Clone <see cref="IDocumentDock"/> object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>The new instance or reference </returns>
        public static IDocumentDock? ClooneDocumentDock(IDocumentDock source)
        {
            var target = source.Factory?.CreateDocumentDock();
            
            if(!(target is null))
            {
                CloneDockProperties(source, target);
            }

            return target;
        }

        /// <summary>
        /// Clone <see cref="IDockWindow"/> object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>The new instance or reference</returns>
        public static IDockWindow? CloneDockWindow(IDockWindow source)
        {
            source.Save();

            var target = source.Factory?.CreateDockWindow();
            if(!(target is null))
            {
                CloneDockWindowProperties(source, target);
            }
            return target;
        }
        
    }
}
