# Python

## high order functions
Returns iterable to save resources. It's possible to continue to chain high order functions.

```python
xs = [1,2,3,4,5]

ys = map(lambda y: y*2, 
  map(lambda x: x+1, xs))
```
https://stackoverflow.com/questions/1303347/getting-a-map-to-return-a-list-in-python-3-x

### filter

```python
integers = range(0, 10)  
even = [] 
for i in integers:     
    if i % 2 == 0:         
        even.append(i)  
>>> even 
>>> [0, 2, 4, 6, 8]
```

### map

```python
integers = range(0, 10)
list(map(lambda x: x * x, integers))
>>> [0, 1, 4, 9, 16, 25, 36, 49, 64, 81]
```

### sum
```python
integers = range(1, 10)
sum(integers)  
>>> 45
```


### any, all
```python
any([False, True, False])   
>>> True    
all([False, True, False])   
>>> False
```

### reduce
```python
from functools import reduce
integers = range(1, 10)  
reduce(lambda x, y: x * y, integers)  
>>> 362880
```

https://medium.com/@bonfirealgorithm/beyond-the-for-loop-higher-order-functions-and-list-comprehensions-in-python-695b58ab71d3

## string interpolation

```python
name = 'Robert'
print(f'Hello {name}')
```
