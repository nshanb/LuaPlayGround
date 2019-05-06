-- basic types: nil, boolean, number, string, function, userdata, thread, table
if(x) then print('nil is true') else print('nil is false') end
print(type(x))

tn = 1; ts = '1'; tf = function(i) end; tt = {}
print(type(tn),type(ts),type(tf),type(tt))


-- constant number
x = 3.4; x = 3e-4; x = -0x00ff;
print(x, 0x0.1e, 0x1p3)

-- constant string
s = 'a\tb'; 
print(s, '\x61\x62\x63', '\u{061}\u{161}')
s = [[a mulit line
string]]

print('aa' .. "bb")

-- coercions 
print(10 .. 20, '10'+'20')
print(tostring(10) == '10', 10 == tonumber('10'))

-- table
a = {}; a.x = 7
b = a; b["y"] = 8
print(a['x'], a.y)

