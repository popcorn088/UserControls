using UserControls.CoefsTableControl;
using UserControlsSample.CoefsTableSample;

namespace UserControlsSampleTest
{
    [TestClass]
    public class UnitTest1
    {
        CoefsTablePageViewModel _vm;
        Coef coef;
        [TestMethod]
        public void TestMethod1()
        {
            _vm = new CoefsTablePageViewModel();
            coef = new Coef();
        }
    }
}