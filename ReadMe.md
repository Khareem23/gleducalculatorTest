## Project Information
This solution uses the following azure services, i decided to go
a bit further than requirement to demonstrate the ability to 
work end to end a software development solution. 

- Azure Key vault
- Azure SQL
- Azure Web App ( App Service)

### Azure SQL
This service was used to provision MS-SQL Server which is the database used for this
solution where the log data is stored. The connection string was initially saved
in Azure Key Vault for security reasons but due to limited access of the Azure
Account i used , i was not able to set up AD App Registration for the Key Vault,
so i resulted to storing configuration data in AppSettings file which i'm aware of
the Security vulnerabilities of such approach. So, kindly accept this approach from me
being a Test Code.


### Azure Web App ( App Service )
The app was deployed to Azure Web App. Below is the link to access it
Deployment URL :  
https://ibocartestproject.azurewebsites.net/index.html

## Valid Request
Here is a Valid Sample Request
``` 

```

##Invalid Request
Here some required fields are empty, I wrote an Action Filter that handles validation
between the request and response pipeline. This validator will return the
Appropriate Validation error .





