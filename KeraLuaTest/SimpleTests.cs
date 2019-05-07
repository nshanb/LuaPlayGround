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

            PrintChunk("", "Empty");

            PrintChunk("x=1");

            PrintChunk("1");

            PrintChunk("2","two");

            stackDump();

            state.Close();
        }

        [TestMethod]
        public void CompileAndRunString()
        {
            state = new Lua();

            LuaStatus result = state.LoadString("x=1");
            stackDump();

            state.Call(0, 0);
            stackDump();

            result = state.LoadString("1 print(x)"); // stdout??  PANIC: unprotected error in call to Lua API (attempt to call a string value)
            stackDump();

            state.Call(0, 0);
            stackDump();

            state.Close();
        }
        private LuaStatus PrintChunk(string chunkStr, string chunkName = null)
        {
            LuaStatus result;
            result = state.LoadString(chunkStr, chunkName);
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

        private void stackDump()
        {
            int top = state.GetTop();
            Console.WriteLine($"Stack:[{top}]");
            for (int i = 1; i <= top; i++)
            {
                LuaType t = state.Type(i);
                switch(t)
                {
                    case LuaType.Boolean:
                        Console.WriteLine($"{i}:{state.TypeName(i)}:{state.ToBoolean(i)}");
                        break;
                    case LuaType.Function:
                        Console.WriteLine($"{i}:{state.ToString(i)}");
                        break;
                    case LuaType.LightUserData:
                        Console.WriteLine($"{i}:{state.TypeName(i)}");
                        break;
                    case LuaType.Nil:
                        Console.WriteLine($"{i}:{state.TypeName(i)}");
                        break;
                    case LuaType.None:
                        Console.WriteLine($"{i}:{state.TypeName(i)}");
                        break;
                    case LuaType.Number:
                        Console.WriteLine($"{i}:{state.TypeName(i)}:{state.ToNumber(i)}");
                        break;
                    case LuaType.String:
                        Console.WriteLine($"{i}:{state.TypeName(i)}:{state.ToString(i)}");
                        break;
                    case LuaType.Table:
                        Console.WriteLine($"{i}:{state.TypeName(i)}");
                        break;
                    case LuaType.Thread:
                        Console.WriteLine($"{i}:{state.TypeName(i)}");
                        break;
                    case LuaType.UserData:
                        Console.WriteLine($"{i}:{state.TypeName(i)}");
                        break;
                    default:
                        throw new Exception($"Unknown type:{t}, typename:{state.TypeName(i)}");
                }
            }
        }
    }
}
