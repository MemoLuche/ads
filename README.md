# Maka House - Real Estate Property Listing Application

## What is this?

Maka House is a modern web application for real estate property listings built with ASP.NET Core MVC. The application allows users to browse, filter, and search for properties (houses, apartments, commercial spaces, and land) for sale or rent.

## Features

- **Property Listings**: Browse through a catalog of available properties
- **Advanced Filtering**: Filter properties by:
  - Property type (House, Apartment, Land, Commercial)
  - City and neighborhood
  - Number of bedrooms, bathrooms, and parking spaces
  - Price range
- **Sorting Options**: Sort by price (ascending/descending) or publication date
- **Property Categories**: View properties organized by categories
- **Contact Form**: Submit inquiries through a built-in contact form
- **Responsive Design**: Mobile-friendly interface
- **SQLite Database**: Lightweight database for easy deployment

## Technology Stack

- **Framework**: ASP.NET Core 8.0 MVC
- **Database**: SQLite with Entity Framework Core 9.0.5
- **Frontend**: Razor Views, HTML, CSS, JavaScript
- **Containerization**: Docker support included

## Prerequisites

To run this application, you need one of the following:

### Option 1: .NET SDK (For Development)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later

### Option 2: Docker (For Containerized Deployment)
- [Docker](https://www.docker.com/get-started)

## How to Execute This Application

### Method 1: Using .NET CLI (Development)

1. **Navigate to the project directory**:
   ```bash
   cd <project-directory>
   ```
   
   Replace `<project-directory>` with the path where you cloned or downloaded the project.
   
   If you need to clone the repository first:
   ```bash
   git clone <repository-url>
   cd <project-directory>
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Build the project**:
   ```bash
   dotnet build
   ```

4. **Run the application**:
   ```bash
   dotnet run
   ```

5. **Access the application**:
   - Open your browser and navigate to: `https://localhost:5001` or `http://localhost:5000`
   - The exact URLs will be displayed in the console output

### Method 2: Using Docker

1. **Build the Docker image**:
   ```bash
   docker build -t makahouse .
   ```

2. **Run the container**:
   ```bash
   docker run -p 8080:8080 makahouse
   ```

3. **Access the application**:
   - Open your browser and navigate to: `http://localhost:8080`

### Method 3: Using Docker Compose (Recommended for Production)

Create a `docker-compose.yml` file (optional) or run directly:

```bash
docker compose up
```

## Database

The application uses a SQLite database located at `Data/MakaHouse.db`. The database includes:

- **Propiedades Table**: Stores property information including:
  - Title, description, and price
  - Property type and operation type (sale/rent)
  - Location details
  - Number of rooms, bathrooms, parking spaces
  - Square meters
  - Publication date
  - Featured property flag

The database comes pre-populated with sample property data.

### Database Migrations

If you need to apply or create new migrations:

```bash
# Create a new migration
dotnet ef migrations add MigrationName

# Apply migrations to the database
dotnet ef database update
```

## Project Structure

```
<project-root>/
├── Controllers/         # MVC Controllers
│   └── HomeController.cs
├── Models/             # Data models
│   ├── Propiedad.cs
│   ├── ContactViewModel.cs
│   └── ErrorViewModel.cs
├── Views/              # Razor views
│   ├── Home/
│   └── Shared/
├── Data/               # Database context and database file
│   ├── ApplicationDbContext.cs
│   └── MakaHouse.db
├── Migrations/         # EF Core migrations
├── wwwroot/           # Static files (CSS, JS, images)
├── Properties/         # Launch settings
├── Program.cs         # Application entry point
├── Dockerfile         # Docker configuration
└── appsettings.json   # Application configuration
```

## Available Routes

- **/** or **/Home/Index** - Home page with featured properties
- **/Home/Propiedades** - Property listings with filters
- **/Home/Categorias** - Property categories
- **/Home/MisionVisionObjetivos** - About page
- **/Home/Asesores** - Real estate advisors page
- **/Home/Contacto** - Contact form
- **/Home/Privacy** - Privacy policy

## Configuration

### Connection String

The database connection is configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=Data/MakaHouse.db"
  }
}
```

### Environment Variables

For Docker deployment, you can override settings using environment variables:

```bash
docker run -p 8080:8080 \
  -e ConnectionStrings__DefaultConnection="Data Source=Data/MakaHouse.db" \
  makahouse
```

## Development

### Running in Development Mode

The application detects the environment and adjusts settings accordingly:

```bash
# Set development environment
export ASPNETCORE_ENVIRONMENT=Development  # Linux/Mac
# or
set ASPNETCORE_ENVIRONMENT=Development     # Windows

dotnet run
```

### Building for Production

```bash
dotnet publish -c Release -o out
```

## Troubleshooting

### Port Already in Use

If ports 5000/5001 are already in use, you can specify different ports:

```bash
dotnet run --urls "http://localhost:3000;https://localhost:3001"
```

### Database Issues

If you encounter database errors:

1. Delete the existing database:
   - Linux/Mac: `rm Data/MakaHouse.db`
   - Windows: `del Data\MakaHouse.db`
   - Or use EF Core: `dotnet ef database drop`
2. Reapply migrations: `dotnet ef database update`

### Docker Build Issues

Ensure you have the latest Docker version and sufficient disk space.

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## License

This project is for educational/demonstration purposes.

## Support

For issues or questions, please open an issue in the repository.
