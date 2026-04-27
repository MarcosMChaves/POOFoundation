# OOPFoundation

###### CST | TADS | POO

Defines **Foundation** abstractions, classes and interfaces for teaching **Object-Oriented Paradigm in C#**. 

## Structures

### Packages
`NONE`

### Abstract Classes
`ADecimalValidation` *implements* `IDecimalValidation` : defines the `DecimalIsValid()` method

`ADoubleValidation` *implements* `IDoubleValidation` : defines the `DoubleIsValid()` method

`AIntegerValidation` *implements* `IIntegerValidation` : defines the `IntegerIsValid()` method

`AText` *implements* `ISanitization`, `ITextValidation` : defines methods 
- [x] `Sanitize()` : used to sanitize (remove) undesired characters
- [x] `TextIsValid()` : used to verify if string has only valid content
- [x] customized `ToString(mask)` : allows string formatting, e.g. formats **ABC123DEF** with mask '###.###-###' as **ABC.123-DEF**

### Interfaces
`IDecimalValidation`

`IDoubleValidation`

`IFloatValidation`

`IIntegerValidation`

`ISanitization`

`ITextValidation`

### Concrete Classes
`Currency` *extends* `ADecimalValidation`: it is used to create a currency object to represent a real world currency e.g. **BRL** as for **Brazilian Reais** or **GBP** as for **Great Britain Pound**, validating and retaining its value

`SanitizationPattern` : it is used to **standardize** different and more common sanitization patterns like `.CPF`="0-9" (only digits are valid) or `.CNPJ`="0-9A-Z" (digits and upper letters are valid)

`Text` *inherist* `AText` : it is used to create text objects to **validate** and **sanitize** its value

`Year` *extends* `AIntegerValidation` : it is used to create **year** objects and **validate** its value, e.g. **YearOfBirth**

## UML

**Class Diagram**

!(OOP-Foundation.png)

---
## NOTICE! 

This is a **NuGet** package aimed at teaching Object-Oriented Paradigm **concepts** to a specific group of students. 

---

Prof. Marcos M. Chaves
