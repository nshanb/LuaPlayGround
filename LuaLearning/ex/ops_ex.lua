--[[
operator precedence
  or
  and
  <     >     <=    >=    ~=    ==
  |
  ~
  &
  <<    >>
  ..
  +     -
  *     /     //    %
  unary operators (not   #     -     ~)
  ^
  
  .. and ^ are right associative
]]--

print(1|2|4 == 7, 1&2 == 0, ~2 == -3, 1~2 == 3, 1<<2 == 4, 4>>1 == 2)
print(5/2, 5//2, 5%2)

a = {1, 2, 3}; b = {1, 2, x=1, 3}; c = {x=1, y=2}
print(#a, #b, #c)

x=1; y=2
max = (x > y) and x or y

x = x or def -- set x to def if x is not set

