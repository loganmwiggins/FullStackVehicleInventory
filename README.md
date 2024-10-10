
# 🚗 Vehicle Inventory - ZML Toyota Dealership

Welcome to the **Vehicle Inventory** site for the **ZML Toyota Dealership**! This web application allows users to browse a catalog of available Toyota vehicles and provides full CRUD (Create, Read, Update, Delete) functionality for managing the vehicle inventory. 

Created by: Logan Wiggins, Zach Kirschner, and Margaret Rivas

## Features

### General Features
- **Browse Toyota Vehicles**: Customers can browse through an extensive list of available Toyota vehicles.
- **View Vehicle Details**: Users can click on a vehicle to view detailed information, including pricing, fuel type, and availability.
  
### CRUD Functionality for Managing Cars
- **Create**: Admins can add new vehicles to the inventory.
- **Read**: View a list of all available vehicles, with options to search and filter.
- **Update**: Edit details of existing vehicles, such as model, price, availability, and more.
- **Delete**: Remove vehicles from the inventory that are no longer available or needed.

### Additional Features
- **Search and Filter**: Search by vehicle model, year, and other filters.
- **Responsive Design**: Mobile-friendly design that ensures users have a seamless experience across devices.
- **Image Support**: Each vehicle listing can display a vehicle image, enhancing the browsing experience.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap
- Font Awesome
- jQuery

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Steps

1. **Clone the repository**:
   ```bash
   git clone https://github.com/loganmwiggins/FullStackVehicleInventory.git
   ```

2. **Install dependencies**:
   Ensure all necessary NuGet packages are restored:
   ```bash
   dotnet restore
   ```

4. **Update Database**:
   Set up the database using Entity Framework migrations:
   ```bash
   dotnet ef database update
   ```

5. **Run the application**:
   ```bash
   dotnet run
   ```

6. **Open the browser**:
   Once the application is running, open your browser and navigate to:
   ```
    http://localhost:5065/
   ```
