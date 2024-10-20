<body>
    <h1>SaaS de Controle de Finanças Pessoais</h1>
    <p>Bem-vindo ao projeto SaaS de Controle de Finanças Pessoais, no qual você pode analisar suas transações através de gráficos e filtrar as operações por mês e ano. Este projeto foi desenvolvido utilizando as seguintes tecnologias:</p>
    <ul>
        <li>ASP.NET Minimal APIs</li>
        <li>Blazor WASM</li>
        <li>MudBlazor</li>
        <li>Identity</li>
        <li>EntityFramework</li>
        <li>SQL Server</li>
        <li>Views SQL</li>
    </ul>
    <p>O projeto segue alguns princípios de CQRS, DDD e SOLID para garantir uma arquitetura robusta e escalável.</p>

  <h2>Video Demo</h2>
https://www.youtube.com/watch?v=mo0og7f-mUk

   <h2>Endpoints</h2>
    <h3>Categories</h3>
    <ul>
        <li><strong>POST</strong> <code>api/categories</code>: Cria uma nova categoria</li>
        <li><strong>GET</strong> <code>api/categories</code>: Obtém todas as categorias paginadas</li>
        <li><strong>PUT</strong> <code>api/categories/{id}</code>: Edita uma categoria existente</li>
        <li><strong>DELETE</strong> <code>api/categories/{id}</code>: Exclui uma categoria existente</li>
        <li><strong>GET</strong> <code>api/categories/{id}</code>: Busca uma categoria por Id</li>
    </ul>
    

![parte1fotoatt](https://github.com/user-attachments/assets/0201fd9f-3de2-4acd-a430-ee9347cfbc9b)


   <h3>Transactions</h3>
    <ul>
        <li><strong>POST</strong> <code>api/transactions</code>: Cria uma nova transação</li>
        <li><strong>GET</strong> <code>api/transactions</code>: Obtém todas as transações paginadas</li>
        <li><strong>PUT</strong> <code>api/transactions/{id}</code>: Edita uma transação existente</li>
        <li><strong>DELETE</strong> <code>api/transactions/{id}</code>: Exclui uma transação existente</li>
        <li><strong>GET</strong> <code>api/transactions/{id}</code>: Busca uma transação por Id</li>
    </ul>
    
![Parte2Foto](https://github.com/user-attachments/assets/52a3c14d-2cb6-41de-9454-f1540c90744c)

   <h3>Identity</h3>
    <p>Endpoints para autenticação e autorização do usuário</p>
    

   <h2>Arquitetura</h2>
   
  ![arcsa](https://github.com/user-attachments/assets/588d20e7-64a4-44ed-a0d3-835a1cabb647)

</body>
