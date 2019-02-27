require('file-loader?name=[name].[ext]!./index.html');

import { Observable } from "rxjs";
const a = new Observable<number>(subs => {
    setInterval(() => subs.next(Math.random()), 1000)
})

const value = document.getElementById('value')
a.subscribe(v => {
    value.innerText = v.toString()
})
