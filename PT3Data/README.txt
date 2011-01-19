The PT3Data class library project is where all code for interactions with a PT3 database will go.

Defaults folder:
This is where production models will go. For example, if the RTPEVCFramework sends data about
a player calling a bet, it will send a request for an instance of what the "Call" model in this
folder will query and return. The "Call" model may send back statistics like VPIP, PFr, cold call
%, etc.

Mockup folder:
This is where test models will go before they're ready to be considered for defaults. This is also
where you can test out new implementations of an existing Defaults model.

Plugins:
Any outside libraries required to do things like query a postgressql library go here. Make sure to
add them to the project's assembly "References" in order to use them.

DBUtil.cs:
This is a generic utility to use to query the database and retrieve results. It accepts a query, and it
returns a DataSet containing all results.