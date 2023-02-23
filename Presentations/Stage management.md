Talk is not about the fundamentals of NgRx.
Why not? Getting Started Course alone takes already more than half a day: https://app.pluralsight.com/library/courses/angular-ngrx-getting-started/table-of-contents
The Newest stuff in v15: https://ngrx.io/guide/migration/v15

Goal: Explain the main architectural decisions you need to make when using NgRx?
Questions:
- How do I architect the state of my app?
  - When to use Store or ComponentStore?
  - 

## Outline
  - Apps vs. (library) components
  - Hierarchical app state
    - What state should be put in the store, and what not?
  - Component:
    - Show pro/cons of component store

###############################################

# Apps vs. (shippable) components
- Difference between presentational and container components
- Do you need a state management framework? (presentational components)
- How to wire app state to your container components


# Hierarchical state
- AppStateModule: Good to implement Cross-cutting concerns here.
- Separate feature state modules (functional)
- Separate technical
- State per page / Dedicated state module
- Routing dictates what can be deep linked
- Hierarchical state also on folder level! 
- State modules can use parents and if imported siblings
- State modules cant use childs (and you should not want to), use router
- Let the feature modules load your state modules

# Component store
(Show screenshot of 2 floorplans at same time)
- Each component instance has one single state instance
- Encapsulated and managed by component
- Small
- Automatically cleaned up
- State management for components that must support multiple concurrent instances
Separate libraries, ship component together with behaviour

Store:
- Always one single instance
- Encapsulated by module hierarchy
- Support multiple effects at the same time (powerful!)
- More scalable
- DevTools! 


