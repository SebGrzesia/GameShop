## Dependencies
* visual studio community 2022
* C#
* SQL Server managment studio

## Starting a project

Open the project and select "Tools" => "NuGet Package Manager" => "Manage NuGet Packages for Solution..."
Install required packages:
![image](https://github.com/SebGrzesia/GameShop/assets/101827942/bcbc68d0-635f-4451-91e4-8c671e5991cc)


Change the connection string in appsettings.json folder to your own.
![image](https://github.com/SebGrzesia/GameShop/assets/101827942/ed488b45-718c-4757-a569-9d364b17cda3)

Then select "Tools" => "NuGet Package Manager" =>  "Package manager console"
![image](https://github.com/SebGrzesia/GameShop/assets/101827942/5d14a5be-4a9f-46a1-bc6c-a1d82a75e0d2)



In the console, enter the commands listed below.
## Commands
* Add-Migration InitialCreate
* Update-Database
