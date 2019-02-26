import { Observable } from "rxjs";

const a = new Observable(subs => {
    setInterval(() => subs.next(Math.random()), 1000)
})

a.subscribe(console.log)