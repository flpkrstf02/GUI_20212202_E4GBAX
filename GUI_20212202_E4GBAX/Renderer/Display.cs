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
        int enemyCounter;
        public void Resize(Size size)
        {
            this.size = size;
        }
        public void SetupModel(IGameModel model)
        {
            this.model = model;
            enemyCounter = 1;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (size.Width > 50 && size.Height > 50)
            {
                double rectWidth = size.Width / model.GameMatrix.GetLength(1);
                double rectHeight = size.Height / model.GameMatrix.GetLength(0);
                drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.Black, 0), new Rect(0, 0, size.Width, size.Height));
                for (int i = 0; i < model.GameMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < model.GameMatrix.GetLength(1); j++)
                    {
                        ImageBrush brush = new ImageBrush();

                        switch (model.GameMatrix[i, j])
                        {
                            case TowerDefenseLogic.TowerItem.wall:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", "bg_ground_4.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case TowerDefenseLogic.TowerItem.lvl1tower:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", "bg_ground_0.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case TowerDefenseLogic.TowerItem.lvl2tower:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", "bg_ground_0.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case TowerDefenseLogic.TowerItem.lvl3tower:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", "bg_ground_0.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case TowerDefenseLogic.TowerItem.path:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", "bg_ground_2.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case TowerDefenseLogic.TowerItem.available:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", "bg_ground_0.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case TowerDefenseLogic.TowerItem.start:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", "bg_ground_2.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case TowerDefenseLogic.TowerItem.goal:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", "bg_ground_2.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case TowerDefenseLogic.TowerItem.crossroad:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", "bg_ground_2.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            default:
                                break;
                        }
                        drawingContext.DrawRectangle(brush, new Pen(Brushes.Black, 0), new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight));

                    }
                }
                foreach (var item in model.Towers)
                {
                    ImageBrush towerbrush = new ImageBrush();
                    if (item.cost == 40)
                    {
                        towerbrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", "tower1.png"), UriKind.RelativeOrAbsolute)));
                    }
                    else if (item.cost == 100)
                    {
                        towerbrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", "tower2.png"), UriKind.RelativeOrAbsolute)));
                    }
                    else if (item.cost == 200)
                    {
                        towerbrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", "tower3.png"), UriKind.RelativeOrAbsolute)));
                    }
                    if (towerbrush != null)
                    {
                        drawingContext.DrawRectangle(towerbrush, new Pen(Brushes.Black, 0), new Rect(item.centerIdxY * rectWidth, item.centerIdxX * rectHeight, rectWidth, rectHeight));
                    }
                }

                foreach (var item in model.Enemies)
                {
                    ImageBrush brush = new ImageBrush();
                    if (enemyCounter>=12)
                    {
                        enemyCounter = 1;
                    }
                    else
                    {
                        enemyCounter++;
                    }
                    brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Assets", $"Run{enemyCounter}.png"), UriKind.RelativeOrAbsolute)));
                    drawingContext.DrawLine(new Pen(Brushes.White, 2), new Point(item.Center.X - 20, item.Center.Y - 30), new Point(item.Center.X + 20, item.Center.Y - 30));
                    if (item.Damage == 10)
                    {
                        //hp 10
                        drawingContext.DrawLine(new Pen(Brushes.Green, 2), new Point(item.Center.X - 20, item.Center.Y - 30), new Point(item.Center.X - 20 + (item.Health * 4), item.Center.Y - 30));
                    }
                    else if (item.Damage == 25)
                    {
                        //hp 25
                        drawingContext.DrawLine(new Pen(Brushes.Green, 2), new Point(item.Center.X - 20, item.Center.Y - 30), new Point(item.Center.X - 20 + (item.Health * 1.6), item.Center.Y - 30));
                    }
                    else if (item.Damage == 50)
                    {
                        //hp 100
                        drawingContext.DrawLine(new Pen(Brushes.Green, 2), new Point(item.Center.X - 20, item.Center.Y - 30), new Point(item.Center.X - 20 + (item.Health * 0.4), item.Center.Y - 30));
                    }

                    drawingContext.DrawEllipse(brush, null, new Point(item.Center.X, item.Center.Y), 40, 40);
                }

            }
        }
    }
}
