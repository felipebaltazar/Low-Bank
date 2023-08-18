using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowBank_Windows
{
    public class CustomPanel : Panel
    {
        public bool ArredondaCantosInferiores
        {
            get; set;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            int cornerRadius = 40;

            Rectangle Rect = new Rectangle(0, 0, Width, Height);
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, cornerRadius, cornerRadius, 180, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - cornerRadius, Rect.Y, cornerRadius, cornerRadius, 270, 90);

            if (ArredondaCantosInferiores == false)
            {
                cornerRadius = 1;
            }

            GraphPath.AddArc(Rect.X + Rect.Width - cornerRadius, Rect.Y + Rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);

            Region = new Region(GraphPath);
        }
    }
}
