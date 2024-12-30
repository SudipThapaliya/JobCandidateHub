# JobCandidateHub
JobCandidateHub is a web application designed to manage job candidate information efficiently. It provides a robust API for creating, reading, updating, and deleting candidate data, ensuring streamlined recruitment processes.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Running the Application](#running-the-application)
- [Testing](#testing)

## Features

- Manage candidate profiles with CRUD operations.
- Search and filter candidates based on various criteria.
- Secure authentication and authorization mechanisms.
- Responsive design for seamless use across devices.

## Technologies Used

- **Backend**: ASP.NET Core 8
- **Database**: Entity Framework Core with SQLite
- **Testing**: xUnit, Moq
- **Logging**: // Logging is not used as not mentioned on requirement
- **Auth**: // Auth is not used as not mentioned on requirement
- **Caching**: // Catching is not used as not mentioned on requirement

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Node.js](https://nodejs.org/) (for frontend development)

### Installation

	1. **Clone the repository:**
		```bash
		git clone https://github.com/SudipThapaliya/JobCandidateHub.git
		cd JobCandidateHub
	2. Set up the database:
		-Update the connection string in appsettings.json to point to your SQLite instance.
		-Apply migrations to set up the database schema:
			dotnet ef database update
	3. Configure environment variables:
		-Create a .env file in the project root and add necessary environment variables as per your setup.
		
## Project Structure
	-JobCandidateHub.API: Contains the main API controllers and endpoints.
	-JobCandidateHub.Core: Database connection logic.
	-JobCandidateHub.Entity: Entity models representing the database schema.
	-JobCandidateHub.Interface: Interfaces for services and repositories.
	-JobCandidateHub.Model: Data Transfer Objects (DTOs) for API communication.
	-JobCandidateHub.Service: Implementation of services.
	-JobCandidateHub.Test: Unit and integration tests.
## Running the Application
	1. Navigate to the API project:
		cd JobCandidateHub.API
	2. Run the application:
		dotnet run
	3. Access the API documentation:
		Navigate to https://localhost:[Port]/swagger to explore the available endpoints.
## Testing
	- Run unit tests:
		dotnet test
	- Ensure all tests pass before making contributions.
