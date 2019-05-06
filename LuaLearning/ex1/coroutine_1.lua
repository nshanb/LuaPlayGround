co = coroutine.create(
  function ()
    print("hi")
  end
)

print(coroutine.status(co))
coroutine.resume(co)
print(coroutine.status(co))
coroutine.resume(co)


