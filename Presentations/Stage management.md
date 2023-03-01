State Management in Angular using NgRx.

This talk is not a "Getting Started" or "Fundamentals" course about NgRx.

Did you ever have questions like: 
- How do I set up a sound architecture of my app using NgRx?
- I'm working on an app that uses NgRx, but I'm not sure how to improve its architecture.

I like to give you my personal takeaways on this.


## Outline
- State 
  - What is state? 
  - Immutability & serializability 
  - Scope (where is which part of state needed, e.g. current project context)
  - Ownership & lifespan (what it is, what it means for architecture)

- NgRx
  - What is NgRx?
  - Redux principles
  - NgRx Store
  - NgRx ComponentStore

- My takeaways for improving architecture:
  - Design app hierarchy driven by domain (with module tree and routing)
  - Which state is needed where in your app? (think about ownership)
  - Module-owned state:
    - Use state ownership and scope to group state inside modules 
    - If your state is mutable, check whether you can make it immutable (for Store). If it cannot, eg leaflet, that's fine.
      - For immutable state, use a Service.
    - If you need cyclic data, create it in a selector or pipe
  - For owner = component, consider ComponentStore or a service 


# State
## What is state?
State is the runtime representation of our application.
It can be any value: 

String, Number, Boolean, Array, Object, undefined or null, Date, Map, Set, Function, Observable or Promise, ArrayBuffer, Blob, HTMLElement, window and similar


## Immutability & serializability
Let's make a separation between these 2 types:

- Serializable & immutable state:
  String, Number, Boolean, Array, Object, undefined or null

- the rest: 
  Date, Map, Set, Function, Observable, Promise, ArrayBuffer, Blob, HTMLElement, window

## State scope
(where is which part of state needed)
State can be
- app-wide (online / offline, current dialog, current panel)
- specific feature of the app (Open a project, this current project context is needed at many places), 
- only needed inside a specific (Container)Component


## State ownership & lifespan
(who creates and destroys the state)
- An eagerly-loaded Feature Module 
- A lazy-loaded Feature Module 
- A Component (PrivaFilter, state is not needed outside this component, and 2 filters is 2 states)
(if 2 components use the state, do I expect them to be the same? )
(if I destroy and create the component, must the state still be there? )



## State complexity


## NgRx
NgRx is a framework for using the Redux implementation in Angular.

Note: Redux / NgRx is not intended to make simple things even more simple.
It is intended to make difficult things less difficult.

Do I need it?

Simple answer: If you do need a State Management framework, you know you need it.

So: For a simple app (e.g. ToDo management), it's probably not needed.
A service having a Subject holding the todo items probably suffices.

For a complex app though, it can be a decent choice.


## Redux principles

1. Single source of truth (Store - will come back to this later)
2. State is read only
3. Changes are made via pure functions (reducers)

Advantages:
- Centralized, immutable state (hydrate state via LocalStorage)
- Performance (OnPush)
- Tooling! (look whether state correct, no logging)
- Component communication (inject Store)




Principles are important, as not respecting them will not result in the advantages.
E.g. 
- storing a non-serializable tree structure. 
  - Then the content cannot be persisted e.g. in LocalStorage.
- storing a mutable object
  - Violates the principles



## NgRx Store

Ask: Who knows this diagram? Please raise hand.

Explain ![](https://ngrx.io/generated/images/guide/store/state-management-lifecycle.png)


- Each state module contains 
  - a Store and Reducer(s)
  - possibly Actions, Effects (and services)
- Not components, as they are in the View Component Modules
The components can use the state as their module import the state module.


Centralized immutable state
- Fits well for the hierarchy of your app, pages, routing
- Tooling (DevTools)

- Immutability & serializability:  The store implements the Redux principles
- Scope: Wide or small scope
- Ownership & lifespan: Module-owned, long-lived state


## NgRx Component store

- Immutability & serializability: Uses the Redux principles
- Scope: Small scope
- Ownership & lifespan: Component-owned, short-lived state

  - Fits for components with complex state that need to be instantiated multiple times
  - Tooling lacking, less scalable but more flexible




## Store vs ComponentStore

Explain ![](https://ngrx.io/generated/images/guide/component-store/state-structure.png)





## Design app hierarchy driven by domain
The more your app architecture is sound, the more advantages you can leverage of NgRx.

It's recommended to have separate feature module per page.
- Recommended even further: Feature module per Organism (Atomic Design).


### Sample domain model
Teachers, Students, Courses



### Sample app hierarchy

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


These modules could be lazy loaded using the router config. This will also apply for feature state modules as we'll see later.


So if you have a TeachersModule and CoursesModule, in which all components are placed, it will be difficult to leverage NgRx.




Ask: No surprises at this point, right?





## Which state is needed where

State for Students, Courses

- /courses (all courses) 
- /students (all students)
- /students/1 (current student)
- /students/1/courses (course subset)

It's possible to create a CoursesState module and reuse it for student courses, but note it also reuses the actual course state!
Consider a separate StudentCoursesStateModule
Ask yourself: Do sibling/child modules need this state?
 If yes, create a separate state module.


Cross-cutting concerns: Showing/hiding panels/dialogs/isOnline state



What NOT to store:
State that cannot respect the principles, e.g.:
- mutual state (Leaflet instance)
  Nuance: technically you can, by configuration, but you should not use it
- or short-lived and small-scoped state


## Module-owned state:
Use state scope to identify state modules
- If your state is mutable, check whether you can make it immutable (for Store). If it cannot, eg leaflet, that's fine.
- For immutable state, use a Service.
- If you need cyclic data, create it in a selector or pipe


If the specific teacher page shows all its courses, it does not automatically mean teacher and courses should be part of the same state module.
Split up state modules when in doubt!

- TeachersStateModule
  - TeacherStateModule
  - CoursesStateModule


AppStateModule: Implement Cross-cutting concerns here: Showing/Hiding Panels/Dialogs, Online/Offline behavior,

State modules can use parents and if imported siblings
State modules cannot use their children (and you should not want to). If you want, use router to navigate!

E.g. when a different teacher is chosen, the course module can use that state.


Hierarchical state also on folder level!


## Component-owned state
consider ComponentStore or a service
  


# Conclusion:
State
- Immutable and serializable state
- Scope, Ownership & Lifespan 

- Redux principles

- Steps for improving architecture:
  - Design app hierarchy 
  - Which state is needed where? 
  - Try to avoid mutable state, if not possible put it in service
  - Module-owned state: Store 
  - Component-owned state: ComponentStore 
