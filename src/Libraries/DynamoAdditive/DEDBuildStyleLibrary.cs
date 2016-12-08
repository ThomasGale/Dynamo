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


namespace DynamoAdditive
{
    /// <summary>
    /// Wrapper for the DED BuildStyle library
    /// </summary>
    public class DEDBuildStyleLibrary
    {
        #region Static Factory Methods

        //Static Factory method
        IPathGenerationFactory _pathGenerationFactory = new NetfabbPathGenerationFactory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Autodesk\Dynamo\Additive\test\tmp");

        #endregion

        #region Private Fields

        IBuildStyleLibrary _buildStyleLibrary;

        #endregion

        //Internal List of Parameters

        internal DEDBuildStyleLibrary(string buildStyleFolder)
        {
            var _weirdSliceCreator = _pathGenerationFactory.ConstructSliceCreator();
            _buildStyleLibrary = _pathGenerationFactory.ConstructBuildStyleLibrary(buildStyleFolder);
        }

        public static DEDBuildStyleLibrary ContructBuildStyleLibrary(string buildStyleFolder)
        {
            return new DEDBuildStyleLibrary(buildStyleFolder);
        }

        public IList<DEDBuildStyle> GetBuildStyleList()
        {
            IList<DEDBuildStyle> buildStyleList = new List<DEDBuildStyle>();

            foreach(IBuildStyle buildStyle in _buildStyleLibrary.buildstyleList)
            {
                DEDBuildStyle dedBuildStyle = new DEDBuildStyle(buildStyle);
                buildStyleList.Add(dedBuildStyle);
            }

            return buildStyleList;
        }
    }
}
