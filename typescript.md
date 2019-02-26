# TypeScript

## Typed Dictionary
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

tsconfig.json
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

## Edit JSON File
```javascript
const fs = require('fs');
const pathModelfile = "./dashboard_model.json"
const pathNewModelFile = "dashboard_new.json"
const obj = JSON.parse(fs.readFileSync(pathModelfile, 'utf8'));
const countFrequencyBand = 20
const frequencyBandSize = 100
const frequencyStart = 100

const generateField = name => {
  return [
    {
      "params": [
        name
      ],
      "type": "field"
    },
    {
      "params": [],
      "type": "mean"
    },
    {
      "params": [
        name
      ],
      "type": "alias"
    }
  ]
}

function generateAllFields() {
  let i = 0
  return new Array(countFrequencyBand).fill(1).map(() => {
    let freq = frequencyStart + frequencyBandSize * i++
    return generateField(freq.toString())
  })
}

obj.panels[0].targets[0].select = generateAllFields()
fs.writeFileSync("dashboard_new.json", JSON.stringify(obj, null, 4), "utf8")
```

## Using Webpack to pack typescript output

```javascript
// file: webpack.config.js
const path = require('path');

module.exports = {
  entry: './dist/main.js',
  output: {
    filename: '../bundle.js',
    path: path.resolve(__dirname, 'dist')
  }
};
```

```bash
yarn add webpack webpack-cli
npx webpack --config webpack.config.js
```
https://webpack.js.org/guides/getting-started/
