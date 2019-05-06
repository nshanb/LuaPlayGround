co = coroutine.create(function (j)
    if(j) then coroutine.yield(11,'aa') end
    for i=1,10 do
      print("co", i)
      coroutine.yield(i,10,'a')
    end
  end
)

print(coroutine.resume(co))
print(coroutine.resume(co,16))
print(coroutine.status(co))



