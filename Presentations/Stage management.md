State Management in Angular using NgRx.

Talk is not about the fundamentals of NgRx.
Why not? Getting Started Course alone takes already more than half a day: https://app.pluralsight.com/library/courses/angular-ngrx-getting-started/table-of-contents
The Newest stuff in v15: https://ngrx.io/guide/migration/v15


Goal: What are the main takeaways to have a sound app architecture using NgRx?


## Outline

###############################################


## Do you need NgRx (or a state management framework in general)?
For a simple app (e.g. ToDo management), probably not.
A service having a Subject holding the todo items probably suffices.

So: NgRx is not intended to make simple things even more simple.
It is intended to make difficult things less difficult.

If you have a complex app for which:
- the state needs to be accessed by many components and services, 
- and is impacted by actions from different sources.


## The architecture of the app must be sound
A good start is to create feature modules per page

Sample domain model
- Teachers
  - Teacher
    - Courses

Create a feature module structure

- TeachersModule
  - TeacherModule
    - CoursesModule

These modules could be lazy loaded using the router config.

-> Hierarchical module tree should match de domain


## Use the Store for hierarchical state
Each feature module can import state module for state that it needs.

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

-> Keep in mind state is hierarchical


## What's the scope of state?
- /projects/1/customers (customer subset)
- /customers (all customers)

It's possible to create a CustomerState module and reuse it, but note it also reuses the actual customer state!
Consider a separate ProjectCustomerStateModule
Ask yourself: Do sibling/child modules need this state?
 If yes, create a separate state module.

-> Keep in mind what state is needed at which places in your app


## State ownership

Store vs ComponentStore vs Service
- Store:
  - Centralized immutable state
  - Fits well for the hierarchy of your app, pages, routing
  - Tooling (DevTools)

- Component Store
  - Local immutable state
  - Fits for components with complex state that need to be instantiated multiple times
  - Tooling lacking, less scalable but more flexible

- Service
  - Fits for short-lived, small-scoped state
  


# Conclusion:
- Domain model must be leading for decisions
- Hierarchical state
- State scope
- State lifetime

