// #region Copyright
// /* 
// ============================================================
// PatternsExamples - Facade.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    

#region Copyright

#endregion

namespace PatternsExamples.B_Structural.B_Facade
{
    public interface IBetterAPI
    {
        int AddThreeNumbers(int firstParam, int secondParam, int thirdParam);

        int AddThenMultiply(int addend1, int factor);

        int AddThenMultiply(int addend1, int addend2, int factor);

        int AddThenMultiply(int addend1, int addend2, int addend3, int factor);
    }

    public class BetterAPI : IBetterAPI
    {
        private readonly IConfusing _confusing;
        private readonly IOverdone _overdone;

        public BetterAPI()
        {
            //Demo Code
            _confusing = new Confusing();
            _overdone = new Overdone("foo");
        }

        public BetterAPI(IConfusing confusing, IOverdone overdone)
        {
            _confusing = confusing;
            _overdone = overdone;
        }

        public int AddThreeNumbers(int firstParam, int secondParam, int thirdParam) => 
			_confusing.Execute(firstParam, secondParam, thirdParam);

	    public int AddThenMultiply(int addend1, int factor) => 
			_overdone.DoSomething(addend1, factor);

	    public int AddThenMultiply(int addend1, int addend2, int factor) => 
			_overdone.DoSomethingElse(addend1, addend2, factor);

	    public int AddThenMultiply(int addend1, int addend2, int addend3, int factor) => _overdone.DoSomethingAgain(addend1, addend2, addend3, factor);
    }
}
