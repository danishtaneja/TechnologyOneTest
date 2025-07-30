Step 1 Clone the Repository: 
  • Open Visual Studio. 
  • From the Git menu, select "Clone Repository" (or "Clone" if it's your first time using the Git menu). 
  • In the "Clone a repository" window, under "Enter a Git repository URL," paste the URL of your GitHub repository. 
  • Choose a local path where you want to store the project. • Click "Clone." If prompted, sign in to your GitHub account and authorize Visual Studio. 
Step 2 Open the Project in Visual Studio: 
  • After cloning, Visual Studio will typically prompt you to open the solution file (.sln). If not, navigate to the cloned directory and double-click the .sln file. 
Step 3 Restore NuGet Packages (Dependencies): 
  • Once the solution is open, Visual Studio should automatically detect and attempt to restore any missing NuGet packages (dependencies). 
    You'll often see a "Restore" button or message in the Solution Explorer or Output window. 
  • Alternatively, you can manually restore packages: • Right-click on the solution in Solution Explorer. 
  • Select "Manage NuGet Packages for Solution." 
  • Click the "Restore" button if packages are missing. Step 4 Build the Project: 
  • After the NuGet packages are restored, build the project to ensure all code compiles correctly. 
  • Go to the "Build" menu and select "Build Solution." Step 5 Run the Project: 
  • Once the build is successful, you can run the ASP.NET Web API project. 
  • Press F5 or click the "Start Debugging" button (green play icon) in the Visual Studio toolbar. 
    This will typically launch the Web API in your default browser or through IIS Express, allowing you to interact with its endpoints 
Step 6 Run the API’s Testing using Web Browser or Postman: 
  • From Postman Testing use URL (https://localhost:7297/api/NumberToWords ) 
  • From Web Browser Testing use URL (https://localhost:7267/swagger/index.html ) 
Step 7 Open the Index.html file for Client-side results : 
• For Client-side Result use URL (https://localhost:5246/index.html )
