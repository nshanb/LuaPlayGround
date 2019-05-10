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

            PrintChunk("2", "two");

            stackDump(state);

            state.Close();
        }

        [TestMethod]
        public void CompileAndRunString()
        {
            state = new Lua();

            LuaStatus result = state.LoadString("x=1");
            stackDump(state);

            state.Call(0, 0);
            stackDump(state);

            result = state.LoadString("1");
            stackDump(state);

            state.PCall(0, 0, 0);
            stackDump(state);

            result = state.LoadString("print(x)"); // stdout??
            stackDump(state);

            state.Call(0, 0);
            stackDump(state);

            state.Close();
        }

        [TestMethod]
        public void PanicError() // PANIC: unprotected error in call to Lua API (attempt to call a string value)
        {
            state = new Lua();

            LuaFunction oldPanic = state.AtPanic(MyPanicFunc);
            stackDump(state);

            LuaStatus result = state.LoadString("1");
            stackDump(state);

            try
            {
                state.Call(0, 0);
                Assert.Fail("Shoudln't go so far");
            }
            catch(MyPanicException ex)
            { }
            stackDump(state);

            state.Close();
        }
        public static LuaFunction MyPanicFunc = MyPanic;
        static int MyPanic(IntPtr lua_State)
        {
            Lua state = Lua.FromIntPtr(lua_State);
            stackDump(state);
            throw new MyPanicException("MyPanic");
            //return 0;
        }
        class MyPanicException : Exception
        {
            public MyPanicException(string err) : base(err)
            { }
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

        static private void stackDump(Lua _state)
        {

            int top = _state.GetTop();
            Console.WriteLine($"Stack:[{top}]");
            for (int i = 1; i <= top; i++)
            {
                LuaType t = _state.Type(i);
                switch (t)
                {
                    case LuaType.Boolean:
                        Console.WriteLine($"{i}:{_state.TypeName(i)}:{_state.ToBoolean(i)}");
                        break;
                    case LuaType.Function:
                        Console.WriteLine($"{i}:{_state.ToString(i)}");
                        break;
                    case LuaType.LightUserData:
                        Console.WriteLine($"{i}:{_state.TypeName(i)}");
                        break;
                    case LuaType.Nil:
                        Console.WriteLine($"{i}:{_state.TypeName(i)}");
                        break;
                    case LuaType.None:
                        Console.WriteLine($"{i}:{_state.TypeName(i)}");
                        break;
                    case LuaType.Number:
                        Console.WriteLine($"{i}:{_state.TypeName(i)}:{_state.ToNumber(i)}");
                        break;
                    case LuaType.String:
                        Console.WriteLine($"{i}:{_state.TypeName(i)}:{_state.ToString(i)}");
                        break;
                    case LuaType.Table:
                        Console.WriteLine($"{i}:{_state.TypeName(i)}");
                        break;
                    case LuaType.Thread:
                        Console.WriteLine($"{i}:{_state.TypeName(i)}");
                        break;
                    case LuaType.UserData:
                        Console.WriteLine($"{i}:{_state.TypeName(i)}");
                        break;
                    default:
                        throw new Exception($"Unknown type:{t}, typename:{_state.TypeName(i)}");
                }
            }
        }
    }
}
