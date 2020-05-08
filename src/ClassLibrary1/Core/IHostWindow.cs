
namespace Dock.Model
{
    /// <summary>
    /// Host Windows contract
    /// </summary>
    public interface IHostWindow
    {
        /// <summary>
        /// Gets or Sets value that indicates whether host size and position is tracked 
        /// </summary>
        bool IsTracked { get; set; }

        /// <summary>
        /// Gets or set dock window
        /// </summary>
        IDockWindow? Window { get; set; }

        /// <summary>
        /// presents host
        /// </summary>
        /// <param name="isDialog">The Value that indicates whther window is dialog</param>
        void Present(bool isDialog);
        
        /// <summary>
        ///  Exit host
        /// </summary>
        void Exit();

        /// <summary>
        /// sets host position
        /// </summary>
        /// <param name="x">The X cordinate of host</param>
        /// <param name="y">The Y cordinate of host</param>
        void SetPosition(double x, double y);

        /// <summary>
        /// Gets host position
        /// </summary>
        /// <param name="x">The X cordinate of host</param>
        /// <param name="y">The Y cordinate of host</param>
        void GetPosition(out double x, out double y);

        /// <summary>
        /// sets host Size
        /// </summary>
        /// <param name="width">The width host</param>
        /// <param name="height">The height host</param>
        void Setsize(double width, double height);

        /// <summary>
        /// sets host Size
        /// </summary>
        /// <param name="width">The width host</param>
        /// <param name="height">The height host</param>
        void GetSize(out double width,out double height);

        /// <summary>
        /// Sets host topmpst 
        /// </summary>
        /// <param name="topmost">The host topmost</param>
        void SetTopmost(bool topmost);
        
        /// <summary>
        /// The host title 
        /// </summary>
        /// <param name="title"></param>
        void SetTitle(string title);

        /// <summary>
        /// Set host layout
        /// </summary>
        /// <param name="layout"></param>
        void SetLayout(IDock layout);
    }
}
