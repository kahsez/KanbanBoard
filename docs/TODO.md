### WIP
- App
  - Create Empty Board
  - RUD Board
- Persistence
  1. In-memory database

- Input and output DTOs to abstract Domain Layer

### Refactor


### Docs
- Architecture Diagram
- Readme
  - Include diagrams
  - REST
  - Testing (integration, TDD)
  - Architecture (names used)
    - Use Cases = Use Case Interactors = Application Services 
    - Driven Ports = Secondary Ports = Use Case Output Ports
    - Request DTO = Input Data
    - Response DTO = Output Data
  - CI
  - Decisions (number of controllers and use cases, no interface for driving ports)

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
