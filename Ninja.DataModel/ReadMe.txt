After Creating Classes and NinjaContext

I run the following to add migration and create new database

1. EntityFrameWork\enable-migrations
2. EntityFramework\add-migration Initial
3. EntityFramework\update-database -script => to apply migrations and see/review the script
4. EntityFramework\update-database -verbose => create databse

When new fields added
1. EntityFramework\add-migration AddBirthdayToNinja
2. EntityFramework\update-database -verbose => update databse
