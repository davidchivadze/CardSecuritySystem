namespace Domain.Migrations
{
    using Core.Encryption;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Domain.Data>
    {
        private readonly bool _pendingMigrations;
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;
            // Check if there are migrations pending to run, this can happen if database doesn't exists or if there was any
            //  change in the schema
            var migrator = new DbMigrator(this);
            _pendingMigrations = migrator.GetPendingMigrations().Any();

            // If there are pending migrations run migrator.Update() to create/update the database then run the Seed() method to populate
            //  the data if necessary
            if (_pendingMigrations)
            {
                migrator.Update();
                this.Seed(new Domain.Data());
            }
        }

        protected override void Seed(Domain.Data context)
        {
            this.SeedProcedures(context);
            if (context.Currencies.Count() == 0)
            {
                context.Currencies.Add(new Models.EntityModels.Currency() { ID = 1, Description = "₾" });
                context.Currencies.Add(new Models.EntityModels.Currency() { ID = 2, Description = "$" });
                context.Currencies.Add(new Models.EntityModels.Currency() { ID = 3, Description = "€" });
                context.SaveChanges();
            }
            if (context.ForgivenessTypes.Count() == 0)
            {
                context.ForgivenessTypes.Add(new Models.EntityModels.ForgivenessType() { ID = 1, Description = "პატიების გარეშე" });
                context.ForgivenessTypes.Add(new Models.EntityModels.ForgivenessType() { ID = 2, Description = "X წუთის პატიება თვეში" });
                context.ForgivenessTypes.Add(new Models.EntityModels.ForgivenessType() { ID = 3, Description = "X რაოდენობის პატიება თვეში" });
                context.ForgivenessTypes.Add(new Models.EntityModels.ForgivenessType() { ID = 4, Description = "დარედაქტირდა" });
                context.SaveChanges();
            }
            if (context.FineTypes.Count() == 0)
            {
                context.FineTypes.Add(new Models.EntityModels.FineType() { ID = 1, Description = "ჯარიმის გარეშე" });
                context.FineTypes.Add(new Models.EntityModels.FineType() { ID = 2, Description = "პროცენტული ჯარიმა წუთზე" });
                context.FineTypes.Add(new Models.EntityModels.FineType() { ID = 3, Description = "ფიქსირებული ჯარიმა წუთზე" });
                context.FineTypes.Add(new Models.EntityModels.FineType() { ID = 4, Description = "პროცენტული ჯარიმა" });
                context.FineTypes.Add(new Models.EntityModels.FineType() { ID = 5, Description = "ფიქსირებული ჯარიმა" });
                context.FineTypes.Add(new Models.EntityModels.FineType() { ID = 6, Description = "ბიჯური ჯარიმა" });
                context.SaveChanges();
            }
            if (context.SalaryTypes.Count() == 0)
            {
                context.SalaryTypes.Add(new Models.EntityModels.SalaryType() { ID = 1, Description = "ყოველთვიური ანაზღაურება" });
                context.SalaryTypes.Add(new Models.EntityModels.SalaryType() { ID = 2, Description = "საათობრივი ანაზღაურება" });
                context.SalaryTypes.Add(new Models.EntityModels.SalaryType() { ID = 3, Description = "წლიური ანაზღაურება" });
                context.SalaryTypes.Add(new Models.EntityModels.SalaryType() { ID = 4, Description = "კვირეული ანაზღაურება" });
                context.SaveChanges();
            }
            if (context.Genders.Count() == 0)
            {
                context.Genders.Add(new Models.EntityModels.Gender() { ID = 1, Description = "Male" });
                context.Genders.Add(new Models.EntityModels.Gender() { ID = 2, Description = "Female" });
                context.SaveChanges();
            }
            if (context.Countries.Count() == 0)
            {
                context.Countries.Add(new Models.EntityModels.Country() { ID = 1, Description = "საქართველო" });
                context.SaveChanges();
            }

            if (context.Cities.Count() == 0)
            {
                context.Cities.Add(new Models.EntityModels.City() { ID = 1, Description = "თბილისი", CountryID = 1 });
                context.SaveChanges();
            }

            if (context.HolidayTypes.Count() == 0)
            {

                context.HolidayTypes.Add(new Models.EntityModels.HolidayType() { ID = 1, Description = "შვებულება" });
                context.HolidayTypes.Add(new Models.EntityModels.HolidayType() { ID = 2, Description = "დეკრეტი" });
                context.HolidayTypes.Add(new Models.EntityModels.HolidayType() { ID = 3, Description = "უხელფასო შვებულება" });
                context.HolidayTypes.Add(new Models.EntityModels.HolidayType() { ID = 4, Description = "Day Off" });
                context.HolidayTypes.Add(new Models.EntityModels.HolidayType() { ID = 5, Description = "გამონაკლისი" });
                context.HolidayTypes.Add(new Models.EntityModels.HolidayType() { ID = 6, Description = "ბიულეტინი" });
                context.SaveChanges();
            }
            if (context.ScheduleTypes.Count() == 0)
            {
                context.ScheduleTypes.Add(new Models.EntityModels.ScheduleType() { ID = 1, Description = "სტანდარტული" });
                context.ScheduleTypes.Add(new Models.EntityModels.ScheduleType() { ID = 2, Description = "არასტანდარტული" });

                context.SaveChanges();
            }
            if (context.DeviceTypes.Count() == 0)
            {
                context.DeviceTypes.Add(new Models.EntityModels.DeviceType()
                {
                    Description = "ZKTeco მოწყობილობა",
                    ID = 1
                });
                context.SaveChanges();
            }
            if (context.Users.Count() == 0)
            {
                context.Users.Add(new Models.EntityModels.Users()
                {
                    UserName = "admin",
                    Password = HashGenerator.CreateMD5("admin")
                });
            }
            if (context.EmployeeWorkingLogTimeTypes.Count() == 0)
            {
                context.EmployeeWorkingLogTimeTypes.Add(new Models.EntityModels.EmployeeWorkingLogTimeType()
                {
                    ID = 1,
                    Description = "ნამუშევარი საათები"
                });
                context.SaveChanges();

                context.EmployeeWorkingLogTimeTypes.Add(new Models.EntityModels.EmployeeWorkingLogTimeType()
                {
                    ID = 2,
                    Description = "შესვენება"
                });
                context.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }

        private void SeedProcedures(Domain.Data context)
        {
            context.Database.ExecuteSqlCommand(@"
CREATE OR ALTER PROCEDURE [dbo].[GenerateFullReport]
	@StartDate DATE,
	@EndDate DATE,
	@EmployeeID INT =NULL
AS
BEGIN
	--SELECT DISTINCT IndRegID,DateTimeRecord, emp.FirsName+' '+emp.LastName As FullName
	
	--FROM DeviceUserLogs dul
	--INNER JOIN Employee emp ON emp.UserIdInDevice=dul.IndRegID
	----where IndRegID=3
	--ORDER BY DateTimeRecord DESC 

	DECLARE @EmployeeIDWork INT

	DECLARE @EmployeeStartTime DateTime,
			@EmployeeEndTime DateTime,
			@WeekHouresAmount INT,
			@DaylyHouresAmount INT,
			@OnWorkingDaysOnly BIT,
			@BreakAmount INT,
			@IsWorkingDay BIT=1,
			@CheckInTime DATETIME,
			@CheckOutTime DateTime,
			@IndRegID INT,
			@EmployeeFullName NVARCHAR(max),
			@DailyHouresAmountResult DECIMAL (18,2),
			@WorkMinutesBySchedule INT
	
	DECLARE @LoopStartDate DATE=@StartDate
	--მომხმარებლის დროების წყვეტა საიდან სადამდე

	IF OBJECT_ID('tempdb.dbo.#UsersReportResponse', 'U') IS NOT NULL
			DROP TABLE #UsersReportResponse
	
	--DECLARE @EmployeeID INT

	CREATE TABLE #UsersReportResponse(
	EmployeeID INT,
	ScheduleFromTime DateTime,
	ScheduleToTime DateTime,
	IsWorkingDay BIT,
	CheckInTime DATETIME,
	CheckOutTime DATETIME,
	LateCheckInMinutes INT,
	EarlyCheckInMinutes INT,
	EarlyCheckOutMinutes INT,
	LateCheckOutMinutes INT,
	WorkStatus NVARCHAR(250),
	FullName NVarChar(max),
	IndRegID INT,
	WorkedMinutess INT,
	FineMinutes INT,
	WorkedInSchedule INT,
	WorkedOutSchedule INT,
	MissedMinutes INT)

	
	DECLARE employeeCursor CURSOR FOR   
	SELECT ID,UserIdInDevice,FirsName+' '+LastName
	FROM Employee
	WHERE IsActive=1 AND UserIdInDevice IS NOT NULL AND UserIdInDevice!=0
	OPEN employeeCursor
	FETCH NEXT FROM employeeCursor   
	INTO @EmployeeIDWork,@IndRegID,@EmployeeFullName
	WHILE @@FETCH_STATUS = 0  
		BEGIN
		
		SELECT TOP 1
		@EmployeeStartTime=sc.StartTime,
		@EmployeeEndTime=sc.EndTime,
		@WeekHouresAmount=sc.WeekHouresAmount,
		@DaylyHouresAmount=DaylyHouresAmount,
		@OnWorkingDaysOnly=OnWorkingDaysOnly,
		@BreakAmount=BreakAmount,
		@WorkMinutesBySchedule=DATEDIFF(MINUTE,sc.StartTime,sc.EndTime)-sc.BreakAmount*60
		 FROM Employee emp
		INNER JOIN [Schedules] sc ON sc.ID=emp.ScheduleID WHERE emp.ID=@EmployeeIDWork
		
		WHILE(@LoopStartDate<=@EndDate)
		BEGIN
		
		--ვადგენთ არის თუ არა თარიღი სამუშაო დღე
		IF(DATEPART(WEEKDAY,@LoopStartDate)=7 OR DATEPART(WEEKDAY,@LoopStartDate)=1)
		BEGIN
		SET @IsWorkingDay=0
		END
		ELSE
		BEGIN 
		SET @IsWorkingDay=1
		END
		--ვადგენთ პირველად შესვლის დროს და ბოლო გასვლის დროს
			PRINT @IndRegID
		SET @CheckInTime=(SELECT TOP 1 FromDate FROM EmployeeWorkingLogs where IndRegID=@IndRegID AND CAST(FromDate AS DATE)=CAST(@LoopStartDate AS DATE) AND EmployeeWorkingLogTimeTypeID=1
		ORDER BY FromDate ASC)
		SET @CheckOutTime=(SELECT TOP 1 ToDate FROM EmployeeWorkingLogs where IndRegID=@IndRegID AND CAST(FromDate AS DATE)=CAST(@LoopStartDate AS DATE) AND  EmployeeWorkingLogTimeTypeID=1
		ORDER BY ToDate Desc)
		
		SELECT @DailyHouresAmountResult=SUM(ewl.Minutes) FROM dbo.EmployeeWorkingLogs ewl WHERE CAST(ewl.FromDate AS DATE)=CAST(@LoopStartDate AS DATE) AND ewl.IndRegID=@IndRegID AND ewl.EmployeeWorkingLogTimeTypeID=1
		
				INSERT INTO #UsersReportResponse 
				(EmployeeID,
				ScheduleFromTime,
				ScheduleToTime,
				IsWorkingDay,
				CheckInTime,
				CheckOutTime,
				LateCheckInMinutes,
				EarlyCheckInMinutes,
				LateCheckOutMinutes,
				EarlyCheckOutMinutes,
				WorkStatus,
				IndRegID,
				FullName,
				WorkedMinutess,
				WorkedInSchedule,
				WorkedOutSchedule
				)
				VALUES 
				(@EmployeeIDWork,
				(CAST(CAST(@LoopStartDate as DATE) as DATETIME)+CAST(@EmployeeStartTime as DATETIME)),
				(CAST(CAST(@LoopStartDate as DATE) as DATETIME)+CAST(@EmployeeEndTime as DATETIME)),
				@IsWorkingDay,
				@CheckInTime,
				@CheckOutTime,
				CASE WHEN (DATEDIFF(minute,(CAST(CAST(@LoopStartDate as DATE) as DATETIME)+CAST(@EmployeeStartTime as DATETIME)),@CheckInTime)<=0) THEN
				0 ELSE DATEDIFF(minute,(CAST(CAST(@LoopStartDate as DATE) as DATETIME)+CAST(@EmployeeStartTime as DATETIME)),@CheckInTime) END,
				CASE WHEN (DATEDIFF(minute,@CheckInTime,(CAST(CAST(@LoopStartDate as DATE) as DATETIME)+CAST(@EmployeeStartTime as DATETIME)))<=0) THEN
				0 ELSE -DATEDIFF(minute,(CAST(CAST(@LoopStartDate as DATE) as DATETIME)+CAST(@EmployeeStartTime as DATETIME)),@CheckInTime) END,
				CASE WHEN (DATEDIFF(minute,(CAST(CAST(@LoopStartDate as DATE) as DATETIME)+CAST(@EmployeeEndTime as DATETIME)),@CheckOutTime)<=0) THEN
				0 ELSE DATEDIFF(minute,(CAST(CAST(@LoopStartDate as DATE) as DATETIME)+CAST(@EmployeeEndTime as DATETIME)),@CheckOutTime) END,
								CASE WHEN (DATEDIFF(minute,@CheckOutTime,(CAST(CAST(@LoopStartDate as DATE) as DATETIME)+CAST(@EmployeeEndTime as DATETIME)))<=0) THEN
				0 ELSE -DATEDIFF(minute,(CAST(CAST(@LoopStartDate as DATE) as DATETIME)+CAST(@EmployeeEndTime as DATETIME)),@CheckOutTime) END,
				CASE when @CheckInTime IS NULL THEN N'გააცდინა' ELSE N'იმუშავა' END,
				@IndRegID,
				@EmployeeFullName,
				@DailyHouresAmountResult,
				CASE WHEN @WorkMinutesBySchedule>=@DailyHouresAmountResult THEN @DailyHouresAmountResult ELSE @WorkMinutesBySchedule END,
				CASE WHEN @WorkMinutesBySchedule>=@DailyHouresAmountResult THEN 0 ELSE @DailyHouresAmountResult-@WorkMinutesBySchedule END
                
				)



			SET @LoopStartDate=DATEADD(day,1,@LoopStartDate)
		END
		SET @LoopStartDate=@StartDate
	FETCH NEXT FROM employeeCursor   
	INTO @EmployeeIDWork,@IndRegID,@EmployeeFullName

		END
		CLOSE employeeCursor
		DEALLOCATE  employeeCursor
	SELECT * FROM #UsersReportResponse
	--SELECT DISTINCT ltt.Description as Status,CAST(ewl.FromDate as DATE) DateRecord,IndRegID,SUM(ewl.Minutes) as MinutesSum, emp.FirsName+' '+emp.LastName As FullName,emp.ID as EmployeeID,emp.PersonalNumber,ep.Description Position FROM [EmployeeWorkingLogs] ewl
	--INNER JOIN EmployeeWorkingLogTimeTypes ltt ON ltt.ID=ewl.EmployeeWorkingLogTimeTypeID
	--INNER JOIN Employee emp ON emp.UserIdInDevice=ewl.IndRegID
	--INNER JOIN EmployeeDetails ed ON ed.ID=emp.[EmployeeDetails_ID]
	--INNER JOIN EmployeePositions ep ON ep.ID=ed.EmployeePositionID
	--where
	--FromDate>=@StartDate AND ToDate<=@EndDate
	--AND emp.ID=ISNULL(@EmployeeID,emp.ID)
	--GROUP BY 
	-- ltt.Description,CAST(ewl.FromDate as DATE),IndRegID,emp.FirsName+' '+emp.LastName,emp.ID,emp.PersonalNumber,ep.Description
	--SELECT (CASE when IsCheckIn=1 then N'ნამუშევარი საათები' ELSE N'შესვენება' END) as Statuss,FullName,CAST(FromTime as DATE) as DateLog,IndRegID,CAST(SUM(Minutess)/60 as NVARCHAR(max))+':'+CAST(SUM(Minutess)%60 as NVARCHAR(MAX)) FROM [EmployeeWorkingLogs] GROUP BY 
	--(CASE when IsCheckIn=1 then N'ნამუშევარი საათები' ELSE N'შესვენება' END),
	--FullName,
	--CAST(FromTime as DATE),
	--IndRegID

		


END



");
            context.Database.ExecuteSqlCommand(@"
CREATE OR ALTER PROCEDURE [dbo].[GenerateMODReport]
	@StartDate DATE,
	@EndDate DATE,
	@EmployeeID INT =NULL
AS
BEGIN
	--SELECT DISTINCT IndRegID,DateTimeRecord, emp.FirsName+' '+emp.LastName As FullName
	
	--FROM DeviceUserLogs dul
	--INNER JOIN Employee emp ON emp.UserIdInDevice=dul.IndRegID
	----where IndRegID=3
	--ORDER BY DateTimeRecord DESC 
	
	DECLARE @LoopStartDate DATE=@StartDate
	--მომხმარებლის დროების წყვეტა საიდან სადამდე

	IF OBJECT_ID('tempdb.dbo.#UsersLogList', 'U') IS NOT NULL
			DROP TABLE #UsersLogList
	
	--DECLARE @EmployeeID INT

	CREATE TABLE #UsersLogList(IsCheckIn BIT,FromTime DATETIME,ToTime DATETIME,FullName NVarChar(max),IndRegID INT,Minutess INT)

	
	--DECLARE employeeCursor CURSOR FOR   
	--SELECT ID
	--FROM Employee
	--WHERE IsActive=1 AND UserIdInDevice IS NOT NULL
	--OPEN employeeCursor
	--FETCH NEXT FROM employeeCursor   
	--INTO @EmployeeID
	--WHILE @@FETCH_STATUS = 0  
	--	BEGIN
	--	WHILE(@LoopStartDate<=@EndDate)
	--	BEGIN
	--	INSERT INTO #UsersLogList
	--	EXEC [dbo].[GetEmployeeLogDate]
	--			@StartDate = @LoopStartDate,
	--			@EndDate = @LoopStartDate,
	--			@EmployeeID = 3

	--	SET @LoopStartDate=DATEADD(day,1,@LoopStartDate)
	--	END

	--FETCH NEXT FROM employeeCursor   
	--INTO @EmployeeID
	--	END
	--	CLOSE employeeCursor
	--	DEALLOCATE  employeeCursor
	
	SELECT DISTINCT ltt.Description as Status,CAST(ewl.FromDate as DATE) DateRecord,IndRegID,SUM(ewl.Minutes) as MinutesSum, emp.FirsName+' '+emp.LastName As FullName,emp.ID as EmployeeID,emp.PersonalNumber,ep.Description Position FROM [EmployeeWorkingLogs] ewl
	INNER JOIN EmployeeWorkingLogTimeTypes ltt ON ltt.ID=ewl.EmployeeWorkingLogTimeTypeID
	INNER JOIN Employee emp ON emp.UserIdInDevice=ewl.IndRegID
	INNER JOIN EmployeeDetails ed ON ed.ID=emp.[EmployeeDetails_ID]
	INNER JOIN EmployeePositions ep ON ep.ID=ed.EmployeePositionID
	where
	FromDate>=@StartDate AND ToDate<=@EndDate
	AND emp.ID=ISNULL(@EmployeeID,emp.ID)
	GROUP BY 
	 ltt.Description,CAST(ewl.FromDate as DATE),IndRegID,emp.FirsName+' '+emp.LastName,emp.ID,emp.PersonalNumber,ep.Description
	--SELECT (CASE when IsCheckIn=1 then N'ნამუშევარი საათები' ELSE N'შესვენება' END) as Statuss,FullName,CAST(FromTime as DATE) as DateLog,IndRegID,CAST(SUM(Minutess)/60 as NVARCHAR(max))+':'+CAST(SUM(Minutess)%60 as NVARCHAR(MAX)) FROM [EmployeeWorkingLogs] GROUP BY 
	--(CASE when IsCheckIn=1 then N'ნამუშევარი საათები' ELSE N'შესვენება' END),
	--FullName,
	--CAST(FromTime as DATE),
	--IndRegID

		


END


");
            context.Database.ExecuteSqlCommand(@"

CREATE OR ALTER PROCEDURE [dbo].[GenerateMODReportData]
	@StartDate DATE,
	@EndDate DATE 
AS
BEGIN
;WITH cte AS (
    SELECT 
        MachineNumber, 
        IndRegID, 
        dwVerifyMode,
		dwInOutMode,
		DateTimeRecord,
        ROW_NUMBER() OVER (
            PARTITION BY 
        MachineNumber, 
        IndRegID, 
        IndRegID, 
        dwVerifyMode,
		dwInOutMode,
		DateTimeRecord
            ORDER BY 
        MachineNumber, 
        IndRegID, 
        IndRegID, 
        dwVerifyMode,
		dwInOutMode,
		DateTimeRecord
        ) row_num
     FROM 
        dbo.DeviceUserLogs
)
DELETE FROM cte
WHERE row_num > 1;
	--SELECT DISTINCT IndRegID,DateTimeRecord, emp.FirsName+' '+emp.LastName As FullName
	
	--FROM DeviceUserLogs dul
	--INNER JOIN Employee emp ON emp.UserIdInDevice=dul.IndRegID
	----where IndRegID=3
	--ORDER BY DateTimeRecord DESC 
	
	DECLARE @LoopStartDate DATE=@StartDate
	--მომხმარებლის დროების წყვეტა საიდან სადამდე

	IF OBJECT_ID('tempdb.dbo.#UsersLogList', 'U') IS NOT NULL
			DROP TABLE #UsersLogList
	
	DECLARE @EmployeeID INT

	CREATE TABLE #UsersLogList(IsCheckIn BIT,FromTime DATETIME,ToTime DATETIME,FullName NVarChar(max),IndRegID INT,Minutess INT)

	
	DECLARE employeeCursor CURSOR FOR   
	SELECT ID
	FROM Employee
	WHERE IsActive=1 AND UserIdInDevice IS NOT NULL
	OPEN employeeCursor
	FETCH NEXT FROM employeeCursor   
	INTO @EmployeeID
	WHILE @@FETCH_STATUS = 0  
		BEGIN
		WHILE(@LoopStartDate<=@EndDate)
		BEGIN
		INSERT INTO #UsersLogList
		EXEC [dbo].[GetEmployeeLogDate]
				@StartDate = @LoopStartDate,
				@EndDate = @LoopStartDate,
				@EmployeeID = @EmployeeID

		SET @LoopStartDate=DATEADD(day,1,@LoopStartDate)
		END

	FETCH NEXT FROM employeeCursor   
	INTO @EmployeeID
		END
		CLOSE employeeCursor
		DEALLOCATE  employeeCursor
	

	--SELECT (CASE when IsCheckIn=1 then N'ნამუშევარი საათები' ELSE N'შესვენება' END) as Statuss,FullName,CAST(FromTime as DATE) as DateLog,IndRegID,CAST(SUM(Minutess)/60 as NVARCHAR(max))+':'+CAST(SUM(Minutess)%60 as NVARCHAR(MAX)) FROM #UsersLogList GROUP BY 
	--(CASE when IsCheckIn=1 then N'ნამუშევარი საათები' ELSE N'შესვენება' END),
	--FullName,
	--CAST(FromTime as DATE),
	--IndRegID

		


END



");
			context.Database.ExecuteSqlCommand(@"

CREATE OR ALTER PROCEDURE [dbo].[GetEmployeeLogDate]
	@StartDate DATE,
	@EndDate DATE,
	@EmployeeID INT
AS
BEGIN
	--SELECT DISTINCT IndRegID,DateTimeRecord, emp.FirsName+' '+emp.LastName As FullName
	
	--FROM DeviceUserLogs dul
	--INNER JOIN Employee emp ON emp.UserIdInDevice=dul.IndRegID
	----where IndRegID=3
	--ORDER BY DateTimeRecord DESC 
	
	
	--მომხმარებლის დროების წყვეტა საიდან სადამდე

	IF OBJECT_ID('tempdb.dbo.#UserDistinctLog', 'U') IS NOT NULL
			DROP TABLE #UserDistinctLog
	CREATE TABLE #UserDistinctLog( IndRegID INT,FullName NVarChar(max),FromTime DateTime,ToTime DateTime)
	INSERT INTO #UserDistinctLog

	SELECT DISTINCT 
	dul1.IndRegID,
	emp.FirsName+' '+emp.LastName As FullName,
	CAST(dul1.DateTimeRecord as DATETIME) as FromTime,
	CAST(dul3.DateTimeRecord as DATETIME) as ToTime

FROM
    DeviceUserLogs dul1
	INNER JOIN(	SELECT DISTINCT 
	(ROW_NUMBER() OVER(ORDER BY IndRegID,CAST(DateTimeRecord as DATETIME) ASC)) as RowNumber,
	dul1.IndRegID,
	CAST(dul1.DateTimeRecord as DATETIME) as DateTimeRecord
		FROM
			DeviceUserLogs dul1 where dul1.DateTimeRecord>=@StartDate AND dul1.DateTimeRecord<=@EndDate) as dul2 ON dul2.DateTimeRecord=dul1.DateTimeRecord
    INNER JOIN (SELECT DISTINCT 
				IndRegID,
				CAST(DateTimeRecord as DATETIME) as DateTimeRecord,
				(ROW_NUMBER() OVER(ORDER BY IndRegID,CAST(DateTimeRecord as DATETIME) ASC)) as RowNumber 
					from DeviceUserLogs 
					where DateTimeRecord>=@StartDate AND DateTimeRecord<=@EndDate
					ORDER BY 2 OFFSET (1) ROWS) as dul3 ON dul2.RowNumber+1=dul3.RowNumber
	INNER JOIN Employee emp ON emp.UserIdInDevice=dul1.IndRegID
	where dul1.DateTimeRecord>=@StartDate AND dul1.DateTimeRecord<=@EndDate
ORDER BY 3

INSERT INTO [dbo].[EmployeeWorkingLogs]
           ([FromDate]
           ,[ToDate]
           ,[IndRegID]
           ,[Minutes]
           ,[EmployeeWorkingLogTimeTypeID])
SELECT FromTime,ToTime,IndRegID,DATEDIFF(mi,FromTime,ToTime) as Minutess,CASE WHEN ((ROW_NUMBER() OVER(ORDER BY IndRegID,FromTime ASC))%2=1) then 1 ELSE 2 END FROM #UserDistinctLog

;WITH cte AS (
    SELECT 
        [FromDate], 
        [ToDate], 
        IndRegID, 
        [Minutes],
		[EmployeeWorkingLogTimeTypeID],
        ROW_NUMBER() OVER (
            PARTITION BY 
        [FromDate], 
        [ToDate], 
        IndRegID, 
        [Minutes],
		[EmployeeWorkingLogTimeTypeID]
            ORDER BY 
        [FromDate], 
        [ToDate], 
        IndRegID, 
        [Minutes],
		[EmployeeWorkingLogTimeTypeID]
        ) row_num
     FROM 
        dbo.[EmployeeWorkingLogs]
)
DELETE FROM cte
WHERE row_num > 1;
END


");
		}
    }
}
