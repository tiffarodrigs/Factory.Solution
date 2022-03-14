# _Hair Salon_

#### By _**Tiffany Rodrigo**_

#### _One to many ralationship using database in C#

## Technologies Used
* _C#_
* _.Net 5.0_
* _ASP.Net Core_
* _Razor_
* _MySQL_
* _EntityFramework Core_
* _CSS_



## Description

__An MVC web application to  manage  employees (stylists) and their clients. Claire should be able to add a list of stylists working at the salon, and for each stylist, add clients who see that stylist. The stylists have specific specialties, so each client can only see (belong to) a single stylist.


_

## Setup/Installation Requirements
* _Install the MySQL Community Server & MySQL Workbench_
* _Install .NET5_
* _Clone this repository to your desktop._
* _Import sql database :
  *_Open MySQL WorkBench_
  *_In the Navigator > Administration window, select Data Import/Restore._
  *_In Import Options select Import from Self-Contained File_
  *_Navigate to tiffany_rodrigo.sql in the root directory_
  *_Click OK_
  *_Click Start Import_
  *_Refresh all to see the database appear_
* _Create appsettings.json in the folder HairSalon_
* _Copy the below content in the appsettings.json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=<database_name>;uid=root;pwd=<password>;"
  }
}
* _Navigate to the HairSalon of the directory in terminal_
* _Run dotnet restore_
* _Now object folder will be created_
* _Commit the .gitignore_
* _Run dotnet build_
* _Run dotnet run_
* _Visit http://localhost:5000_







## License

_MIT_

Copyright (c) _Mar_ 13th 2022_ _Tiffany Rodrigo_




