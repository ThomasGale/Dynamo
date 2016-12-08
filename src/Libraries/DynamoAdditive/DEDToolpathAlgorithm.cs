//Framework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//3rd Party
using NetfabbAlgorithm;
using NetfabbAlgorithm.FBYPathGeneration;
using NetfabbAlgorithm.FBYPathGenerationInterface;

using ManufacturingGeneralTypes.Factory;
using ManufacturingGeneralTypes.Path;

using ManufacturingAdditiveTypes.Factory.Netfabb;
using ManufacturingAdditiveTypes.Netfabb.Path;

namespace DynamoAdditive
{
    public class DEDToolpathAlgorithm
    {
        string _tempDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Autodesk\Dynamo\Additive\test\tmp";

        internal DEDToolpathAlgorithm()
        {

        }

        public static DEDToolpathAlgorithm Construct()
        {
            return new DEDToolpathAlgorithm();
        }


        public Toolpath CalculateToolpath(string stlFileLocation, DEDBuildStyle selectedBuildStyle)
        {
            //Do the Calculation
            IPathGenerationFactory pathGenerationFactory = new NetfabbPathGenerationFactory(_tempDataDirectory);
            IPathFactory pathFactory = new ManufacturingGeneralTypes.Factory.Implementation.PathFactory();
            IAdditivePathFactory additivePathFactory = new ManufacturingAdditiveTypes.Factory.Netfabb.Implementation.AdditivePathFactory();

            ISliceCreator sliceCreator = pathGenerationFactory.ConstructSliceCreator();
            IFolderCreator folderCreator = pathGenerationFactory.ConstructFolderCreator();

            IPathGenerationModel pathGenerationModel = pathGenerationFactory.ConstructPathGenerationModel(sliceCreator, folderCreator, pathFactory, additivePathFactory);

            IPath path = pathGenerationModel.GeneratePathFromBuildStyle(selectedBuildStyle.BuildStyle, stlFileLocation);

            var toolpathpoints = new List<ToolpathPoint>();

            //Construct Toolpath Object
            foreach (ILayer layer in path.Layers)
            {
                foreach(IExposure exposure in layer.Exposures)
                {
                    foreach(ISegment segment in exposure.Segments)
                    {
                        foreach(IPoint point in segment.Points)
                        {
                            toolpathpoints.Add(ToolpathPoint.FromPoint(point));
                        }
                    }
                }
            }

            return Toolpath.FromPointsList(toolpathpoints);
        }

    }
}
