<h3>Running the application</h3>
<p>You will need to have the following installed to run the application</p>
<ul>
<li>.Net Core 3.1</li>
<li>The latest stable version of node</li>
<li>Microsoft SQL Seerver Express or Local DB</li>
</ul>

<h3>Running the backend</h3>
<p>Go into the src\Resumes.Api folder and run the following command for the command prompt</p>
<ul>
<li>dotnet run</li>
</ul>
<p>
The backend will start running on http://localhost:5000/ . The database will be seeded on application start-up.
The connection string is in the appsettings.json file.
</p>

<h3>Running the front-en</h3>
<p>Go into the src\resumes-spa folder and run the following commands for the command prompt</p>
<ul>
<li>npm install</li>
<li>ng serve --open</li>
</ul>
<p>
The fronted will start running on http://localhost:4200/ . 
</p>