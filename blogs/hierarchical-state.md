# Hierarchical state


If we see the domain model of an app, it is usually hierarchical.

Example: In our app, we can open a project. Once the r
Consider the following domain model:

- projects
  - current project
    - templates
    - topology
      - current zone
- library


We can organize our project in a tree, but also in a list:

- projects
  - project
- templates
- topology
  - current zone
- library

## Pros of file structure in a list
- can be easier to navigate, needs less width to show in de IDE

## Pros of file structure in a tree
- dependencies, lazy loading is transparent:
  - you are allowed to import parent and sibling modules, but not allowed import childs

I tend to always use a hierarchical structure on folder level, as it makes the dependencies transparent. 
