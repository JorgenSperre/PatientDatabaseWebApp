<h3 align="center">PatientDatabaseWebApp</h3>

  <p align="center">
    A simple web app for a patient database. Developed with Blazor.
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
  </ol>
</details>


### Prerequisites

Visual Studio:
* [Visual Studio (latest release)](https://visualstudio.microsoft.com/downloads/) with the ASP.NET and web development workload

Visual Studio Code:
* [Visual studio code](https://code.visualstudio.com/download)
* [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
* [.Net SDK](https://dotnet.microsoft.com/download/dotnet)

### Installation

Clone the repo:
   ```sh
   git clone https://github.com/JorgenSperre/PatientDatabaseWebApp.git
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Run the app

Visual Studio:
* Make sure the PatientDatabaseWebApp project is selected as the startup project.
* Press F5 to run the app.
* Generate custom certificate when prompted. [Relevant section in blazor tutorial](https://learn.microsoft.com/en-us/aspnet/core/blazor/tutorials/movie-database-app/part-1?view=aspnetcore-9.0&pivots=vs#run-the-app)


VS Code:
* Press F5 to run the app.
* At the Select debugger prompt in the Command Palette at the top of the VS Code UI, select C#. At the next prompt, select the default launch configuration (C#: PatientDatabaseWebApp [Default Configuration]).
* The default browser is launched at http://localhost:{PORT}, which displays the app's UI. The {PORT} placeholder is the random port assigned to the app when the app is created. If you need to change the port due to a local port conflict, change the port in the project's Properties/launchSettings.json file.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->
## Usage



The application consists of a database of patients with Id, Date of birth, Age, and a list of conditions.

The web app gives the user an overview of the database content, such as the number of patients, and the most common conditions.

The "Patients" tab lists all the patients, and has the option to sort and search.

The user is also able to add, view details, edit, and delete patients.
<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- CONTACT -->
## Contact

Project Link: [https://github.com/JorgenSperre/PatientDatabaseWebApp](https://github.com/JorgenSperre/PatientDatabaseWebApp)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

[Bootstrap.com]: https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white
[Bootstrap-url]: https://getbootstrap.com
[JQuery.com]: https://img.shields.io/badge/jQuery-0769AD?style=for-the-badge&logo=jquery&logoColor=white
[JQuery-url]: https://jquery.com 
