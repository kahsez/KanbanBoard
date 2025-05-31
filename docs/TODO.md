### WIP
- App
  - RUD Board
- Add IDs to boards
  
### Test
- Two posted boards have different IDs

### Refactor
- Move DI add services from program to somewhere else

### Docs
- Architecture Diagram
- Readme
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
    - Why not using DTOs to communicate with repositories

### Features
- App
  - CRUD Cards
  - CRUD Columns
  - Create Default Board
  - Move Cards between Boards

- Persistence
  - [x] In-memory database
  - [ ] SQLite Database (Using EFCore)
  - [ ] External SQL Database (Using EFCore)

- View
  - OpenAPI generator
  - Desktop View
    - Console View? 
    - Unity View? 
    - WPF View?
  - Web View
    - Blazor?

- Authentication
