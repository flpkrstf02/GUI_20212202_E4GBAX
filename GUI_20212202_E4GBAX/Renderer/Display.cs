using GUI_20212202_E4GBAX.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        public void SetupModel(IGameModel model)
        {
            this.model = model;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (size.Width > 50 && size.Height > 50)
            {
                double rectWidth = size.Width / model.GameMatrix.GetLength(1);
                double rectHeight = size.Height / model.GameMatrix.GetLength(0);
                drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.Black, 0),new Rect(0, 0, size.Width, size.Height));
                for (int i = 0; i < model.GameMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < model.GameMatrix.GetLength(1); j++)
                    {
                        ImageBrush brush = new ImageBrush();
                        ImageBrush towerbrush = new ImageBrush();
                        switch (model.GameMatrix[i, j])
                        {
                            case TowerDefenseLogic.TowerItem.wall:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bg_ground_4.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case TowerDefenseLogic.TowerItem.position:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bg_ground_0.png"), UriKind.RelativeOrAbsolute)));
                                towerbrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "tower1.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case TowerDefenseLogic.TowerItem.path:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bg_ground_2.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case TowerDefenseLogic.TowerItem.available:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bg_ground_0.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case TowerDefenseLogic.TowerItem.start:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bg_ground_2.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            default:
                                break;
                        }
                        drawingContext.DrawRectangle(brush, new Pen(Brushes.Black, 0), new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight));
                        if (towerbrush != null)
                        {
                            drawingContext.DrawRectangle(towerbrush, new Pen(Brushes.Black, 0), new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight));
                        }
                    }
                }
                foreach (var item in model.Enemies)
                {
                    ImageBrush brush = new ImageBrush();
                    brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Run2.png"), UriKind.RelativeOrAbsolute)));
                    drawingContext.DrawEllipse(brush, null, new Point(item.Center.X, item.Center.Y), 40, 40);
                }

            }
        }
    }
}
