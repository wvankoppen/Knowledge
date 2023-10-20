State Management in Angular using NgRx.

This talk is not a "Getting Started" or "Fundamentals" course about NgRx.

Did you ever have questions like: 
- How do I set up a sound architecture of my app using NgRx?
- I'm working on an app that uses NgRx, but I'm not sure how to improve its architecture.

I like to give you my personal takeaways on this.

# About me
•Wouter van Koppen
•36 years old
•Live in Delft
•Like backpacking, photography, cooking
•Electrical Engineering & Computer Science
•Started at Priva in 2013
Interested in JavaScript, Angular, Reactive programming, State Management

# Outline
- About me (1 min)  
- Intro: What is NgRx? (2 min)  
- State metrics (7 min)  
  ( In order to leverage the power of NgRx, it's important to have a solid understanding about what kind of state is needed in your app
the following metrics help to gain insight.
)

  - Immutability & serializability 
  - Ownership 
  - Scope (where is which part of state needed, e.g. global, local or somewhere in between)
  - Lifespan (what it is, what it means for architecture)

(
There are no straightforward answers as every app is different. Though I can help you make a sound choice using my takeaways)

- My takeaways for improving architecture: (10 min)
  
  
# NgRx
- a framework for building reactive applications in Angular 
- Manage global and local state in a scalable way
  - not intended to make simple things even more simple. It is intended to make difficult things less difficult.
  - For a simple app (e.g. ToDo management), it's probably not needed.
A service having a Subject holding the todo items probably suffices.

For a complex app though, it can be a decent choice.

In order to make a sound choice for architecting your state, hereby the metrics that you need to think about.

# State metrics

## State Immutability & serializability
What is state? -> A representation of what happened so far in our application

String
Number
Bigint 
Boolean
Undefined
Null
Symbol
Object -> Promise, Map, Set, ArrayBuffer, Blob, HTMLElement, etc


- The first 7 can are serializable & immutable
- object can be both also, but only if you don't mutate it yourself
- third party types that are stored as 
- data in pure form (without logic) is usually both, use Object.freeze to be sure
- both are important,
  - immutability to be sure for state to track changes 
  - serializability for state persistence / rehydration from storage

## State scope
(In how many places in your can a piece of state be used)
State can be
- global / app wide (online / offline, current dialog , current panel)
- specific feature of the app (Open a project, this current project context is needed at many places), 
- local / only needed inside a specific (Container)Component

## State lifespan
(When state created and destroyed)
- When app is starts
- When module is loaded
- When component is instantiated
  (if I destroy and re-create a certain component that needs state, must the state still be there? )

## State ownership 
(Who creates and destroys a piece of state)
- An Angular (feature) Module 
- An Angular Component (PrivaFilter, state is not needed outside this component, and 2 filters is 2 states)
(can there be more components?)
(if 2 of the same components are instantiated, do I expect them to be of the same state? )

Short recap of these state metrics: Immutability, serializability, scope, lifespan, ownership



•
•



# Takeaways

## Design app hierarchy driven by domain
The more your app architecture is sound, the more advantages you can leverage of NgRx.

It's recommended to have separate feature module per page.
- Recommended even further: Feature module per Organism (Atomic Design).


### Sample domain model
Teachers, Students

List of teachers, list of students



### Sample app hierarchy

- Teachers      (/teachers)
  - Teacher     (/teachers/1)
    - Students  (/teachers/1/students)

Create a feature module structure

- AppModule  
  - TeachersModule
    - TeacherModule
      - TeacherStudentsModule


If the domain also contains:
- Students
  - Student
    - Teachers

then you probably need

- AppModule
  - StudentsModule
    - StudentModule
      - StudentTeachersModule


These modules could be lazy loaded using the router config. This will also apply for feature state modules as we'll see later.


So if you have a TeachersModule and StudentsModule, in which all components are placed, it will be difficult to leverage NgRx.

Outcome: A hierarchical, modular separation of your view components



## Think about State immutability & serializability
- If pieces of state are mutable, check whether you can make it immutable. If it cannot, eg leaflet, use a Service
- If pieces of state are unserializable, check whether you can make it serializable (store raw, remove cycles)
  If you need cyclic data, consider to transform this in a selector or pipe



## Use NgRx Store for Module-owned state

Ask: Who knows this diagram? Please raise hand.

Explain ![](https://ngrx.io/generated/images/guide/store/state-management-lifecycle.png)



1. Single source of truth 
2. State is read only
3. Changes are made via pure functions (reducers)

Advantages:
- Centralized, immutable state (hydrate state via LocalStorage)
- Performance (OnPush)
- Tooling! (look whether state correct, no logging)
- Component communication (inject Store)



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


What NOT to store:
State that cannot respect the principles, e.g.:
- mutual state (Leaflet instance)
  Nuance: technically you can, by configuration, but you should not use it





### Use NgRx Component store for component-owned state

- Immutability & serializability: Uses the Redux principles
- Scope: Small scope
- Ownership & lifespan: Component-owned, short-lived state

  - Fits for components with complex state that need to be instantiated multiple times
  - Tooling lacking, less scalable but more flexible


Explain ![](https://ngrx.io/generated/images/guide/component-store/state-structure.png)










- For component-owned state, consider NgRx ComponentStore (or an Angular service, declare in ElementInjector)
- For module-owned state, separate in state modules (imp!) for the app hierarchy (or use standalone API )
- Separation enables Lazy loading:

  - TeachersStateModule
    - TeacherStateModule


## Think about state scope


State modules can use parents and if imported siblings
State modules cannot use their children (and you should not want to). If you want, use router to navigate!

E.g. when a different teacher is chosen, the students module can use that state.


E.g. AppStateModule has app-wide scope: Implement Cross-cutting concerns here: Showing/Hiding Panels/Dialogs, Online/Offline behavior,

  - Don't mix long and small scoped state in a single state module (remember app hierarchy)
  - Use the app domain hierarchy to group slices of state in state modules



If the specific teacher page shows all his students (where students is not a separate page), it does not automatically mean teacher and student should be part of the same state module.
Split up state modules when in doubt!

- TeachersStateModule
  - TeacherStateModule
  - StudentsStateModule

Why? Because tomorrow it might be a separate page, and then you need to split anyway.


If we also would have extra:

- Students      (/students)

Could we reuse the StudentsStateModule module students list?
-> That would interfere with the TeacherStudentList 
Could we reuse the StudentsStateModule module with a separate list?
-> Technically yes, but note the scope of the existing module is smaller (lazy loading!).
It's better to separate (rename existing module to TeacherStudentsStateModule!


Outcome: Hierarchical state also on folder level!










# Conclusion:
State
  - Immutability, Serializability, Scope, Ownership & Lifespan

- Takeaways for improving architecture:
  1. Design an app hierarchy driven by domain (with module tree and routing)
  2. Use the NgRx Store for module-owned state
    - Can be both wide and small-scoped
    - Usually long-lived 
  3. Use the NgRx ComponentStore for component-owned state
    - Only for small-scoped state
    - Usually short-lived
  4. Avoid mutable state, when impossible use a Service
    - Use the Injector to denote scope
