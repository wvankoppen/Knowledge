State Management in Angular using NgRx.

This talk is not a "Getting Started" or "Fundamentals" course about NgRx.

Did you ever have questions like: 
- How do I set up a sound architecture of my app using NgRx?
- I'm working on an app that uses NgRx, but I'm not sure how to improve its architecture.

I like to give you my personal takeaways on this.


## Outline
- State 
  - Types of state (immutable & serializable state, the rest)
  - Scope (where is which part of state needed)
  - Ownership & lifespan (what it is, what it means for architecture)

- NgRx
  - Redux principles
  - NgRx Store
  - NgRx ComponentStore

- Steps for improving architecture:
  - Design app hierarchy (with module tree and routing)
  - Which state is needed where? (think about ownership)
  - Module-owned state:
    - Use state scope to identify state modules
    - If your state is mutable, check whether you can make it immutable (for Store). If it cannot, eg leaflet, that's fine.
      - For immutable state, use a Service.
    - If you need cyclic data, create it in a selector or pipe
  - For owner = component, consider ComponentStore or a service 


# State
State is the runtime representation of our application.
How does it affect architecture?

## Types of state
Let's make a separation between these 2 types:

- Serializable & Immutable state:
  String
  Number
  Boolean
  Array
  Object
  undefined or null

- the rest: 
  Date, Map, Set,
  Function
  Observable or Promise
  ArrayBuffer or Blob
  HTMLElement
  window and similar

## State scope
(where is which part of state needed)
State can be
- app-global (online / offline, current dialog, current panel)
- big part of the app (Open a project, this current project info is needed at many places), 
- For a (container) component (PrivaFilter?)

## State ownership & lifespan
- App / (Feature) Module 
- Component / Service

(if 2 components use the state, do I expect them to be the same? )



## State size



## NgRx?
NgRx is a framework for using the Redux implementation in Angular.

Simple: If you do need a State Management framework, you know you need it.

So: For a simple app (e.g. ToDo management), it's probably not needed.
A service having a Subject holding the todo items probably suffices.

Note: Redux / NgRx is not intended to make simple things even more simple.
It is intended to make difficult things less difficult.

NgRx might be a good choice if you have a large, complex app for which the state:
- is big and needs to be accessed by many components
- is impacted by actions from different sources.



## Redux principles

Principles:
1. Single source of truth (Store - explain later on what to store)
2. State is read only
3. Changes are made via pure functions (reducers)

Advantages:
- Centralized, immutable state (hydrate state via LocalStorage)
- Performance (OnPush)
- Tooling! (look whether state correct, no logging)
- Component communication (inject Store)




Principles are important, as not respecting them will not result in the advantages.
E.g. storing a non-serializable tree structure.




## NgRx Store
E.g.: Teacher list, Courses list


What NOT to store:
State that cannot respect the principles, e.g.:
- mutual state (Leaflet instance)
  Nuance: technically you can, by configuration, but you should not use it
- or short-lived and small-scoped state



Think about state hierarchy and how this fits your domain model.

Explain ![](https://ngrx.io/generated/images/guide/store/state-management-lifecycle.png)
Ask: Who knows this diagram? Please raise hand.
- Each state module contains a Store and Reducer(s), and possibly Actions, Effects (and services)
- Not components, as they are in the View Component Modules
- The components can use the state as their module import the state module.

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

-> Takeaway 4: Use the hierarchical, scalable power of the Store


## Component store
Up until now, the feature module was the owner of the state.

Store vs ComponentStore
- Store:
  - Module is owner
  - Centralized immutable state
  - Fits well for the hierarchy of your app, pages, routing
  - Tooling (DevTools)

- Component Store
  - Component is owner
  - Local immutable state
  - Fits for components with complex state that need to be instantiated multiple times
  - Tooling lacking, less scalable but more flexible



Explain ![](https://ngrx.io/generated/images/guide/component-store/state-structure.png)

- -> Takeaway 6: Use the flexibility and isolation of the NgRx ComponentStore




## Design hierarchy



## App architecture: Driven by domain
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









## State ownership
- /customers (all customers) 
- /projects/1/customers (customer subset)

It's possible to create a CustomerState module and reuse it, but note it also reuses the actual customer state!
Consider a separate ProjectCustomerStateModule
Ask yourself: Do sibling/child modules need this state?
 If yes, create a separate state module.




  


# Conclusion:
State
- Immutable and serializable state
- Scope, Ownership & Lifespan 

- Redux principles

- Steps for improving architecture:
  - Design app hierarchy 
  - Which state is needed where? 
  - Mutable state in service
  - Module-owned state: Store 
  - Component-owned state: ComponentStore 
