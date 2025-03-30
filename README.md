1. Created 2 microservices
2. One is Customer.Microservice webApi project using entityframeworeCore
3. 2nd project is Products.Microservice webApi project
4. Created a gateway api project to access these two microservices
5. Gateway.WebApi is the empty webApi project
6. Configure Ocelot as api gateway in program.cs 
7. // Configure configuration sources
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(); // Register Ocelot
// Use Ocelot Middleware
await app.UseOcelot();
8. Define upstream and downstream routes, http methods and port numbers in Ocelot.json
9. Build the complete solution and set all three projects as startup projects (multiple)
10. Cross check the portnumbers in all the 3 projects. Portnumber in Ocelot.json file should match portnumbers in launchSettings.json.
11. Run the application
12. The gateway will run at: /gateway/Products which internally calls /api/Products, similarly /gateway/Customer will internally call /api/Customer
