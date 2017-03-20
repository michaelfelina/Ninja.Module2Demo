After Creating Classes and NinjaContext

I run the following to add migration and create new database

1. EntityFrameWork\enable-migrations
2. EntityFramework\add-migration Initial
3. EntityFramework\update-database -script => to apply migrations and see/review the script
4. EntityFramework\update-database -verbose => create databse

When new fields added
1. EntityFramework\add-migration AddBirthdayToNinja
2. EntityFramework\update-database -verbose => update databse

Deffault Database Connection
LocalDb

  <entityFramework>

    <defaultConnectionFactory type=“System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework“>

      <parameters>

        <parameter value=“v11.0“ />

      </parameters>

    </defaultConnectionFactory>

  </entityFramework>

Now, replace that portion of the configuration to make use of Sql Server instead of LocalDb.

Sql Server

  <entityFramework>

    <defaultConnectionFactory type=“System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework“>

      <parameters>

        <parameter value=“Data Source=.; Integrated Security=True; MultipleActiveResultSets=True“ />

      </parameters>

    </defaultConnectionFactory>

  </entityFramework>