using GUI_20212202_E4GBAX.Models;
using System.Windows;

namespace GUI_20212202_E4GBAX.Logic
{
    public interface ITowerLogic
    {
        Tower Tower12Maker(Point p, int x, int y);
        Tower Tower1Maker(Point p, int x, int y);
        Tower Tower2Maker(Point p, int x, int y);
    }
}