State Management in Angular using NgRx.

This talk is not a "Getting Started" or "Fundamentals" course about NgRx.

DO you ever have questions like: 
- How do I set up a sound architecture of my app using NgRx?
- I'm working on a NgRx project but not sure how to improve the architecture.

I like to give you my personal takeaways on this.


## Outline
- Do I need NgRx?
- Redux principles
- App architecture: Driven by domain
- Hierarchical modules, hierarchical state
- What (not) to store
- Sharing state
- State ownership



## Do I need NgRx?
Simple: If you do need a State Management framework, you know you need it.

So: For a simple app (e.g. ToDo management), it's probably not needed.
A service having a Subject holding the todo items probably suffices.

Note: Redux / NgRx is not intended to make simple things even more simple.
It is intended to make difficult things less difficult.

NgRx might be a good choice if you have a large, complex app for which the state:
- is big and needs to be accessed by many components
- and is impacted by actions from different sources.



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

-> Takeaway 1: The Redux principles 


## App architecture: Driven by domain
The more your app architecture is sound, the more advantages you can leverage of NgRx.

It's recommended to have separate feature module per page.
- Recommended even further: Feature module per Organism (Atomic Design).


### Sample domain model
Teachers, Students, Courses



### Sample app wireframe

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


-> Takeaway 2: The module tree of your app should match the domain


Ask: No surprises at this point, right?






## Hierarchical modules, hierarchical state
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



## What (not) to store

Think about
1. what state needs to be shared across your app.
2. whether the state respects the Redux principles

E.g.: Teacher list, Courses list


-> Takeaway 3: Think about what state relations are needed in your app

What NOT to store:
State that cannot respect the principles, e.g.:
- mutual state (Leaflet instance)
  Nuance: technically you can, by configuration, but you should not use it
- or short-lived and small-scoped state

Where do we store this state? Angular Service!



## Sharing state
- /customers (all customers) 
- /projects/1/customers (customer subset)

It's possible to create a CustomerState module and reuse it, but note it also reuses the actual customer state!
Consider a separate ProjectCustomerStateModule
Ask yourself: Do sibling/child modules need this state?
 If yes, create a separate state module.

-> Takeaway 5: Think about state scope


## State ownership
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

  


# Conclusion:
- -> Takeaway 1: The hierarchical module tree of your app should match the domain
- -> Takeaway 2: Think about what state relations are needed in your app
- -> Takeaway 3: Take the Redux principles to heart
- -> Takeaway 4: Use the scalable, hierarchical power of the NgRx Store
- -> Takeaway 5: Think about state scope
- -> Takeaway 6: Use the flexibility and isolation of the NgRx ComponentStore