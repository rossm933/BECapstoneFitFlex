<h1 align="center" style="font-weight: bold;">FitFlex 💻</h1>

<p align="center">
 <a href="#tech">Technologies</a> • 
 <a href="#started">Getting Started</a> • 
  <a href="#routes">API Endpoints</a> •
 <a href="#colab">Collaborators</a> •
 <a href="#contribute">Contribute</a>
</p>

<p align="center">
    <b>The FitFlex API provides endpoints for managing workoouts, exercises, and tags for the exercises. This collection allows users to retrieve, create, update, and delete workouts, exercises, tags, and user. It is designed to facilitate creating workouts and adding exercises to the workout. The tags on the exercises allow the user to know where on the body the exercise targets. 
</p>

<h2 id="technologies">💻 Technologies</h2>

- list of all technologies you used
- C#
- .NET
- SQL
- Postman

<h2 id="started">🚀 Getting started</h2>

1.) Clone a repository option in Visual Studio 
2.) Enter or type the repository location, and then select the Clone button<br>

In the terminal enter the following: 
3.) ```bash
dotnet ef --version
```
4.) ```bash
dotnet tool install --global dotnet-ef
```
5.) ```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0
```
6.) ```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0
```
7.) ```bash
dotnet user-secrets set "FitFlexDbConnectionString"
```
8.)```bash
dotnet user-secrets set "FitFlexDbConnectionString"
```
9.)```bash
"Host=localhost;Port=5432;Username=postgres;Password="YourPgAdminPassword"!;Database=FitFlex"
```
10.)```bash
"dotnet ef database update"
```
11.) To start building the program, press the green Start button on the Visual Studio toolbar, or press F5 or Ctrl+F5. Using the Start button or F5 runs the program under the debugger.

<h3>Prerequisites</h3>

Here you list all prerequisites necessary for running your project. For example:

- [Visual Studio](https://visualstudio.microsoft.com/)
- [.NET](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

<h3>Cloning</h3>

How to clone your project

```bash
git clone git@github.com:rossm933/BECapstoneFitFlex.git
```

<h3>Starting</h3>

How to start your project

```bash
cd BECapstoneFitFlex
dotnet watch run
```

<h2 id="routes">📍 API Endpoints</h2>

​
| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /workout/user/{userId}</kbd>     | Retrieves workouts by UserId
| <kbd>GET /workout/{id}</kbd>     | Retrieves individual workout by id
| <kbd>POST /workout</kbd>     | Creates a new workout
| <kbd>PUT /workout/{id}</kbd>     | Update a workout
| <kbd>DELETE /workoout/{id}</kbd>     | Deletes a workout by id
| <kbd>GET /exercise</kbd>     | Retrieves all exercises
| <kbd>GET /exercise/{id}</kbd>     | Retrieves individual exercise by id
| <kbd>POST /exercise</kbd>     | Creates a new exercise
| <kbd>PUT /exercise/{id}</kbd>     | Update a exercise
| <kbd>DELETE /exercise/{id}</kbd>     | Deletes a exercise by id
| <kbd>GET /tag</kbd>     | Retrieves all tags
| <kbd>POST /tag</kbd>     | Creates a new tag
| <kbd>PUT /tag/{id}</kbd>     | Update a tag
| <kbd>DELETE /tag/{id}</kbd>     | Deletes a tag by id
| <kbd>GET /user/{id}</kbd>     | Retrieves individual user by id
| <kbd>POST /user</kbd>     | Creates a new user
| <kbd>PUT /user/{id}</kbd>     | Update a user
| <kbd>DELETE /user/{id}</kbd>     | Deletes a user by id


<h2 id="colab">🤝 Collaborators</h2>

Special thank you for all people that contributed for this project.

<table>
  <tr>
    <td align="center">
      <a href="https://github.com/rossm933">
        <img src="https://avatars.githubusercontent.com/u/148557558?v=4" width="100px;" alt="Ross Morgan Profile Picture"/><br>
        <sub>
          <b>Ross Morgan</b>
        </sub>
      </a>
    </td>
  </tr>
</table>

<h2 id="contribute">📫 Contribute</h2>

Here you will explain how other developers can contribute to your project. For example, explaining how can create their branches, which patterns to follow and how to open an pull request

1. `git clone git@github.com:rossm933/BECapstoneFitFlex.git`
2. `git checkout -b feature/NAME`
3. Follow commit patterns
4. Open a Pull Request explaining the problem solved or feature made, if exists, append screenshot of visual modifications and wait for the review!

<h3>Documentations that might help</h3>

[📝 How to create a Pull Request](https://www.atlassian.com/br/git/tutorials/making-a-pull-request)

[💾 API Postman Documentation]()
