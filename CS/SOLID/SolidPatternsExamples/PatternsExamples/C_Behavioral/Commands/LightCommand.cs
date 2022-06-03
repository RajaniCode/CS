// #region Copyright
// /* 
// ============================================================
// PatternsExamples - LightCommand.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

namespace PatternsExamples.C_Behavioral.Commands
{
    public class LightCommand : IDemoCommand
    {
        private readonly ILight _light;

        public LightCommand(ILight light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.LightIsOn = !_light.LightIsOn;
        }
    }
}