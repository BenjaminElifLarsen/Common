# Common

This library contains the 'common' patterns that I use for project development i C Sharp.

These are:
- CQRS
- Repository Pattern
- Result Pattern
- Specification Pattern

## Notes

It should be noticed that the Result Pattern does not contain the extension used to convert results to HTTP status codes.

For the Repository Pattern, the IBaseRepository should be implemented by classes that use a specific ORM, like EntityFrameWorkRepository for EntityFramework Core. 
Thus the base model is not coupled to a specific ORM.

The Specification Pattern will normally be altered when I use it. The extension will not be used as I perfer to know which ISpecification implementation that failed.
At the same time only runs until the first invalidation and I like to let the user know all validation errors at ones rather than one at a time. 
The reason for the extension and non-binary flag version is given here is because it is the most basic version, which I will not remove from when using it in other projects. Do note that I am currently reading up on Martin Fowler´s Specification for the purpose of implementing a better version than the one present here.
