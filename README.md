<body>
    <h1>Personal Finance Management SaaS</h1>
    <p>Welcome to the Personal Finance Management SaaS project, where you can analyze your transactions through graphs and filter operations by month and year. This project was developed using the following technologies:</p>
    <ul>
        <li>ASP.NET Minimal APIs</li>
        <li>Blazor WASM</li>
        <li>MudBlazor</li>
        <li>Identity</li>
        <li>Entity Framework</li>
        <li>SQL Server</li>
        <li>SQL Views</li>
    </ul>
    <p>The project follows principles of CQRS, DDD, and SOLID to ensure a robust and scalable architecture.</p>

 <h2>Video Demo</h2>
    <p><a href="https://www.youtube.com/watch?v=mo0og7f-mUk">Watch the demo here</a></p>

 <h2>Endpoints</h2>
    <h3>Categories</h3>
    <ul>
        <li><strong>POST</strong> <code>api/categories</code>: Creates a new category</li>
        <li><strong>GET</strong> <code>api/categories</code>: Retrieves all paginated categories</li>
        <li><strong>PUT</strong> <code>api/categories/{id}</code>: Edits an existing category</li>
        <li><strong>DELETE</strong> <code>api/categories/{id}</code>: Deletes an existing category</li>
        <li><strong>GET</strong> <code>api/categories/{id}</code>: Fetches a category by Id</li>
    </ul>
    
 <img src="https://github.com/user-attachments/assets/0201fd9f-3de2-4acd-a430-ee9347cfbc9b" alt="Categories Endpoints">

  <h3>Transactions</h3>
    <ul>
        <li><strong>POST</strong> <code>api/transactions</code>: Creates a new transaction</li>
        <li><strong>GET</strong> <code>api/transactions</code>: Retrieves all paginated transactions</li>
        <li><strong>PUT</strong> <code>api/transactions/{id}</code>: Edits an existing transaction</li>
        <li><strong>DELETE</strong> <code>api/transactions/{id}</code>: Deletes an existing transaction</li>
        <li><strong>GET</strong> <code>api/transactions/{id}</code>: Fetches a transaction by Id</li>
    </ul>
    
   <img src="https://github.com/user-attachments/assets/52a3c14d-2cb6-41de-9454-f1540c90744c" alt="Transactions Endpoints">

   <h3>Identity</h3>
    <p>Endpoints for user authentication and authorization</p>

 <h2>Architecture</h2>
    <img src="https://github.com/user-attachments/assets/588d20e7-64a4-44ed-a0d3-835a1cabb647" alt="Architecture Diagram">
</body>
