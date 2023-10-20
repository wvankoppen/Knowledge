


### App architecture

Use [Atomic Design](https://bradfrost.com/blog/post/atomic-web-design/) as described by Brad Frost.


Types of components:
* Atoms (e.g. a text box)
* Molecules (e.g. a text box combined with a search button)
* Organisms (e.g. a header consisting of several molecules)
* Templates (e.g. a template for combining several components together)
* Pages


Guidelines
- Atoms can be combined into Molecules
- Atoms and Molecules can have Inputs/Outputs, not a Store.
- Organisms may have a Store
- Preferably, components do not contain state itself.

Principles:
- Immutability
- Single source of truth
- Unidirectional data flow



[State management](https://www.linkedin.com/pulse/understanding-state-management-front-end-paradigm-jitendrasinh-gohil/)


[NgRx best practices]https://indepth.dev/posts/1451/ngrx-best-practices-new

Layered Architecture:
- Lazy loadable feature module in a tree hierarchy
  - State module 
    - Actions
    - Effects
      - Router
      - API
  - ...Modules

State:
- URL (for deep linking)
- Store


App state vs. component state vs. services.





## Domain-driven design


## Cross-cutting concerns
- Throbbers, dialogs, panels




# Core responsibilities
## Visualisation / user input

Components should be dumb.
Two responsibilities:
- display data (input)
- notify about a user action (output)


Components should be dumb: Just to present data (input/state) and dispatch (output/router nav/store dispatch)


Components can be aggregated: atoms become molecules, molecules become organisms.

Eventually, components dispatch to the store. Can be directly (organism) or indirectly (via parent component)

### Data
Data is retrieved from the store. 
It is added to the store by using a reducer.

This enables us to divide the problem into two easier sub problems.
- render the latest content of store
- get new content
- store the latest version of the model

The latter is done via the reducer.

## Logic
Effects listen to actions and act on it. They implement logic.


- where to load data?
  - Route guards
  - Routing effects
  - In component itself

- how to deal with nullability
  - always assume data to be maybe not there yet (undefined)
    - allows distinction of empty response from not-there-yet responses


# DDD
Allows the app to have different data models.



 
 | Device | Zone |
 | Project |

Questions:
- Can each bounded context be reached independently (deep linking)
  - If not, consider to use a logical view on the state.
  - If yes, it's probably best to have duplications in your state. (Zone has some Device properties and vice versa)




Pros: 
- Debugging problem on UI: First inspect the state. If the state is...
  - incorrect, look below the state (in effects).
  - correct, look above the state (in selectors / components)

Cons:
- Initial complexity in your app



## Models on the FE
Definitely not the same as a BE model.
- Can be generated via swagger docs
