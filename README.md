# Challenge - Backend + Frontend Project

This repository contains a small test project (challenge) that includes:
- **Backend:** .NET API  
- **Frontend:** React + Axios

The goal is to run the project locally and test its functionality without any database or complex setup.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [Node.js 20+](https://nodejs.org/)  
- [npm](https://www.npmjs.com/) (v10+ comes with Node.js)  

## Project Structure

/frontend # React project
/backend # .NET API project
.gitignore
README.md
---

## Frontend
- Framework: React  
- Libraries: Axios  

### Running Frontend
Open a terminal in the `word-sarch-ui` folder.

Install dependencies:
npm install

Start the development server:
npm run dev

The frontend expects a .env file in the word-search-ui folder with the following:
VITE_API_URL=https://localhost:7082
⚠️ **Note:** leaving this here on purpose—don’t worry, all safe, it’s just for the challenge 😉

Open your browser at the URL shown in the terminal (usually http://localhost:5173/).

Backend
Framework: .NET 8 API
No database required

Running Backend
Open a terminal in the backend folder.

Run the API:
dotnet run

By default, the API will run at:

https://localhost:7082
To test endpoints, you can open Swagger UI:

https://localhost:7082/swagger/index.html
Environment Variables
No database or external services are used, so no .env file is required.

Notes
This project is intended for a challenge/test environment only.
If you want to change ports, update the .NET launch settings or React dev server config.

