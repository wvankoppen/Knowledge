State Management in Angular using NgRx.

This talk is not a "Getting Started" or "Fundamentals" course about NgRx.

Did you ever have questions like: 
- How do I set up a sound architecture of my app using NgRx?
- I'm working on an app that uses NgRx, but I'm not sure how to improve its architecture.

I like to give you my personal takeaways on this.


## Outline
- Intro: What is NgRx? (1 min)  
- State metrics (6 min)  
  ( In order to leverage the power of NgRx, it's important to have a solid understanding about the state needed in your app
the following metrics help with that
)

  - Immutability & serializability 
  - Ownership 
  - Scope (where is which part of state needed, e.g. global, local or somewhere in between)
  - Lifespan (what it is, what it means for architecture)

- NgRx (5 min)
  (I will show the Store and ComponentStore)
  - NgRx Store
  - NgRx ComponentStore

(
There are no straightforward answers as every app is different.  Though I can help you make the right choice using my takeaways)

- My takeaways for improving architecture: (10 min)
  
  
# NgRx
- a framework for building reactive applications in Angular 
- not intended to make simple things even more simple. It is intended to make difficult things less difficult.

Do I need it?
Simple answer: If you do need a State Management framework, you know you need it.

So: For a simple app (e.g. ToDo management), it's probably not needed.
A service having a Subject holding the todo items probably suffices.

For a complex app though, it can be a decent choice.

In order to make a sound choice for architecting your state, hereby the metrics that you need to think about.

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
- global / app wide (online / offline, current dialog, current panel)
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






## NgRx Store

Ask: Who knows this diagram? Please raise hand.

Explain ![](https://ngrx.io/generated/images/guide/store/state-management-lifecycle.png)


1. Single source of truth (Store)
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





## NgRx Component store

- Immutability & serializability: Uses the Redux principles
- Scope: Small scope
- Ownership & lifespan: Component-owned, short-lived state

  - Fits for components with complex state that need to be instantiated multiple times
  - Tooling lacking, less scalable but more flexible


Explain ![](https://ngrx.io/generated/images/guide/component-store/state-structure.png)



Short recap: Store vs ComponentStore






# Takeaways

## Design app hierarchy driven by domain
The more your app architecture is sound, the more advantages you can leverage of NgRx.

It's recommended to have separate feature module per page.
- Recommended even further: Feature module per Organism (Atomic Design).


### Sample domain model
Teachers, Students, Courses

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


So if you have a TeachersModule and CoursesModule, in which all components are placed, it will be difficult to leverage NgRx.

Outcome: A hierarchical, modular separation of your view components






## Think about state ownership and lifespan: Module or component?
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






## Think about State immutability & serializability
- If pieces of state are mutable, check whether you can make it immutable. If it cannot, eg leaflet, use a Service
- If pieces of state are unserializable, check whether you can make it serializable (store raw, remove cycles)
  If you need cyclic data, consider to transform this in a selector or pipe




# Conclusion:
State
- Immutable and serializable state
- Scope, Ownership & Lifespan 

NgRx
- Store and ComponentStore

- Steps for improving architecture:
  - Design an app hierarchy driven by domain (with module tree and routing)
  - Think about state ownership and lifespan: Module or component?
  - Think about state scope
  - Think about State immutability & serializability
