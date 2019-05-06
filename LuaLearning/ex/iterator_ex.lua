function list_iter (t)
  local i = 0
  local n = #t
  return function ()
    i = i + 1
    if i <= n then return t[i] end
  end
end

t = {10, 20, 30}
for element in list_iter(t) do print(element) end

--[[
for var_1, ..., var_n in explist do block end

do
  local _f, _s, _var = explist
  while true do
    local var_1, ... , var_n = _f(_s, _var)
    _var = var_1
    if _var == nil then break end
    block
  end
end
[Stateless Iterator](https://www.lua.org/pil/7.3.html)
]]--

