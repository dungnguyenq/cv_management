- This is the simple web application Which will help Head Hunter or Human Resource can manage their candidates

- Technologies and frameworks used:
  + ASP.NET MVC Core 3.1
  + Entity Framework Core 3.1
  + IdentityServer4 
  + Angular 8
  
- Live Demo:
  + Front-end: https://sd3246storage.z23.web.core.windows.net/
  + API: https://sd3246-api.azurewebsites.net/
  + Username/Passwork: dung@nashtechglobal.com/Nashtech@123
                       dung@gmail.com/Nashtech@123
- Step to run
  + Build Solution
  + In solution explore, select project 'CVManagement.Api' as startup project
  + Press "F5" or "Ctrl + F5" to run
  + Using visual studio code or any command line
  + Open Folder CVManagement.UI
  + Type the command: "npm install"  to install package
  + Type: "ng serve" to run 
  + Navigate to http://localhost:4200/ to enjoy

- Currently Fuction in App:
  + Add/delete/edit candidate information
  + Add/delete/edit master data 
  + Sendmail to candidate via smtp gmail( not available in azure web app, this function will be update later)
  + Get all list of candidate, filter by all information, pagination
 
- Function will be implement in the future:
  + Add/delete/edit Job
  + Mapping candidates to the right jobs 
  + Add role for Candidate, candidate canupdate their information and find new job
  + Add role for teamwork, head hunt can manage candidate for team
  + Update process for candidate from send cv to become a Staff
  + ...

