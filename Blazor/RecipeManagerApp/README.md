# Recipe Manager App

A simple Blazor WebAssembly application for managing recipes.  
This project demonstrates component-based architecture, state management using services, and routing in a Blazor environment.

## Purpose

This project was created to practice:

- Blazor component development
- Using services to manage shared state
- Navigation between pages using routing
- Two-way data binding in forms
- Handling user input with validation

It also reinforces foundational web development concepts while using the Blazor framework.

## Concepts Demonstrated

- Razor Components (`.razor` files) and parameter passing
- Component lifecycle methods (`OnInitialized`, `OnParametersSet`)
- Dependency Injection (`@inject`) with a singleton service
- Forms with validation using `EditForm`, `DataAnnotationsValidator`, and `ValidationSummary`
- Navigation between pages using `NavLink` and `NavigationManager`
- Simple in-memory state management with a singleton service

## Project Structure

- `Recipe.cs` – Represents the data model for a recipe (Id, Name, Description)  
- `RecipeService.cs` – Handles all recipe data operations: fetch, add, and retrieve by Id  
- `Home.razor` – Lists all recipes and links to recipe details or add recipe page  
- `AddRecipe.razor` – Form to add a new recipe with validation  
- `RecipeDetails.razor` – Displays the details of a single recipe  
- `Program.cs` – Registers the `RecipeService` as a singleton for shared state

## How It Works

1. The app loads the **Home** page listing all recipes.  
2. Users can view details of a recipe or navigate to **Add Recipe**.  
3. The **Add Recipe** page allows entering a name and description, validates input, and adds the recipe to the service.  
4. After adding, the user is navigated back to the home page where the new recipe is listed.  
5. Clicking a recipe on the home page navigates to the **Recipe Details** page.  

## How to Run

1. Open the project in Visual Studio or VS Code  
2. Run the application using the terminal:  
dotnet run  
3. Navigate to the displayed local URL in your browser

## Possible Improvements

- Persist recipes using a database instead of in-memory storage  
- Add edit and delete functionality for recipes  
- Improve the UI using CSS frameworks like Bootstrap or Tailwind  
- Add search or filtering of recipes  
- Include user authentication for personalized recipe lists  

## Notes

This project is intentionally simple to focus on Blazor fundamentals, component structure, and service-based state management.  
The main purpose was to reinforce Razor component principles, routing, and form handling within a Blazor WebAssembly application.