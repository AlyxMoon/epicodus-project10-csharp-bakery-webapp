# Epicodus | Independent Project 10 | C# Vendor and Order Tracker

##### Table of Contents
1. [Description](#description)
2. [Setting Up The Project](#setting-up-the-project)
   - [Setting Up for Local Development](#setting-up-for-local-development)
4. [Objectives](#objectives)
   - [Further Exploration Objectives](#further-exploration-objectives)

## Description

This is my tenth independent project for the Epicodus bootcamp program. The goal is to create a C# Asp.Net web application with the following functionality:

- Create a Vendor class. This class should include properties for the vendor's name, a description of the vendor, a List of Orders belonging to the vendor, and any other properties you would like to include.
- Create an Order class. This class should include properties for the title, the description, the price, the date, and any other properties you would like to include.
- The homepage of the app at the root path (localhost:5000/) should be a splash page welcoming Pierre and providing him with a link to a Vendors page.
- The vendors page should contain a link to a page presenting Pierre with a form he can fill out to create a new Vendor. After the form is submitted, the new Vendor object should be saved into a static List and Pierre should be routed back to the homepage.
- Pierre should be able to click a Vendor's name and go to a new page that will display all of that Vendor's orders.
- Pierre should be provided with a link to a page presenting him with a form to create a new Order for a particular Vendor. Hint: The route for this page might look something like: "/vendors/1/orders/new".

- **Author**: Allister Moon Kays
- **Copyright**: MIT License

## Setting Up The Project

#### Setting Up for Local Development
1. Ensure you have `.Net` (current version at this time is `.Net 5.0`) installed on your computer (https://dotnet.microsoft.com/download).
1. Download the files or clone the repository to your computer.
2. Open the project folder in your code editor of choice.
3. Running the application
  - To run the application, use `dotnet run` while in the `Bakery` directory.
  - Then, open your browser and load the dev server address to see the app. The default address will be `http://localhost:5000`.

To test the application, use `dotnet test` while in the `Bakery.Tests` directory.

## Objectives
- A splash page is used.
- Project has Vendor and Order classes.
- Project uses two or more controllers.
- Models are thoroughly tested.
- GET and POST requests/responses are used successfully.
- MVC routes follow RESTful conventions.
- Code and documentation follow best practices (descriptive variables names, proper indentation and spacing, separation between user-interface and business logic, detailed commit messages in the correct tense, and a well-formatted README with installation instructions).
- Project is in a polished, portfolio-quality state.
- Required functionality was present at deadline.
- Project demonstrates understanding of this week's concepts. If prompted, you can discuss your code with an instructor using the correct terminology.

### Further Exploration Objectives
- Allow Pierre to click an Order's name to go to a separate page to view its details.
- Add the ability to delete individual Vendors, all Orders belonging to a Vendor, individual Orders, or all Vendors.
- Add the ability to update Vendor or Order details.
- Add the ability for Pierre to note whether an order has been paid for or not.
- Add custom CSS and JavaScript.
- Add search functionality to your app.
