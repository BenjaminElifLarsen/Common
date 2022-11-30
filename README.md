# Common

This library contains the 'common' patterns and other things that I use for project development i C Sharp.
The files here are mainly contracts, in form of interfaces, and it is expected that systems that usage this module should provide the implementations.

The libary requires the usages of C Sharp 11 or the preview for it.

These are:
- CQRS
- Repository Pattern
- Result Pattern
- Specification Pattern
- Binary Flag
- Events
- Process Manager
- Memento Pattern
and more 

## Notes

It should be noticed that the Result Pattern does not contain the extension used to map results to HTTP status codes. This is because the mapping can rely on framework like Asp.Net Core.

For the Repository Pattern, the IBaseRepository should be implemented by classes that use a specific ORM, like EntityFrameWorkRepository for EntityFramework Core. 
Thus the base model is not coupled to a specific ORM.

Regarding the Specification Pattern it should be noticed that I am using my binary flag for the validation. The binary flag class was designed to help add, compare, and transport binary flags and can thus handle both int32 and enums and contains overwriten operators. 
Under the Specification Pattern folder there are contrats for converting a binary flag into a collection of errors (strings) and validation. Do note that IErrorConversion contains abstract static methods, which is first coming with C Sharp 11 and IDEs, at least Visual Studio 2022, flags these as errors (VS 2022 can still compile them) when using the language preview.

It shall be pointed out that I am currently learning and praticing Process Manager, Mememnto pattern, and Events, thus these contracts are not finalised and may change as I read and pratice them more.



