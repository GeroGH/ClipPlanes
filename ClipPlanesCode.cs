using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.Model.UI;

namespace ClipPlanes
{
    internal static class ClipPlanesCode
    {
        private static Point MaxPoint = new Point();
        private static Point MinPoint = new Point();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OptionSelectionForm());
        }

        public static void Execute(UserOption option)
        {
            if (option != UserOption.ClearPlanes)
            {
                if (!ExtractPoints(option))
                {
                    Operation.DisplayPrompt("No valid parts selected.");
                    return;
                }
            }

            var visibleViews = ViewHandler.GetVisibleViews();

            while (visibleViews.MoveNext())
            {
                var view = visibleViews.Current;

                switch (option)
                {
                    case UserOption.DirectionX:
                    case UserOption.DirectionY:
                    case UserOption.DirectionZ:
                        CreateClipPlanes(view, option);
                        break;

                    case UserOption.ClearPlanes:
                        DeleteClipPlanes(view);
                        break;
                }
            }

            new Model().CommitChanges();

            Operation.DisplayPrompt("Operation completed.");
        }

        private static bool ExtractPoints(UserOption direction)
        {
            const double offset = 250;

            var points = new List<Point>();
            var selector = new Tekla.Structures.Model.UI.ModelObjectSelector();
            var objects = selector.GetSelectedObjects();

            if (objects.GetSize() == 0)
                return false;

            while (objects.MoveNext())
            {
                if (objects.Current is Part part)
                {
                    var solid = part.GetSolid();
                    points.Add(solid.MaximumPoint);
                    points.Add(solid.MinimumPoint);
                }
            }

            if (points.Count == 0)
                return false;

            switch (direction)
            {
                case UserOption.DirectionX:
                    MaxPoint = points.Aggregate((a, b) => a.X > b.X ? a : b);
                    MinPoint = points.Aggregate((a, b) => a.X < b.X ? a : b);
                    break;

                case UserOption.DirectionY:
                    MaxPoint = points.Aggregate((a, b) => a.Y > b.Y ? a : b);
                    MinPoint = points.Aggregate((a, b) => a.Y < b.Y ? a : b);
                    break;

                case UserOption.DirectionZ:
                    MaxPoint = points.Aggregate((a, b) => a.Z > b.Z ? a : b);
                    MinPoint = points.Aggregate((a, b) => a.Z < b.Z ? a : b);
                    break;
            }

            OffsetPoint(MaxPoint, offset, direction);
            OffsetPoint(MinPoint, -offset, direction);

            return true;
        }

        private static void CreateClipPlanes(Tekla.Structures.Model.UI.View view, UserOption direction)
        {
            Vector vectorUp;
            Vector vectorDown;

            switch (direction)
            {
                case UserOption.DirectionX:
                    vectorUp = new Vector(1, 0, 0);
                    vectorDown = new Vector(-1, 0, 0);
                    break;

                case UserOption.DirectionY:
                    vectorUp = new Vector(0, 1, 0);
                    vectorDown = new Vector(0, -1, 0);
                    break;

                case UserOption.DirectionZ:
                    vectorUp = new Vector(0, 0, 1);
                    vectorDown = new Vector(0, 0, -1);
                    break;

                default:
                    return;
            }

            var upPlane = new ClipPlane
            {
                View = view,
                UpVector = vectorUp,
                Location = MaxPoint
            };
            upPlane.Insert();

            var downPlane = new ClipPlane
            {
                View = view,
                UpVector = vectorDown,
                Location = MinPoint
            };
            downPlane.Insert();
        }

        private static void DeleteClipPlanes(Tekla.Structures.Model.UI.View view)
        {
            var clipPlanes = view.GetClipPlanes();

            foreach (ClipPlane cp in clipPlanes)
            {
                cp.Delete();
            }
        }

        private static void OffsetPoint(Point point, double offset, UserOption direction)
        {
            switch (direction)
            {
                case UserOption.DirectionX:
                    point.X += offset;
                    break;

                case UserOption.DirectionY:
                    point.Y += offset;
                    break;

                case UserOption.DirectionZ:
                    point.Z += offset;
                    break;
            }
        }
    }
}