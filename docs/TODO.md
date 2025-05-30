### WIP
- App
  - Create Empty Board
  - RUD Board
- Persistence
  1. In-memory database

### Refactor


### Docs
- Architecture Diagram
- Readme
  - Include diagrams
  - REST
  - Testing (integration, TDD)
    - test helpers = test api = test utils
  - Architecture (names used)
    - Use Cases = Use Case Interactors = Application Services 
    - Driven Ports = Secondary Ports = Use Case Output Ports
    - Request DTO = Input Data
    - Response DTO = Output Data
  - CI
  - Conventional Commits
  - Decisions 
    - Number of controllers and use cases
    - No interface for driving ports
    - Creating a new client in each integration test

### Features
- App
  - CRUD Cards
  - CRUD Columns
  - Create Default Board
  - Move Cards between Boards

- Persistence
  2. SQLite Database (Using EFCore)
  3. External SQL Database (Using EFCore)

- View
  - Desktop View
    - Console View? 
    - Unity View? 
    - WPF View?
  - Web View
    - Blazor?

- Authentication
