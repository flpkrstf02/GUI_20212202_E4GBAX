using GUI_20212202_E4GBAX.Logic;
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
        IGameModel model;
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
                double rectWidth = size.Width / model.GameMatrix.GetLength(1);
                drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.Black, 0),
                    new Rect(0, 0, size.Width, size.Height));
                for (int i = 0; i < model.GameMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < model.GameMatrix.GetLength(1); j++)
                    {
                        ImageBrush brush = new ImageBrush();
                        switch(model.GameMatrix[i, j])
                        {
                            
                        }
                        
                    }
                }
                
            }
        }
    }
}
