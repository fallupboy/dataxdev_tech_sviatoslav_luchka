# dataxdev_tech_sviatoslav_luchka

All you have to do to try this project is to check your connection between MSSQL server and project. So please go to Web.config file and check your connection string. Then after your first run of the web service you need to comment out all the data which in Global.asax.cs file which were added to initially create the database with data already  filled (28-46 lines)

To change log files path you have to change the 'file value' in Web.config -> log4net

If you are having a problem with 'roslyn' you can run 'Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r' in Package Manager Console to resolve it
