x = 1; y = 2;
x,y = y,x
a1,a2,a3 = x,y
print(a1,a2,a3)

f = function() x = 3 end
a1,a2 = x,y,f()
print(a1,a2,x)

-- 'function f () body end'  === 'f = function () body end'
-- 'local function f () body end' === 'local f; f = function () body end'
-- function(a,b,c, ... ) ... === vararg

-- upvalue === local in extrenal block

v = 10
do
 local v = v
 print(v)
 v = v + 1
 print(v)
 do
  local v = v + 1
  print(v)
 end
 print(v)
end
print(v)

-- 'o:foo(x)' === o.foo(o, x)

function g (a, b, ...) end
-- g(1) => a=1, b=nil, arg = {n=1}
-- g(1,2,3,4) => a=1,b=2, arg = {n=1,3,4}

s = function(options) ; end
s{argument1=1,optinal1=2}
