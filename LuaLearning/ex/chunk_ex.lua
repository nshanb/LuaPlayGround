-- chunk == a piece of code

dofile('ex/chunk_ex1.lua')
print(x)

f = load('y=1')
print(type(f))

z = f()
print(z, y)

f1 = load('')
print(f1,f1())
-- load, loadfile
-- require, package.loadlib (libname, funcname)

