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
    /// DED BuildStyle Wrapper
    /// </summary>
    public class DEDBuildStyle
    {
        private IBuildStyle _buildStyle;

        //Internal List of Parameters

        internal DEDBuildStyle(IBuildStyle buildStyle)
        {
            _buildStyle = buildStyle;
        }

        internal IBuildStyle BuildStyle
        {
            get { return _buildStyle; }
        }

        //Get / modify the List of BuildStyle parameters
    }
}
