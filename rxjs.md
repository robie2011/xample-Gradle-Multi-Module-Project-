# RxJs
## Links

  * [API](https://rxjs-dev.firebaseapp.com/api)
  * https://www.npmjs.com/package/rxjs
  * [Online RxJs Playground](https://stackblitz.com/fork/rxjs?devtoolsheight=60)

## create
```typescript
const stuff$ = of(
	'Spaghetti',
	42,
	'Meatballs'
);
```

## subscription
```typescript
const lowercaseStuff$ = stuff$.piepe(map(x => x.toLowerCase()))

lowercaseStuff$.subscribe(
	(x => console.log('Success:', x)),
	(x => console.log('Error:', x)),
	(() => console.log('Complete'))
);
```

## suppress error

*Example 1 (not so elegant, but wont' show any error on console)*
```typescript
/**
  * Can throw an error on the console but the observable chain will continue
  */
tryDeleteConsumer = () : Observable<{}> => {
  const url = `${serverUrlPrefix}/consumers/${config.consumerGroup}/instances/${config.consumerName}`
  return this.http.delete(url, this.getRequestOptions()).pipe(
    catchError(err => of(true))
  )
}
```

*Example 2*
```typescript
import { of } from 'rxjs'; 
import { map, catchError } from 'rxjs/operators';

const stuff$ = of(
	'Spaghetti',
	42,
	'Meatballs'
);


const sub = stuff$.pipe(
  map(x => x.toLowerCase()),
  catchError(error => of(error))
)

sub.subscribe(
	(x => console.log('Success:', x)),
	(x => console.log('Error:', x)),
	(() => console.log('Complete'))
);

```

[source](https://iamturns.com/continue-rxjs-streams-when-errors-occur/)

## Convert Callback to Observable
```typescript

// 0 args
function functionWith0ArgAndCallback(x, cb) {
    cb('hello')
}
const bound0 = bindCallback(functionWith0ArgAndCallback)
bound0(3).subscribe(console.log)

// 1 args
function functionWith1ArgAndCallback(x, cb) {
    cb(x*2)
}
const bound1 = bindCallback(functionWith1ArgAndCallback)
bound1(3).subscribe(console.log)

// 2 args
function functionWith2ArgAndCallback(x,y, cb) {
  cb(x+y)
}
const bound2 = bindCallback(functionWith2ArgAndCallback)
bound2(3,7).subscribe(console.log)

// 3 args
function functionWith3ArgAndCallback(x,y,z,cb) {
  cb(x+y+z)
}
const bound3 = bindCallback(functionWith3ArgAndCallback)
bound3(3,7,5).subscribe(console.log)

```

## Migration to RxJs 6

using pipes

```typescript
// old style
source
 .map(x => x + x)
 .mergeMap(n => of(n + 1, n + 2)
   .filter(x => x % 1 == 0)
   .scan((acc, x) => acc + x, 0)
 )
 .catch(err => of('error found'))
 .subscribe(printResult);


 // new style
 source.pipe(
 map(x => x + x),
 mergeMap(n => of(n + 1, n + 2).pipe(
   filter(x => x % 1 == 0),
   scan((acc, x) => acc + x, 0),
 )),
 catchError(err => of('error found')),
).subscribe(printResult); 
```

see https://github.com/reactivex/rxjs/blob/HEAD/docs_app/content/guide/v6/migration.md
