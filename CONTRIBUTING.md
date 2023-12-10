# Contributing

## How to contribute
Fixes for bugs, refactoring for efficiency, or simple reporting of poor performance such as errors are truly appreciated for the betterment of the program. The following enumerate several ways to contribute to this project:

### By reporting bugs

If you find a bug, please report it to the [issue tracker](https://github.com/mrwnmncd/peter-parking/issues) on GitHub. When reporting bugs, it is recommended that you make use of the provided template.

When filing your bug, please be as precise as possible. Bugs that can be reproduced by anyone are much easier to fix. If you can, please include a minimal test case that demonstrates the bug. This makes it much easier to track down the bug.

### By suggesting new features

If you have an idea for a new feature, please suggest it by creating a new [issue](https://github.com/mrwnmncd/peter-parking/issues) on GitHub. If you think that your feature is related to an existing issue, please mention it in your description.

### By writing code

If you want to contribute code, you can do so through GitHub by forking the repository and sending a pull request.

It is generally recommended that you create an issue on the [issue tracker](https://github.com/mrwnmncd/peter-parking/issues) on GitHub before you start working on writing codes. This allows us to discuss the feature and make sure that it is something that we want to add to the project. 

The flow will look something like this:

1. Fork the repository on GitHub
2. Create a named feature branch (like `add_component_x`)
3. Write your change
4. Test your change
5. Submit a Pull Request

We will review your pull request and either merge it, request changes to it, or close it with an explanation.

---

### Creating Issues and Reporting a Bug

When reporting an issue, please make sure to describe the error comprehensively.

- Make a concise and descriptive title, highlighting the essence of the bug
- Explain the observed behavior and its impact.
- If possible, state what you are expecting to happen and what actually happened.
- State what you did. Enumerate the exact steps needed to consistently reproduce the bug.
- Specify the operating system, program version, software version, and any relevant hardware details.
- If you have additional information, you may also include them such as any workarounds or related bug reports you've found. You may also include screenshots, screen recordings to illustrate the issue.


### Merging to Branch

Commits are expected to be made to appropriate branches. There is no limit with the number of branch nor is there any rule to creating other branches. However, there must be naming convention observed. 

The main branch of this repository is `master`. This branch should and must have the latest functional source codes and can be built or compiled seamlessly. 

#### Minimum Requirement for Branching
This repository is expected to have 3 fundamental branches namely: `master`, `docs`, and `cleanup`. 
- Branch **`master`** should never have any direct commit unless exceptional situations call for its necessity. 
- Branch **`docs`** may be committed to only when changes relate to the documentation of this repository or project. Comments in the codes should be made with the working branch associated unless the codes are unchanged from the `master` branch and only comments are modified. Updates in releases and `changelogs` may also be committed to this branch.
- Branch **`cleanup`** allows subtle changes to be committed to the source. Commits and changes made are expected to NOT BREAK with the codes in the `master` branch. These changes pertains to variable and configuration file/s, changes to `.gitignore`, `license`, and technical or grammatical corrections, among others. 

A general rule of thumb is that branches `cleanup` and `docs` must never conflict with the `master` branch when merged as these branches are merged more often than others. 

### Branching Convention
Creating other branches is allowed, provided that the minimum requirements are met and the naming convention is observed. 

In naming a branch, it should observe the following practice:
1. **Descriptive**: It should clearly describe the work that is being done on the branch.
2. **Concise**: It should be short and to the point.
3. **Unique**: It should not clash with any existing branch names.
4. **Consistent**: It should be easy to understand for you and for others.
Always name the branches *in lowercase*; *using hyphens to separate words*; and *avoiding using spaces or special characters*.

There must be a ***prefix*** that indicates the type of work being done, such as:
- `feature/`* (for new features)
- `bugfix/`* (for bug fixes)
- `hotfix/`* (for urgent bug fixes)
- `cleanup/`* (for maintenance tasks and minor changes)
- `docs/`* (for changes in the documentation)
