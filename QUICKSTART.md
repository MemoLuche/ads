# Quick Start Guide - Maka House

This is a quick reference to get the application running in under 5 minutes.

## What is this?

**Maka House** is a real estate property listing web application where users can browse, filter, and search for properties for sale or rent.

## Fastest Way to Run

### Option 1: Using .NET (Recommended for Development)

```bash
# 1. Navigate to the project directory
cd /path/to/ads

# 2. Run the application
dotnet run

# 3. Open your browser
# Navigate to: http://localhost:5000
```

That's it! The application will:
- Automatically restore dependencies
- Build the project
- Start the web server
- Use the included SQLite database

### Option 2: Using Docker (Recommended for Production)

```bash
# 1. Build and run with Docker
docker build -t makahouse .
docker run -p 8080:8080 makahouse

# 2. Open your browser
# Navigate to: http://localhost:8080
```

## What You'll See

Once running, you can access:

- **Home Page** (`/`) - Featured properties and welcome message
- **Properties** (`/Home/Propiedades`) - Full catalog with filters
- **Categories** (`/Home/Categorias`) - Browse by property type
- **Contact** (`/Home/Contacto`) - Submit inquiries

## Stopping the Application

- **If using `dotnet run`**: Press `Ctrl+C` in the terminal
- **If using Docker**: Press `Ctrl+C` or run `docker stop <container-id>`

## Need More Details?

See the [full README.md](README.md) for:
- Complete feature list
- Project structure
- Configuration options
- Troubleshooting
- Development guide

## Requirements

- **For .NET**: .NET 8.0 SDK or later
- **For Docker**: Docker installed on your system

## Common Issues

**Port already in use?**
```bash
# Use a different port
dotnet run --urls "http://localhost:3000"
```

**Docker build fails?**
- Check you have Docker running
- Ensure you have internet connectivity for downloading base images

## Database

The application uses a pre-configured SQLite database located at `Data/MakaHouse.db` with sample property data. No additional setup required!
