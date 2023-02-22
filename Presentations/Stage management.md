Goal:
- Present architectural considerations




----------------------------------
- teaser: are you asking yourself
  State in my app is hard to reason about, hard to debug (need to add console logs etc)
  
 If you never have to debug state issues in your app, I like to quote the NgRx author Mike Ryan:
 "You may not need NgRx"

Ask: does this apply to you?
It applies to a lot of apps, history:
  - Flux (Architectural PATTERN introduced by Facebook for React)
  - Redux (implementation of Flux)
  - NgRx (Redux framework for Angular) [not only solution, also ngxs or akita]
  
- OUTLINE

- Principles: short!
  - single source of truth (do not think in terms of UI, think in terms of state)
  - Immutable state (state is read-only)
  - Unidirectional data flow (changes made via pure functions)
  
  - actions, reducers, effects, selectors

- Architectural setup (hierarchical folders)
  - Atomic Design by Brad Frost
    * Atoms (e.g. a text box)
    * Molecules (e.g. a text box combined with a search button)
    * Organisms (e.g. a header consisting of several molecules)
    * Templates (e.g. a template for combining several components together)
    * Pages

  - State modules
    - DO! separate from component modules
    - Consider hierarchical folder structure

Show Next FE arch board: https://miro.com/app/board/o9J_lYEWEF0=/

- App state vs component state

- What to store?
  - app state that is shared
- What NOT to store?
  - unshared state
  - unserializable, cyclic state (RouterState) (NUANCE ngrx-router module)
  - mutable state (leaflet map)

- Tooling: 
  - DevTools
  - CLI

- Scenario: 
  - overview page of detailed dtos, linking to pages of less detailed dtos

- Pitfalls
  - cycles, identical return causes loop
  - error in main stream causes app to die


-------------------------------------------------------

https://app.pluralsight.com/library/courses/angular-ngrx-getting-started/table-of-contents

-------------------------------------------------------


## What is it?
- As an application grows, complexity of managing the state increases 
- In a big application where we have a high number of components, managing their state can become a big pain

## Why complex?
State management problems often sound like:

- Do I modify data in the child component or bubble an event to its container component?
- Do I request the same data from the API again?
- Why is the modified data not reflected on the UI in the parent component?
- Reactive loops when observables are chained to each other
- The state is spread across the app within services

https://redux.js.org/faq/general/

https://medium.com/@dan_abramov/you-might-not-need-redux-be46360cf367
https://ordina-jworks.github.io/angular/2018/10/08/angular-state-management-comparison.html


(Redux Concept is FAR MORE important than library or syntax)



# NgRx
Imagine scenario: 
Display the name of the logged-in user in multiple places in the app.

Can we do this just by injecting a service, invoke the HttpClient and retrieve an observable? 
Yes. Though:

Service needs to maintain state apart from making get rest calls to the backend. 
Imagine: 
  - data is retrieved async from multiple data sources
  - a refresh trigger to reload the data can come from different places
  - the update name triggers multiple asynchronous actions each with its own latency and error handling
 

  - At the end of it the implementation code will probably have a similar pattern.


(maybe present NgRx solution here)


- What has NgRx has to offer:
  - App store
  - Component store





https://www.linkedin.com/pulse/understanding-state-management-front-end-paradigm-jitendrasinh-gohil/

[NgRx, is it worth it?](https://medium.com/web-factory-llc/ngrx-is-it-worth-it-6ad9585dcbaa)



COMMENTS:
- Intro: short
- Focus on scenarios
- Code sample
- Outcome: structure should be sound (architecture)
- What should be stored (app state, component state)





------------------------------------

npm install -g @angular/cli@15
ng add @ngrx/schematics@latest
npm install @ngrx/{store,effects,entity,store-devtools} --save
ng generate @ngrx/schematics:store State --root --module app.module.ts
ng generate @ngrx/schematics:effect App --root --module app.module.ts
