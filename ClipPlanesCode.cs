using System.Collections.Generic;
using System.Linq;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using ModelObjectSelector = Tekla.Structures.Model.UI.ModelObjectSelector;

namespace ClipPlanes
{
    internal static class ClipPlanesCode
    {
        static void Main()
        {
            var visibleViews = ViewHandler.GetVisibleViews();
            while (visibleViews.MoveNext())
            {
                var currentView = visibleViews.Current;
                var clipPlanes = currentView.GetClipPlanes();
                foreach (ClipPlane clipPlane in clipPlanes)
                {
                    clipPlane.Delete();
                }
            }
            visibleViews.Reset();

            var points = new List<Point>();
            var model = new Model();

            ModelObjectEnumerator.AutoFetch = true;
            var mos = new ModelObjectSelector();
            var moe = mos.GetSelectedObjects();

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

            maxZPoint.Z += 50;
            minZPoint.Z -= 250;

            while (visibleViews.MoveNext())
            {
                var upPlane = new ClipPlane();
                upPlane.View = visibleViews.Current;
                upPlane.UpVector = new Vector(0, 0, 1);
                upPlane.Location = maxZPoint;
                upPlane.Insert();

                var downPlane = new ClipPlane();
                downPlane.View = visibleViews.Current;
                downPlane.UpVector = new Vector(0, 0, -1);
                downPlane.Location = minZPoint;
                downPlane.Insert();
            }
        }
    }
}