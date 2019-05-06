using System;
using KeraLua;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeraLuaTest
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
        public void CompileResults()
        {
            state = new Lua();

            PrintChunk("");

            PrintChunk("x=1");

            PrintChunk("1");

            PrintChunk("2");

            state.Close();
        }

        private LuaStatus PrintChunk(string chunkStr)
        {
            LuaStatus result;
            result = state.LoadString(chunkStr);
            Console.WriteLine($"chunk:[{chunkStr}]");
            Console.WriteLine(result);
            Console.WriteLine(state.ToString(-1));
            //Console.WriteLine(state.ToString(0));
            Console.WriteLine(state.ToString(1));
            Console.WriteLine(state.ToString(2));
            Console.WriteLine(state.ToString(3));
            Console.WriteLine(state.ToString(4));
            return result;
        }
    }
}
