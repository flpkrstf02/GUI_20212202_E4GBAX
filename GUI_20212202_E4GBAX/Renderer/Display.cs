using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_E4GBAX.Renderer
{
    public class Display : FrameworkElement
    {
        Size size;
        public void Resize(Size size)
        {
            this.size = size;
        }
        public void SetupLogic()
        {

        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (size.Width > 50 && size.Height > 50)
            {

            }
        }
    }
}
