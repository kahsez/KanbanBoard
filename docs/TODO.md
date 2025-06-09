### WIP
- Persistence
  - SQLite Database (Using EFCore)
  
### Test
- Test Data Builder for client?
- Separate boards tests in multiple classes?

### Refactor
- Move DI add services from program to somewhere else
- Move Id generation to application layer?
- Change int id to uuid

### Docs
- Readme
  - REST
  - Persistence (Multiple implementations)
  - Testing (integration, TDD)
  - Architecture
  - CI
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

