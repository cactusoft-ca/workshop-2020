## Contributing

These instructions will show you the required conventions to work on this project. Respecting conventions helps to have a cleaner code and a better understanding of a project.

## Table of Contents

* [Coding conventions](#coding-conventions) 
  * [Naming](#naming)
  * [Style](#style)
  * [Design and patterns](#design-and-patterns)
* [Testing conventions](#testing-conventions) 
  * [Class naming](#class-naming)
  * [Project structure](#project-structure)
  * [Test plan](#test-plan)
  * [Test naming](#test-naming)
* [Adding a new project](#adding-a-new-project) 
* [Commit conventions](#commit-conventions) 
* [Releases](#releases)
* [Creating a new version](#creating-a-new-version)
* [Pull Requests conventions](#pull-requests-conventions)

### Coding conventions

#### Naming
Naming conventions for this project are pretty much default C# conventions with the following exceptions:
- Private members in a class should respect the PascalCase casing.

#### Style
- Encourage guard clauses for conditional logic when possible. It has the advantage of reducing nested if/else logic in the code.
- Use empty string literals (`""`) instead of `string.Empty`
- Prefer `null` to empty or default values (e.g. `""`, 0, etc.), whenever you want to convey the data or information is missing

#### Design and patterns
- Design with testing in mind
- Avoid the use of static classes or members (I'm looking at you, _Singleton_.)
- Prefer composition over inheritance to share behavior
- Prefer inheritance over composition when polymorphic behavior reduces code complexity

### Branching model

When starting a new feature, branch off of `develop`. Your branch should respect the following pattern:

1. `feature/WSP-xxxx-descriptive-name` for feature branches
2. `bugfix/WSP-xxxx-descriptive-name` for bugfixes
3. `hotfix/WSP-xxxx-descriptive-name` for hotfixes

 For bigger features, using sub-feature branches is encouraged. If you do, please follow the following pattern: `feature/WSP-xxxx/sub-feature-description`. These branches should ultimately be merged into your _integration branch_ (`feature/WSP-xxxx-descriptive-name`).

 ```
feature/WSP-1234/my-other-sub-branch                            ————————
                                                                /        \
feature/WSP-1234/my-sub-branch         ——————————————————     /          \
                                       /                  \   /            \
feature/WSP-1234-my-feature          ————————————————————————————————————————
                                     /                                        \
develop                            —————————————————————————————————————————————
                                   /                                             \
master                           —————————————————————————————————————————————————
 ```

### Testing conventions
In the project, we aim to follow the one-test-class-per-class pattern. This way, if you want to find the tests for a given class, you just need to search for the following file: {TheClass}Tests.

#### Class naming

<b>Unit tests:</b> 

For unit tests, you pretty much always know which class you want to test. So name your class using the class name + Tests.
 ```
 Example:
 If you want to test the calculator class, your class name would be:
 CalculatorTests
 ```
 
<b>Integration tests:</b>
 
Integration tests are a bit different. Generally, you want to test multiple parts of the application together or the architecture.

With this in mind, try to name your class by the concept that is being tested + Tests. Generally, a concept ends with "ing" at the end. (Versioning, logging)
  ``` 
 Example:
 If you want to test how the application automatically logs controller actions, your class name could be:
 ControllerLoggingTests 
 ```
#### Project structure

Do not put unit tests and integration tests in the same project. Considering that integration tests take a lot more time to execute, we want them separated so that we can have the possibility to only run unit tests in certain situations if wanted.
 
#### Test plan
When contributing to the project, follow these rules:

1. At least one integration test is needed for each controller action
2. At least one unit test should validate business logic when creating services

#### Test naming
When implementing test methods, follow this convention: MethodName_Scenario_ExpectedBehavior
  ```
 Example:
 If you want to test if by subtracting 3 to 9 you get 6, the test method name would be the following:
 Subtract_WhenSubtracting3to9_Returns6
 ```
 
### Adding a new project

When adding a new project, do not create a new solution (.sln) file. Link the new project to the already existing solution (.sln) file.

Once the project is added, there are a few steps to do before you can get started. 

1. Enable "Treat warnings as errors" in project properties.
  ```
Right click project 🡒 Properties 🡒 Build 🡒 Set treat warnings as errors to "All"
 ```
 
2. Add StyleCop.Analyzers NuGet package to project.
  ```
Right click project 🡒 Manage NuGet packages 🡒 Browse and install StyleCop.Analyzers
 ```

3. Add a file link to GlobalSupression.cs file.
  ```
Right click project 🡒 Add 🡒 Existing item 🡒 Go to project root 🡒 From the Add button drop-down list, select Add As Link
 ``` 

### Commit conventions

#### The five rules of a great Git commit message

1. Limit the subject line to 50 characters
2. Capitalize the subject line
3. Do not end the subject line with a period
4. Use the imperative mood in the subject line
5. Use the body to explain what and why vs. how

#### Why the five rules exist

<b>1. Limit the subject line to 50 characters <br/></b>
50 characters is not a hard limit, just a rule of thumb. The goal is to have the most concise way to explain what's going on. <br/> <br/>
<b>2. Capitalize the subject line <br/></b>
This is as simple as it sounds. It's just cleaner. <br/><br/>
<b>3. Do not end the subject line with a period <br/></b>
Space is precious when trying to have 50 characters commit messages. <br/><br/>
<b>4. Use the imperative mood in the subject line <br/></b>
Imperative mood just means “spoken or written as if giving a command or instruction”. 

Try to make your commit subject like the ones that git offers. 

Let's say that you merge a branch. Git default message would be: Merge branch 'myfeature'. Notice that the action is not in the past tense.

Furthermore, you can start the subject line with a type of commit.

- Feat: The new feature you're adding to a particular application
- Fix: A bug fix
- Style: Feature and updates related to styling
- Refactor: Refactoring a specific section of the code base
- Test: Everything related to testing
- Docs: Everything related to documentation
- Chore: Regular code maintenance.

<b>5. Use the body to explain what and why vs. how<br/></b>
If you need to add more details to your commit, feel free to use the body. The subject line should be as short and precise as possible.

#### TLDR

You should commit every time a new "action" has been added to the code base.

For example. Let's say your goal is to create a simple calculator. The calculator can add, subtract, multiply and divide.

The good way to commit would be to make 4 commits.

1. Feat: Add "add" operator to calculator
2. Feat: Add "subtract" operator to calculator
3. Feat: Add "multiply" operator to calculator
4. Feat: Add "divide" operator to calculator

The bad way to commit would be to make this commit.

1. added 4 new operators to the calculator object.

So if you feel as if you can't name your commit with an action, maybe the modification to the code base is too small.
With the same idea, if you feel as if you need 200 characters to explain the modification that you've made, maybe you should have committed more often.
