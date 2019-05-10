using KeraLua;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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
            LuaStatus result = state.LoadFile(GetScriptPath("smoketest"));
            Assert.AreEqual(LuaStatus.OK, result);

            result = state.PCall(0, -1, 0);
            Assert.AreEqual(LuaStatus.OK, result);

            state.Close();
        }

        private string GetScriptPath(string name)
        {
            string path = new Uri(GetType().Assembly.CodeBase).AbsolutePath;
            path = Directory.GetParent(path).Parent.Parent.Parent.Parent.ToString();
            path = Path.Combine(path, "LuaLearning", "tests");
            //Console.WriteLine(path);
            return Path.Combine(path, name + ".lua");
        }
    }
}
