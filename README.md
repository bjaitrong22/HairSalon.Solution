# Application Name

HairSalon.Solution

#### Description

HairSalon.Solution is a tracking application for keeping track of stylists and their clients. The HairSalon owner can add,view,edit,and delete the stylist and their respective clients on the list. The stylists' and clients' information can be viewed by clicking on their names. 

#### Author

By Bai Jaitrong

## Technologies Used
  * Visual Studio code 1.73.1
  * .NET 6 SDK
  * C# 10
  * SQL
  * MySQL Workbench
  * Entity Framework Core
  
## Step 1. Installing MySQL Server and MySQl Workbench:

• Follow the instruction from LearnHowToProgram.com to install both MySQL Server 8.0.19 or the newest listed version and MySQL Workbench. Below is the link to the instructions:

https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql

• Ensure that the MySQL server is running by opening the Terminal or Windows Powershell and entering the command below:

  mysql -uroot -pepicodus 

If you set up MySQL Server with a different username and/or password, the command pattern is given below: 

mysql [YourUsername] -p[YourPassword] 

* omit the square brackets'[ ]'

## Step 2. Setup/Installation Requirements

  • Create a repository in your GitHub account for this project by selecting the green New button on the upper left side of the screen and follow the instruction. The button is across from Recent Repositories. You will need the URL for this repository in step 7.

  • Clone HairSalon.Solution repository to your desktop or a subdirectory in your desktop by running the command: 
  
    git clone https://github.com/bjaitrong22/HairSalon.Solution.git

  * Be careful not to clone the repository inside a local repository. Otherwise, you will have a nested git respository.

## Step 3. Removing the original remote repository and adding your remote repository

  • Navigate to the top level/root of the HairSalon.Solution directory using your command line.

  • Run the following command to find the name of the remote repository attached to this project so that it can be removed before adding your remote repository:

    git remote -v

    bj      https://github.com/bjaitrong22/HairSalon.Solution.git (fetch)
    bj      https://github.com/bjaitrong22/HairSalon.Solution.git (push)

  * you will get the response above, and the remote repository's nick name/identifier is bj or you may see it as origin.

 • Enter the command: 
 
    git remote rm origin 
    
    If the identifier is origin. Replace origin if the identifier is something else. So if the identifier is bj, you would enter git remote rm bj. 
      
• Confirm that the prior remote repository has been removed by running the command below:

    git remote -v  
      
    * Nothing should show up. That means the remote has been removed. If it hasn't been removed correctly, return to step 4. & 5. 
      
• Now you can add your remote repository by running the command below (be sure to remove the brackets) using your project's git repository url.  

    git remote add origin [your-project-url-here]. 
      
  * You can use an identifier other than origin. Copy the URL from your GitHub project repository by clicking the green CODE drop down menu on your GitHub repository and put it at the end of the command above. Which you should already have from step 1.
      
• You can confirm that the new remote is correctly linked by running the command: 

    git remote -v

## Step 4. Pushing .gitignore file from the clone HairSalon.Solution
    
• Before pushing any changes to your remote repository, navigate to top level/root of the HairSalon.Solution directory in your command line and run the following commands:  

    git add .gitignore 
    git commit -m "Add .gitignore file."
    git push [your-remote-Identifier] main
    
  This will let GitHub know what files not to upload to GitHub from your local repository.

## Step 7. Protecting the Database Connection String with appsettings.json

• Navigate to the HairSalon.Solution/HairSalon in your commandline.

• Run the command below:

    touch appsettings.json

• Open the appsettings.json file using your text editor of your choosing; the path should be "HairSalon.Solution/HariSalon/appsettings.json". Enter the code below:

{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=hair_salon;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
    }
}

* NOTE: 
a. The .gitignore file that was downloaded already has appsettings.json listed.

b. Make sure that [YOUR-USERNAME] and [YOUR-PASSWORD] matches the database username and password of your local MySQL server.Also the port 3306 is the default port.

## Step 6. Importing bai_jaitrong.sql (the included database .sql file):

  1. Open MySQL Workbench.
  2. In the Navigator > Administration window, select Data Import/Restore.
  3. In Import Options select Import from Self-Contained File.
  4. Navigate to bai_jaitrong.sql
  5. Under Default Schema to be Imported To, select the New button.
  6. Enter the name of the database.
      • In this case: hair_salon
  7. Click Ok.
  8. Click Start Import.
  9. Reopen the Navigator > Schemas tab. Right click and select Refresh All to see the imported database.

## Step 7. You are now ready to work on the project

• Open the project using your chosen text editor.
  
• Restore,build,and run the project:

     * Navigate to the subdirectroy HairSalon.Solution/HairSalon using your command line.

     * First, restore the dependencies that are listed in HairSalon.csproj by running the following command: 
     
        dotnet restore

     * Afterwards,run the command: 
         
         dotnet build. 
         
     * Finally, run the command below:

        dotnet run

        You can also run "dotnet watch run" if you would like the system to update the web pages as you experiment with the code.
    
## Known Bugs

  * The names does not stay left justified on the stylists and clients list.

# License

 * Portfolio is licensed under the terms of GNU AFFERO GENERAL PUBLIC LICENS Version 3, 19 November 2007 ( change if you are using a different license)


 