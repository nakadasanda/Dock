

namespace Dock.Model.Controls
{
    /// <summary>
    /// Proportional dock contract
    /// </summary>
    public interface IProportionalDock : IDock
    {
        Orientation Orientation { get; set; }
    }
}
