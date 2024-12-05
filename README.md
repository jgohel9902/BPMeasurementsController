# Blood Pressure Measurement App

This is a simple ASP.NET Core MVC application that utilizes **Entity Framework Core** with a **Database-First** approach to manage blood pressure measurements. The application connects to a SQL Server LocalDB database and uses generated models to display measurement data in an HTML table on the home page.

## Features
- **Database-first** approach using **Entity Framework Core**.
- View and manage blood pressure measurement records.
- User-friendly interface displaying data in an HTML table.
- Integration with SQL Server LocalDB.

## Installation

### Prerequisites:
- **.NET 6 or higher** installed on your machine.
- **SQL Server Management Studio (SSMS)** for managing the LocalDB instance.
- A **LocalDB** instance set up with the necessary tables.

### Steps to Run Locally:
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/bp-measurement-app.git
   
2. Navigate to the project directory :
   ```bash
   cd bp-measurement-app

3. Install required dependencies:
   ```bash
   dotnet restore

4. Set up LocalDB databse

5. Run the application :
   ```bash
   dotnet run

### Technologies  Used:
- ASP.NET Core MVC.
- Entity Framework Core.
- SQL Server LocalDB.
