using System.Collections.Generic;
using System.Linq;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace ClipPlanes
{
    internal static class ClipPlanesCode
    {
        static void Main()
        {
            var mve = ViewHandler.GetVisibleViews();
            while (mve.MoveNext())
            {
                var currentView = mve.Current;
                var clipPlanes = currentView.GetClipPlanes();
                foreach (ClipPlane clipPlane in clipPlanes)
                {
                    clipPlane.Delete();
                }
            }
            mve.Reset();

            var points = new List<Point>();
            var model = new Model();

            ModelObjectEnumerator.AutoFetch = true;
            var mos = new Tekla.Structures.Model.UI.ModelObjectSelector();
            var moe = mos.GetSelectedObjects();

            if (moe.GetSize() == 0)
            {
                return;
            }

            while (moe.MoveNext())
            {
                var part = moe.Current as Part;
                if (part == null)
                {
                    continue;
                }

                points.Add(part.GetSolid().MaximumPoint);
                points.Add(part.GetSolid().MinimumPoint);
            }

            var maxZPoint = points.OrderByDescending(p => p.Z).First();
            var minZPoint = points.OrderByDescending(p => p.Z).Last();

            var offset = 887;
            OffsetPointInXYZ(maxZPoint, offset);
            OffsetPointInXYZ(minZPoint, -offset);

            using (var dialog = new OptionSelectionForm())
            {
                dialog.ShowDialog();

                switch (dialog.SelectedOption)
                {
                    case UserOption.DirectionX:
                        while (mve.MoveNext())
                        {
                            CreateClipPlane(mve, maxZPoint, new Vector(1, 0, 0));
                            CreateClipPlane(mve, minZPoint, new Vector(-1, 0, 0));
                        }
                        break;

                    case UserOption.DirectionY:
                        while (mve.MoveNext())
                        {
                            CreateClipPlane(mve, maxZPoint, new Vector(0, 1, 0));
                            CreateClipPlane(mve, minZPoint, new Vector(0, -1, 0));
                        }
                        break;

                    case UserOption.DirectionZ:
                        while (mve.MoveNext())
                        {
                            CreateClipPlane(mve, maxZPoint, new Vector(0, 0, 1));
                            CreateClipPlane(mve, minZPoint, new Vector(0, 0, -1));
                        }
                        break;
                }
            }
        }

        private static void CreateClipPlane(ModelViewEnumerator mve, Point maxZPoint, Vector vector)
        {
            var upPlane = new ClipPlane();
            upPlane.View = mve.Current;
            upPlane.UpVector = vector;
            upPlane.Location = maxZPoint;
            upPlane.Insert();
        }

        private static void OffsetPointInXYZ(Point point, double offset)
        {
            point.X += offset;
            point.Y += offset;
            point.Z += offset;
        }
    }
}