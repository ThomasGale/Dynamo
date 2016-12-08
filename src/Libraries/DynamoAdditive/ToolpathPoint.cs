//Framework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//3rd Party
using Autodesk.DesignScript.Geometry;

using ManufacturingGeneralTypes.Factory;
using ManufacturingGeneralTypes.Factory.Implementation;

using ManufacturingGeneralTypes.Path;

namespace DynamoAdditive
{
    public class ToolpathPoint
    {
        //Path can be internal static object for construction **** Needs re-factoring
        private static IPathFactory _pathFactory = new PathFactory();

        private IPoint _point;

        internal ToolpathPoint(IPoint point)
        {
            _point = point;
        }

        internal ToolpathPoint(double x, double y, double z)
        {
            //Construct a _point object with just XYZ data for the time being
            _point = _pathFactory.ConstructPoint(
                _pathFactory.ConstructPointVector(x, y, z, 0, 0, 1, 1, 0, 0),
                _pathFactory.ConstructPointAxes(),
                _pathFactory.ConstructPointData()
                );
        }

        public static ToolpathPoint FromPoint(IPoint point)
        {
            return new ToolpathPoint(point);
        }

        public static ToolpathPoint FromCoordinates(double x, double y, double z)
        {
            return new ToolpathPoint(x, y, z);
        }      

        public Point AsPoint()
        {
            return Point.ByCartesianCoordinates(CoordinateSystem.Identity(), _point.PointVector.X, _point.PointVector.Y, _point.PointVector.Z);
        }

        public double X
        {
            get { return _point.PointVector.X; }
        }

        public double Y
        {
            get { return _point.PointVector.Y; }
        }

        public double Z
        {
            get { return _point.PointVector.Z; }
        }

    }
}
