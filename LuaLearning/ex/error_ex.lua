-- pcall, xpcall == catch errors
x = function(i)
  if i<0 then error('this is an error',1) end
end
y = function(xa)
  print('xpcall',xa)
end

a,b,c = pcall(x,-11)
print(a,b,c)
a,b,c = xpcall(x,y,-11)
print(a,b,c)

a,b,c = pcall(x, 11)
print(a,b,c)

print(_ENV)
print(_G)

a,b = load('a')
print(a,b)

a,b,c,d = assert(true,'could be',2,3)
print(a,b,c,d)