# RxJS

## Building blocks

- Producer: Get values and pass to observer
- Observable: Ties observer to producer
- Observer: listens to producer

## Hot vs Cold
TL;DR: You want a HOT observable when you don’t want to create your producer over and over again.

```
COLD is when your observable creates the producer (unicast)
var cold = new Observable((observer) => {
var producer = new Producer();
// have observer listen to producer here
});
```

```
HOT is when your observable closes over the producer (multicast)
var producer = new Producer();
var hot = new Observable((observer) => {
// have observer listen to producer here
});
```

- Subject:  
**Multicast** (like going to the cinema). Is a data producer and consumer: Thus an Observer and Observable. Can read and produce values and can be used to proxy.

- Observable: 
**Unicast** (like watching Netflix). It is a data consumer.
