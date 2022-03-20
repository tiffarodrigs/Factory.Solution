# _Factory_

#### By _**Tiffany Rodrigo**_

#### Many to many ralationship using database in C# ASP.Net Core MVC

## Technologies Used
* _C#_
* _.Net 5.0_
* _ASP.Net Core_
* _Razor_
* _MySQL_
* _EntityFramework Core_
* _CSS_
* _Linq_
* _HtmlHelper_



## Description

An MVC web application to  keep track of their machine repairs. An MVC web application to manage their engineers, and the machines they are licensed to fix. The factory manager should be able to add a list of engineers, a list of machines, and specify which engineers are licensed to repair which machines. There should be a many-to-many relationship between Engineers and Machines. An engineer can be licensed to repair (belong to) many machines (such as the Dreamweaver, the Bubblewrappinator, and the Laughbox) and a machine can have many engineers licensed to repair it.



User Stories
* _As the factory manager will able to see a list of all engineers, and will be able to see a list of all machines._
* _As the factory manager, will be able to select a engineer, see their details, and see a list of all machines that engineer is licensed to repair.  Also  be able to select a machine, see its details, and see a list of all engineers licensed to repair it_
* _As the factory manager, can add new engineers to our system when they are hired.  Also  to add new machines to our system when they are installed._
*_As the factory manager, The user should be able to add new machines even if no engineers are employed. Also be able to add new engineers even if no machines are installed_
* _As the factory manager, the user need to be able to add or remove machines that a specific engineer is licensed to repair. Also need to be able to modify this relationship from the other side, and add or remove engineers from a specific machine.
 Should be able to navigate to a splash page that lists all engineers and machines. Users should be able to click on an individual engineer or machine to see all the engineers/machines that belong to it._


_

## Setup/Installation Requirements
* _Install the MySQL Community Server & MySQL Workbench_
* _Install .NET5_
* _Clone this repository to your desktop._
* _Import sql database :
* _Add a new file called appsettings.json in the project's production folder and store the following { "ConnectionStrings": { "DefaultConnection": "Server=localhost;Port=3306;database=[NAME-OF-THE-DATABASE-YOU-CREATED-ABOVE];uid=root;pwd=[YOUR-PASSWORD-HERE];" } }_
* _Create your own database by Navigating to the Factory directory in terminal runthe following command:_
  * _Run "dotnet restore" in Terminal then hit enter_
  * _Run "dotnet build" to Terminal_
  * _Run "dotnet ef migration add InitialCreate"_
  * _Run "dotnet ef database update"_
  * _Run dotnet run_
  * _Visit http://localhost:5000_


## License

_MIT_

Copyright (c) _Mar_ 19th 2022_ _Tiffany Rodrigo_




