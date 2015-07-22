# Reporting Issues
**The issue tracker is not a support forum.** Unless you can provide precise *technical information* regarding an issue, you *should not post in it*. If you post support questions, generic messages to the developers or vague reports without technical details, they will be closed and locked.

If you believe you have a valid issue report, please post text or screenshots of the issue, along with the version / commit, any error messages and reproduction steps.

# Contributing
Coding style is very important when making commits, just try to follow as many of them as possible.

It's impossible for everyone to follow each rule perfectly, the rules are just a guide to help consistency and maintainability

### Class Structure
UnityNative projects are written with the [SOLID](https://en.wikipedia.org/wiki/SOLID) principle in mind. This also allows the projects to be used with [Inversion of Control](https://en.wikipedia.org/wiki/Inversion_of_control)

TL;DR **ALL** objects should be stored as their interface implementation (`IUnityNativeSharingAdapter`) and not the concrete (`AndroidUnityNativeSharingAdapter`). Public variables should be defined in the interface as properties (`int i { get; }`)

### Naming Rules
* Scope: Explicit e.g. `private int i;` `internal int i;` `public int i;`
* Functions: `PascalCase`
* Variables: `PascalCase` for `public` and `camelCase` for everything else, including `const`
* Classes: `PascalCase`
* Namespaces: `UnityNative.PROJECT.SCOPE` e.g. `UnityNative.Sharing.Adapters`
* Variable Ordering: Alphabetical
* Method Ordering: Static Methods, Constructor, Instance Methods

### Indentation/Whitespace Style
Do not use tabs, use 4-spaces instead.

### Comments
Comment all public methods

### Pull Requests
Make each pull request as small and clean as possible, if a change in a class isn't needed for what is being worked on, remove it from the PR.

The aim is to merge squash each commit into master, this allows the commits to be atomic and makes life a lot easier if a commit needs to be reverted

Include as much detail in each commit, this should include a condensed description as the PR title, and include details in the PR message, when squashed, the commit title should be the PR title with a link to the PR e.g. #101 Fixed bug in XYZ

### Releases
Each release will have it's own branch and GitHub release, this allows the specific releases of the project to be pulled with Unity's Package Manager 
