# AzureRmRest

[![Build status](https://ci.appveyor.com/api/projects/status/tpo1ex6acpb5e9tx/branch/master?svg=true)](https://ci.appveyor.com/project/Mark-Broadhurst/azurermrest/branch/master)

[![Build history](https://buildstats.info/appveyor/chart/mark-broadhurst/azurermrest)](https://ci.appveyor.com/project/mark-broadhurst/azurermrest/history)


For making deployments to Azure super easy without needing any powershell 


## Setting up security

You are going to need 4 things to get this going. 

 - Subscription ID
 - Tenant ID
 - Application ID
 - Secure Key

### Subscription ID

Search for `Subscriptions` in the new Azure portal. Pick one. It should look something like this `8a79e991-ea57-4ca4-a3cb-82bf4aa4ad7a`. 

### Tenant ID

To find your tenant id you can click navigate to the azure portal, search for `active directory`, once you have selected an instance of it, you can navigate
to the `Properties` on the blade and scroll down and copy the `Directory ID`.

### Application ID (or service principal)

You can setup your service principal by clicking [here](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal). 

Once you have completed this, take note of your `Application ID`. It is important you do not confuse this with the `Object ID`. 
An example would be `245b7150-973e-45ab-8612-541d538f1427`.

### Secure Key

Next you will have to generate a secure key. Once you have created your principal, this can be found under the `Keys` in the `Settings` blade 
once you have selected the account in Azure AD. An example would be `C6ptRXDfV+fh/IcVXpkZZmEVpOSQw3lg4YtVzUEbdyo=`
