# Clinic
Clinic project

Project to track patient's appointments.

To run this project follow these steps:

1. Restore Nuget Packages.
2. If necessary update the csc Nuget Package manually using this command in the Nuget Terminal:
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
3. Run "Update-database -force" to apply all the database migrations.
  - If necessary create the App_Data folder
  - If "can't attach database" error occurs when applying the migrations, remove the initial_catalog part in the connection string, execute the migrations and restore de initial_catalog part.


Users to log into the application:

# Guest User
user: guest@clinic.com
pass: Clinic123.

# Admin User
user: admin@clinic.com
pass: Clinic123.

:)
