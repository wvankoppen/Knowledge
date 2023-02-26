State Management in Angular using NgRx.

This talk is not a "Getting Started" or "Fundamentals" course about NgRx.

I like to give you my personal takeaways on improving the architecture of your app using NgRx.


## Outline
- NgRx: Do I need it?
- App architecture matters
- What (not) to store
- Hierarchical modules, hierarchical state
- Sharing state
- State ownership

## NgRx: Do I need it?
If you need a State Management framework, you know you need it.

So: For a simple app (e.g. ToDo management), it's probably not needed.
A service having a Subject holding the todo items probably suffices.

So: Redux / NgRx is not intended to make simple things even more simple.
It is intended to make difficult things less difficult.

NgRx might be a good choice if you have a complex app for which:
- the state is big and needs to be accessed by many components, 
- and is impacted by actions from different sources.



## App architecture matters
A good start is to create a separate feature module per page.
- Recommend also to do this per Organism (Atomic Design). 


### Sample domain model
Teachers, Students, Courses


- Teachers
  - Teacher
    - Courses

Create a feature module structure

- TeachersModule
  - TeacherModule
    - TeacherCoursesModule


If the domain also contains:
- Courses
  - Course
    - Teachers

then you probably need

- CoursesModule
  - CourseModule
    - CourseTeachersModule


These modules could be lazy loaded using the router config.


-> Takeaway 1: The hierarchical module tree of your app should match the domain


Ask: No surprises at this point, right?

## WRedux principles:

Principles:
1. Single source of truth (Store - explain later on what to store)
2. State is read only
3. Changes are made via pure functions (reducers)

Advantages:
- Centralized, immutable state (hydrate state via LocalStorage)
- Performance (OnPush)
- Tooling! (look whether state correct, no logging)
- Component communication (inject Store)


-> Takeaway 2: Take the Redux principles to heart


## What (not) to store

Think about 
1. what state needs to be shared across your app.
2. whether it respects the Redux principles 

E.g.: Teacher list, Courses list 


-> Takeaway 3: Think about what state relations are needed in your app

What NOT to store:
State that cannot respect the principles, e.g.:
- mutual state (Leaflet instance)
Nuance: technically you can, by configuration, but you should not use it
- or short-lived and small-scoped state

Where do we store this state? Angular Service!


## Hierarchical modules, hierarchical state
Identify state modules in your app.
Each feature module can import state module for state that it needs.

Explain ![](https://ngrx.io/generated/images/guide/store/state-management-lifecycle.png)
- Each state module can contain Selectors, Store, Reducer, Actions, Effects (and services) 
- Not components, as they are in the View Component Modules 
- The components can use the state as their module import the state module.

Split up state modules when in doubt!
If the specific teacher page shows all its courses, it does not mean teacher and courses should be part of the same state module.

- TeachersStateModule
  - TeacherStateModule
  - CoursesStateModule


AppStateModule: Implement Cross-cutting concerns here: Showing/Hiding Panels/Dialogs, Online/Offline behavior,

State modules can use parents and if imported siblings
State modules cannot use their children (and you should not want to). If you want, use router to navigate!

Hierarchical state also on folder level!

E.g. when a different teacher is chosen, the course module can use that state.

-> Takeaway 4: Use the scalable, hierarchical power of the Store


## Sharing state
- /projects/1/customers (customer subset)
- /customers (all customers)

It's possible to create a CustomerState module and reuse it, but note it also reuses the actual customer state!
Consider a separate ProjectCustomerStateModule
Ask yourself: Do sibling/child modules need this state?
 If yes, create a separate state module.

-> Takeaway 5: Think about state scope


## State ownership

Store vs ComponentStore 
- Store:
  - Centralized immutable state
  - Fits well for the hierarchy of your app, pages, routing
  - Tooling (DevTools)

- Component Store
  - Local immutable state
  - Fits for components with complex state that need to be instantiated multiple times
  - Tooling lacking, less scalable but more flexible

Explain ![](https://ngrx.io/generated/images/guide/component-store/state-structure.png)


  


# Conclusion:
- -> Takeaway 1: The hierarchical module tree of your app should match the domain
- -> Takeaway 2: Think about what state relations are needed in your app
- -> Takeaway 3: Take the Redux principles to heart
- -> Takeaway 4: Use the scalable, hierarchical power of the NgRx Store
- -> Takeaway 5: Think about state scope
- -> Takeaway 6: Use the flexibility and isolation of the ComponentStore
