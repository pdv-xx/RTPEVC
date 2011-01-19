DataService is where the UI retrieves data from via the Fetch.cs methods. Methods in Fetch.cs accept
the data the UI provides, creates the appropriate DataCore object with it, and passes that object to
the appropriate PT3Data Default model. The result will be a DataSet that can either be mangled in the
Fetch.cs method, or it can be returned as is to the UI.

* Note: only put static methods in Fetch.cs. That way, you just do Fetch.methodNameHere(paramsHere) to
get results. You don't have to create a fetch object and then call whichever method each time you need
to make a query this way. Use Fetch.playerStatistic as an example.