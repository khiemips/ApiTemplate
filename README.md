## Create api
 - Create a new api inherit from _ApiBaseController<{YourEntity}>_ .  Now you have a api with CRUD :)
 - The entities are located in "Entity" project. In case you wanna add a new entity, it must be inherited from _EntityBase_ class.
 - If you need to extend the api for other business, just create the sevices then inject them into api contractor.

## Create OData api
 - The same as creating api, just inherit from _ODataBaseController<{YourEntity}>_ :)  

 ## Create Jenkins pipeline
 
