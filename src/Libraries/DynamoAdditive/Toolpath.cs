//Framework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoAdditive
{
    /// <summary>
    /// Manufacturing Wrapper for Toolpath
    /// </summary>
    public class Toolpath
    {
        private IList<ToolpathPoint> _toolpathPoints;

        internal Toolpath(IList<ToolpathPoint> toolpathPoints)
        {
            _toolpathPoints = toolpathPoints;
        }

        /// <summary>
        /// Construct Toolpath from a list of toolpath points
        /// </summary>
        /// <param name="toolpathPoints"></param>
        /// <returns></returns>
        public static Toolpath FromPointsList(IList<ToolpathPoint> toolpathPoints)
        {
            return new Toolpath(toolpathPoints);
        }

        /// <summary>
        /// Get the list of toolpath points
        /// </summary>
        public IList<ToolpathPoint> ToolpathPoints
        {
            get { return _toolpathPoints; }
        }
    }
}
