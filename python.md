# Python

## Built-in Functions

|                                                              | Built-in Functions                                           |                                                              |                                                              |                                                              |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| [`abs()`](https://docs.python.org/3/library/functions.html#abs) | [`delattr()`](https://docs.python.org/3/library/functions.html#delattr) | [`hash()`](https://docs.python.org/3/library/functions.html#hash) | [`memoryview()`](https://docs.python.org/3/library/functions.html#func-memoryview) | [`set()`](https://docs.python.org/3/library/functions.html#func-set) |
| [`all()`](https://docs.python.org/3/library/functions.html#all) | [`dict()`](https://docs.python.org/3/library/functions.html#func-dict) | [`help()`](https://docs.python.org/3/library/functions.html#help) | [`min()`](https://docs.python.org/3/library/functions.html#min) | [`setattr()`](https://docs.python.org/3/library/functions.html#setattr) |
| [`any()`](https://docs.python.org/3/library/functions.html#any) | [`dir()`](https://docs.python.org/3/library/functions.html#dir) | [`hex()`](https://docs.python.org/3/library/functions.html#hex) | [`next()`](https://docs.python.org/3/library/functions.html#next) | [`slice()`](https://docs.python.org/3/library/functions.html#slice) |
| [`ascii()`](https://docs.python.org/3/library/functions.html#ascii) | [`divmod()`](https://docs.python.org/3/library/functions.html#divmod) | [`id()`](https://docs.python.org/3/library/functions.html#id) | [`object()`](https://docs.python.org/3/library/functions.html#object) | [`sorted()`](https://docs.python.org/3/library/functions.html#sorted) |
| [`bin()`](https://docs.python.org/3/library/functions.html#bin) | [`enumerate()`](https://docs.python.org/3/library/functions.html#enumerate) | [`input()`](https://docs.python.org/3/library/functions.html#input) | [`oct()`](https://docs.python.org/3/library/functions.html#oct) | [`staticmethod()`](https://docs.python.org/3/library/functions.html#staticmethod) |
| [`bool()`](https://docs.python.org/3/library/functions.html#bool) | [`eval()`](https://docs.python.org/3/library/functions.html#eval) | [`int()`](https://docs.python.org/3/library/functions.html#int) | [`open()`](https://docs.python.org/3/library/functions.html#open) | [`str()`](https://docs.python.org/3/library/functions.html#func-str) |
| [`breakpoint()`](https://docs.python.org/3/library/functions.html#breakpoint) | [`exec()`](https://docs.python.org/3/library/functions.html#exec) | [`isinstance()`](https://docs.python.org/3/library/functions.html#isinstance) | [`ord()`](https://docs.python.org/3/library/functions.html#ord) | [`sum()`](https://docs.python.org/3/library/functions.html#sum) |
| [`bytearray()`](https://docs.python.org/3/library/functions.html#func-bytearray) | [`filter()`](https://docs.python.org/3/library/functions.html#filter) | [`issubclass()`](https://docs.python.org/3/library/functions.html#issubclass) | [`pow()`](https://docs.python.org/3/library/functions.html#pow) | [`super()`](https://docs.python.org/3/library/functions.html#super) |
| [`bytes()`](https://docs.python.org/3/library/functions.html#func-bytes) | [`float()`](https://docs.python.org/3/library/functions.html#float) | [`iter()`](https://docs.python.org/3/library/functions.html#iter) | [`print()`](https://docs.python.org/3/library/functions.html#print) | [`tuple()`](https://docs.python.org/3/library/functions.html#func-tuple) |
| [`callable()`](https://docs.python.org/3/library/functions.html#callable) | [`format()`](https://docs.python.org/3/library/functions.html#format) | [`len()`](https://docs.python.org/3/library/functions.html#len) | [`property()`](https://docs.python.org/3/library/functions.html#property) | [`type()`](https://docs.python.org/3/library/functions.html#type) |
| [`chr()`](https://docs.python.org/3/library/functions.html#chr) | [`frozenset()`](https://docs.python.org/3/library/functions.html#func-frozenset) | [`list()`](https://docs.python.org/3/library/functions.html#func-list) | [`range()`](https://docs.python.org/3/library/functions.html#func-range) | [`vars()`](https://docs.python.org/3/library/functions.html#vars) |
| [`classmethod()`](https://docs.python.org/3/library/functions.html#classmethod) | [`getattr()`](https://docs.python.org/3/library/functions.html#getattr) | [`locals()`](https://docs.python.org/3/library/functions.html#locals) | [`repr()`](https://docs.python.org/3/library/functions.html#repr) | [`zip()`](https://docs.python.org/3/library/functions.html#zip) |
| [`compile()`](https://docs.python.org/3/library/functions.html#compile) | [`globals()`](https://docs.python.org/3/library/functions.html#globals) | [`map()`](https://docs.python.org/3/library/functions.html#map) | [`reversed()`](https://docs.python.org/3/library/functions.html#reversed) | [`__import__()`](https://docs.python.org/3/library/functions.html#__import__) |
| [`complex()`](https://docs.python.org/3/library/functions.html#complex) | [`hasattr()`](https://docs.python.org/3/library/functions.html#hasattr) | [`max()`](https://docs.python.org/3/library/functions.html#max) | [`round()`](https://docs.python.org/3/library/functions.html#round) |                                                              |



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
d

## Iterator functions

**Infinite iterators:**

| Iterator                                                     | Arguments     | Results                                        | Example                                |
| ------------------------------------------------------------ | ------------- | ---------------------------------------------- | -------------------------------------- |
| [`count()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.count) | start, [step] | start, start+step, start+2*step, …             | `count(10) --> 10 11 12 1314 ...`      |
| [`cycle()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.cycle) | p             | p0, p1, … plast, p0, p1, …                     | `cycle('ABCD') --> A B C DA B C D ...` |
| [`repeat()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.repeat) | elem [,n]     | elem, elem, elem, … endlessly or up to n times | `repeat(10, 3) --> 10 10 10`           |



**Iterators terminating on the shortest input sequence:**

| Iterator                                                     | Arguments                   | Results                                    | Example                                                  |
| ------------------------------------------------------------ | --------------------------- | ------------------------------------------ | -------------------------------------------------------- |
| [`accumulate()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.accumulate) | p [,func]                   | p0, p0+p1, p0+p1+p2, …                     | `accumulate([1,2,3,4,5]) -->1 3 6 10 15`                 |
| [`chain()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.chain) | p, q, …                     | p0, p1, … plast, q0, q1, …                 | `chain('ABC', 'DEF') --> A BC D E F`                     |
| [`chain.from_iterable()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.chain.from_iterable) | iterable                    | p0, p1, … plast, q0, q1, …                 | `chain.from_iterable(['ABC','DEF']) --> A B C D E F`     |
| [`compress()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.compress) | data, selectors             | (d[0] if s[0]), (d[1] if s[1]), …          | `compress('ABCDEF',[1,0,1,0,1,1]) --> A C E F`           |
| [`dropwhile()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.dropwhile) | pred, seq                   | seq[n], seq[n+1], starting when pred fails | `dropwhile(lambda x: x<5,[1,4,6,4,1]) --> 6 4 1`         |
| [`filterfalse()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.filterfalse) | pred, seq                   | elements of seq where pred(elem) is false  | `filterfalse(lambda x: x%2,range(10)) --> 0 2 4 6 8`     |
| [`groupby()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.groupby) | iterable[, key]             | sub-iterators grouped by value of key(v)   |                                                          |
| [`islice()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.islice) | seq, [start,] stop [, step] | elements from seq[start:stop:step]         | `islice('ABCDEFG', 2, None)--> C D E F G`                |
| [`starmap()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.starmap) | func, seq                   | func(*seq[0]), func(*seq[1]), …            | `starmap(pow, [(2,5), (3,2),(10,3)]) --> 32 9 1000`      |
| [`takewhile()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.takewhile) | pred, seq                   | seq[0], seq[1], until pred fails           | `takewhile(lambda x: x<5,[1,4,6,4,1]) --> 1 4`           |
| [`tee()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.tee) | it, n                       | it1, it2, … itn splits one iterator into n |                                                          |
| [`zip_longest()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.zip_longest) | p, q, …                     | (p[0], q[0]), (p[1], q[1]), …              | `zip_longest('ABCD', 'xy',fillvalue='-') --> Ax By C-D-` |



**Combinatoric iterators:**

| Iterator                                                     | Arguments          | Results                                                      |
| ------------------------------------------------------------ | ------------------ | ------------------------------------------------------------ |
| [`product()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.product) | p, q, … [repeat=1] | cartesian product, equivalent to a nested for-loop           |
| [`permutations()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.permutations) | p[, r]             | r-length tuples, all possible orderings, no repeated elements |
| [`combinations()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.combinations) | p, r               | r-length tuples, in sorted order, no repeated elements       |
| [`combinations_with_replacement()`](https://docs.python.org/3/library/itertools.html?highlight=itertools#itertools.combinations_with_replacement) | p, r               | r-length tuples, in sorted order, with repeated elements     |
| `product('ABCD', repeat=2)`                                  |                    | `AA AB AC AD BA BB BC BD CA CB CCCD DA DB DC DD`             |
| `permutations('ABCD', 2)`                                    |                    | `AB AC AD BA BC BD CA CB CD DA DBDC`                         |
| `combinations('ABCD', 2)`                                    |                    | `AB AC AD BC BD CD`                                          |
| `combinations_with_replacement('ABCD',2)`                    |                    | `AA AB AC AD BB BC BD CC CD DD`                              |



https://docs.python.org/3/library/itertools.html?highlight=itertools


## string interpolation

```python
name = 'Robert'
print(f'Hello {name}')
```

## number formatting

python 2

  print "%02d" % (1,)

python 3.+

  print("{:02d}".format(1))

python 3.6+

  print(f"{1:02d}")
  
https://stackoverflow.com/questions/134934/display-number-with-leading-zeros
