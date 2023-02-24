Talk is not about the fundamentals of NgRx.
Why not? Getting Started Course alone takes already more than half a day: https://app.pluralsight.com/library/courses/angular-ngrx-getting-started/table-of-contents
The Newest stuff in v15: https://ngrx.io/guide/migration/v15

Goal: Explain the main architectural decisions you need to make when using NgRx?
Questions:
- How do I architect the state of my apps and components?
  - When to use Store or ComponentStore?
  - When to use entity?

## Outline
  - What state means for apps and (library) components
  - Hierarchical app state
  - What state should be put in the store, and what not?
  - Show pro/cons of component store

###############################################

# What state means for apps and (library) components
- Do you need a state management framework?
  For a presentational components only, probably not. 
  Container components usually need state, (not necessarily in components itself) either a service or a state management solution. 
  Wire app state to your container components via Store.
- State ownership: App or component
  - App: Store logical choice, unless you need dynamically created components, then Component Store
  - Container component: App state if you need the pros (Debugging, Actions), Component Store if you need multipe instances


# Component store
(Show screenshot of 2 floor plans at same time)
- Each component instance has one single state instance
- Encapsulated and managed by component
- Automatically cleaned up with component
- State management for components that must support multiple concurrent instances
  Separate libraries, ship component together with behaviour

Store:
- Always one single instance
- Encapsulated by module hierarchy
- Support multiple effects at the same time (powerful!)
- More scalable
- DevTools!



# Hierarchical state
- AppStateModule: Good to implement Cross-cutting concerns here: Panels, Dialogs, IsOnline, 
- Separate feature state modules (functional)
- Separate technical
- State per page / Dedicated state module
  - Sometimes it will happen that both components need the state
- Routing dictates what can be deep linked
- Hierarchical state also on folder level! 
- State modules can use parents and if imported siblings
- State modules cant use childs (and you should not want to), use router
- Let the feature modules load your state modules


Conclusion:
What must be the key takeaway?
