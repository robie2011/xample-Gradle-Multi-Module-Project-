# RxJs

## suppress error
```typescript
/**
 * Try to delete consumer (if exists) and suppress error (consumer not exists)
 */
tryDeleteConsumer = () : Observable<{}> => {
  return Observable.create(obs => {
    try {
      const url = `${serverUrlPrefix}/consumers/${config.consumerGroup}/instances/${config.consumerName}`
      this.http.delete(url, this.getRequestOptions()).subscribe(resp => {
        return obs.next(true)
      })
    } catch (error) {
      return obs.next(true)
    }
  })
}

```
