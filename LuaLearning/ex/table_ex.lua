
t = { 11, 12, z = 5, ['x'] = 6, 'third' }
print(t.z, t.x, t['z'])
print(t[1],t[2],t[3],t[4])

f = function() return 1,2,3 end
t = {4, f()}
t1= {f(),4}
print(#t, #t1)

