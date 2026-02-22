# Dot-Net-Training

A comprehensive C# and .NET training project covering fundamental concepts through advanced topics including OOP, inheritance, interfaces, LINQ, threading, unit testing, and more.

## 📋 Table of Contents

- [Overview](#overview)
- [Project Structure](#project-structure)
- [Key Topics Covered](#key-topics-covered)
- [Getting Started](#getting-started)
- [Running Tests](#running-tests)
- [Project Details](#project-details)

## 🎯 Overview

This project is a complete C# learning journey from basics to advanced topics. It includes practical examples, assignments, and unit tests demonstrating real-world coding practices.

**Latest Additions:** MoreQuestions modules, M1 practice sets, Async/Await practice, String/Ado.NET tracks, and scenario-based problem folders

## 📁 Project Structure

```
Dot-Net-Training/
├── DOTNET.slnx                    # Solution file
├── Notes.txt                      # Training notes
├── README.md                      # Repository guide
├── Apps/                          # Standalone demo applications
├── Day-01-Basics/                 # Basic C# concepts
├── Day-02-Control/                # Control flow assignments
├── Day-03-Oops/                   # Object-oriented programming
├── Day-04-Inheritance/            # Inheritance concepts
├── Day-05-Abstract-Inheri/        # Abstract class practice
├── Day-06-Interface/              # Interface implementation
├── Day-07-Multiplnheritance/      # Multiple inheritance patterns
├── Day-08-FolderStruct/           # Folder structure exercises
├── Day-09-Indexer-Static/         # Indexers and static members
├── Day-10-ExtenAndRegEx/          # Extensions and regex
├── Day-11-Serialization-Delegates/# Serialization and delegates
├── Day-12-Reflection/             # Reflection exercises
├── Day-13-Enum/                   # Enumerations
├── Day-14-LINQ/                   # LINQ queries
├── Day-15-Generic-And-Threads/    # Generics and threading
├── Day-16-PracticeQuestions/      # Practice problems
├── Day-17-MoreQuestions/          # Additional questions
├── Day-18-Attributes/             # Custom attributes
├── Day-19-PettyCash-Manager/      # Petty cash manager project
├── Day-20-PracticeQuestions/      # Exception/string/interface practice
├── Day-21-Unit-Testing/           # NUnit + Moq projects
├── Day-22-TopicwisePrac/          # Topic-wise practice
├── Day-23-TopBrainAssesment/      # Assessment tasks
├── Day-24-ExceptionHandlingQues/  # Exception handling scenarios
├── Day-25-MoreQuestions/          # GymStream, LMS, Logistics
├── Day-26.1-M1QuesPrac/           # Module-1 scenario practice
├── Day-26.2-AsynchAwait/          # Async/Await practice
├── Day-27-StringQues/             # String question set
├── Day-28-Ado.NetTrial/           # ADO.NET trial work
├── Day-28.2-CollectionModerate/   # Collection moderate-level practice
├── Day-29-Ado.NetwithLinq/        # ADO.NET with LINQ practice
├── FlexibleInventorySystem_Prctice/ # Inventory practice project
├── GenericAndDelegate/            # Generic + delegate practice
├── OopsQuestions/                 # OOP practice questions
├── PracticeQuestion/              # General practice set
├── ScenarioBased10Feb/            # Scenario-based exercises
├── ScenarioBasedCollectionQuestions/ # Collection scenario questions
└── StrinPracQuestions12Feb/       # String practice questions
```

## 🎓 Key Topics Covered

### Beginner
- ✅ Variables, Data Types, and Operators
- ✅ Control Flow (if-else, switch, loops)
- ✅ Methods and Functions

### Intermediate
- ✅ Object-Oriented Programming (Classes, Objects)
- ✅ Inheritance and Polymorphism
- ✅ Abstract Classes and Interfaces
- ✅ Exception Handling
- ✅ Collections and Generics

### Advanced
- ✅ LINQ (Language Integrated Query)
- ✅ Delegates and Events
- ✅ Reflection
- ✅ Threading and Async Programming
- ✅ Custom Attributes
- ✅ Serialization
- ✅ Regular Expressions

### Testing & Best Practices
- ✅ Unit Testing with NUnit
- ✅ Mocking with Moq
- ✅ Test-Driven Development (TDD)
- ✅ AAA Pattern (Arrange-Act-Assert)

## 🚀 Getting Started

### Prerequisites

- **Visual Studio 2022** or **VS Code**
- **.NET 10.0** SDK or higher
- **NUnit** (for testing)
- **Moq** (for mocking)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/Dot-Net-Training.git
cd Dot-Net-Training
```

2. Open in VS Code:
```bash
code .
```

3. Restore NuGet packages:
```bash
dotnet restore
```

## 🧪 Running Tests

### Run All Tests
```bash
cd Day-21-Unit-Testing/EmployeeApp.Tests
dotnet test
```

### Run Specific Test Class
```bash
dotnet test --filter "CalculatorTests"
dotnet test --filter "EmpService2Tests"
dotnet test --filter "EmployeeServiceTests"
```

### Run with Verbose Output
```bash
dotnet test --verbosity detailed
```

### View Test Coverage
```bash
dotnet test --collect:"XPlat Code Coverage"
```

## 📚 Project Details

### Day-21-Unit-Testing (Latest)

**Core Components:**
- `Calculator.cs` - Basic arithmetic operations (Add, Subtract, Multiply, Divide, Modulus)
- `EmployeeService.cs` - Employee repository management
- `EmpService2.cs` - Custom employee service implementation
- `EmpService3.cs` - Alternative employee service implementation

**Test Files:**
- `CalculatorTests.cs` - 14 comprehensive calculator tests
- `EmployeeServiceTests.cs` - Employee service mocking tests
- `IEmpRepo2Test.cs` - Interface implementation tests with Moq

**Test Coverage:**
- ✅ Normal operations
- ✅ Edge cases (zero, negative numbers)
- ✅ Exception handling
- ✅ Multiple scenarios with TestCase attribute
- ✅ Mocking with Moq framework

### Test Examples

#### Calculator Test (Direct Testing)
```csharp
[Test]
public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
{
    // Arrange
    var calculator = new Calculator();
    int a = 5, b = 3;
    
    // Act
    int result = calculator.Add(a, b);
    
    // Assert
    Assert.That(result, Is.EqualTo(8));
}
```

#### Employee Service Test (Mocking)
```csharp
[Test]
public void GetEmployeeCount_ReturnsCorrectCount()
{
    // Arrange
    var mockRepo = new Mock<IEmployeeRepository>();
    mockRepo.Setup(r => r.GetAll()).Returns(new List<Employee> 
    { 
        new Employee { Id = 1, Name = "Ravi", Salary = 50000 }
    });
    var service = new EmployeeService(mockRepo.Object);
    
    // Act
    int count = service.GetEmployeeCount();
    
    // Assert
    Assert.That(count, Is.EqualTo(1));
}
```

## 🔍 Key Concepts Demonstrated

### Unit Testing Patterns
- **AAA Pattern**: Arrange-Act-Assert
- **SetUp/TearDown**: Test initialization and cleanup
- **TestCase**: Parametrized testing with multiple inputs
- **Mocking**: Using Moq for dependency injection

### Best Practices
- ✅ Descriptive test names
- ✅ Single responsibility per test
- ✅ No test interdependency
- ✅ Comprehensive edge case coverage
- ✅ Clear assertion messages

## 📖 Learning Resources

### NUnit Documentation
- [NUnit Official Site](https://nunit.org/)
- [NUnit Assertions](https://docs.nunit.org/articles/nunit/writing-tests/assertions/assertion-models/constraint-model.html)

### Moq Documentation
- [Moq GitHub](https://github.com/moq/moq4)
- [Moq Quickstart](https://github.com/moq/moq4/wiki/Quickstart)

### C# Documentation
- [Microsoft C# Guide](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [LINQ Tutorials](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)

## 🛠️ Technologies & Tools

| Tool | Version | Purpose |
|------|---------|---------|
| .NET | 10.0+ | Runtime Framework |
| C# | 12+ | Programming Language |
| NUnit | 6.1+ | Unit Testing |
| Moq | 4.x | Mocking Framework |
| VS Code | Latest | IDE |

## 📝 Assignments Summary

### Day-02 Control Flow
- Armstrong Number, Fibonacci, Prime Numbers
- Banking System, Guessing Game
- Diamond and Pascal Triangle Patterns

### Day-20 Exception Questions
- Exception handling patterns
- String manipulation
- Interface implementation

### Day-21 Unit Testing
- Calculator tests (14 tests)
- Employee service tests (3 tests)
- Employee repository tests (14 tests)
- Interface mocking tests (3 tests)

**Total: 34+ comprehensive unit tests**

## 🎯 How to Use This Repository

1. **For Learning**: Go through each day's folder sequentially
2. **For Reference**: Check specific topics under their respective days
3. **For Testing**: Run the unit tests in Day-21 to see TDD in action
4. **For Practice**: Complete the assignment files in each day's folder

## 🤝 Contributing

To contribute to this project:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/improvement`)
3. Commit your changes (`git commit -am 'Add new tests or examples'`)
4. Push to the branch (`git push origin feature/improvement`)
5. Submit a Pull Request

## 📄 License

This project is open source and available under the MIT License.

## 👤 Author
  
GitHub: [@Fleek691](https://github.com/Fleek691)

## 📞 Support

For questions or issues:
- Open an issue on GitHub
- Check existing documentation
- Review test files for usage examples

---

**Last Updated:** February 2026  
**Project Status:** Active Development  
**Latest Focus:** Mixed practice across testing, async, strings, collections, and ADO.NET/LINQ
