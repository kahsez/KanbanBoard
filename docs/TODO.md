### WIP
- App
  - Update Board
- Persistence
  - SQLite Database (Using EFCore)
  
### Test
- Test Data Builder for client?
- Separate boards tests in multiple classes?

### Refactor
- Move DI add services from program to somewhere else
- Move Id generation to application layer?

### Docs
- Readme
  - REST
  - Persistence (Multiple implementations)
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
- Deploy
- View
  - OpenAPI generator
  - Desktop View
    - Console View? 
    - Unity View? 
    - WPF View?
  - Web View
    - Blazor?

- Authentication
- Persistence
  - [x] In-memory database
  - [ ] External SQL Database (Using EFCore)

- App
  - CRUD Cards
  - CRUD Columns
  - Create Default Board
  - Move Cards between Boards

