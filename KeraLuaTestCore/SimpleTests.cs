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

        [TestMethod]
        public void LuaScript_smoketest()
        {
            state = new Lua();
            state.Close();
        }
    }
}
