# SOLID


### Principles:
- Encapsulation: The bundling of data together with the methods that operate on that data. Information   hiding is used to hide data, preventing undesired   access to it.
- Abstraction: Use simple   things to represent complexity. E.g.: we know how to turn the TV on, but we   don’t need to know how it works in order to watch it.
- Inheritance: Create new   types that share some of the attributes of existing classes. This lets us   build on previous work without reinventing the wheel.
- Polymorphism: Each   method that expects a base type, will automatically except any derived types   from it.


### Acronym

|            SRP             |       OCP                                  |   LSP                    |          ISP               | DIP                        |
|-------------------------|-----------------------------------------|-----------------------|-------------------------|-------------------------|
|     Robert C. Martin    |     Bertrand Meyer (Eiffel language)    |     Barbara Liskov    |     Robert C. Martin    |     Robert C. Martin    |
|    |     |     In polymorphism, the is-a relationship must be threated as a can-be-substituted-for relationship. If an object quacks like a duck, and walks like a duck, but needs batteries, probably you have the wrong abstraction.   |    Use Role interfaces instead of Header interfaces.   |         |
|          ![](solid/srp.jpg)               |     ![](solid/ocp.jpg)                                    |      ![](solid/lsp.jpg)                 |              ![](solid/isp.jpg)           |           ![](solid/dip.jpg)              |

### Code problems that SOLID addresses:
- Rigidity:	Difficult  to change
- Fragility:	Easy to break
- Immobility:	Difficult to reuse
- Viscosity:	Difficult to do the right thing


### Interfaces
- Header interface: An interface extracted from a class containing all public members (thus, presumably one implementer). Not an abstraction.
- Role interface: An interface as an abstraction.
Being able to implement a meaningful Composite is a good indication of a sound interface.

https://blog.ploeh.dk/2010/12/03/Towardsbetterabstractions
