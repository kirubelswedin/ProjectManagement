# ProjectManagement

A modern project management system built with React and .NET for managing projects, clients, and resources.

## Features

- **Project Management**: Create, edit, and delete projects
- **Client Management**: Manage clients and their information
- **Resource Allocation**: Assign project managers and resources to projects
- **Status Tracking**: Track project status and progress

## Tech Stack

### Frontend

- React
- TypeScript
- Context API for state management
- CSS for styling

### Backend

- .NET API
- SQL Server database
- Docker for containerization

## Getting Started

### Prerequisites

- Node.js (v14 or later)
- npm or yarn
- Docker and Docker Compose
- .NET SDK 6.0 or later

### Installation

1. Clone the repository:

   ```
   git clone https://github.com/yourusername/ProjectManagement.git
   cd ProjectManagement
   ```

2. Start the backend with Docker:

   ```
   cd Docker
   docker-compose up -d
   ```

3. Install frontend dependencies and start the development server:

   ```
   cd ../React
   npm install
   npm run dev
   ```

4. Open your browser and navigate to `http://localhost:3000`
