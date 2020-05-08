﻿

using System.Security.Cryptography.X509Certificates;

namespace Dock.Model.Adapter
{
    public class HostAdapter : IHostAdapter
    {
        private readonly IDockWindow _window;
        
        /// <summary>
        ///Initialize new instance of<see cref="HostAdapter"/> 
        /// </summary>
        /// <param name="window">The window instance.</param>
        public HostAdapter(IDockWindow window)
        {
            _window = window;
        }

        ///<inheritdoc/>
        public void Save()
        {
            if (!(_window.Host is null))
            {
                _window.Host.GetPosition(out double x, out double y);
                _window.X = x;
                _window.Y = y;

                _window.Host.GetSize(out double width, out double height);
                _window.Width = width;
                _window.Height = height;
            }

        }
        ///<inheritdoc/>
        public void Present(bool isDialog)
        {
            if(_window.Layout is null)
            {
                return;
            }
            if(_window.Host is null)
            {
                _window.Host = _window.Factory?.GetHostWindow(_window.Id);
                if(!(_window.Host is null))
                {
                    _window.Host.Window = this._window;
                }
            }

            if(!(_window.Host is null))
            {
                _window.Host.Present(isDialog);
                _window.Host.SetPosition(_window.X, _window.Y);
                _window.Host.Setsize(_window.Width, _window.Height);
                _window.Host.SetTopmost(_window.Topmost);
                _window.Host.SetTitle(_window.Title);
                _window.Host.SetLayout(_window.Layout);
                _window.Host.IsTracked = true;
            }
        }

        ///<inheritdoc/>
        public void Exit()
        {
            if(!(_window.Host is null))
            {
                Save();
                _window.Host.IsTracked = false;
                _window.Host.Exit();
                _window.Host = null;
            }
        }
    }
}
