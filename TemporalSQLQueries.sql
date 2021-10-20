SELECT  [Id]
      ,[FirstName]
      ,[LastName]
      ,[MiddleName],PeriodEnd,PeriodStart
  FROM [TemporalTest].[dbo].[People] 

  update people set lastname='Jones' where firstname='George'

  SELECT  [Id]
      ,[FirstName]
      ,[LastName]
      ,[MiddleName],PeriodEnd,PeriodStart
  FROM [TemporalTest].[dbo].[People] 
  FOR System_Time AS OF '2021-10-16 17:21:24.4302038'

  