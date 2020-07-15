# No Search Engine

NoSearchEngine is a search engine that works on recommendations, rather that trawling the web.  

Registered users are able to store a list of resources from the web, along with descriptions, tags, and ratings.  Users can also rate sites on their usefulness, and give credit to the user that added the site.

Each added site must be approved by a user with more than a certain credit score.

Registered and unregistered users can search these resources against the descriptions.

The currently deployed alpha version is <a href="https://nosearchengineapp.azurewebsites.net/">here</a>


## How to Contribute

There are a list of issues.  Please check first, and then fork the repo and submit a PR.

## Running the Code

Install <a href="https://nodejs.org/en/">npm</a>.

Entity Framework is using SQL Server, so you'll need SQL Express at least.

The code is a Visual Studio solution.

## Passwords and secrets

In order to run the code, you'll either need to add the following json to your <b>appsettings.json</b>, or to your <b>secrets.json</b>:

```
{  
  "Authentication": {
    "Twitter": {
      "ConsumerAPIKey": "",
      "ConsumerSecret": ""
    }
  }, 
  "ConnectionStrings": {
    "AppConfig": "",
    "SqlConnectionString": ""
  },
  "IdentityServer": {
    "Key": {
      "Type": "File",
      "FilePath": "nosearch.pfx",
      "Password": ""
    }
  }
}
```

