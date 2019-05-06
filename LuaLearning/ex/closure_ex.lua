newCounter = function ()
  local i = 0
  return function ()   -- anonymous function
    i = i + 1
    return i
  end
end

c1 = newCounter()
c2 = newCounter()

print(c1(), c1())
print(c2(), c1())

do
  local oldOpen = io.open
  io.open = function (filename, mode)
    if access_OK(filename, mode) then
      return oldOpen(filename, mode)
    else
      return nil, "access denied"
    end
  end
end

