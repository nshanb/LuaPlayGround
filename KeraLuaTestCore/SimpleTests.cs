using KeraLua;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeraLuaTestCore
{
    [TestClass]
    public class SimpleTests
    {
        Lua state;

        [TestMethod]
        public void SmokeTest()
        {
            state = new Lua();
            state.Close();
        }
    }
}
