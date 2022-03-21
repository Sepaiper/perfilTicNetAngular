# perfilTicNetAngular
Angular technical test
***
## Installation of the angular project
***
### Previous
npm v8.3.1
node v16.14.0
***
Access the TicAngular Profile folder and execute the npm i command, if everything is satisfactory execute the ng serve command
## Installation of the .net project
### Previous
Microsoft.AspNetCore.MVC.core v2.2.5
Microsoft.EntityFrameworkCore.SqlServer v5.0.10
Microsoft.EntityFrameworkCore.Tools v5.0.10
Microsoft.Extensions.DependencyInjection.Abstractions v6.0.0
Microsoft.VisualStudio.Azure.Containers.Tools.Targets v1.11.1
Swashbuckle.AspNetCore v5.6.3
***
#### Migrations
verify that you have SQL server installed on the computer, in each solution you must run the respective migrations in the package manager console with the following commands:
##### Admin
* add-migration InitialCreate -p perfilTicNetAdmin.Repository -c PerfilTicNetAdminContext -o Migrations -s perfilTicNetAdmin.Repository
* update-database -p perfilTicNetAdmin.Repository -s perfilTicNetAdmin.Repository
##### Products
* add-migration InitialCreate -p PerfilTicNetProducts.Repository -c PerfiltTicNetProductContext -o Migrations -s PerfilTicNetProducts.Repository
* update-database -p PerfilTicNetProducts.Repository -s PerfilTicNetProducts.Repository
##### Categories
* add-migration InitialCreate -p perfilTicNetCategories.Repository -c PerfilTicNetCategoriesContext -o Migrations -s perfilTicNetCategories.Repository
* update-database -p perfilTicNetCategories.Repository -s perfilTicNetCategories.Repository
***
#### Configuration
Open the solution of each project, if necessary open the Framework And Drivers folder and in the .Api project click on Set startup project
***
Due to time issues, environments were not handled, before or after compiling the project in IIS Express, verify the repositories of each solution in the Interface Adapters/Gateways/x.Repository.Http/Repositories path and in each exposed class, modify the url corresponding microservice
***
### End
If everything is successful, IIS Express will present the Swaggers in your localHost


