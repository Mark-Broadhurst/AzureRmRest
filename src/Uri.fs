module Fake.AzureRm.Uri

let ResourceGroupUri subscriptionId name =
  sprintf
    "https://management.azure.com/subscriptions/%s/resourceGroups/%s?api-version=2015-11-01"
    subscriptionId name

let AppServicePlanUri subscriptionId resourceGroupName name =
  sprintf
    "https://management.azure.com/subscriptions/%s/resourceGroups/%s/providers/Microsoft.Web/serverfarms/%s?api-version=2015-08-01"
    subscriptionId resourceGroupName name

let AppServiceUri subscriptionId resourceGroupName name =
  sprintf
    "https://management.azure.com/subscriptions/%s/resourceGroups/%s/providers/Microsoft.Web/sites/%s?api-version=2015-08-01"
    subscriptionId resourceGroupName name

let VfsUri name path =
  sprintf
    "https://%s.scm.azurewebsites.net/api/vfs/%s/"
    name
    path

let SqlServerUri subscriptionId resourceGroupName serverName = 
  sprintf 
    "https://management.azure.com/subscriptions/%s/resourceGroups/%s/providers/Microsoft.Sql/servers/%s?api-version=2014-04-01-preview"
    subscriptionId
    resourceGroupName
    serverName

let SqlDatabaseUri subscriptionId resourceGroupName serverName databaseName = 
  sprintf 
    "https://management.azure.com/subscriptions/%s/resourceGroups/%s/providers/Microsoft.Sql/servers/%s/databases/%s?api-version=2014-04-01-preview"
    subscriptionId
    resourceGroupName
    serverName
    databaseName