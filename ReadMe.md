## Project Information
After implementing the requirements, I decided to go a bit further to document the API 
using Swagger and then deploy the applications both the backend API (.Net Core ) and Frontend
(Angular) in Azure. In addition, I set up a CI/CD pipeline with Github action 
which builds on every commit to master branch in the github Repository, then
deploy the frontend project to  Azure Static Web App. 

This solution uses the following azure services,

- Azure Key vault
- Azure SQL
- Azure App Service ( Web App  & Static Web App )

### Azure SQL
This service was used to provision MS-SQL Server which is the database used for this
solution where the log data is stored. The connection string was initially saved
in Azure Key Vault for security reasons but due to limited access of the Azure
Account i used , i was not able to set up AD App Registration for the Key Vault,
so i resulted to storing configuration data in AppSettings file which i'm aware of
the Security vulnerabilities of such approach. So, kindly accept this approach from me being a Test Code.


### Azure App Service ( PAAS )
The frontend was deployed using Static Web App in Azure and the backend deployed with
Azure Web App. Both are Platform as a service(PAAS) offering high scalability,
Availability and no management of underlying infrastructure.

Below are the links to access them :

### Deployed API URL :
https://gledu-calculatortest.azurewebsites.net/index.html

### Deployed Frontend :
https://lemon-wave-076186403.1.azurestaticapps.net/


According to the requirement , there are 2 Implementations 
of the Diagnostic Interface. The default concrete implementation is the 
database logger which logs result, operations and date&time to a MS SQL Server 
Database.

To view the the debugOutput logger , Go to CalculatorTest.API, inside the 
startup.cs file, Uncomment this line & comment the other
```
// services.AddScoped<IDiagnosticLogger,DebugLogger>();
```
### Web API 
To run the API backend , simple follow this steps :
1. Navigate to the API root directory 
   ``` cd  CalculatorTest.API ```
2. Run ``` dotnet build ```
3. Run ``` dotnet run  ```


### Library Test  ( Angular Client)
The test solution uses a 3rd party library MOQ to mock the dependencies. To run the Library Test, simple follow this steps :
1. Navigate to the API root directory
   ``` cd   GLEducation.Lib.Test  ```
2. Run ``` dotnet build ```
3. Run ``` dotnet test  ```

### Frontend ( Angular Client)
The frontend by default uses the production API endpoint but in Dev Environment, it switches to
localHost running on Port 5000 and 50001.

To run client Application, simple follow this steps :

1. Ensure the API is running, the API runs on 
   http port 5000 and https port 5001. The angular app 
   communicate with the Api on port 5000.
2. Navigate to the API root directory
   ``` cd   Calcular.Frontend/client    ```
3. Run ``` npm install ```
4. Run ``` npm run start  ```

### Prime Number Sample Request 
```
request Body : 
[2,3,5,7,11,13,17]

position : 4 

```









