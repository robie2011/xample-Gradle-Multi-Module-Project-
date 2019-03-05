# Python

## high order functions
Returns iterable to save resources. It's possible to continue to chain high order functions.

```python
xs = [1,2,3,4,5]

ys = map(lambda y: y*2, 
  map(lambda x: x+1, xs))
```

https://stackoverflow.com/questions/1303347/getting-a-map-to-return-a-list-in-python-3-x
