# TypeScript

## Typed Dictioanry
```typescript
interface MetricByKey {
  [key: string]: Metric
}

let metricByKey: MetricByKey = {}
```

## Creating Project
```bash
mkdir projectname
cd projectname
mkdir src
yarn add @types/node

#npm i -g tsc

# to run typescript without compiling
#npm i ts-node
```

```json
{
    "compilerOptions": {
        "target": "es6",
        "module": "commonjs",
        "outDir": "dist",
        "sourceMap": true
    },
    "files": [
        // "./node_modules/@types/mocha/index.d.ts",
        "./node_modules/@types/node/index.d.ts"
    ],
    "include": [
        "src/**/*.ts",
        ""
    ],
    "exclude": [
        "./node_modules/*"
    ]
}
```
