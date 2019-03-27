# NodeJs

## Typescript
TypeDef for typescript (`@types/NPM-PACKAGE-NAME`)

npm install --save @types/node

## Buffer
Can e.g. convert base64 Encoding to Double With Big Ending.
```typescript
let decodedString = new Buffer('....', 'base64').toString()
let decodedDoubleValue = new Buffer('...', 'base64').readDoubleBE(0)
```

  * [Working with JS-Buffer](https://allenkim67.github.io/programming/2016/05/17/nodejs-buffer-tutorial.html)
  
  
## Streams
  
```typescript
import { Writable , Readable } from "stream"

const out = new Writable({
  write(chunk, encoding, callback){
    console.log("received: " + chunk.toString())
    
    // wait 300sec. before continue stream
    setTimeout(callback, 300)
  }
})


let currentCharCode = 65
const producer = new Readable({
    read(){
        this.push(String.fromCharCode(currentCharCode++));
        if (currentCharCode > 90) {
          this.push(null);
        }
    }
})

producer.pipe(out)
```

https://medium.freecodecamp.org/node-js-streams-everything-you-need-to-know-c9141306be93

### WARNING
Do not mix pieping-style and event-style! 

Using certain methods automatically switch to different style. E.g. `.end()`-listener or `.on('data')`-switches to Event style.
