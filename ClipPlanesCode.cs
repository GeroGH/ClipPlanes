using System;
using System.Collections.Generic;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using ModelObjectSelector = Tekla.Structures.Model.UI.ModelObjectSelector;

namespace ClipPlanes
{
    internal static class ClipPlanesCode
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var Points = new List<Point>();

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

                Points.Add(part.GetSolid().MaximumPoint);
                Points.Add(part.GetSolid().MinimumPoint);
            }

            model.CommitChanges();
        }
    }
}
