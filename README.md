# Fake.AzureRm

For making deployments super easy without needing powershell 

## Setting up security

You are going to need 4 things to get this going. 

 - Subscription ID
 - Tenant ID
 - Application ID
 - Secure Key

### Subscription ID

Search for `Subscriptions` in the new Azure portal. Pick one. It should look something like this `8a79e991-ea57-4ca4-a3cb-82bf4aa4ad7a`. 

### Tenant ID

To find your tenant id you can click (here)[TODO] GVDM: Need a non-powershell way of finding this.

### Application ID (or service principal)

You can setup your service principal by clicking (here)[https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal]. 

Once you have completed this, take note of your `Application ID`. It is important you do not confuse this with the `Object ID`. 
An example would be `245b7150-973e-45ab-8612-541d538f1427`.

### Secure Key

Next you will have to generate a secure key. Once you have created your principal, this can be found under the `Keys` in the `Settings` blade 
once you have selected the account in Azure AD. An example would be `C6ptRXDfV+fh/IcVXpkZZmEVpOSQw3lg4YtVzUEbdyo=`


## Running the examples 

For running the examples I would recommend using some environment variables. Take the values collected from above and place them into the following env vars:

`Subscription ID` -> `FAKE_AZURERM_EXAMPLES_SUB_ID`
`Tenant ID` -> `FAKE_AZURERM_EXAMPLES_TEN_ID`
`Application ID` -> `FAKE_AZURERM_EXAMPLES_APP_ID`
`Secure Key` -> `FAKE_AZURERM_EXAMPLES_SECRET`

Then head down to the .examples\1.Generate.Secure.Token console and hit F5

You should receive a bearer token which you can then use to run further samples.


