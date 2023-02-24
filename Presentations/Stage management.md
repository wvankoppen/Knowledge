Talk is not about the fundamentals of NgRx.
Why not? Getting Started Course alone takes already more than half a day: https://app.pluralsight.com/library/courses/angular-ngrx-getting-started/table-of-contents
The Newest stuff in v15: https://ngrx.io/guide/migration/v15

Goal: What are the main takeaways to have a sound app architecture using NgRx?
Questions:
- How do I architect the state of my apps and components?
- What does state mean for apps 
- What does state mean for components

## Outline

###############################################

# What state means for apps and (library) components

## Do you need a state management framework?
For a simple app (TODO management app?) probably not.
A service with a subject holding the todo items probably suffices.
NgRx is not intended to make simple things even simpler.

Having said that, and if you have a complex app for which the state needs to be accessed by many components and services, and is impacted by actions from different sources.


# The domain must be leading 

- Teachers
  - Teacher
    - Courses

Create a module structure

- TeachersModule
  - TeacherModule
    - CoursesModule

Separate state modules when in doubt!
If your teacher1 page shows all its courses, it does not mean it should be part of the same state module.

- TeachersStateModule
  - TeacherStateModule
  - CoursesStateModule

Also take into account cross-cutting functionality:
AppStateModule: Good to implement Cross-cutting concerns here: Panels, Dialogs, IsOnline,

Hierarchical state also on folder level!
State modules can use parents and if imported siblings
State modules cannot use their children (and you should not want to), use router to navigate!
Let the feature modules load your state modules



## What state needs to be kept during app lifetime?
- /projects/1/customers (customer subset)
- /customers (all customers)

Can create a CustomerState module and reuse, but you also reuse the state!
Consider a separate ProjectCustomerStateModule
Do sibling/child modules need this state?

-> Keep in mind what state needs to be kept and shared during app lifetime


## What deep links do exist in your app?
E.g.
- /projects
- /projects/1
- /projects/1/items
- /projects/1/items/1

This could result in the following state modules:
- ProjectsState, 
- ProjectState, 
- ProjectItemsState, 
- ProjectItemState, 



- /customers
- /customers/1
- /customers/1/projects

If your customer page has a dialog to list the invoices for that customer, you could 

-> Keep in mind what can be deep linked!





## State management cardinality
### Module / singleton: 
Centralized immutable state
Hierarchy
Tooling (DevTools)
Inter-component communication

### Container component / NOT singleton

Container components usually need state, (not necessarily in components itself) either a service or a state management solution. Wire app state to your container components via Store.



### TODO
App state if you need the pros (Debugging, Actions), Component Store if you need multipe instances


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



Conclusion:
What must be the key takeaway?
