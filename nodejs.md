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