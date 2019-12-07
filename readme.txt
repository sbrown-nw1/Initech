API Programming Assignment

Dev Notes:
 - Unit tests are very basic to prove appropriate tiers are mockable and testable.
 - Solution uses litedb which is a NoSQL document database for persistence.  It is thread and process safe.  We always initialize the database in Application_Start() (usig povided .json files in App_Data and is quite quick) unless you set the the following appSetting in Web.config:
	- InitDB => false
 - Future sprint work would include:
	- separating out DBTier to new project
	- separating out BusinessTier to new project

Product Owner / ScrumMaster Notes:
 - Recommend adding json web token API endpoint and .Net HttpModule for jwt validation
	- we will need SSL certs for all environements if we are going to do this correctly, I will investigate
 - Any API Endpoint that returns a List / Collection is paged to avoid excessive and inefficient resource consumption at all tiers.  Defaults include and we can update these defauls if necessary:
	- page: 1 (first page), optional argument and any page can be requested
        - pageSize: 2 (return two items per page), optional argument and any pageSize can be requested

Sprint One Demo:
 - Can show all unit tests passing.
 - Steps to demo:
	1. git clone https://github.com/sbrown-nw1/Initech
	2. open InitechAPI.sln in Visual Studio 2017 or newer
	3. run unit tests if desired (note: sometimes the VS Test runner does not recognize unit tests between versions of VS)
	4. select F5 to start InitechAPI, should open in browser at http://localhost:49229/api/agents
 
 - Endpoints to use and verify:

HttpGet in browser:
 - ~/api/agents/{page?}/{pageSize?} or {args} can be on querystring, {args?} are optional - will show two agents along with usage, page and pageSize info
 - ~/api/agent/101 or {args} can be on querystring, {args?} are optional - will show requested agent if valid id is entered (101) or no agent if invalid
 - ~/api/customerdetail/{page?}/{pageSize?} or {args} can be on querystring, {args?} are optional - will show two customers
 - ~/api/customers/101/{page?}/{pageSize?} or {args} can be on querystring, {args?} are optional - will show two customers by agentId (101)

HttpPost in Fiddler Composer tab, make sure Fiddler headers contain Content-Type: application/json:
 - ~/api/customers with valid Customer json in body (including agentId 101), verify Post with ~/api/customers/101?page=1&pageSize=10000 and look at last customer
 - ~/api/agents with valid Agent json in body, verify Post with ~/api/agent/{returned agentId returned from Post)

HttpPut in Fiddler Composer tab, make sure Fiddler headers contain Content-Type: application/json:
 - ~/api/agent/101 with valid Agent json in body, verify Put with ~/api/agent/101
 - ~/api/customerdetail/1042 with valid Customer json in body (including agentId 101), verify Put with ~/api/customers/101?page=1&pageSize=10000 and look for updated customer

HttpDelete in Fiddler Composer tab, make sure Fiddler headers contain Content-Type: application/json:
 - ~/api/customers/1042, verify Delete with ~/api/customers/101?page=1&pageSize=10000 and confirm deleted customer
