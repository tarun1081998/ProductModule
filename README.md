# ProductModule
This is a basic project which have functionalities like 
-Show products data, 
-Add new product
-Edit product
-Delete product

## Prerequisites
1. Sql server must be installed on the system [(https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu) -> (for ubuntu)]
2. Dotnet ef core and its tools must be installed on the system [(https://docs.microsoft.com/en-us/ef/core/cli/dotnet) -> (for ubuntu)]
3. Add dotnet ef core to path [(export PATH=$PATH:/home/{username}/.dotnet/tools) -> (for ubuntu)]

## Steps to run this Project
1. Clone this repo
-- $ git clone https://github.com/tarun1081998/ProductModule.git
2. navigate to "appsettings.json" file
3. change the connectionstring in "appsettings.json" (change server, user id, password) according to your sql server.
4. run following command   
-- $ dotnet ef update database  
-- $ dotnet run  
Above command will start the api project
5. Navigate to "NunitTest" folder
6. run the following command
-- $ dotnet test

