-- setmetatable (table, metatable), getmetatable (object)
-- __add +, __sub -, __mul *, __div /, __mod %, __pow ^, __unm unary -, __idiv //,
--  __band &, __bor |, __bxor ~, __bnot unary ~, __shl <<, __shr >>
-- __concat .., __len #, 
-- _eq ==, __lt <, __le <= [ a<=b == not b<a]
--[when t is not table, or key is missing]
-- __index t[key], __newindex t[key] = value, 
-- __call func(args)

--==============
-- __gc function called during finalization 
-- __mode {'v','k','vk'} weak table

--==============
-- __tostring,__metatable

Set = {}

Set.mt = {}

function Set.new(t)
  local set = {}
  setmetatable(set, Set.mt)
  for o in pairs(t) do set[t[o]] = true end
  return set
end

function Set.union (a,b)
  local res = Set.new{}
  for k in pairs(a) do res[k] = true end
  for k in pairs(b) do res[k] = true end
  return res
end

Set.mt.__add = Set.union

function Set.print(set)
  local s = "{"
  local sep = ""
  for e in pairs(set) do
    s = s .. sep .. e
    sep = ", "
  end
  print( s .. "}")
end

x = Set.new{'a','b','cc'}
Set.print(x)
y = Set.new{'d','ee'}
Set.print(y)
z = Set.union(x,y)
Set.print(z)

Set.print(y+x)

